/* **********************************************************
 * Description : PatientsPage.cs having functions, methods and Objects of add new patient
 *              Edit, remove existing patient details.
 * 
 * Date: 07-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;


namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// PatientsPage class having mehtods and object related Patient Tab inside Myaccount 
    /// </summary>
    public class PatientsPage : MyAccountPage
    {

        /// <summary>
        /// SelectPatient method select patient using first name and last name 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the first name of the patient wish to select</param>
        /// <param name="lname">Enter the last name of the patient wish to select</param>
        public static void SelectPatient(RemoteWebDriver driver,
          Iteration reporter,
          string fname,
          string lname)
        {
            reporter.Add(new Act("select the patient using first name and last name"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//span[span[normalize-space()='{0}'] and span[normalize-space()='{1}']]/parent::div/preceding-sibling::div/descendant::input[starts-with(@id,'patient')]", fname, lname)));
        }

        /// <summary>
        /// ClickViewAppointments method click on ViewAppointments using First Name and Last Name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the first name of the patient wish to select</param>
        /// <param name="lname">Enter the Last name of the patient wish to select</param>
        public static void ClickViewAppointments(RemoteWebDriver driver,
          Iteration reporter,
          string fname,
          string lname)
        {
            reporter.Add(new Act("select the patient using first name and last name"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//span[span[normalize-space()='{0}'] and span[normalize-space()='{1}']]/parent::div/following-sibling::div/descendant::button[normalize-space()='View Appointments']", fname, lname)));
        }

        /// <summary>
        /// ClickEdit method click on Edit button of patient using First name and Last name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the first name of the patient wish to select</param>
        /// <param name="lname">Enter the first name of the patient wish to select</param>
        public static void ClickEdit(RemoteWebDriver driver,
          Iteration reporter,
          string fname,
          string lname)
        {
            reporter.Add(new Act("select the patient using first name and last name"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//span[span[normalize-space()='{0}'] and span[normalize-space()='{1}']]/parent::div/following-sibling::div/descendant::span[normalize-space()='Edit']", fname, lname)));
        }

        /// <summary>
        /// ClickRemove method click on Remove button of patient using First name; last name.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the first name of the patient wish to select</param>
        /// <param name="lname">Enter the last name of the patient wish to select</param>
        public static void ClickRemove(RemoteWebDriver driver,
          Iteration reporter,
          string fname,
          string lname)
        {
            reporter.Add(new Act("select the patient using first name and last name"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//span[span[normalize-space()='{0}'] and span[normalize-space()='{1}']]/parent::div/following-sibling::div/descendant::span[normalize-space()='Remove']", fname, lname)));
        }

        /// <summary>
        /// TypeNewPatientFirstName method type first name for add new patient details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the Patinet name wish to add</param>
        public static void TypeNewPatientFirstName(RemoteWebDriver driver,
          Iteration reporter,
          string fname)
        {
            reporter.Add(new Act("Select the patient using first name and last name"));
            Selenide.SetText(driver, Util.GetLocator("newfname_txt"), Selenide.ControlType.Textbox, fname);
        }

        /// <summary>
        /// TypeNewPatientLastName method type last name for add new patient details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lname">Enter the Patinet last name wish to add</param>
        public static void TypeNewPatientLastName(RemoteWebDriver driver,
          Iteration reporter,
          string lname)
        {
            reporter.Add(new Act("Select the patient using last name and last name"));
            Selenide.SetText(driver, Util.GetLocator("newlname_txt"), Selenide.ControlType.Textbox, lname);
        }

        /// <summary>
        /// TypeDOB is method to enter the date of birth of the patient
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="date">Date of born</param>
        /// <param name="month">Month of born</param>
        /// <param name="year">Year of born</param>
        public static void TypeDOB(RemoteWebDriver driver,
         Iteration reporter,
         string date,
         string month,
         string year)
        {
            TypeDate(driver, reporter, date);
            TypeMonth(driver, reporter, month);
            TypeMonth(driver, reporter, year);
        }

        /// <summary>
        /// TypeDate method enter year birth in MyAccount 'Patient Details' tab
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="date"></param>
        public static void TypeDate(RemoteWebDriver driver,
         Iteration reporter,
         string date)
        {
            reporter.Add(new Act("Enter Day/Date of birth in new patient details"));
            Selenide.SetText(driver, Util.GetLocator("newpatientbday_txt"), Selenide.ControlType.Textbox, date);
        }

        /// <summary>
        /// TypeMonth method enter year birth in MyAccount 'Patient Details' tab
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="month"></param>
        public static void TypeMonth(RemoteWebDriver driver,
         Iteration reporter,
         string month)
        {
            reporter.Add(new Act("Enter month of birth in new patient details"));
            Selenide.SetText(driver, Util.GetLocator("newpatientbmonth_txt"), Selenide.ControlType.Textbox, month);
        }

        /// <summary>
        /// TypeYear method enter year birth in MyAccount 'Patient Details' tab
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="year"></param>
        public static void TypeYear(RemoteWebDriver driver,
         Iteration reporter,
         string year)
        {
            reporter.Add(new Act("Enter year of birth in new patient details"));
            Selenide.SetText(driver, Util.GetLocator("newpatientbyear_txt"), Selenide.ControlType.Textbox, year);
        }

        /// <summary>
        /// ClickAddNewPatient method click on Add new Patient button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickAddNewPatient(RemoteWebDriver driver,
         Iteration reporter)
        {
            reporter.Add(new Act("Click on Add new patient button"));
            Selenide.Click(driver, Util.GetLocator("newpatientsave_btn"));
        }
    }
}
