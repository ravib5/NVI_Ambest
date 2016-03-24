/* **********************************************************
 * Description : SFO_TC035.cs Single Frame Order
 *                           Age: over 13
 *                           Patient Options: I Know the Patient's Prescription
 *                           Lens Packages: Basic Package
 *                           Optional Tint: Fashion Tint
 *                           Verify Product Details in Review Section then Click CheckOut
 *              
 * Date :  26-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.SingleFrameOrder
{
    class SFO_TC035 : BaseCase
    {
        /// <summary>
        /// Description : SFO_TC035.cs Single Frame Order, Age: over 13, Patient Options: I Know Patient's Ptrescription, Lens Packages: Basic Package
        /// Optional Tint: Fashion Tint, Verify Product Details in Review Section then Click CheckOut
        /// </summary>
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Single Frame Order for a patient >13 years with I Know Patient's Prescription,Basic Package Lens Options, Fashion Tint";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on eyeglasses and verifying the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting any section of glasses in the Home page";
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
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter,"24");
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


            Step = "Clicking 'add lenses & add to cart' button and Select EyeGlass Pair Option";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Selecting the patient's Age over 13 and Click on Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the patient's prescription information";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);

            Step = "Clicking on I Know Patient's Prescription Option";
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "know");


            Step = "Enter the Patient's Prescription Information and Click Next";
            EyeGlassWizardPage.SelectEyePrescriptionPower(Driver, Reporter, TestData["RIGHTSPHERE"], TestData["LEFTSPHERE"]);
            EyeGlassWizardPage.SelectEyePrescriptionCylinder(Driver, Reporter, TestData["RIGHTCYLINDER"], TestData["LEFTCYLINDER"]);
            EyeGlassWizardPage.SelectEyePrescriptionAxis(Driver, Reporter, TestData["RIGHTAXIS"], TestData["LEFTAXIS"]);
            EyeGlassWizardPage.SelectEyePrescriptionPD(Driver, Reporter, TestData["PD"]);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the Lens Package Options";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);

            Step = "Clicking on Basic Package Option";
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "basic");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Tint Options";
            EyeGlassWizardPage.CheckLensTintOptions(Driver, Reporter);

            Step = "Choosing Fashion Tint Option in EyeGlass Wizard Page";
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "fashion");
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
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
        }
    }
}
