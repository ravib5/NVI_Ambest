/* *******************************************************
 * Description : AccountRegisterPage.cs class contains all object and method
 *               to create new account in americasbest.com
 *               
 * Date : 16-Feb-2016
 * 
 * *******************************************************
 */

using System;
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;


namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// Description : AccountRegisterPage.cs class contains all object and method  to create new account in americasbest.com
    /// </summary>
    public class AccountRegisterPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Register";
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
        /// CreateNewUserAccount method enter new User Information on account register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">User lirst name</param>
        /// <param name="lastName">User last name</param>
        /// <param name="emailId">User email</param>
        /// <param name="password">Password for new user register</param>
        /// <param name="conPassowrd">Confirmtion password for new user register</param>
        public static void CreateNewUserAccount(RemoteWebDriver driver,
            Iteration reporter,
            string firstName,
            string lastName,
            string emailId,
            string password,
            string conPassowrd)
        {
            TypeFirstName(driver, reporter, firstName);
            TypeLastName(driver, reporter, lastName);
            TypeEmail(driver, reporter, emailId);
            TypePassword(driver, reporter, password);
            TypeConfirmPassword(driver, reporter, conPassowrd);
            CheckTermsandCondition(driver, reporter);
            Check13Years(driver, reporter);
            ClickCreateAccount(driver, reporter);
        }

        /// <summary>
        /// TypeFirstName method enter first name on account register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fName">First name of new user wish to enter</param>
        public static void TypeFirstName(RemoteWebDriver driver, Iteration reporter,
            String fName)
        {
            reporter.Add(new Act("Enter First Name in register page "));
            Selenide.SetText(driver, Util.GetLocator("newaccfname_txt"), Selenide.ControlType.Textbox, fName);
        }

        /// <summary>
        /// TypeLastName method enter last name on account register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lName">Last name of new user wish to enter</param>
        public static void TypeLastName(RemoteWebDriver driver, Iteration reporter,
            String lName)
        {
            reporter.Add(new Act("Enter Last Name in register page "));
            Selenide.SetText(driver, Util.GetLocator("newacclname_txt"), Selenide.ControlType.Textbox, lName);
        }

        /// <summary>
        /// TypeEmail method enter email on account register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="email">email id of new user wish to enter</param>
        public static void TypeEmail(RemoteWebDriver driver, Iteration reporter,
            String email)
        {
            reporter.Add(new Act("Enter Email in register page " + email));
            Selenide.SetText(driver, Util.GetLocator("newaccemail_txt"), Selenide.ControlType.Textbox, email);
        }

        /// <summary>
        /// TypePassword method enter newpassword on account register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="password"></param>
        public static void TypePassword(RemoteWebDriver driver, Iteration reporter,
            String password)
        {
            reporter.Add(new Act("Enter password in register page "));
            Selenide.SetText(driver, Util.GetLocator("newaccpasswd_txt"), Selenide.ControlType.Textbox, password);
        }

        /// <summary>
        /// TypeConfirmPassword method enter confirm password in register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="conPasswd"></param>
        public static void TypeConfirmPassword(RemoteWebDriver driver, Iteration reporter,
            String conPasswd)
        {
            reporter.Add(new Act("Enter confirm password in register page "));
            Selenide.SetText(driver, Util.GetLocator("newacc_conpasswd_txt"), Selenide.ControlType.Textbox, conPasswd);
        }

        /// <summary>
        /// CheckTermsandCondition method select (check/uncheck) 'Terms and Conditions' on register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckTermsandCondition(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Select (check/uncheck) 'Terms and Condition' on register page"));
            Selenide.Click(driver, Util.GetLocator("newacc_tandc_chk"));
        }

        /// <summary>
        /// Check13Years method select (check/uncheck) '13 years or Older' on register page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void Check13Years(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Select (check/uncheck) '13 years or Older' on register page"));
            Selenide.Click(driver, Util.GetLocator("newacc_is13_chk"));
        }

        /// <summary>
        /// ClickCreateAccount method click on create account buttons
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickCreateAccount(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Create Account button on account register page"));
            Selenide.Click(driver, Util.GetLocator("newacc_create_btn"));
        }

        //@TODO below method need to impliment
        public static void AssertNewAccountCreation(RemoteWebDriver driver,
            Iteration reporter)
        {
           // ** This method need to impliment once able to login in americesbest
        }

    }
}
