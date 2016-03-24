/* **********************************************************
 * Description : MyAccountAutoReorderPage.cs page contains
 *               Auto ReOrder details, Edit, deactivate auto reorder, placeOrderNow, etc.
 *               
 * Date :  14-Mar-2016
 * 
 * **********************************************************
 */


using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// MyAccountAutoReorderPage is internal page of the Myaccount.
    /// So MyAccountAutoReorderPage class inherites MyaccountPage methods
    /// </summary>
    public class MyAccountAutoReorderPage : MyAccountPage
    {
        /// <summary>
        /// AssertScheduledAutoReorder method is used to verify ' Scheduled Auto Reorder Summary' section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertScheduledAutoReorder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Scheduled Auto Reorder Summary' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("scheduleautoreorder_lbl"));
        }

        /// <summary>
        /// AssertAdditionalInfo method is used to verify ' Additional Information ' section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAdditionalInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Additional Information' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("additionalinforeorder_lbl"));
        }

        /// <summary>
        /// AssertAutoReorderDetails method is used to verify 'Auto Reorder Details' section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAutoReorderDetails(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Auto Reorder Details' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("autoreorder_lbl"));
        }

        /// <summary>
        /// AssertPaymentInfo method is used to verify 'Payment Information' section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPaymentInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Payment Information' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("pymtinfo_lbl"));
        }

        /// <summary>
        /// AssertShippingInfo method is used to verify 'Shipping Information' section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertShippingInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Shipping Information' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shippinginfo_lbl"));
        }

        /// <summary>
        /// AssertDeactivateAutoReorderBtn method is used to verify 'Deactivate AutoReorder button' is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDeactivateAutoReorderBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Deactivate AutoReorder button' is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("deactivateautoreorder_btn"));
        }

        /// <summary>
        /// ClickDeactivateAutoReorderBtn method is used to verify 'Deactivate AutoReorder button' is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickDeactivateAutoReorderBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on 'Deactivate AutoReorder button'"));
            Selenide.Click(driver, Util.GetLocator("deactivateautoreorder_btn"));
        }

        /// <summary>
        /// AssertPlaceOrderNowBtn method is used to verify 'PlaceOrder now button'is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPlaceOrderNowBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Place Order now' button is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("placeordernowreorder_btn"));
        }

        /// <summary>
        /// ClickPlaceOrderNowBtn method is to click on 'PlaceOrder now' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPlaceOrderNowBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click 'Place Order now' button on AutoReOrder Page"));
            Selenide.Click(driver, Util.GetLocator("placeordernowreorder_btn"));
        }

        /// <summary>
        /// VerifyAutoReorderNumber method is to verify the Ordernumber displayed under 'Scheduled AutoReorder Summary' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderID"></param>
        public static void VerifyAutoReorderNumber(RemoteWebDriver driver, Iteration reporter, 
            string orderID)
        {
            reporter.Add(new Act("Verify 'AutoReorder' under 'Scheduled AutoReorder Summary'"));
            string actualOrderId = Selenide.GetText(driver, Util.GetLocator("autoreordernum_lbl"), Selenide.ControlType.Label);
            if (!actualOrderId.Contains(orderID))
                throw new Exception(String.Format("Expected Order not matching under 'Scheduled AutoReorder Summary', Expected: { 0 }, Actual: { 1}", orderID, actualOrderId));
        }

        /// <summary>
        /// AssertReorderProductName method assert Product Name on 'AutoReorder Details'section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name to wish to assert</param>
        /// <param name="IsContactLens">true: Is ContactLens; False: for eyeglasses</param>
        public static void AssertReorderProductName(RemoteWebDriver driver, Iteration reporter,
            string pName,
            bool IsContactLens = true)
        {
            // *** actualProductText name stores the ProductName, List is used because for multiple names. *** //
            List<string> actualProductText = new List<string>();

            reporter.Add(new Act("Verify Product name on AutoReorder page"));

            // *** If Order contains Contact Lens, Prodcut Name should display 2 rows in the AutoReorder  *** //
            if (IsContactLens)
            {
                for (int index = 1; index <= 2; index++)
                {
                    actualProductText.Add(Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='order-detail-info']/descendant::table/tbody/tr[{0}]/td[2]", index)), Selenide.ControlType.Label));
                }
            }
            else
            {
                actualProductText.Add(Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                //neeed to change the below xpath for Eyeglasses
                    "//div[@class='order-detail-info']/table/descendant::tbody/tr/td"), Selenide.ControlType.Label));
            }

            foreach (string actualOrder in actualProductText)
            {
                if (!(actualOrder.Trim().ToLower()).Contains(pName.ToLower()))
                {
                    reporter.Chapter.Step.Action.IsSuccess = false;
                    throw new Exception(string.Format("Product Name is not Excepted. Actual Id: {0} <br> Excepted Id {1}", actualProductText, pName));
                }
            }
        }

        /// <summary>
        /// AssertReOrderShippingAddress method assert Shipping Address on OrderTracking page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="shippinAddress">Shipping address wish to assert</param>
        public static void AssertReOrderShippingAddress(RemoteWebDriver driver, Iteration reporter,
            string shippinAddress)
        {
            reporter.Add(new Act("Verify Shipping address on AutoReOrder page"));
            string actualAddress = Selenide.GetText(driver, Util.GetLocator("autoreordershippingadd_lbl"), Selenide.ControlType.Label);

            if (!(actualAddress.Trim().ToLower()).Contains(shippinAddress.ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("Shipping Address is not as Excepted. Actual Id: {0} <br> Excepted Id {1}", actualAddress, shippinAddress));
            }
        }

        /// <summary>
        /// AssertReOrderBillingAddress method assert Billing address on OrderTracking page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="billingAddress">Billing address wish to assert</param>
        public static void AssertReOrderBillingAddress(RemoteWebDriver driver, Iteration reporter,
            string billingAddress)
        {
            reporter.Add(new Act("Verify Billing address on AutoReorder page"));
            string actualAddress = Selenide.GetText(driver, Util.GetLocator("autoreorderbillingadd_lbl"), Selenide.ControlType.Label);

            if (!(actualAddress.Trim().ToLower()).Contains(billingAddress.ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("Billing address is not as Excepted. Actual Id: {0} <br> Excepted Id {1}", actualAddress, billingAddress));
            }
        }

        /// <summary>
        /// AssertDeactivateAutoReOrderSuccessMsg method is used to verify if the success message is displayed when disable autoreorder button is clicked
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDeactivateAutoReOrderSuccessMsg(RemoteWebDriver driver, Iteration reporter)
        {
            string expectedMsg = "Your Auto Reorder has been updated!";
            reporter.Add(new Act("Verify Success message when user clicks on 'Deactivate auto reorder' button"));
            string actualMsg = Selenide.GetText(driver, Util.GetLocator("deactvatesuccessmsg_lbl"), Selenide.ControlType.Label);

            if (!(actualMsg.Trim().ToLower()).Contains(expectedMsg.ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("AutoReorder Deactivate success message is not as Excepted. Actual Id: {0} <br> Excepted Id {1}", actualMsg, expectedMsg));
            }
        }

        /// <summary>
        /// AssertActivateAutoReOrderBtn method is used to verify 'Activate AutoReOrderBtn' is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertActivateAutoReOrderBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify button name is changed to 'Activate AutoReorder button'"));
            Selenide.VerifyVisible(driver, Util.GetLocator("activateautoreorder_btn"));
        }

        /// <summary>
        /// ClickBackToOrderHistory method is to click on 'Back to Order History' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickBackToOrderHistory(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click 'Back to Order History' button"));
	    Selenide.Wait(driver, 2, true);
            Selenide.WaitForElementVisible(driver, Util.GetLocator("backtoorder_btn"));
            Selenide.Click(driver, Util.GetLocator("backtoorder_btn"));
        }

        /// <summary>
        /// AssertAutoReOrderStatus method is used to verify the status of the 'AutoReOrder'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="OrderID"></param>
        public static string GetAutoReOrderStatus(RemoteWebDriver driver, Iteration reporter, 
            string OrderID)
        {
            reporter.Add(new Act("Verify the order status in 'AutoReOrder' section"));
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='auto-reorder-title row']/descendant::span[text()='Your Auto Reorder']"));
            string status = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[contains(text(),'{0}')]/ancestor::div[@class='auto-reorder-wrapper row ng-scope']/descendant::span[@ng-if='!autoReorder.active']", OrderID)), Selenide.ControlType.Label);
            return status;
        }

        /// <summary>
        /// VerifyPlaceOrderPopUp method is used to verify the popup when clicked on 'Place Order Now' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPlaceOrderPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Click Place Order Now to place this order' popup"));
            Selenide.VerifyVisible(driver, Util.GetLocator("placeorder_popup"));
        }

        /// <summary>
        /// AssertCancelOnPopUp method is used to Verify the cancel button in PlaceOrder Popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertCancelOnPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Cancel button on 'Click Place Order Now to place this order' popup"));
            Selenide.VerifyVisible(driver, Util.GetLocator("cancelplaceorder_btn"));
        }

        /// <summary>
        /// AssertPlaceOrderOnPopUp method is used to Verify the Place Order Now button on Popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPlaceOrderOnPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Place Order Now' button on 'Click Place Order Now to place this order' popup"));
            Selenide.VerifyVisible(driver, Util.GetLocator("placeorderonpopup_btn"));
        }

        /// <summary>
        /// ClickPlaceOrderOnPopUp method is used to Click the Place Order Now button on Popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPlaceOrderOnPopUp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click 'Place Order Now' button on 'Click Place Order Now to place this order' popup"));
	    Selenide.Wait(driver, 2,true);
            Selenide.Click(driver, Util.GetLocator("placeorderonpopup_btn"));
        }

    }
}
