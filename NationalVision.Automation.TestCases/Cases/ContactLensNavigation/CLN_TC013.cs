/* **********************************************************
 * Description : CLO_TC013.cs test case for
 *                            Contact lenses navigation
 *                            Navigate to $13.99 option 
 *                            Verify display of the products
 *              
 *               
 * Date :  15-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.ContactLensNavigation
{
    /// <summary>
    /// Description : CLO_TC013.cs test case for 
    ///               Contact lensses navigation
    ///               Navigate to $13.99 option 
    ///               Verify display of the products
    /// </summary>
    class CLN_TC013 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Contact Lenses Product Details functionality";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);

            Step = "Hover on contact lens offers tab";
            string[] strings = { "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, strings);

            Step = "Clicking on sublink Contact Lens offers $13.99 option";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying Eyecare club page with the content and links";
            ContactLensOffersPage.VerifyContactLensPageLinks(Driver, Reporter, "Sofmed 55 Contacts");
            ContactLensOffersPage.VerifyContactLensPageLinks(Driver, Reporter, "Shop all brands");
            ContactLensOffersPage.VerifyContactLensPageLinks(Driver, Reporter, "Learn more");
            ContactLensOffersPage.VerifyFindStoreOption(Driver, Reporter);

            Step = "Clicking on sofmed 55 contacts link and verify it navigate respective page";
            ContactLensOffersPage.ClickEyeCareClubPageLink(Driver, Reporter, "Sofmed 55 Contacts");
            ContactLensOffersPage.AssertPageTitle(Driver,Reporter,"Sofmed Contact Lens");
            ContactLensShelfPage.AssertProductNamePrice(Driver, Reporter, "Sofmed");

            Step = "Clicking on Shop all brands link";
            ContactLensOffersPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            ContactLensOffersPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensOffersPage.ClickEyeCareClubPageLink(Driver, Reporter, "Shop all brands");
            ContactHomePage.AssertPageTitle(Driver, Reporter);

            Step = "Clicking on Learn more link";
            ContactLensOffersPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            ContactLensOffersPage.ClickSubMenuLink(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensOffersPage.ClickEyeCareClubPageLink(Driver, Reporter, "Learn more");
            EyeCareClubpage.AssertPageTitle(Driver,Reporter);
        }
    }
}
