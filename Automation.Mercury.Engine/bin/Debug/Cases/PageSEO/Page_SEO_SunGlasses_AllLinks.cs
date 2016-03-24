/* **********************************************************
 * Description : Page_SEO_WomensGlass_AllLinks.cs test case Print SEO details of on home page
 * 
 * 
 * Date :  14-Mar-2016
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;
using System.Collections.Generic;



namespace NationalVision.Automation.Tests.Cases.PageSEO
{
    class Page_SEO_SunGlasses_AllLinks : BaseCase
    {
        List<string> linkNames = new List<string>();
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Getting Page SEOs";
            Step = "Open browser log into application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);
            string[] glasses = { "sunglasses" };
            //, "men's glasses", "kid's glasses", "all glasses", "sunglasses" 
            foreach (string MainlinkName in glasses)
            {
                CommonPage.ClickLeftMenuLinks(Driver, Reporter, MainlinkName);
                CommonPage.ClickShowAllBrands(Driver, Reporter);
                CommonPage.ClickShowAllBrands(Driver, Reporter, "frame-color");
                Selenide.Wait(Driver, 0.5, true);

                int leftmenu = CommonPage.GetLeftMenuLinksCount(Driver, Reporter);

                for (int leftlist = 1; leftlist <= leftmenu; leftlist++)
                {
                    linkNames.Add(CommonPage.GetLeftMenuLinkText(Driver, Reporter, leftlist));
                }

                foreach (string linkName in linkNames)
                {
                    if (EyeGlassesShelfPage.IsRemoveAllLinkExist(Driver, Reporter))
                    {
                        EyeGlassesShelfPage.RemoveAllAppliedFilters(Driver, Reporter);
                        Selenide.WaitForElementNotVisible(Driver, Util.GetLocator("spinner_loader_ico"));
                    }

                    //CommonPage.ClickShowAllBrandsLink(Driver, Reporter); 
                    //CommonPage.ClickShowAllBrandsLink(Driver, Reporter, "frame-color");


                    Step = string.Format("Clicking on Link: {0}", (MainlinkName.Replace("'", "") + "_" + linkName));
                    //Selenide.Wait(Driver, 1, true); // This is manditory to complete page loading.
                    EyeGlassesShelfPage.ClickLeftFilters(Driver, Reporter, linkName);
                    //Selenide.Wait(Driver, 0.75, true); // This is manditory to complete page loading.
                    Selenide.WaitForElementNotVisible(Driver, Util.GetLocator("spinner_loader_ico"));
                    EyeGlassesShelfPage.PageSEOInfo(Driver, Reporter, (MainlinkName.Replace("'", "") + "_" + linkName.Replace("'", "").Replace("/", "")), resultsPath);
                }
            }
        }
    }
}
