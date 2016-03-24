/* **********************************************************
 * Description : TwoPairOrder.cs having functions, methods and Objects of select the product from Eyeglasses, 
 * Add to Cart, choose 2 pair, select the product from that
 * Date: 08-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class EyeGlassWizardTwoPairOrderPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Recommended";
        public static void AssertPageTitle(RemoteWebDriver driver,
            Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// ClickOnSecondPairProduct method click on selective product from EyeGlassWizard page and it redirects to Product details page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Product name on which it should click</param>
        public static void ClickOnSecondPairProduct(RemoteWebDriver driver, Iteration reporter, string productName)
        {
            reporter.Add(new Act("Click on Second Pair Product in EyeGlassWizard Page"));
            Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
            "//div[@class='two-pair row']/descendant::span[text()= '" + productName + "']"));

            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='two-pair row']/descendant::span[text()='" + productName + "']"));
        }


        /// <summary>
        /// ClickOnSecondPairProduct method click on selective product from EyeGlassWizard page and it redirects to Product details page
        /// This method takes index of the product as input parameter
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="index">index of the Product on which it should click</param>
        /// <returns></returns>
        public static string ClickOnSecondPairProduct(RemoteWebDriver driver, Iteration reporter, int index = 1)
        {
            string productName = null;
            if (index > 0)
            {
                if (index <= 6)
                {
                    productName = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='two-pair row']/descendant::span[@class='frame-name'][{0}]", index)), Selenide.ControlType.Label);

                    reporter.Add(new Act(string.Format(@"Click on Product: {0}", productName)));

                    Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='two-pair row']/descendant::span[@class='frame-name'][{0}]", index)));

                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='two-pair row']/descendant::span[@class='frame-name'][{0}]", index)));
                }
                else
                {
                    productName = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]", index)), Selenide.ControlType.Label);

                    reporter.Add(new Act(string.Format(@"Click on Product: {0}", productName)));

                    Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
                        @"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]"));

                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        @"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]"));
                }
            }
            else
            {
                productName = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                       string.Format(@"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]", index)), Selenide.ControlType.Label);

                reporter.Add(new Act(string.Format(@"Click on Product: {0}", productName)));

                Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
                    @"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]"));

                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    @"//div[@class='two-pair row']/descendant::span[@class='frame-name'][1]"));

            }
            return productName;
        }

        /// <summary>
        /// VerifySecondpairPage method verify the SecondPair note available in EyeGlassWizard
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySecondPairNote(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("verify the Secondpair note available"));
            Selenide.VerifyVisible(driver, Util.GetLocator("secondpair_lab"));
        }
        /// <summary>
        /// VerifySecondpair method verify the SecondPair product available in EyeGlassWizard
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySecondPair(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify the Second pair added to the cart or not"));
            string actual = Selenide.GetText(driver, Util.GetLocator("secondpairproduct_lab"), Selenide.ControlType.Label);
            ClickOnSecondPairProduct(driver, reporter, actual);
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(driver, reporter);
            Selenide.WaitForElementVisible(driver, Util.GetLocator("secondpairproductleft_lab"));
            string expected = Selenide.GetText(driver, Util.GetLocator("secondpairproductleft_lab"), Selenide.ControlType.Label);
            if ((actual.ToUpper()).Equals(expected))
            {
                reporter.Add(new Act("The Second pair added to the Cart"));
            }
        }

    }
}
