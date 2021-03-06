﻿/* **********************************************************
 * Description : SPO_TC043.cs test case for Second Pair order eyeglasses
 *                Age: over 13 
 *                Patient Info: Any Patient's Prescription Type
 *                Lens Package: No Package
 *                Lens Option: Basic Package with NoTint for Frame1 and Fashion Tint for frame2
 *                Select Add A/R or No A/R for Frame1 and 2 and click Checkout
 *               
 * Date :  03-Mar-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{
    /// <summary>
    /// Description : SPO_TC043.cs test case for Second Pair order eyeglasses Age: over 13,Patient Info: Any Patient's Prescription Type,
    ///              Lens Package: No Package, Lens Option: Basic ackage with NoTint for Frame1 and Fashion Tint for frame2, Select Add A/R or No A/R for Frame1 and 2 
    ///              and click Checkout
    /// </summary>
    class SPO_TC043 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            // **** Assigning product value to local variable to use mulitple place in same class ****//
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Verify Second Pair order for a patient over 13 years with Options:No Prescription,No package,Basic ackage with NoTint for Frame1 and FashionTint for frame2";
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
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "Popular");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter);
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "24");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter,"24");

            Step = "Verifying tryon, clicking on the product and verifying all the features in the product display page";
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

            Step = "Clicking on AddLenses and AddToCart button";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting 2 pair and click on Next";
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.VerifySecondPairNote(Driver, Reporter);

            Step = "Selecting Second Pair Product in the EyeGlassWizard Page and click on Add Lenses and Add to Cart Button";
            string secondProduct = EyeGlassWizardTwoPairOrderPage.ClickOnSecondPairProduct(Driver, Reporter, 5);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertAddLensAndAddToCart(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting the age of the patient as over 13 and Clicking Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying step 2: Patient's Prescription Information Options, Selecting an option and Clicking Next";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "donotknow");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifing Lens package and Selecting 'No Package' under choose a Lens Package and Clicking Next";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Lens Options and Selecting the option as 'Basic Package' and Clicking Next";
            EyeGlassWizardPage.CheckLensOptions(Driver, Reporter);
            EyeGlassWizardPage.SelectLensOptions(Driver, Reporter, "basic");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Tint options, Selecting NoTint option for both the frames and clicking Next";
            EyeGlassWizardPage.CheckLensTintOptions(Driver, Reporter);
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "fashion");
            EyeGlassWizardPage.VerifySubTintOption(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying AntiReflective options and selecting Anti A/R for first Frame and Clicking Next";
            EyeGlassWizardPage.VerifyAntiReflectiveForFrame(Driver, Reporter);
            EyeGlassWizardPage.CheckAntiReflectiveOption(Driver, Reporter);
            EyeGlassWizardPage.SelectAntiReflectiveOption(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            
            Step = "Verify buttons under 'Review your selections' section";
            EyeGlassWizardPage.AssertPageHeading(Driver, Reporter, TestData["HEADER"]);
            EyeGlassWizardPage.VerifyReviewProductName(Driver, Reporter, _product);
            EyeGlassWizardPage.VerifyReviewProductName(Driver, Reporter, secondProduct, 2);
            EyeGlassWizardPage.VerifyPrintToStore(Driver, Reporter);
            EyeGlassWizardPage.VerifyBackButton(Driver, Reporter);
            EyeGlassWizardPage.VerifyCheckOutButton(Driver, Reporter);

            Step = "Clicking on CheckOut Button";
            EyeGlassWizardPage.ClickCheckOutButton(Driver, Reporter);

            Step = "Verifying Keep Shopping button and Start CheckOut button";
            //ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "eyeglasses", _product);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "eyeglasses", _product);
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "eyeglasses", secondProduct, 1);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "eyeglasses", secondProduct, 1);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
        }
    }
}
