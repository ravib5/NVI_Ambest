/* **********************************************************
 * Description : SPO_TC040.cs test case for Second Pair order eyeglasses
 *                Age: over 13 
 *                Patient Info: Just Browser
 *                Lens Package: No Package
 *                Lens Option: Uncoated
 *               
 * Date :  15-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{
    /// <summary>
    /// Description : SPO_TC040.cs test case for Second Pair order eyeglasses; Age: over 13 
    ///               Patient Info: Just Browser; Lens Package: No Package; Lens Option: Uncoated
    /// </summary>
    class SPO_TC040 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            // **** Assigning product value to local variable to use mulitple place in same class ****//
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Verify Second Pair order for a patient over 13 years with Options:No Prescription,No package,Scratch resistant lense coating";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on eyeglasses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting 'Frames' under 'Shop By Type' Menu";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Selecting any section of glasses then verifying the resutls sortby, pagination, results per page";
            EyeGlassesShelfPage.VerifyAddToFavorites(Driver, Reporter);
            EyeGlassesShelfPage.VerifySortBy(Driver, Reporter);
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "popular");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter, "12");
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "24");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter, "24");

            Step = "Verifying the Product details on Product details page.";
            EyeGlassesShelfPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            EyeGlassesShelfPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            EyeGlassesShelfPage.AssertTryOn(Driver, Reporter, _product);
            EyeGlassesProductDisplayPage.AssertZoomButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.ZoomImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.VerifyImageZoomed(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.SimilarProducts(Driver, Reporter, _product);
            EyeGlassesProductDisplayPage.AssertProductDescription(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickProductReviews(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductReviews(Driver, Reporter);

            Step = "Clicking on AddLens and AddToCart button";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting 2 pair and click on Next";
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.VerifySecondPairNote(Driver, Reporter);

            Step = "Selecting Second Pair Product in the EyeGlassWizard Page and click on Add Lenses and Add to Cart Button";
            string secondProduct = EyeGlassWizardTwoPairOrderPage.ClickOnSecondPairProduct(Driver, Reporter, 2);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertAddLensAndAddToCart(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting the age of the patient and verify the popup when user select Patient is over 13 and click on Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying step 2: Patient's Prescription Information Options";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);

            Step = "Clicking on Just Browsing option";
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "browsing");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifing Lens package";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);

            Step = "Selecting 'No Package' under choose a Lens Package";
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Lens Options";
            EyeGlassWizardPage.CheckLensOptions(Driver, Reporter);

            Step = "Selecting 'NoPackageUncoated' under select your lens option";
            EyeGlassWizardPage.SelectLensOptions(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Review Your Selections Page with product information,print,back,Checkoutbtn";
            EyeGlassWizardPage.AssertPageHeading(Driver, Reporter, TestData["HEADER"]);
            EyeGlassWizardPage.VerifyReviewProductName(Driver, Reporter, _product);
            EyeGlassWizardPage.VerifyBackButton(Driver, Reporter);
            EyeGlassWizardPage.VerifyPrintToStore(Driver, Reporter);
            EyeGlassWizardPage.VerifyCheckOutButton(Driver, Reporter);

            Step = "Clicking on CheckOut Button";
            EyeGlassWizardPage.ClickCheckOutButton(Driver, Reporter);

            Step = "Verifying Keep Shopping, Start CheckOut buttons and Edit,Remove for each product";
            //ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "eyeglasses", _product);
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "eyeglasses", _product);
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "eyeglasses", secondProduct, 1);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "eyeglasses", secondProduct, 1);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
        }
    }
}
