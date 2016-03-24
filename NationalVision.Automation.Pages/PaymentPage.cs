/* *******************************************************
 * Description : PaymentPage.cs contains all the methods, objects related to Payment page    
 *                like verifying all the sections and making pymt etc.  
 *               
 * Date : 11-Feb-2016
 * 
 * *******************************************************
 */
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;

namespace NationalVision.Automation.Pages
{
    public class PaymentPage : CommonPage
    {


        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Payment";
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// VerifyPaymentMethodSec method is used to verify payment method section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPaymentMethodSec(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Payment method section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("pymtmethod_sec"));
        }

        /// <summary>
        /// VerifyReOrderSec method is used to verify Reorder section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyReOrderSec(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Reorder section"));
            Selenide.VerifyVisible(driver, Util.GetLocator("reorder_sec"));
        }

        /// <summary>
        /// VerifyRemindMe method used to verify Remind me Ckeckbox is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyRemindMe(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Remind me Checkbox"));
            Selenide.VerifyVisible(driver, Util.GetLocator("remind_chk"));
        }

        /// <summary>
        /// CheckRemindMe method is to verify if the Remind Me checkbox is checked, if not click is performed on RemindMe checkbox
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckRemindMe(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("remind_chk")))
                reporter.Add(new Act("Remind Me Checkbox is checked"));
            else
            {
                reporter.Add(new Act("Click Remind Me Checkbox"));
                Selenide.Click(driver, Util.GetLocator("remind_chk"));
            }
        }

        /// <summary>
        /// CheckReOrder method is used to click on Reorder Checkbox
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckReOrder(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("reorder_chk")))
                reporter.Add(new Act("Reorder Checkbox is checked"));
            else
            {
                reporter.Add(new Act("Click Reorder Checkbox"));
                Selenide.Click(driver, Util.GetLocator("reorder_chk"));
            }
        }
        
        /// <summary>
        /// SelectRemindFreq is used to select the Remind me frequency
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="freq">Default options:2 weeks, 1 month</param>
        public static void SelectRemindFreq(RemoteWebDriver driver, Iteration reporter,
            string freq)
        {
            reporter.Add(new Act("Remind me freq is select as " + freq));
            Selenide.SetText(driver, Util.GetLocator("remindfreq_dd"), Selenide.ControlType.Listbox, freq);
        }

        /// <summary>
        /// This method is used to verify Complete Order button is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyCompleteOrder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Complete Order button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("complete_btn"));
        }

        /// <summary>
        /// EnterPaymentDetails method used to enter the caredit card details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="cardNum">Card Number</param>
        /// <param name="cardName">Name on the Card</param>
        /// <param name="expMth">Expiry Month</param>
        /// <param name="expYear">Expiry Year</param>
        public static void EnterPaymentDetails(RemoteWebDriver driver, Iteration reporter,
            string cardName,
            string cardNum,
            string expMth,
            string expYear)
        {
            VerifyPaymentMethod(driver, reporter);
            TypeNameOnCard(driver, reporter, cardName);
            TypeCardNumber(driver, reporter, cardNum);
            TypeCardExpMth(driver, reporter, expMth);
            TypeCardExpYear(driver, reporter, expYear);
        }

        /// <summary>
        /// VerifyPaymentMethod method verify if the Cardpayment method is selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPaymentMethod(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("creditcard_rb")))
                reporter.Add(new Act("Credit Card payment method is selected"));
        }

        /// <summary>
        /// TypeNameOnCard method used to enter the card name in Payment Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="cardName">Name on the Card</param>
        public static void TypeNameOnCard(RemoteWebDriver driver, Iteration reporter,
            string cardName)
        {
            reporter.Add(new Act("Enter Name on the Card in Payment Page"));
            Selenide.Clear(driver, Util.GetLocator("ccname_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("ccname_txt"), Selenide.ControlType.Textbox, cardName);
        }

        /// <summary>
        /// TypeCardNumber method used to enter the card number in Payment Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="cardNum">Enter the credit card numer, use default CC always</param>
        public static void TypeCardNumber(RemoteWebDriver driver, Iteration reporter,
            string cardNum)
        {
            reporter.Add(new Act("Enter the Card number in Payment Page"));
            Selenide.SetText(driver, Util.GetLocator("cardnum_txt"), Selenide.ControlType.Textbox, cardNum);
        }

        /// <summary>
        /// TypeCardExpMth method used to enter the card expiry month in Payment Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// /// <param name="expMth">Enter CC expire Month</param>
        public static void TypeCardExpMth(RemoteWebDriver driver, Iteration reporter,
            string expMth)
        {
            reporter.Add(new Act("Enter Expiry month of the Card in Payment Page"));
            Selenide.SetText(driver, Util.GetLocator("expmth_dd"), Selenide.ControlType.Listbox, expMth);
        }

        /// <summary>
        /// TypeCardExpYear method is used to enter the card expiry year in Payment Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// /// <param name="expYear">Enter CC expire year</param>
        public static void TypeCardExpYear(RemoteWebDriver driver, Iteration reporter,
            string expYear)
        {
            reporter.Add(new Act("Enter Expiry year of the Card in Payment Page"));
            Selenide.SetText(driver, Util.GetLocator("expyear_dd"), Selenide.ControlType.Listbox, expYear);
        }

        /// <summary>
        /// ChooseBillingAdd method is to choose the billing address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="addNewaddress">Default value false, TRUE: If user want to add new billing address</param>
        public static void ChooseBillingAdd(RemoteWebDriver driver, Iteration reporter,
            bool addNewaddress = false)
        {
            Selenide.Wait(driver, 1, true);
            if (!addNewaddress)
            {
                if (!Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.XPath,
                    "//input[starts-with(@id, 'cc-existingBillingAddress')]")))

                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        "//input[starts-with(@id, 'cc-existingBillingAddress')]"));
            }
            else
            {
                reporter.Add(new Act("Selecting new billing address"));
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    "//input[starts-with(@id, 'cc-newBillingAddress')]"));
            }
        }

        /// <summary>
        /// EnterComments method used to enter the special comments in Payments page
        /// comments default value= Testing, so once user even order the product is should not condider
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="comments">Enter only 'Testing'</param>
        public static void EnterComments(RemoteWebDriver driver, Iteration reporter,
            string comments)
        {
            reporter.Add(new Act("Entered comments in special Comments or instruction panel on Payment page"));
            Selenide.SetText(driver, Util.GetLocator("commentspymt_txt"), Selenide.ControlType.Textbox, comments);
        }

        /// <summary>
        /// ClickCompleteOrder method is used to click Complete Order button 
        /// *** User should check need to confirm order or not before click this button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickCompleteOrder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Complete Order button is clicked"));
            Selenide.Click(driver, Util.GetLocator("complete_btn"));

            // *** If user click this method it confirm the order, please caution while using this method *** //
            // *** This method redirect to Order Confiramtion Page ***//
        }
    }
}
