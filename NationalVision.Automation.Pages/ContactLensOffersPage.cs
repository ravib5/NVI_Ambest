
/* **********************************************************
 * Description : ContactLensOffersPage.cs contains the methods related to finding a Store,
 *               verify contact Lense page links, Eye care club page links
 *              
 * Date :  15-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;


namespace NationalVision.Automation.Pages
{
    public class ContactLensOffersPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Eyecare Club for Contact Lens Wearers";

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
        /// VerifyBrowseourframes method verify link is present in eyecare club page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="link">Link name wish to assert</param>
        public static void VerifyContactLensPageLinks(RemoteWebDriver driver, Iteration reporter,
            string link)
        {
            reporter.Add(new Act(string.Format("Verify link: {0} presence in Eyecare Club page", link)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.LinkText, link));
        }

        /// <summary>
        /// VerifyFindaStorelinkwithfield method verify Find a store link with a field is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyFindStoreOption(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Find a store option and user able to enter ZIP"));
            Selenide.VerifyVisible(driver, Util.GetLocator("findastoretoscheduleanexam_txt"));
        }

        /// <summary>
        /// ClickBrowseOurFrames method click on links in Eyecare Club page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="link">Link name wish to click</param>
        public static void ClickEyeCareClubPageLink(RemoteWebDriver driver, Iteration reporter,
            string link)
        {
            reporter.Add(new Act(string.Format("Click on link {0} on Eye care club page", link)));
            Selenide.Click(driver, Locator.Get(LocatorType.LinkText, link));

            // *** Click on selective links it redirect to respective Pages.
        }
    }
}
