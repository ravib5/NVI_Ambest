/* **********************************************************
 * Description : EyeGlassesProducDisplayPage.cs contains the methods related to 
 *                 verifying if productImage, Zoom in, click and drag image and etc. are displayed
 *              
 * Date :  09-Feb-2015
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class EyeGlassesProductDisplayPage : CommonPage
    {
        
        /// <summary>
        /// AssertZoomButton method verify if the Zoom button is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertZoomButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Zoom button is present on Product display Page to zoom image"));

            Selenide.VerifyVisible(driver, Util.GetLocator("zoomin_btn"));
                
        }

        /// <summary>
        /// ZoomImage method double click on Zoom Icon in product details page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ZoomImage(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on zoom to maximize image"));
            Selenide.DoubleClick(driver, Util.GetLocator("zoomin_btn"));
        }

        /// <summary>
        /// VerifyImageZoomed method verifies after clicking on Zoom button did zoom image appears are not
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyImageZoomed(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Image zoomed after clicking on zoom button"));
            Selenide.WaitForElementVisible(driver, Util.GetLocator("zoomimage_img"));
            Selenide.VerifyVisible(driver, Util.GetLocator("zoomimage_img"));
        }

        /// <summary>
        /// AssertFindInStoreButton method verify if Find in store button is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertFindInStoreButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("FindInStore button is present in Productdescription Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("findinstr_btn"));
        }

        /// <summary>
        /// AssertAddLensAndAddToCart method verify if Find in store button is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddLensAndAddToCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("AddLenses And AddToCart button is present in Productdescription Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='product-details']/descendant::input[@value=' add lenses & add to cart']"));
        }

        /// <summary>
        /// ClickAddLensAndAddToCart method click on 'Add Lens or Add to Cart' button on Eyeglass Page
        /// This method redirects to EyeGlassWizrdPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickAddLensAndAddToCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Add to Cart Button"));
            Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='product-details']/descendant::input[@value=' add lenses & add to cart']"));       
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='product-details']/descendant::input[@value=' add lenses & add to cart']"));

            // *** ClickAddLensAndAddToCart method redirect to EyeGlassWizardPage.
        }

        /// <summary>
        /// This method is to verify if Product Details button is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertProductDescription(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Product description is present below the product image"));
            if (Selenide.VerifyVisible(driver, Util.GetLocator("productdetails_lab")))
                reporter.Add(new Act("Product Details Button is present in Product Description Page"));
        }

        /// <summary>
        /// ClickProductReviews method is to click on product reviews
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickProductReviews(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click Product Reviews Button bottom to Product Description Page"));
            Selenide.Click(driver, Util.GetLocator("productreview_btn"));
        }

        /// <summary>
        /// AssertProductReviews method verifies Product Reviews label prescens at bottom product display page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertProductReviews(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.VerifyVisible(driver, Util.GetLocator("productreview_lab")))
                reporter.Add(new Act("Product Reviews and rating is displayed on bottom of the Product Details page"));
        }

        /// <summary>
        /// Assert similar products section and verify the similar products are available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">productName with which the similar products compare</param>
        public static void AssertSimilarProductSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify SimilarProductsSection in Product Description Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("similarproducts_section"));
        }

        /// <summary>
        /// Assert similar products section and verify the similar products are available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName"></param>
        public static void SimilarProducts(RemoteWebDriver driver, Iteration reporter, string productName)
        {
            reporter.Add(new Act("Verify similar products are available in EyeGlassesProductDisplayImage"));
            int simiarProCount = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath, "//div[@class='similar-products']/descendant::li/a[@class='similar-products-name']"));

            string actualText = null;

            for (int counter = 1; counter <= simiarProCount; counter++)
            {
                actualText = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@class='similar-products']/descendant::a[@class='similar-products-name'][{0}]", counter)), Selenide.ControlType.Label);
                if (actualText.Equals(""))
                {
                    break;
                }
                else
                {
                    string[] FString = actualText.Split(' ');
                    if (productName.Contains(FString[0]))
                    {
                        reporter.Add(new Act(String.Format(@"Similar Products Window Displaying: '{0}' ",actualText)));
                    }
                    //@TODO Need to fix this soon
                    //else // *** This is commented sometimes it showing not proper error message
                    //{
                    //    reporter.Add(new Act(String.Format(@"Similar Products Window Displaying not matching product: '{0}' ",actualText)));
                    //    reporter.Chapter.Step.Action.IsSuccess = false;
                    //}
                }
            }
        }

        /// <summary>
        /// AssertProductImage method verify if the Product image is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertProductImage(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.VerifyVisible(driver, Util.GetLocator("eyeglassproductimage_img")))
                reporter.Add(new Act("productimage is available in Product display Page"));
        }

        /// <summary>
        /// AssertProductName method compare the selected product name displaying on the Product details page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name wish to verify on product details page</param>
        public static void AssertProductName(RemoteWebDriver driver, Iteration reporter, string pName)
        {
            reporter.Add(new Act("Verifying the product name on EyeglassProductDetails Page"));
            string actuName = Selenide.GetText(driver, Util.GetLocator("eyeproductname_lab"), Selenide.ControlType.Label);

            if (!pName.Equals(actuName))
            {
                throw new Exception(string.Format("Product name not match, Expected : {0} <br> Actual : {1}", pName, actuName));
            }
        }
    }
}
