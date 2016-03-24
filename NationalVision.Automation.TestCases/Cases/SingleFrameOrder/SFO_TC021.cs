/* **********************************************************
 * Description : SFO_TC021.cs for Single frame Order with below options 
                             Age :over 13;
 *                           Patinet Options: Just Browsing;
 *                           EyeGlasses Packages: Verilite Package;                           
 *                           Lens Tint Options: No Tint
 *                           Anti-Reflective Coating: No A/R or Add A/R
 *                           Verify Product Details in Review Section and Click CheckOut
 *              
 * Date :  23-Feb-2016
 * 
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.SingleFrameOrder
{
    class SFO_TC021 : BaseCase
    {
        /// <summary>
        /// Description : SFO_TC021.cs for Single frame Order with below options; Age :over 13; Patient Options: Just Browsing;
        ///             EyeGlasses Packages: Verilite Package;  Lens Tint Options: No Tint; Anti-Reflective Coating: No A/R or Add A/R
        ///             Verify Product Details in Review Section and Click CheckOut
        /// </summary>
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verify SingleFrame Order for a patient over 13 years with options:'Verilite package with No Tint'";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on eyeglasses and verify the sub tabs";
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
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "6");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter, "6");
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

            Step = "Selecting the patient's age over 13 and click on Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the patient's prescription information";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);

            Step = "Clicking on Justbrowsing Option";
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "browsing");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the Lens Package Options";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);

            Step = "Clicking on Verilite Package Option in Lens Package";
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "verilite");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Various Tint Options";
            EyeGlassWizardPage.CheckVeriliteLensTintOptions(Driver, Reporter);

            Step = "Selecting the no tint Option in Optional Tint";
            EyeGlassWizardPage.SelectLensTintOptions(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying Would Like to Add an Anti-Reflective Coating Options";
            EyeGlassWizardPage.CheckAntiReflectiveOption(Driver, Reporter);

            Step = "Clicking on any Anti-Reflective Coating Options";
            EyeGlassWizardPage.SelectAntiReflectiveOption(Driver, Reporter, true);
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
