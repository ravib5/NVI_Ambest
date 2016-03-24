/* **********************************************************
 * Description : CLO_TC010.cs test case for 
                              Contact lens navigation 
                              Navigate to 'Shop by brand' tab
                              Verify display of the products 
                  
 *               
 *              
 * Date :  09-Feb-2016
 * 
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;


namespace NationalVision.Automation.Tests.Cases.ContactLensNavigation
{
    /// <summary>
    /// Description : CLO_TC010.cs test case for 
    ///               Contact lens navigation
    ///               Navigate to 'Shop by brand' tab
    ///               Verify display of the products
    /// </summary>
    class CLN_TC010 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Contact Lenses Product Details functionality";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);

            Step = "Selecting a brand under shop by brand";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINK"]);

            Step = "Clicking on a Product under shop by brand";
            ContactLensesProductDisplayPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying Product details page";
            ContactLensesProductDisplayPage.ProductPageDetails(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying left menu display in the product page";
            ContactLensesProductDisplayPage.AssertLeftMenuLinks(Driver, Reporter);
        }

    }
}
