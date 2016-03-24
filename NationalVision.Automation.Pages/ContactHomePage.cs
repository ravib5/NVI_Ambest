
/* **********************************************************
 * Description : ContactHomePage.cs page nothing but "americasbest.staging.americasbest.com/shop"
 *                
 *              
 * Date :  11-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;

namespace NationalVision.Automation.Pages
{
    public class ContactHomePage : CommonPage
    {
       // *** PageTitle varible store the Title of this page,
       // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Contacts & Eyeglasses | Prescription Glasses | Contact Lenses";
        
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
        /// ClickGO method click on Go in Find a store
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickGO(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on GO button to search for stores"));
            Selenide.Click(driver, Util.GetLocator("storelofind_btn"));
        }

        /// <summary>
        /// TypeZipForStoreSearch method enter zip code on contact Home page and it redirect to the Store Locations page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void TypeZipForStoreSearch(RemoteWebDriver driver, Iteration reporter,
            string zip)
        {
            reporter.Add(new Act("Enter Zip code to search for store on Contact Home Page"));
            Selenide.SetText(driver, Util.GetLocator("searchstorezip_txt"), Selenide.ControlType.Textbox, zip);
            ClickGO(driver, reporter);
            Selenide.Wait(driver, 5, true);
        }

        /// <summary>
        /// ClickShoppingCart method is to click on Shopping Cart link in the homepage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickShoppingCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Shopping Cart link"));
            Selenide.Click(driver, Util.GetLocator("shoppingcart_lnk"));
        }

        /// <summary>
        /// CheckTotalItemsInCart method is to retreive the number of items in the cart page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <returns></returns>
        public static string CheckTotalItemsInCart(RemoteWebDriver driver, Iteration reporter)
        {
            string totalItems = Selenide.GetText(driver, Util.GetLocator("shoppingcart_lnk"),Selenide.ControlType.Label);
            reporter.Add(new Act("Number of items in Shopping Cart is "+totalItems));
            return totalItems;
        }
        
    }
}
