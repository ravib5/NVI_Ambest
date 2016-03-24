/* **********************************************************
 * Description : BeginOrderPage.cs when user start order checkout without logging
 *               Application navigate to beginorder page.
 *               This page contains to create new user and shipping methods 
 *               along sign-in window to for existing users
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

    public class BeginOrderPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Begin Order";

        /// <summary>
        /// AssertPageTitle assert current page title.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }        /// <summary>
        /// VerifyShippingAddSection method verify if the Shipping Address section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyShippingAddSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Shipping Address Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shippingadd_sec"));
        }

        /// <summary>
        /// VerifyAccInfoSection method verify if the Account Information section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyAccInfoSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Account Information Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("acctinfo_sec"));
        }

        /// <summary>
        /// VerifyPhNumSection method verify if the Phone Number section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPhNumSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Phone Number Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("phnum_sec"));
        }

        /// <summary>
        /// VerifyShippingMethodSection method verify if the Shipping Method section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyShippingMethodSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Shipping Method Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shipmethod_sec"));
        }

        /// <summary>
        /// VerifySpecialCommentsSection method verify if the Special Comments section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySpecialCommentsSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Special Comments Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("specialcomments_lbl"));
        }

        /// <summary>
        /// EnterShippingAddress method enter the Shipping Address information for new user creation
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First Name</param>
        /// <param name="lastName">Last Name</param>
        /// <param name="streetAdd1"> Street Address1</param>
        /// <param name="streetAdd2">Street Address2</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zip">Zip Code</param>
        /// <param name="country">Country</param>
        public static void EnterShippingAddress(RemoteWebDriver driver, Iteration reporter,
            string firstName,
            string lastName,
            string streetAdd1,
            string streetAdd2,
            string city,
            string state,
            string zip,
            string country)
        {
            TypeNewUserFName(driver, reporter, firstName);
            TypeNewUserLName(driver, reporter, lastName);
            TypeNewUserAddress1(driver, reporter, streetAdd1);
            TypeNewUserAddress2(driver, reporter, streetAdd2);
            TypeNewUserCity(driver, reporter, city);
            SelectStateofNewUser(driver, reporter, state);
            TypeNewUserZIP(driver, reporter, zip);
            SelectCountryofNewUser(driver, reporter, country);
        }

        /// <summary>
        /// TypeNewUserFName method enter First name in shipping address for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First Name</param>
        public static void TypeNewUserFName(RemoteWebDriver driver, Iteration reporter,
            string firstName)
        {
            reporter.Add(new Act("Entered first name to create new user"));
            Selenide.SetText(driver, Util.GetLocator("firstnm_txt"), Selenide.ControlType.Textbox, firstName);
        }

        /// <summary>
        /// TypeNewUserLName method enter last name in shipping address for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lastName">Last Name</param>
        public static void TypeNewUserLName(RemoteWebDriver driver, Iteration reporter,
            string lastName)
        {
            reporter.Add(new Act("Entered last name to create new user"));
            Selenide.SetText(driver, Util.GetLocator("lastnm_txt"), Selenide.ControlType.Textbox, lastName);
        }

        /// <summary>
        /// TypeNewUserAddress1 method enter address details in shipping_address for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd1">Street Address1</param>
        public static void TypeNewUserAddress1(RemoteWebDriver driver, Iteration reporter,
            string streetAdd1)
        {
            reporter.Add(new Act("Entered street address details to create new user"));
            Selenide.SetText(driver, Util.GetLocator("streetadd1_txt"), Selenide.ControlType.Textbox, streetAdd1);
        }

        /// <summary>
        /// TypeNewUserAddress2 method enter address details in shipping_address for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd2">Street Address2</param>
        public static void TypeNewUserAddress2(RemoteWebDriver driver, Iteration reporter,
            string streetAdd2)
        {
            reporter.Add(new Act("Entered street address details to create new user"));
            Selenide.SetText(driver, Util.GetLocator("streetadd2_txt"), Selenide.ControlType.Textbox, streetAdd2);
        }

        /// <summary>
        /// TypeNewUserCity method enter city name in shipping address details for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="city">City</param>
        public static void TypeNewUserCity(RemoteWebDriver driver, Iteration reporter,
            string city)
        {
            reporter.Add(new Act("Entered city details to create new user"));
            Selenide.SetText(driver, Util.GetLocator("city_txt"), Selenide.ControlType.Textbox, city);
        }

        /// <summary>
        /// SelectStateofNewUser method select state in shipping address details for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="state">State</param>
        public static void SelectStateofNewUser(RemoteWebDriver driver, Iteration reporter,
            string state)
        {
            reporter.Add(new Act("Entered state details to create new user"));
            Selenide.SetText(driver, Util.GetLocator("state_dd"), Selenide.ControlType.Listbox, state);
        }

        /// <summary>
        /// TypeNewUserZIP method type ZIP code in shipping address details for new user
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="zip">ZIP</param>
        public static void TypeNewUserZIP(RemoteWebDriver driver, Iteration reporter,
            string zip)
        {
            reporter.Add(new Act("Entered ZIP details to create new user"));
            Selenide.SetText(driver, Util.GetLocator("zip_txt"), Selenide.ControlType.Textbox, zip);
        }

        /// <summary>
        /// SelectCountryofNewUser method select the country from shipping address details 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="country">Country default:United States</param>
        public static void SelectCountryofNewUser(RemoteWebDriver driver, Iteration reporter,
            string country)
        {
            reporter.Add(new Act("Selected Country as " + country + " of new user in shipping address"));
            Selenide.SetText(driver, Util.GetLocator("country_dd"), Selenide.ControlType.Listbox, country);
        }

        /// <summary>
        /// This method is used to enter the account information
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="eMail">Email Address</param>
        /// <param name="createPwd">Enter Password</param>
        /// <param name="confmPwd">Re-Enter password</param>
        public static void EnterAcctInfo(RemoteWebDriver driver, Iteration reporter,
            string eMail,
            string createPwd,
            string confmPwd)
        {
            TypeAcctInfoEmail(driver, reporter, eMail);
            TypeAcctInfoPassword(driver, reporter, createPwd);
            TypeAcctInfoConfirmPassword(driver, reporter, confmPwd);
        }

        /// <summary>
        /// TypeAcctInfoEmail method enter new email address to create new user creation
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="eMail">Enter Email</param>
        public static void TypeAcctInfoEmail(RemoteWebDriver driver, Iteration reporter,
            string eMail)
        {
            reporter.Add(new Act("Enter new email address to create new account"));
            Selenide.SetText(driver, Util.GetLocator("email_txt"), Selenide.ControlType.Textbox, eMail);
        }

        /// <summary>
        /// TypeAcctInfoPassword method type new password to create new user account 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="passwd">Enter Password</param>
        public static void TypeAcctInfoPassword(RemoteWebDriver driver, Iteration reporter,
            string passwd)
        {
            reporter.Add(new Act("Enter password for create new account"));
            Selenide.SetText(driver, Util.GetLocator("pwd_txt"), Selenide.ControlType.Textbox, passwd);
        }

        /// <summary>
        /// TypeAcctInfoConfirmPassword method type value in confirmed password 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="confmPwd">Confirm Password</param>
        public static void TypeAcctInfoConfirmPassword(RemoteWebDriver driver, Iteration reporter,
            string confmPwd)
        {
            reporter.Add(new Act("Enter Confirm / retype password for create new account"));
            Selenide.SetText(driver, Util.GetLocator("confmpwd_txt"), Selenide.ControlType.Textbox, confmPwd);
        }

        /// <summary>
        /// EnterPhoneNumDetails method enter the phone number details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="phNum">Ph Number</param>
        /// <param name="extn">extension</param>
        public static void EnterPhoneNumDetails(RemoteWebDriver driver, Iteration reporter,
            string phNum,
            string extn = "")
        {
            reporter.Add(new Act("Entering Phone Number details successfully"));
            TypePhoneNum(driver, reporter, phNum);

            if (!extn.Equals(""))
                TypePhoneExt(driver, reporter, extn);
        }

        /// <summary>
        /// TypePhoneNum method enter phone number in beginOrder Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="phNum">Phone Number</param>

        public static void TypePhoneNum(RemoteWebDriver driver, Iteration reporter,
            string phNum)
        {
            reporter.Add(new Act("Entering Phone Number details"));
            Selenide.SetText(driver, Util.GetLocator("phnum_txt"), Selenide.ControlType.Textbox, phNum);
        }

        /// <summary>
        /// TypePhoneExt method enters Phone extension details in beginOrder Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="extn">Extension</param>
        public static void TypePhoneExt(RemoteWebDriver driver, Iteration reporter,
            string extn)
        {
            reporter.Add(new Act("Entering Phone Extension details"));
            Selenide.SetText(driver, Util.GetLocator("extn_txt"), Selenide.ControlType.Textbox, extn);
        }

        /// <summary>
        /// SelectShippingMethod method select the Shipping Method
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="USpost">Default: true US Post option would be selected else Fedex</param>
        public static void SelectShippingMethod(RemoteWebDriver driver, Iteration reporter,
            bool USpost = true)
        {
            if (!USpost)
            {
                reporter.Add(new Act("Selected FedEx Shipping method"));
                Selenide.Click(driver, Util.GetLocator("uspost_rb"));
            }
            else
            {
                reporter.Add(new Act("Selected US Postal Service Shipping method"));
                Selenide.Click(driver, Util.GetLocator("fedex_rb"));
            }
        }

        /// <summary>
        /// EnterSpecialComments method enter the special comments
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="comments">Default:'Testing' Comments which need to be entered</param>
        public static void EnterSpecialComments(RemoteWebDriver driver, Iteration reporter,
            string comments)
        {
            reporter.Add(new Act("Entered special comments as " + comments));
            Selenide.SetText(driver, Util.GetLocator("speccomments_txt"), Selenide.ControlType.Textbox, comments);
        }

        /// <summary>
        /// ClickContinue method click on continue button on orderbegin page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickContinue(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Clicked continue button in Begin Order page"));
            Selenide.Click(driver, Util.GetLocator("continue_btn"));
        }

        /// <summary>
        /// VerifyTermsErrorMsg method verify the error message when agree to Terms checkbox is not selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyTermsErrorMsg(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Error Message 'You must accept the Terms and Conditions before continuing' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("termserr_lbl"));
        }

        /// <summary>
        /// VerifyAgeErrorMsg method verify the error message when age checkbox is not selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyAgeErrorMsg(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Error Message 'You must be minimum age or older to continue' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("minageerr_lbl"));
        }

        /// <summary>
        /// SelectTermsChkBox method select I have read and agree to the Terms and Conditions check box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void SelectTermsChkBox(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Checked 'Terms and Conditions' check box"));
            Selenide.Click(driver, Util.GetLocator("terms_chk"));
        }

        /// <summary>
        /// SelectAgeChkBox method select I am 13 years or older check box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void SelectAgeChkBox(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Checked: 'I am 13 years or older' check box"));
            Selenide.Click(driver, Util.GetLocator("age_chk"));
        }

        /// <summary>
        /// This method is to validate "I would like to receive special offers and other emails of interest to me" check box status
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyOffersChkBoxStatus(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("specialoffers_chk")))
                reporter.Add(new Act("'I would like to receive special offers and other emails of interest to me' check box is checked"));
        }

        /// <summary>
        /// VerifyShipAddSecRet method is to verify whether Shipping Address section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyShipAddSecRet(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Shipping Address Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shipaddret_sec"));
        }

        /// <summary>
        /// VerifyShipMetSecRet method is to verify whether Shipping Method section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyShipMetSecRet(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Shipping Method Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shipmethodret_sec"));
        }

        /// <summary>
        /// AssertDefaultAddOption method verifies if the Default address is selected as Default Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDefaultAddOption(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("defaultadd_rb")))
                reporter.Add(new Act("Shipping Address defaulted to Default Address"));
            else
                throw new Exception("Default Address is not selected");
        }

        /// <summary>
        /// SelectShippingAddress method is used to select the address based on address1 given as input
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="address1"></param>
        public static void SelectShippingAddress(RemoteWebDriver driver, Iteration reporter,
            string address1)
        {
            reporter.Add(new Act("Select the shipping address"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                String.Format(@"//strong[text()='{0}']/parent::address/preceding-sibling::input", address1)));
        }
        
        /// <summary>
        /// AssertDefaultMethodOption method verifies if the Default Method is selected as USPOST
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDefaultMethodOption(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("defaultmet_rb")))
                reporter.Add(new Act("Shipping Method defaulted to US Postal Service"));
            else
                throw new Exception("US Postal Service is not selected");
        }

        /// <summary>
        /// ClickContinueRetCm method is to Click Continue button in the BeginOrder Page for Returning Customer
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickContinueRetCm(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Continue button"));
            Selenide.Click(driver, Util.GetLocator("continueretcm_btn"));

            // *** This method redirects EyeCareProvider Page ****//
        }

        /// <summary>
        /// VerifyCommentsRet method is to verify whether Special Comments section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyCommentsRet(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Special Comments Section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("specialcomments_lbl"));
        }

        /// <summary>
        /// VerifyReturnCmSec method is to verify Returning Customer section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyReturnCustomerForm(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Returning Customer section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("returningcm_sec"));
        }

        /// <summary>
        /// EnterReturnCustomerEmail method is used to enter the Return Customer Email
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="returnMail">Returning Cm Email</param>
        public static void EnterReturnCustomerEmail(RemoteWebDriver driver, Iteration reporter, 
            string returnMail)
        {
            reporter.Add(new Act("Enter Email in the returning customer section"));
            Selenide.SetText(driver, Util.GetLocator("returnemail_btn"), Selenide.ControlType.Textbox, returnMail);
        }

        /// <summary>
        /// EnterReturnCustomerPwd method is used to enter the Return Customer Email
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="returnMail">Returning Cm Pwd</param>
        public static void EnterReturnCustomerPwd(RemoteWebDriver driver, Iteration reporter, 
            string returnPwd)
        {
            reporter.Add(new Act("Enter Pwd in the returning customer section"));
            Selenide.SetText(driver, Util.GetLocator("returnpwd_btn"), Selenide.ControlType.Textbox, returnPwd);
        }

        /// <summary>
        /// ClickReturnCustomerLogin method is to click on Login in Returning Cm section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickReturnCustomerLogin(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Login in the returning customer section"));
            Selenide.Click(driver, Util.GetLocator("returnlogin_btn"));
        }

    }
}
