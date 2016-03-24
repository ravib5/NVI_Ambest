/* **********************************************************
 * Description : SFO_TC014.cs select eyeglasses single pair
 *               for the patient age <13 years and verify popup
 *              
 * Date :  09-Feb-2015
 * 
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.SingleFrameOrder
{
    class SFO_TC014 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = " Verify the order of Single Frame for a patient with age less than 13 years";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Hover on EyeGlasses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Navigate to EyeGlasses shelf page assert SortBy, Pagination and Resutls per Page";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            EyeGlassesShelfPage.VerifySortBy(Driver, Reporter);
            EyeGlassesShelfPage.SelectSortBy(Driver, Reporter, "highest");
            EyeGlassesShelfPage.VerifyPagination(Driver, Reporter);
            EyeGlassesShelfPage.NavigateNextPageandVerify(Driver, Reporter);
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter);
            EyeGlassesShelfPage.SelectResutlsperPage(Driver, Reporter, "All");
            EyeGlassesShelfPage.VerifyResultsPerPage(Driver, Reporter,"All");

            Step = "Verify tryon, click on the product and verify all the features in the product display page";
            EyeGlassesShelfPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            EyeGlassesShelfPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            EyeGlassesShelfPage.AssertTryOn(Driver, Reporter, TestData["PRODUCT"]);
            EyeGlassesProductDisplayPage.AssertZoomButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.ZoomImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.VerifyImageZoomed(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.SimilarProducts(Driver, Reporter, TestData["PRODUCT"]);
            EyeGlassesProductDisplayPage.AssertProductDescription(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickProductReviews(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductReviews(Driver, Reporter);

            Step = "Click Add Lenses and Add to cart button and verify the page";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);

            Step = "Selecting the patient's Age as less than 13 and verifying the popup";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, false);
        }
    }
}
