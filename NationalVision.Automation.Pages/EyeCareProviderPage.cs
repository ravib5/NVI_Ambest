/* **********************************************************
 * Description : EyeCareProviderPage.cs contains the methods related to 
 *                Doctor Page like Entering Patient details, selecting prescription etc.
 *              
 * Date :  10-Feb-2015
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class EyeCareProviderPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Eyecare Provider";

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
        /// VerifyContactLenseSec method is to verify Contact Lenses section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="prodName">Product name wish to select</param>
        /// <param name="rightOD">Right(OD) value</param>
        /// <param name="leftOS">Left(OS) value</param>  
        public static void VerifyContactLenseSec(RemoteWebDriver driver, Iteration reporter,
              string prodName,
              string rightOD,
              string leftOS)
        {
            CheckingProductName(driver, reporter, prodName);
            CheckingLensPower(driver, reporter, rightOD, leftOS);
        }

        /// <summary>
        /// CheckingProductName verify product name on Eyecare Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="product">Product Name wish to select</param>
        public static void CheckingProductName(RemoteWebDriver driver, Iteration reporter,
            string product)
        {
            reporter.Add(new Act("Verify Contact Lenses Product Information"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='mini-cart']/descendant::span[@class='product-name']"))))
            {
                string actualName = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='mini-cart']/descendant::span[@class='product-name']")), Selenide.ControlType.Label);

                if (!actualName.Trim().Equals(product))
                {
                    throw new Exception(string.Format("Product not match. Expected : {0} <br> Actual : {1}",
                     product, actualName));
                }
            }
        }

        /// <summary>
        /// CheckingLensPower verify the select Contact lens Eye Power
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rPower">Right(OD) value</param>
        /// <param name="lPower">Left(OS) value</param>
        public static void CheckingLensPower(RemoteWebDriver driver, Iteration reporter,
            string rPower,
            string lPower)
        {
            reporter.Add(new Act("Verify Selected Contact Lenses Eye Power details"));
            if (Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='mini-cart']/descendant::span[@class='product-name']"))))
            {
                string actualRPower = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='mini-cart']/descendant::table[starts-with(@class,'lens-table-style')]/descendant::tbody/tr[1]/td")), Selenide.ControlType.Label);

                string actualLPower = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='mini-cart']/descendant::table[starts-with(@class,'lens-table-style')]/descendant::tbody/tr[2]/td")), Selenide.ControlType.Label);

                if (!actualRPower.Equals(rPower) || !actualLPower.Equals(lPower))
                {
                    throw new Exception(string.Format(@"Product Eye power not match. Expected-Right(OD) : {0} Actual-Right(OD) : {1} <br> Expected-Left(OS) : {2} Actual-Left(OS) : {3} ",
                    rPower, actualRPower, lPower, actualLPower));
                }
            }
        }

        /// <summary>
        /// VerifyPatientSecction method is to verfiy Choose a patient section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPatientSecction(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Choose a Patient section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("choosepatient_sec"));
        }

        /// <summary>
        /// AssertDefaultPatient method is to verfiy Choose a patient section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDefaultPatient(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.XPath,
                "//div[@id='eyecare-provider-patients']/div[1]/input[starts-with(@id,'patient-')]")))
                reporter.Add(new Act("Default Patient is selected"));
            else
                throw new Exception("Default Patient is not selected");
        }


        /// <summary>
        /// VerifyPrescriptionOptionSection method verify 'Select a Prescription Option' (requested-rx-verification-method ) is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPrescriptionOptionWizard(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Select a Prescription section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("prescription_sec"));
        }

        /// <summary>
        /// VerifyGoBackLink method is to verify Go Back Link
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyGoBackLink(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Go Back link"));
            Selenide.VerifyVisible(driver, Util.GetLocator("goback_lnk"));
        }

        /// <summary>
        /// VerifyContinueBtn method verify Continue button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyContinueBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Continue button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("eyecare_continue_btn"));
        }

        /// <summary>
        /// ClickContinueBtn method is to click Continue button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickContinueBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Continue button"));
            Selenide.Click(driver, Util.GetLocator("eyecare_continue_btn"));

            // *** This method redirects to Payment Page *** //
        }

        /// <summary>
        /// EnterPatientDetails method is to enter the patient details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fName">Patient First Name</param>
        /// <param name="mName">Patient Middle Name</param>
        /// <param name="lName">Patient Last Name</param>
        /// <param name="month">Patient born Month</param>
        /// <param name="day">Patient born Day</param>
        /// <param name="year">Patient born Year</param>
        public static void EnterPatientDetails(RemoteWebDriver driver, Iteration reporter,
            string fName,
            string mName,
            string lName,
            string month,
            string day,
            string year)
        {
            TypePatientFName(driver, reporter, fName);
            TypePatientMiddleName(driver, reporter, mName);
            TypePatientLName(driver, reporter, lName);
            SelectPatientMonthofBirth(driver, reporter, month);
            SelectPatientDateofBirth(driver, reporter, day);
            SelectPatientYearofBirth(driver, reporter, year);
        }

        /// <summary>
        /// TypePatientFName method types first name of the patient on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fName">First Name of Patient</param>
        public static void TypePatientFName(RemoteWebDriver driver, Iteration reporter,
            string fName)
        {
            reporter.Add(new Act("Entered patients First name in Eyecare Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_fname_txt"), Selenide.ControlType.Textbox, fName);
        }

        /// <summary>
        /// TypePatientMiddleName method types middle name of the patient on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="mName">Middle name of the patient</param>
        public static void TypePatientMiddleName(RemoteWebDriver driver, Iteration reporter,
            string mName)
        {
            reporter.Add(new Act("Entered patients middle name in Eyecare Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_mname_txt"), Selenide.ControlType.Textbox, mName);
        }

        /// <summary>
        /// TypePatientLName method enter the patinet Last name on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lName">Last name of the Patient</param>
        public static void TypePatientLName(RemoteWebDriver driver, Iteration reporter,
            string lName)
        {
            reporter.Add(new Act("Entered patients last name in Eyecare Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_lname_txt"), Selenide.ControlType.Textbox, lName);
        }

        /// <summary>
        /// SelectPatientDateofBirth method select month of patient on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="month">Enter the month when patient born</param>
        public static void SelectPatientMonthofBirth(RemoteWebDriver driver, Iteration reporter,
            string month)
        {
            reporter.Add(new Act("Select patient month of birth in  Eyecare-Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_month_txt"), Selenide.ControlType.Listbox, month);
        }

        /// <summary>
        /// SelectPatientDateofBirth method select date/day of patient on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="day">Enter the date/day when patient born</param>
        public static void SelectPatientDateofBirth(RemoteWebDriver driver, Iteration reporter,
            string day)
        {
            reporter.Add(new Act("Select patient Month of birth in  Eyecare-Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_day_txt"), Selenide.ControlType.Listbox, day);
        }

        /// <summary>
        /// SelectPatientYearofBirth method select birth year of patient on Eyecare-Provider page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="day">Enter the year when patient born</param>
        public static void SelectPatientYearofBirth(RemoteWebDriver driver, Iteration reporter,
            string year)
        {
            reporter.Add(new Act("Select patient Year of birth in  Eyecare-Provider page"));
            Selenide.SetText(driver, Util.GetLocator("patient_year_txt"), Selenide.ControlType.Listbox, year);
        }

        /// <summary>
        /// SelectState method select the state to find America's Best Contacts & Eyeglasses Store
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="state">State wish to select from list</param>
        public static void SelectState(RemoteWebDriver driver, Iteration reporter, string state)
        {
            reporter.Add(new Act(state + " selected state from list"));
            Selenide.SetText(driver, Util.GetLocator("selectstore_dd"), Selenide.ControlType.Listbox, state);

            WaitUnitlSpinnerDisappears(driver);
        }

        /// <summary>
        /// WaitUnitlSpinnerDisappears method waits until spinner disappers in EyecareProvidePage, 
        ///  when user select Store state, below spinner appears.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void WaitUnitlSpinnerDisappears(RemoteWebDriver driver)
        {
            WaitUnitlSpinnerDisappears(driver, (Util.GetLocator("spinner_loader_ico")).ToString());
        }

        /// <summary>
        /// SelectStore method select the Store from the search results
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void SelectStore(RemoteWebDriver driver, Iteration reporter,
            string store)
        {
            Selenide.WaitForElementClickble(driver, Util.GetLocator("selectstore_rb"), 10);
            reporter.Add(new Act("Selecting store from the stores table"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//label[normalize-space()='{0}']/parent::td/parent::tr/descendant::input", store)));
        }

        /// <summary>
        /// SelectPrescriptionOption select the Prescription options
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">default values:select; enter, email, fax, stores, search</param>
        public static void SelectPrescriptionOption(RemoteWebDriver driver, Iteration reporter,
            string option = "select")
        {
            reporter.Add(new Act("Select Prescription Option radio button as " + option));

            Selenide.JS.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//input[@id='{0}' and @type='radio']", option.ToLower())));

            // *** This is Ajax call so spinner is displaying while it load the respective options.
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// SearchDoctor method search for doctor in selected city, state
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="docLastName">Doctor's last name wish to search</param>
        /// <param name="doctorCity">Doctor's city optional </param>
        /// <param name="doctorState">Doctor's state optional</param>
        public static void SearchDoctor(RemoteWebDriver driver, Iteration reporter,
            string docLastName,
            string doctorCity = null,
            string doctorState = null)
        {
            TypeDoctorLastName(driver, reporter, docLastName);
            // *** TypeDoctorCity method initiate only if doctorCity is not null and empty   ***//
            if (!string.IsNullOrEmpty(doctorCity))
            {
                TypeDoctorCity(driver, reporter, doctorCity);
            }

            // *** TypeDoctorState method initiate only if doctorState is not null and empty  ***//
            if (!string.IsNullOrEmpty(doctorState))
            {
                SelectDoctorState(driver, reporter, doctorState);
            }

            // *** Search for a doctor is Ajax control, Spinner appears whlie loading the doctor's infomration
            WaitUnitlSpinnerDisappears(driver);
        }

        /// <summary>
        /// TypeDoctorLastName method enter the Last-name of the doctor searching.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="docLastName"></param>
        public static void TypeDoctorLastName(RemoteWebDriver driver, Iteration reporter,
            string docLastName)
        {
            reporter.Add(new Act("Enter Doctor LastName "));
            Selenide.SetText(driver, Util.GetLocator("searchdoctorlname_txt"), Selenide.ControlType.Textbox, docLastName);

            // *** Initiating JQuery call while entering doctor name ***//
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// TypeDoctorCity method enter the city of the doctor 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="city"></param>
        public static void TypeDoctorCity(RemoteWebDriver driver, Iteration reporter,
            string city)
        {
            reporter.Add(new Act("Enter Doctor City"));
            Selenide.SetText(driver, Util.GetLocator("searchdoctorcity_txt"), Selenide.ControlType.Textbox, city);

            // *** Initiating JQuery call while entering doctor City  ***//
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// SelectDoctorState method enter state of doctor, searcing.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="state">state of the doctor</param>
        public static void SelectDoctorState(RemoteWebDriver driver, Iteration reporter,
            string state)
        {
            reporter.Add(new Act("Enter Doctor State"));
            Selenide.SetText(driver, Util.GetLocator("searchdoctorstate_txt"), Selenide.ControlType.Select, state);

            // *** Initiating JQuery call while entering doctor State  ***//
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// SearchDoctor method is used to select the doctor from the search results
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="doctorFullName">Doctor's full name</param>
        /// <param name="index">default:1; If same doctot's name appears twice index value changes.</param>
        public static void SelectDoctor(RemoteWebDriver driver, Iteration reporter,
            string doctorFullName,
            int index = 1)
        {
            int TotalRows = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@id='doctor-search-results']/table[@class='table-style col-xs-12 js-paginate']/tbody/tr"));
            if (TotalRows == 0)
            {
                throw new Exception("There are no search results with the given Doctor's name");
            }
            else
            {
                reporter.Add(new Act("Select Doctor from the search results"));

                // *** @TODO This need to be write in a Optimized way. *** //
                // *** Getting Dynamic number generated by application and assigning this value to Input box. *** //
                string for_ID = Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@id='doctor-search-results']/table[@class='table-style col-xs-12 js-paginate']/tbody/descendant::label[normalize-space()='{0}'][{1}]",
                   doctorFullName, index)), "for");

                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@id='doctor-search-results']/table[@class='table-style col-xs-12 js-paginate']/tbody/descendant::input[@id='{0}']", for_ID)));
            }
        }

        /// <summary>
        /// VerifyPrescriptionOptionWizard method verifying prescription options on EyecareProvider Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">default value:select; enter, stores, search, fax, email</param>
        public static void VerifyPrescriptionOptionWizard(RemoteWebDriver driver, Iteration reporter,
            string option)
        {
            switch (option)
            {
                case "select":
                    reporter.Add(new Act("'Doctor/Eyecare Provider' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("docselection_sec"));
                    break;
                case "stores":
                    reporter.Add(new Act("'Select Your America's Best Contacts & Eyeglasses Store' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("docselection_sec"));
                    break;
                case "search":
                    reporter.Add(new Act("'Doctor/Eyecare Provider' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("docselection_sec"));
                    break;
                case "enter":
                    reporter.Add(new Act("'Doctor/Eyecare Provider' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("docselection_sec"));
                    break;
                case "fax":
                    reporter.Add(new Act("'Fax Number' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("faxprescription_sec"));
                    break;
                case "email":
                    reporter.Add(new Act("'Email information' section is present"));
                    Selenide.VerifyVisible(driver, Util.GetLocator("emailprescription_sec"));
                    break;
            }

        }

        /// <summary>
        /// ChoosePatient method is to select the Patient and also verifies whether the patient is selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patientName">Patient Name wish to select</param>
        public static void ChoosePatient(RemoteWebDriver driver, Iteration reporter,
            string patientName)
        {
            reporter.Add(new Act("Select patient " + patientName));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//label[contains(.,'{0}')]/preceding-sibling::input", patientName)));
            if (Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//label[contains(.,'{0}')]/preceding-sibling::input", patientName))))
                reporter.Add(new Act(patientName + " is selected"));
            else
                reporter.Add(new Act("Patient is not selected"));
        }
    }
}
