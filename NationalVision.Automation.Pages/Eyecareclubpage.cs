/* **********************************************************
 * Description : EyeCareClubPage.cs contains the methods related to 
 *                contact lenses navigation and  and display of product when user selects eye care club under Contact lens offers
 *              
 * Date :  11-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class EyeCareClubpage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Eyecare Club for Contact Lens Wearers";
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
        public static void VerifyEyeCareClubPageLinks(RemoteWebDriver driver, Iteration reporter,
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

        /// <summary>
        /// VerifyClubMembership method compare whether the actual membership selected by the customer is displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="three_years">Default value: true (3 year membership); If 5 years membership: false</param>
        /// <param name="isNewMember">Default value: true (New membership); If renew membership: false</param>
        public static void VerifyClubMembership(RemoteWebDriver driver, Iteration reporter,
            bool three_years = true,
            bool isNewMember = true)
        {
            // *** isMatched variable flip the flag if condition not match
            Boolean isMatched = true;

            // *** expecteMembership variable used to assign the value and easily print the final reports
            string expecteMembership = null;

            reporter.Add(new Act("Verify the Club Membership Details"));
            string actualText = Selenide.GetText(driver, Util.GetLocator("membership_lbl"), Selenide.ControlType.Label);

            if (isNewMember)
            {
                if (three_years)
                {
                    expecteMembership = "Eyecare Club 3 Year New";
                    if (!actualText.Contains(expecteMembership))
                    {
                        isMatched = false;
                    }
                }
                else
                {
                    expecteMembership = "Eyecare Club 5 Year New";
                    if (!actualText.Contains(expecteMembership))
                    {
                        isMatched = false;
                    }
                }
            }
            else
            {
                //@TODO *** Below code snippet need to test with orininal data
                if (three_years)
                {
                    expecteMembership = "Eyecare Club 3 Year Renew";
                    if (!actualText.Contains(expecteMembership))
                    {
                        isMatched = false;
                    }
                }
                else
                {
                    expecteMembership = "Eyecare Club 3 Year Renew";
                    if (!actualText.Contains(expecteMembership))
                    {
                        isMatched = false;
                    }
                }
            }

            if (!isMatched) // *** This will check for failure conditions
            {
                throw new Exception(string.Format("Club Membership is not match. Expected : {0} <br> Actual : {1}",
                    expecteMembership, actualText));
            }
        }

        /// <summary>
        /// SelectPatient method to select the patient
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patientName">Patient name wish to select</param>
        public static void SelectPatient(RemoteWebDriver driver, Iteration reporter,
            string patientName)
        {
            reporter.Add(new Act("Patient selected as " + patientName));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//label[contains(.,'" + patientName + "')]/preceding-sibling::input"));
        }

        /// <summary>
        /// ClickContiune method is used to click on continue button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickContiune(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Clicked on continue button"));
            Selenide.Click(driver, Util.GetLocator("eyecareclubcon_btn"));

            // *** ClickContiune mehtod redirect 
        }        
    }
}
