/* **********************************************************
 * Description : CLO_TC012.cs test case for
                              Contact lenses navigation
                              Navigate to eye care club tab
                              Verify display of the products
 *               
 *                            
 * Date :  11-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.ContactLensNavigation
{
    /// <summary>
    /// Description : CLO_TC012.cs test case for 
    ///               Contact lens navigation
    ///               Navigate to eye care club tab
    ///               Verify display of the products
    /// </summary>
    class CLN_TC012 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Contact Lenses Product Details functionality";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);

            Step = "Hover on contact lens offers tab";
            string[] strings = { "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, strings);

            Step = "Clicking on Eyecare club option";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying Eyecare club page with the content and links";
            EyeCareClubpage.AssertPageTitle(Driver, Reporter);
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, "Join the Club");
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, "Browse Our Frames");
            EyeCareClubpage.VerifyEyeCareClubPageLinks(Driver, Reporter, "Shop Now for Contacts");
            EyeCareClubpage.VerifyFindStoreOption(Driver, Reporter);

            Step = "Clicking on join the club link";
            EyeCareClubpage.ClickEyeCareClubPageLink(Driver, Reporter, "Join the Club");
            EyecareClubPurchasePage.AssertPageTitle(Driver, Reporter);
            EyecareClubPurchasePage.VerifyClubMemeberSections(Driver, Reporter, "Become a new Eyecare Club Member!");
            EyecareClubPurchasePage.VerifyClubMemeberSections(Driver, Reporter, "Renew your existing Eyecare Club Membership!");

            Step = "Verifying the order of membership by clicking on Add to cart button";
            string member = "Eyecare Club 3 Year New";
            EyecareClubPurchasePage.ClickClubMemberShipAddToCart(Driver, Reporter);

            Step = "Verifying selected product should be added to the shopping cart";
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyClubMemberDetailsInShoppingCart(Driver, Reporter, member, "1", "99.00"); // example values only

            Step = "Clicking on Browse our frames link in eyecare club page";
            ShoppingCartPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            ShoppingCartPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);
            EyeCareClubpage.ClickEyeCareClubPageLink(Driver, Reporter, "Browse Our Frames");
            EyeGlassesShelfPage.AssertPageTitle(Driver, Reporter, "Shop Hundreds Of Eyeglasses");

            Step = "Clicking on shop now for contacts link in eyecare club page";
            EyeGlassesShelfPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            EyeGlassesShelfPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);
            EyeCareClubpage.ClickEyeCareClubPageLink(Driver, Reporter, "Shop Now for Contacts");
            ContactHomePage.AssertPageTitle(Driver, Reporter);

            Step = "Clicking on Go in Find a store to schedule exam link";
            ContactHomePage.TypeZipForStoreSearch(Driver, Reporter, TestData["ZIP"]);
            StoreLocationsPage.AssertPageTitle(Driver, Reporter);
            
            StoreLocationsPage.ClickScheduleExam(Driver, Reporter, TestData["STORE_NO"]);
        }
    }
}
