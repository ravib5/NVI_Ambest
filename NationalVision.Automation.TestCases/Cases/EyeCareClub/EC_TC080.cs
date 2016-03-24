/* **********************************************************
 * Description : EC_TC080.cs for EyeCareClub Functionality
 *               Click on EyeCareClub, Purchase Club Membership for New Customer,Add to cart and
 *               CheckOut Process
 *               
 *                               
 * Date :  22-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeCareClub
{
    /// <summary>
    /// Description : EC_TC080.cs test case for EyeCareClub Functionality
    /// Click on EyeCareClub, Purchase Club Membership for New Customer,Add to cart and
    /// CheckOut Process
    /// </summary>
    class EC_TC080 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying EyeCareClub Functionality, Purchase Club Membership for new Customer";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Clicking on EyeCareClub Link";
            CommonPage.ClickHomePageTabs(Driver, Reporter, TestData["TABNAME"]);

            Step = "Verifying EyeCareClubMembership Options and Find a Store Option";
            EyeCareClubpage.AssertPageTitle(Driver, Reporter);
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, TestData["LINK1"]);
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, TestData["LINK2"]);
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, TestData["LINK3"]);
            EyeCareClubpage.VerifyFindStoreOption(Driver, Reporter);

            Step = "Clicking on the Join the Club Link and Verifying the membership details with add to cart buttons";
            EyeCareClubpage.ClickEyeCareClubPageLink(Driver, Reporter, TestData["LINK1"]);
            EyecareClubPurchasePage.AssertPageTitle(Driver, Reporter);
            EyecareClubPurchasePage.VerifyClubMemeberSections(Driver, Reporter, TestData["SECTIONNEW"]);
            EyecareClubPurchasePage.VerifyClubMemeberSections(Driver, Reporter, TestData["SECTIONRENEW"]);

            Step = "Choosing Add To Cart button in 'Become a new Eye care Club Member!' section";
            EyecareClubPurchasePage.ClickClubMemberShipAddToCart(Driver, Reporter, true, true);

            Step = "Verifying Shopping Cart Page with product information and price";
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyClubMemberDetailsInShoppingCart(Driver, Reporter, TestData["MEMBER"], TestData["QTY"], TestData["PRICE"]);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);

            Step = "Clicking Checkout button on the shoppingcart page and Verifying the popup";
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);
            ShoppingCartPage.VerifyAddLensesPopUp(Driver, Reporter);

        }
    }
}
