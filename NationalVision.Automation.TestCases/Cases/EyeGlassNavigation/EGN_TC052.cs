/* **********************************************************
 * Description : EGN_TC052.cs test case for 
                              Display of Women's Frames Navigation
                              Attributes of the selected products

 * Date :  17-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;
using System;
using System.Collections.Generic;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{
    /// <summary>
    ///  Description : EGN_TC052.cs test case for Display of Women's Frames Navigation and all Attributes of the selected products
    /// </summary>
    class EGN_TC052 : BaseCase
    {
        List<string> linkNames = new List<string>();
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Women's Frames navigation";
            Step = "Opening browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            string _tabName = TestData["TABNAME"];
            string _subLink = TestData["SUB_LINKS"];
            string _product = string.Empty;

            Step = "Mouse Over on eyeglasses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, _tabName);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting 'Women's Frames' under 'Shop By Type' Menu";
            CommonPage.ClickSubMenuLink(Driver, Reporter, _subLink);

            Step = "Verifying all the products related to eye glasses Sort By, Pagination, Results per page etc";
            EyeGlassesShelfPage.AssertPageTitle(Driver, Reporter);
            EyeGlassesShelfPage.VerifySortBy(Driver, Reporter);
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "lowest");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter);
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "24");

            Step = "Verifying the left pane of the women eye glasses navigation";

            string[] categories = { "Price", "Brand", "Frame Color", "Frame Material",
                                      "Frame Type", "Frame Shape", "Frame Style" };
            foreach (string category in categories)
            {
                EyeGlassesShelfPage.LeftMenuCategory(Driver, Reporter, category);
            }

            Step = "Verifying the various attributes displayed for each product";
            EyeGlassesShelfPage.ClickShowAllBrands(Driver, Reporter);
            EyeGlassesShelfPage.ClickShowAllBrands(Driver, Reporter, "frame-color");
            Selenide.Wait(Driver, 0.5, true);

            int leftmenu = EyeGlassesShelfPage.GetLeftMenuLinksCount(Driver, Reporter);

            for (int leftlist = 1; leftlist <= leftmenu; leftlist++)
            {
                linkNames.Add(CommonPage.GetLeftMenuLinkText(Driver, Reporter, leftlist));

                if (leftlist == 15)
                    break;
            }
            
            foreach (string linkName in linkNames)
            {
                if (!linkName.Contains("$"))
                {
                    EyeGlassesShelfPage.ClickLeftMenuLinks(Driver, Reporter, linkName);

                    Step = "Validating the Results per page for all women glasses section";
                    EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter);
                    EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter);
                    EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "highest");

                    Step = "Verifing Filter brand name";
                    string[] onlylinkName = linkName.Split(new Char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    _product = onlylinkName[0].Trim();
                    int getCount = EyeGlassesShelfPage.GetProductCount(Driver, Reporter);
                    for (int proCount = 1; proCount <= getCount; proCount++)
                    {
                        EyeGlassesShelfPage.AssertProductNames(Driver, Reporter, onlylinkName[0].Trim(), proCount);
                    }

                    Step = "Verifing resutls perpage and sortBy value";
                    EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter);
                    EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "highest");
                    EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "All");
                    EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter, "All");

                    Step = "Verify products per page";
                    int productCount = EyeGlassesShelfPage.GetProductCount(Driver, Reporter);
                    if (productCount != Convert.ToInt16(onlylinkName[1]))
                        throw new Exception(string.Format(@"Page results not match : <b><font color=red> Expected Pageper Results: ""{0}""  </font></b> <br> Actual Pageper results: ""{1}""",
                            onlylinkName[1], productCount));

                    Step = "Click on remove the filters which are selected from the left pane";
                    EyeGlassesShelfPage.RemoveAppliedFilter(Driver, Reporter, onlylinkName[0].Trim());
                    break;
                }
            }

            Step = "Click on Pageniation buttons";
            EyeGlassesShelfPage.MouseOverHomePageTabs(Driver, Reporter, _tabName);
            EyeGlassesShelfPage.ClickSubMenuLink(Driver, Reporter, _subLink);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.ClickPaginationBackArrow(Driver, Reporter);

            Step = "Clicking on favorites icon to add the product to favorites";
            EyeGlassesShelfPage.ClickMyFavoritesIcon(Driver, Reporter, _product);
            EyeGlassesShelfPage.ClickViewFavorites(Driver, Reporter);
            FavoritePage.AssertPageTitle(Driver, Reporter);

            Step = "Verifying view and remove buttons in Favorites page";
            FavoritePage.VerifyViewButtonFavorite(Driver, Reporter);
            FavoritePage.VerifyRemoveButtonFavorite(Driver, Reporter);

            Step = "Mouse Over on eyeglasses and verify the sub tabs";
            FavoritePage.MouseOverHomePageTabs(Driver, Reporter, _tabName);
            FavoritePage.ClickSubMenuLink(Driver, Reporter, _subLink);
            EyeGlassesShelfPage.RemoveFromFavorites(Driver, Reporter, _product);
        }
    }
}
