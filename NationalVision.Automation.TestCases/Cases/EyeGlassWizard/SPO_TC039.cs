/* **********************************************************
 * Description : SPO_TC039.cs Test case order second pair
 *               Second Pair order - for a patient less than 13 years              
 *               
 * Date :  10-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.EyeGlassWizard
{
    class SPO_TC039 : BaseCase
    {
        /// <summary>
        ///  Description : SPO_TC039.cs Test case order second pair, Second Pair order - for a patient less than 13 years
        /// </summary>
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying Second Pair order - for a patient less than 13 years ";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on eyeglasses and verifying the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "shop by type", "shop by price", "learn more" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting submenu link and selecting the product";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUBSECTION"]);

            Step = "Verifying tryon if available and clicking on the product";
            EyeGlassesShelfPage.AssertTryOn(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Verifying the Product details on Product details page.";
            EyeGlassesProductDisplayPage.AssertProductImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductName(Driver, Reporter, TestData["PRODUCT"]);
            EyeGlassesProductDisplayPage.AssertZoomButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.ZoomImage(Driver, Reporter);
            EyeGlassesProductDisplayPage.VerifyImageZoomed(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertFindInStoreButton(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertSimilarProductSection(Driver, Reporter);
            EyeGlassesProductDisplayPage.SimilarProducts(Driver, Reporter, TestData["PRODUCT"]);
            EyeGlassesProductDisplayPage.AssertProductDescription(Driver, Reporter);
            EyeGlassesProductDisplayPage.ClickProductReviews(Driver, Reporter);
            EyeGlassesProductDisplayPage.AssertProductReviews(Driver, Reporter);

            Step = "Clicking on AddLens and AddToCart button";
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Selecting 2 pair and click on Next";
            EyeGlassWizardPage.SelectPairs(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardTwoPairOrderPage.VerifySecondPairNote(Driver, Reporter);

            Step = "Verifying Second Pair Product in the EyeGlassWizard Page and clicking on Add Lenses and Add to Cart Button";
            EyeGlassWizardTwoPairOrderPage.VerifySecondPair(Driver, Reporter);
            
            Step = "Selecting the age of the patient and verifying the popup when user select age 13 or youger";
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, false);
        }
    }
}
