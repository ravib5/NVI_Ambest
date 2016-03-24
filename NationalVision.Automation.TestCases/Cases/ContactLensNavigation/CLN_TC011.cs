/* **********************************************************
 * Description : CLO_TC011.cs test case for
                              Contact lens navigation 
                              Navigate to 'Shop by type' tab
                              Verify display of the products 
              
 *               
 *              
 * Date :  10-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.ContactLensNavigation
{
    /// <summary>
    /// Description : CLO_TC011.cs test case for 
    ///               Contact lens navigation
    ///               Navigate to 'Shop by type' tab
    ///               Verify display of the products
    /// </summary>
    class CLN_TC011 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Contact Lenses Product Details functionality";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);

            Step = "Verifying the sub tab shop by type";
            string[] strings = { "Shop by Type" };
            CommonPage.AssertSubSections(Driver, Reporter, strings);

            Step = "Selecting a brand under shop by tab";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Clicking on a Product under shop by type";
            ContactLensesProductDisplayPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying Product details page";
            ContactLensesProductDisplayPage.ProductPageDetails(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying Shop by brand, shop by type, contact lens offers tabs in the lfet panel in the product page";
            ContactLensesProductDisplayPage.AssertLeftMenuLinks(Driver, Reporter);
        }
    }
}
