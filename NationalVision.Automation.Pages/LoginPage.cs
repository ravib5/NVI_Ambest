/* *******************************************************
 * Description : LoginPage.cs contains all the methods, objects related to Login Page
 *               Enter UserID, Password, Forgot Password and ForgotUserID    
 *               
 * Date : 04-Feb-2016
 * 
 * *******************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using System;
using OpenQA.Selenium.Remote;


namespace NationalVision.Automation.Pages
{
    public class LoginPage : CommonPage
    {
        /// <summary>
        /// This method enter login credentials and click on sign-in 
        /// </summary>
        /// <param name="uname">User Name </param>
        /// <param name="password">Password to login into the application</param>
        public static void Login(RemoteWebDriver driver, Iteration reporter,
            String uname, String password)
        {
            reporter.Add(new Act("Entering Login and Password in Login Page "));
            Selenide.WaitForElementVisible(driver, Util.GetLocator("login_email_txt"));
            Selenide.SetText(driver, Util.GetLocator("login_email_txt"), Selenide.ControlType.Textbox, uname);
            Selenide.SetText(driver, Util.GetLocator("login_pasw_txt"), Selenide.ControlType.Textbox, password);

            reporter.Add(new Act("Click on Sigh-in buttons"));
            Selenide.Click(driver, Util.GetLocator("signin_btn"));
        }

        /// <summary>
        /// Click on logout button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void clickLogout(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on  Logout button"));
            Selenide.Click(driver, Util.GetLocator("acclogout_btn"));
        }

        /// <summary>
        /// ClickCreateNewAccount method click on create new account button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickCreateNewAccount(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Create New Account button"));
            Selenide.Click(driver, Util.GetLocator("createaccount_btn"));

            // *** Create New account redirects to AccountRegister Page *** //
        }

    }
}
