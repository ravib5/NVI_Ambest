﻿/* **********************************************************
 * Description : SPO_TC049.cs test case for Second Pair order eyeglasses
 *                Age: over 13 
 *                Patient Info: Any Patient's Prescription Type
 *                Lens Package: Verilite Package
 *                Lens Optional Tint: NoTint for Frame1 and FashionTint for Frame2
 *                Select Add A/R or No A/R for Frame1 and 2 and click Checkout
 *               
 * Date :  07-Mar-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{

    /// <summary>
    /// Description : SPO_TC049.cs test case for Second Pair order eyeglasses Age: over 13,Patient Info: Any Patient's Prescription Type,
    ///              Lens Package: Verilite Package, Optional Tint: NoTint Option for Frame1 and FashionTint for Frame2, Select Add A/R or No A/R for Frame1 and Frame2
    ///              and click Checkout
    /// </summary>
    class SPO_TC049 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            // **** Assigning product value to local variable to use mulitple place in same class ****//
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Verify Second Pair order for a patient over 13 years with Options:No Prescription,verilite package,Sunglass Tint";
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
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "highest");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "1");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter,"1");

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

            Step = "Clicking on AddLens and AddToCart button";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting 2 pair and click on Next";
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.VerifySecondPairNote(Driver, Reporter);

            Step = "Selecting Second Pair Product in the EyeGlassWizard Page and click on Add Lenses and Add to Cart Button";
            string secondProduct = EyeGlassWizardTwoPairOrderPage.ClickOnSecondPairProduct(Driver, Reporter, 3);
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

            Step = "Verifing Lens package and Selecting 'Verilite Package' under choose a Lens Package and Clicking Next";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "verilite");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Optional Tint options and selecting NoTint and FashionTint for Frames and Clicking Next";
            EyeGlassWizardPage.CheckVeriliteLensTintOptions(Driver, Reporter);
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "fashion");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying AntiReflective options and selecting Anti A/R for Frame1 and Clicking Next";
            EyeGlassWizardPage.VerifyAntiReflectiveForFrame(Driver, Reporter);
            EyeGlassWizardPage.CheckAntiReflectiveOption(Driver, Reporter);
            EyeGlassWizardPage.SelectAntiReflectiveOption(Driver, Reporter, false);
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
