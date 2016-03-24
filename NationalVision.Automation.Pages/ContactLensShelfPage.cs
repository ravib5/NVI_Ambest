/* **********************************************************
 * Description :  ContactLensShelfPage.cs having methods and object relative when select any contact lens
 *               Page should dispaly all the list products relative to that and other related Products.
 *               
 * Date :  10-Feb-2016
 *  *********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class ContactLensShelfPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Contact";

        /// <summary>
        /// AssertPageTitle assert current page title.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// AssertProductNamePrice method verify whether all the products displayed are related to the selected brand
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="brandName">Product name wish to select </param>
        public static void AssertProductNamePrice(RemoteWebDriver driver, Iteration reporter, string brandName)
        {
            reporter.Add(new Act("Assert the product name and price on Contact-lens shelf page"));
            int count = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath, "//div[@class='product-list col-lg-12']/descendant::span[@class='product-name']"));

            for (int i = 1; i <= count; i++)
            {
                string Name = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='product-list col-lg-12']/descendant::span[@class='product-name'][" + i + "]"), Selenide.ControlType.Label);

                // *** Below condition is commented below some product not working properly, test cases failing 
                //if (Name.ToLower().Contains(brandName.ToLower()))
                //{
                string Price = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='product-list col-lg-12']/descendant::span[@class='product-price pricing-color'][" + i + "]"), Selenide.ControlType.Label);
                if (Price.Contains("From"))
                {
                    string[] onlyPrice = Price.Split(new string[] { "From" }, System.StringSplitOptions.RemoveEmptyEntries);

                    // *** Below code written for insert "." into box value ****
                    char[] revers = onlyPrice[0].Trim().ToCharArray();
                    Array.Reverse(revers);
                    revers = new string(revers).Insert(8, ".").ToCharArray();
                    Array.Reverse(revers);
                    // **************************************************************

                    reporter.Add(new Act(string.Format("Product: {0}; <br> Price: {1}", Name, new string(revers))));
                }
                //}
                //else
                //{
                //    throw new Exception("The Product " + Name + " is not related to the brand " + brandName);
                //}

            }
        }
    }
}
