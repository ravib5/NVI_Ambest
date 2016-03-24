/* **********************************************************
 * Description : SPO_TC025.cs test cases for Single frame Order
 *               Age: over 13 
 *               Patient informtion: Prescription don't Know
 *               Lens Package: No Package
 *               Lens Options: Scratch resistant lens coating     
 *               
 * Date :  16-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{
    /// <summary>
    ///  Description : SPO_TC025.cs test cases for Single frame Order; Age: over 13; Patient information: Prescription don't Know
    ///                 Lens Package: No Package; Lens Options: Scratch resistant lens coating  
    /// </summary>
    class SFO_TC025 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying single frame order - for a patient over 13 years ";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on eyeglasses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting 'Women's Frames' under 'Shop By Type' Menu";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "verifying the resutls sortby, pagination, results per page and Clicking on any of the product";
            // **** Assigning product value to local variable to use mulitple place in same class ****//
            string _product = TestData["PRODUCT"];
            EyeGlassesShelfPage.VerifyAddToFavorites(Driver, Reporter);
            EyeGlassesShelfPage.VerifySortBy(Driver, Reporter);
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "lowest");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "24");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter, "24");
            EyeGlassesShelfPage.AssertTryOn(Driver, Reporter, _product);


            Step = "Verifying the Product details on Product details page.";
            EyeGlassesProductDisplayPage.AssertProductImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductName(Driver, Reporter, _product);
            EyeGlassesProductDisplayPage.AssertZoomButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.ZoomImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.VerifyImageZoomed(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertSimilarProductSection(Driver, Reporter);
            EyeGlassesProductDisplayPage.SimilarProducts(Driver, Reporter, _product);
            EyeGlassesProductDisplayPage.AssertProductDescription(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickProductReviews(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductReviews(Driver, Reporter);

            Step = "Clicking 'add lenses and add to cart' button and verifying the page";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Selecting the patient's Age over 13 and click on Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the patient's prescription information";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);

            Step = "Clicking on I don't know the patient's prescription";
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "donotknow");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the Lens Package Options";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);

            Step = "Selecting 'No Package' under choose a Lens Package and Click on Next";
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Lens Options";
            EyeGlassWizardPage.CheckLensOptions(Driver, Reporter);

            Step = "Selecting scratch resistant lens coating in select your lens option page and click on Next";
            EyeGlassWizardPage.SelectLensOptions(Driver, Reporter, "scratch");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Anti-Reflective Coating?' with the No A/R, Add A/R options";
            EyeGlassWizardPage.CheckAntiReflectiveOption(Driver, Reporter);

            Step = "Selecting any of the options either No A/R, or Add A/R and click on Next";
            EyeGlassWizardPage.SelectAntiReflectiveOption(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Review Your Selections Page with product information,print,back,Checkoutbtn";
            EyeGlassWizardPage.AssertPageHeading(Driver, Reporter, TestData["HEADER"]);
            EyeGlassWizardPage.VerifyReviewProductName(Driver, Reporter, _product);
            EyeGlassWizardPage.VerifyBackButton(Driver, Reporter);
            EyeGlassWizardPage.VerifyPrintToStore(Driver, Reporter);
            EyeGlassWizardPage.VerifyBackButton(Driver, Reporter);
            EyeGlassWizardPage.VerifyCheckOutButton(Driver, Reporter);

            Step = "Clicking checkout button";
            EyeGlassWizardPage.ClickCheckOutButton(Driver, Reporter);

            Step = "Verifying cart page with the buttons keep shopping and checkout";
            //ShoppingCartPage.AssertPageTitle(Driver,Reporter);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter,"eyeglasses", _product);
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "eyeglasses", _product);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
        }
    }
}
