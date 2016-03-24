/* **********************************************************
 * Description : Favorite.cs contains the methods related to 
 *                 verifying if Sort By, Pagination, Results per page displayed and etc.
 *              
 * Date :  21-March-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// Favorite.cs contains the methods related to 
   ///  verifying if Sort By, Pagination, Results per page displayed and etc.
    /// </summary>
    public class FavoritePage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Your Favorite Products";
        /// <summary>
        /// AssertPageTitle method assert page title
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// ClickViewFavorites method is to click on view favorites in eye glass shelf page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickViewFavorites(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Clicking 'view favorites' link on the right side of the Eye Glass Shelf page"));
            ClickTopMenuLink(driver, reporter, "my favorites");
        }

        /// <summary>
        /// Verifyviewbutton method is to verify View button available in Favorites page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyViewButtonFavorite(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying view button is present on Favorite List page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("view_btn"));
        }

        /// <summary>
        /// VerifyRemovebutton method is to verify Remove button available in Favorites page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyRemoveButtonFavorite(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying remove button is present on Favorite List page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("remove_btn"));
        }
    }

}

