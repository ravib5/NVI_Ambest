
/* **********************************************************
 * Description :  When user search for Ambert stores using zip code it redirects to 
 *                 StoreLocationsPage.cs Page. It Contains google maps, and near by locations details
 *                 Once user click on schedule appointment it redirects to the schedule appointment
 *                
 *              
 * Date :  11-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;

namespace NationalVision.Automation.Pages
{

    public class StoreLocationsPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Store Locations";

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
        /// ClickScheduleExam method click on specific store to schedule a appointment 
        /// This click action redirects to the schedule appointment Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="storeNumer">Intgern value displaying in Store Locator Page in Nearby Panel</param>
        public static void ClickScheduleExam(RemoteWebDriver driver, Iteration reporter,
            string storeNumer)
        {
            reporter.Add(new Act("Click on schedule Exam of specific store using store number"));
            Selenide.SwitchToFrame(driver, Locator.Get(LocatorType.XPath,
                "//iframe"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[starts-with(@id,'more_info_{0}')]/parent::div/parent::td/descendant::div[@class='result-address']/descendant::a[text()='Schedule Exam']",storeNumer)));
            Selenide.SwitchToDefaultConent(driver);
            // *** This method redirects to the Schedule_Appointment Page
        }
       
        
    }
}
