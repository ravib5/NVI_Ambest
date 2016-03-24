/* **********************************************************
 * Description : CLO_TC001.cs select prodcut from Contact lenses Product list
 *               Enter the Contact lenses prescription details and
 *               Click on add to cart button then verify the keepshopping, startChcekout buttons are present
 *              
 * Date :  08-Feb-2015
 * 
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;


namespace NationalVision.Automation.Tests.Cases.ContactLensOrder
{
    /// <summary>
    ///  CLO_TC001.cs select prodcut from Contact lenses Product list
    ///  Enter the Contact lenses prescription details and
    ///  Click on add to cart button then verify the keepshopping, startChcekout buttons are present
    /// </summary>
    class CLO_TC001 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Keep Shopping functionality in Shopping Cart page of ContactLenses";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "Shop by Brand", "Shop by Type", "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting a brand and verifying the brand name and price under each product";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            ContactLensShelfPage.AssertProductNamePrice(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Clicking on a product, enter the prescription and click on Addto Cart button";
            ContactLensShelfPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter, TestData["RPOWER"], TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter, TestData["RQTY"], TestData["LQTY"]);
            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Verifying the buttons in shopping cart page and click on keep shopping";
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
            ShoppingCartPage.ClickKeepShopping(Driver, Reporter);
        }
    }
}
