/* **********************************************************
 * Description : SFO_TC015.cs Order Single Frame
 *                Age: Over 13
 *                Patient Information: Just Browsing
 *               
 *              
 * Date :  09-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.SingleFrameOrder
{
    class SFO_TC015 : BaseCase
    {
        /// <summary>
        /// Description : SFO_TC015.cs Order Single Frame,Age: Over 13,Patient Information: Just Browsing
        /// </summary>
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Single Frame Order for a patient with age over 13 years and select Just Browsing";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on EyeGlasses and verifying the sub tabs";
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

            Step = "Clicking Add Lenses and Add to cart button and Selecting EyeGlass Pair Option";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Selecting the patient's Age over 13 and clicking on Next";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the patient's prescription information";
            EyeGlassWizardPage.CheckPatientInfoOption(Driver, Reporter);

            Step = "Clicking on Justbrowsing Option";
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "browsing");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Verifying the Lens Package Options";
            EyeGlassWizardPage.CheckLensPackage(Driver, Reporter);
        }
    }
}
