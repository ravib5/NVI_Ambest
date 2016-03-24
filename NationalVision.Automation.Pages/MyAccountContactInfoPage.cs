/* **********************************************************
 * Description : MyAccountContactInfoPage.cs page contains
 *               methods related to verifying and editing contact details of the customer 
 *               
 * Date :  18-Mar-2016
 * 
 * **********************************************************
 */




using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// MyAccountContactInfoPage is internal page of the Myaccount.
    /// So MyAccountContactInfoPage class inherites MyaccountPage methods
    /// methods related to verifying and editing contact details of the customer 
    /// </summary>
    public class MyAccountContactInfoPage : MyAccountPage
    {
        /// <summary>
        /// AssertContactInfo method is used to verify the Contact Informtion in 'Contact Info' Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertContactInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Contact Information section is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contactinfo_lbl"));
        }

        /// <summary>
        /// AssertTypeOfEmail method is used to verify the Contact Informtion in 'Which type of e-mails would you like to receive?' Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertTypeOfEmail(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Which type of e-mails would you like to receive?' is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("typeofmail_lbl"));
        }

        /// <summary>
        /// AssertContactName method is used to verify name under 'Contact Information' section is present in ContactInfo page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertContactName(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify name under 'Contact Information' section is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contactname_lbl"));
        }

        /// <summary>
        /// AssertContactPhoneNum method is used to verify Phone Number under 'Contact Information' section is present in ContactInfo page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertContactPhoneNum(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Phone Number under 'Contact Information' section is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contactphonenum_lbl"));
        }

        /// <summary>
        /// AssertContactEmailAdd method is used to verify EmailAddress under 'Contact Information' section is present in ContactInfo page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertContactEmailAdd(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Email Address under 'Contact Information' section is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contactemail_lbl"));
        }

        /// <summary>
        /// AssertContactPassword method is used to verify Password under 'Contact Information' section is present in ContactInfo page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertContactPassword(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Password under 'Contact Information' section is present in ContactInfo page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contactpwd_lbl"));
        }

        /// <summary>
        /// ClickNameEdit method is used to click on the edit button of the Name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickNameEdit(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Edit icon of 'Name'"));
            Selenide.Click(driver, Util.GetLocator("editname_btn"));
        }

        /// <summary>
        /// ClickPasswordEdit method is used to click on the edit button of the Password
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPasswordEdit(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Edit icon of 'Password'"));
            Selenide.Click(driver, Util.GetLocator("editpwd_btn"));
        }

        /// <summary>
        /// ClickPhoneNumberEdit method is used to click on the edit button of the PhoneNumber
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPhoneNumberEdit(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Edit icon of 'PhoneNumber'"));
            Selenide.Click(driver, Util.GetLocator("editnum_btn"));
        }

        /// <summary>
        /// ClickEmailAddEdit method is used to click on the edit button of the EmailAddress
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickEmailAddEdit(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Edit icon of 'EmailAddress'"));
            Selenide.Click(driver, Util.GetLocator("editmail_btn"));
        }

        /// <summary>
        /// AssertFirstName medthod is used to verify FirstName is present after the name is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertFirstName(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify FirstName is present after the name is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedfirstname_txt"));
        }

        /// <summary>
        /// AssertLastName medthod is used to verify LastName is present after the name is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertLastName(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify LastName is present after the name is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedlastname_txt"));
        }

        /// <summary>
        /// AssertSaveButton medthod is used to verify save button is present after the name is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify save button is present after the name is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editsave_btn"));
        }
        

        /// <summary>
        /// AssertNumSaveButton medthod is used to verify save button is present after the num is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNumSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify save button is present after the name is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editnumsave_btn"));
        }

        /// <summary>
        /// ClickNumSaveButton medthod is used to click on save button after the num is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickNumSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click save button in phone number section"));
            Selenide.Click(driver, Util.GetLocator("editnumsave_btn"));
            Selenide.Wait(driver, 1.5, true);
        }

        /// <summary>
        /// AssertEmailSaveButton medthod is used to verify save button is present after the Email is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertEmailSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify save button is present after the Email is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editemailsave_btn"));
        }

        /// <summary>
        /// ClickEmailSaveButton medthod is used to Click save button in the edited Email section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickEmailSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click save button in Email section"));
            Selenide.Click(driver, Util.GetLocator("editemailsave_btn"));
        }

        /// <summary>
        /// ClickSaveButton medthod is used to click save button after editing the section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click save button after editing the section"));
            Selenide.Click(driver, Util.GetLocator("editsave_btn"));
            Selenide.Wait(driver, 1, true);
        }

        /// <summary>
        /// AssertNameCancelButton medthod is used to verify cancel button is present after the name is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNameCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify cancel button is present after the name is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editnamecancel_btn"));
        }

        /// <summary>
        /// AssertCancelButton medthod is used to verify cancel button is present after the section is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNumCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify cancel button is present after the section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editnumcancel_btn"));
        }

        /// <summary>
        /// AssertEmailCancelButton medthod is used to verify cancel button is present after the section is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertEmailCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify cancel button is present after the section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editemailcancel_btn"));
        }

        /// <summary>
        /// EnterFirstName method is used to enter the first name after the name is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstname">First Name which need to be updated</param>
        public static void EnterFirstName(RemoteWebDriver driver, Iteration reporter,
            string firstname)
        {
            reporter.Add(new Act("Enter FirstName after the name is edited"));
            Selenide.Clear(driver, Util.GetLocator("editedfirstname_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedfirstname_txt"),Selenide.ControlType.Textbox,firstname);
        }

        /// <summary>
        /// EnterLastName method is used to enter the Last name after the name is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lastname">Last Name which need to be updated</param>
        public static void EnterLastName(RemoteWebDriver driver, Iteration reporter,
            string lastname)
        {
            reporter.Add(new Act("Enter LastName after the name is edited"));
            Selenide.Clear(driver, Util.GetLocator("editedlastname_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedlastname_txt"), Selenide.ControlType.Textbox, lastname);
        }

        /// <summary>
        /// AssertNameAfterSave method is used to verify if the changes in Name reflects after editing and saving
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First Name of the customer</param>
        /// <param name="lastName">Last Name of the customer</param>
        public static void AssertNameAfterSave(RemoteWebDriver driver, Iteration reporter,
           string firstName,
           string lastName)
        {
            reporter.Add(new Act("Verify the new Name after edit and save "));
            string actualName = Selenide.GetText(driver, Util.GetLocator("newname_lbl"), Selenide.ControlType.Label);
            if (!actualName.Equals(firstName + " " + lastName))
                throw new Exception(@String.Format("Expected name not matching with Actual Name, Expected: { 0 }, Actual: { 1}", firstName+" "+lastName, actualName));
        }


        /// <summary>
        /// AssertNumberAfterSave method is used to verify if the changes in Phone Number reflects after editing and saving
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First Name of the customer</param>
        /// <param name="lastName">Last Name of the customer</param>
        public static void AssertNumberAfterSave(RemoteWebDriver driver, Iteration reporter,
           string phnum,
           string extension)
        {
            reporter.Add(new Act("Verify the new PhoneNumber after edit and save "));
            string actualNumber = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                "//span[@ng-bind='vm.contactInfo.phoneNumber | tel']"), Selenide.ControlType.Label);
            string[] onlyNumber = actualNumber.Split(new string[] { "FREE" }, StringSplitOptions.RemoveEmptyEntries);
            string[] Number = onlyNumber[0].Split(new Char[] { '(', ')', '-',' ' }, StringSplitOptions.RemoveEmptyEntries);
            string actualNum = Number[0] + Number[1] + Number[2];
            string extn = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                "//span[@ng-show='vm.contactInfo.phoneExtension']"), Selenide.ControlType.Label);
            string number = actualNum + extn;
            if (!number.Equals(phnum +" x"+ extension))
                throw new Exception(@String.Format("Expected number not matching with Actual number, Expected: { 0 }, Actual: { 1}", number + " " + phnum, extension));
        }


        /// <summary>
        /// AssertEmailAfterSave method is used to verify if the changes in eMail reflects after editing and saving
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="eMail">New Email provided by cm</param>
        public static void AssertEmailAfterSave(RemoteWebDriver driver, Iteration reporter,
           string eMail)
        {
            reporter.Add(new Act("Verify the new Email after edit and save "));
            string actualEmail = Selenide.GetText(driver, Util.GetLocator("newemail_lbl"), Selenide.ControlType.Label);
            if (!actualEmail.Equals(eMail))
                throw new Exception(@String.Format("Expected Email not matching with Actual Email, Expected: { 0 }, Actual: { 1}", eMail, actualEmail));
        }

        /// <summary>
        /// AssertPhoneNumber method is used to verify PhoneNumber is present after the 'Number' section is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPhoneNumber(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify PhoneNumber textbox is present after the 'Number' section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editednum_txt"));
        }

        /// <summary>
        /// AssertExtension method is used to verify extension is present after the 'Number' section is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertExtension(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Extension textbox is present after the 'Number' section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedextn_txt"));
        }

        /// <summary>
        /// EnterPhoneNumber method is used to change the number once it is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="number">New Telephone Number</param>
        public static void EnterPhoneNumber(RemoteWebDriver driver, Iteration reporter,
            string number)
        {
            reporter.Add(new Act("Enter PhoneNumber after the number text box is edited"));
            Selenide.Clear(driver, Util.GetLocator("editednum_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editednum_txt"), Selenide.ControlType.Textbox, number);
        }

        /// <summary>
        /// EnterExtension method is used to change the extension once it is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="extn">New extension</param>
        public static void EnterExtension(RemoteWebDriver driver, Iteration reporter,
            string extn)
        {
            reporter.Add(new Act("Enter extension after the number text box is edited"));
            Selenide.Clear(driver, Util.GetLocator("editedextn_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedextn_txt"), Selenide.ControlType.Textbox, extn);
        }

        /// <summary>
        /// AssertNewEmail method is used to verify New email is present after 'E-mail Address' section is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNewEmail(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify New email is present after 'E-mail Address' section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editednewemail_txt"));
        }

        /// <summary>
        /// EnterConfirmEmail method is used to Enter the Email in 'E-mail Address' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="newEmail">Enter New Mail</param>
        public static void EnterNewEmail(RemoteWebDriver driver, Iteration reporter,
            string newEmail)
        {
            reporter.Add(new Act("Enter the New Email in 'E-mail Address' section"));
            Selenide.Clear(driver, Util.GetLocator("editednewemail_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editednewemail_txt"),Selenide.ControlType.Textbox, newEmail);
        }

        /// <summary>
        /// EnterConfirmEmail method is used to Enter the confirm Email in 'E-mail Address' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="newConfirmMail">New Confirm Email</param>
        public static void EnterConfirmEmail(RemoteWebDriver driver, Iteration reporter,
            string newConfirmMail)
        {
            reporter.Add(new Act("Enter the confirm Email in 'E-mail Address' section"));
            Selenide.Clear(driver, Util.GetLocator("editedconfirmemail_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedconfirmemail_txt"),Selenide.ControlType.Textbox, newConfirmMail);
        }

        /// <summary>
        /// EnterEmailPwd method is used to Enter the Password in 'E-mail Address' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pwd">Enter the Password</param>
        public static void EnterEmailPwd(RemoteWebDriver driver, Iteration reporter,
            string pwd)
        {
            reporter.Add(new Act("Enter the Password in 'E-mail Address' section"));
            Selenide.Clear(driver, Util.GetLocator("editedpassword_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedpassword_txt"),Selenide.ControlType.Textbox,pwd);
        }

        /// <summary>
        /// AssertConfirmEmail method is used to verify confirm email is present after 'E-mail Address' section is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertConfirmEmail(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify confirm email is present after 'E-mail Address' section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedconfirmemail_txt"));
        }

        /// <summary>
        /// AssertEmailPassword method is used to verify Password is present after 'E-mail Address' section is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertEmailPassword(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Password is present after 'E-mail Address' section is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedpassword_txt"));
        }

        /// <summary>
        /// AssertCurrentPwd method is used to verify if the current password is present after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertCurrentPwd(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Current Password is present after the password is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedcurrentpwd_txt"));
        }

        /// <summary>
        /// EnterCurrentPwd method is used to Enter in current password textbox after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="currentPwd">Enter the CurrentPassword</param>
        public static void EnterCurrentPwd(RemoteWebDriver driver, Iteration reporter,
            string currentPwd)
        {
            reporter.Add(new Act("Enter Current Password in password section"));
            Selenide.Clear(driver, Util.GetLocator("editedcurrentpwd_txt"),Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedcurrentpwd_txt"), Selenide.ControlType.Textbox, currentPwd);
        }

        /// <summary>
        /// AssertNewPwd method is used to verify if the New password is present after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNewPwd(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify New Password is present after the password is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editednewpwd_txt"));
        }

        /// <summary>
        /// EnterNewPassword method is used to Enter in new password textbox after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="newPwd">Enter the NewPassword</param>
        public static void EnterNewPassword(RemoteWebDriver driver, Iteration reporter,
            string newPwd)
        {
            reporter.Add(new Act("Enter New Password in password section"));
            Selenide.Clear(driver, Util.GetLocator("editednewpwd_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editednewpwd_txt"), Selenide.ControlType.Textbox, newPwd);
        }

        /// <summary>
        /// AssertConfirmPwd method is used to verify if the Confirm password is present after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertConfirmPwd(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Confirm Password is present after the password is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editedconfmpwd_txt"));
        }

        /// <summary>
        /// EnterConfirmPwd method is used to Enter in Confirm password textbox after the password is edited
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="confirmPwd">Enter the Confirm Password</param>
        public static void EnterConfirmPwd(RemoteWebDriver driver, Iteration reporter,
            string confirmPwd)
        {
            reporter.Add(new Act("Enter Confirm Password in password section"));
            Selenide.Clear(driver, Util.GetLocator("editedconfmpwd_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("editedconfmpwd_txt"), Selenide.ControlType.Textbox, confirmPwd);
        }
        /// <summary>
        /// AssertPwdSaveButton medthod is used to verify save button is present after the Password is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPwdSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify save button is present after the Password is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editpwdsave_btn"));
        }

        /// <summary>
        /// ClickPwdSaveButton medthod is used to Click save button once Password is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPwdSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click save button in Password edit section "));
            Selenide.Click(driver, Util.GetLocator("editpwdsave_btn"));
        }

        /// <summary>
        /// AssertPwdCancelButton medthod is used to verify cancel button is present after the Password is edited 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPwdCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify cancel button is present after the Password is edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("editpwdcancel_btn"));
        }

        /// <summary>
        /// ClickTypeOfEmailCheckBox method is used to click on Check boxes under 'type of e-mails would like to receive'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">default: marketing, values:specialoffers,serviceemails,appointmentmails</param>
        public static void ClickTypeOfEmailCheckBox(RemoteWebDriver driver, Iteration reporter,
            string option = "marketing")
        {
            string option_title = null;
            switch (option.ToLower())
            {
                case "marketing":
                    option_title = "sendMarketingEmails";
                    break;
                case "specialoffers":
                    option_title = "sendSpecialOfferEmails";
                    break;
                case "serviceemails":
                    option_title = "sendServiceEmails";
                    break;
                case "appointmentmails":
                    option_title = "sendAppointmentEmails";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Clicking on '{0}' under 'type of e-mails would like to receive'", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//span[starts-with(@ng-class,'vm.contactInfo.{0}')]", option_title)));
        }

        /// <summary>
        /// SaveTypeOfEmailBtn method is used to verify if the Save button is present under'what type of e-mails would like to receive' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void SaveTypeOfEmailBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Save button is present under 'what type of e-mails would like to receive' section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("savetypeofemail_btn"));
        }

        /// <summary>
        /// ClickTypeOfEmailBtn method is used to click on the Save button under'what type of e-mails would like to receive' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickTypeOfEmailBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on the Save button under'what type of e-mails would like to receive' section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("savetypeofemail_btn"));
        }

        /// <summary>
        /// CancelTypeOfEmailBtn method is used to verify if the Save button is present under'what type of e-mails would like to receive' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CancelTypeOfEmailBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Cancel button is present under 'what type of e-mails would like to receive' section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("canceltypeofemail_btn"));
        }
    }
}
