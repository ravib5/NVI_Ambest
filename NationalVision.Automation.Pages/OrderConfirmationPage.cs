/* *******************************************************
 * Description : OrderConfirmationPage.cs contains all the methods, objects related to Order Confirmation    
 *                like verifying order number, estimated delivery dt, Total pymt etc.  
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
    /// <summary>
    /// OrderConfirmationPage.cs contains all the methods, objects related to Order Confirmation    
    /// like verifying order number, estimated delivery dt, Total payment etc.  
    /// </summary>
    public class OrderConfirmationPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Order Confirmation";
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// VerifyThankYou method verify thank you note, if the order placed successfully
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyThankYou(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Order confirmation message"));
            Selenide.VerifyVisible(driver, Util.GetLocator("thanq_lbl"));
        }

        /// <summary>
        /// VerifyPrintReceipt method verify printable receipt, if the order placed successfully
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPrintReceipt(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'See a Prinatble Receipt link'"));
            Selenide.VerifyVisible(driver, Util.GetLocator("prink_lnk"));
        }

        /// <summary>
        /// VerifyOrderNumber method verify if the order number is present and to retreive the order number
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyOrderNumber(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.VerifyVisible(driver, Util.GetLocator("ordernum_lbl")))
                reporter.Add(new Act("Confirmation Order Number: " +
                    Selenide.GetText(driver, Util.GetLocator("ordernum_lbl"), Selenide.ControlType.Label)));
        }

        /// <summary>
        /// VerifyEstDelivery method verify if the Estimated Delivery is present and to retreive it
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyEstDelivery(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.VerifyVisible(driver, Util.GetLocator("delivery_lbl")))
                reporter.Add(new Act("Estimated Delivery Date: " +
                    Selenide.GetText(driver, Util.GetLocator("delivery_lbl"), Selenide.ControlType.Label)));
        }

        /// <summary>
        /// VerifyOrderTotal method verify if the order total is present and to retreive it
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyOrderTotal(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.VerifyVisible(driver, Util.GetLocator("total_lbl")))
                reporter.Add(new Act("Total Order Cost: " +
                    Selenide.GetText(driver, Util.GetLocator("total_lbl"), Selenide.ControlType.Label)));
        }

        /// <summary>
        /// GetOrderNumber return Order Number on order-confirmation page 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <returns>order number</returns>
        public static string GetOrderNumber(RemoteWebDriver driver, Iteration reporter)
        {
            return (Selenide.GetText(driver, Util.GetLocator("ordernum_lbl"), Selenide.ControlType.Label)).Trim();
        }

        /// <summary>
        /// StoreOrderCopy take screenshot and stores to local results path
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="imageSaveTO"></param>
        public static void StoreOrderCopy(RemoteWebDriver driver, string imageSaveTO)
        {
            Selenide.takeScreenshot(driver,
              (Selenide.GetText(driver, Util.GetLocator("ordernum_lbl"), Selenide.ControlType.Label)).Trim(), 
              imageSaveTO);
        }
    }
}
