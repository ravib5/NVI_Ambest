/* **********************************************************
 * Description : Page_SEO_WomensGlass_AllLinks.cs test case Print SEO details of on home page
 * 
 * 
 * Date :  15-Mar-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;
using System.Collections.Generic;

namespace NationalVision.Automation.Tests.Cases.PageSEO
{
    class Page_SEO_WomensGlass_MultipleSelections : BaseCase
    {
        List<string> linkNames = new List<string>();
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Getting Page SEOs";
            Step = "Open browser log into application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);
            string[] glasses = { "women's glasses" };
            //, "men's glasses", "kid's glasses", "all glasses", "sunglasses" 
           
        }
    }
}
