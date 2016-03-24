/* **********************************************************
 * Description : MyAccountTrackOrderPage.cs page contains
 *               Specific Order details
 *               Reorder functionality
 *               
 * Date :  16-Feb-2015
 * 
 * **********************************************************
 */

using System;
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// MyAccountTrackOrderPage is internal page of the Myaccount.
    /// So MyAccountTrackOrderPage class inherites MyaccountPage methods
    /// </summary>
    public class MyAccountTrackOrderPage : MyAccountPage
    {

        /// <summary>
        /// ClickBacktoOrders method click on Back to Order link on Order View Page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickBacktoOrders(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on BackOrder button"));
            Selenide.Click(driver, Util.GetLocator("backtoorder_lnk"));
        }

        /// <summary>
        /// AssertBacktoOrders method verifying BackOrder button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertBacktoOrders(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying BackOrder button on TrackOrder button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("backtoorder_lnk"));
        }

        /// <summary>
        /// ReOrder method click on Reorder button on TrackOrder Page
        /// It redirects to the reorder Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickReOrder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on  ReOrder button On Trackorder Page"));
            Selenide.Click(driver, Util.GetLocator("trackreorder_btn"));

            // *** this method redirects to the Reorder Page *** //
        }

        /// <summary>
        /// AssertReOrder method verifies Reorder button on TrackOrder page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertReOrder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying ReOrder button on TrackOrder button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("trackreorder_btn"));
        }

        /// <summary>
        /// AssertOrderNumber method assert OrderId value on TrackOrder Page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderId">orderId wish to assert on TrackOrder Page</param>
        public static void AssertOrderNumber(RemoteWebDriver driver, Iteration reporter,
            string orderId)
        {
            reporter.Add(new Act("Verifying order number on TrackOrder Page"));
            Selenide.WaitForElementVisible(driver, Util.GetLocator("trackreorderno_lab"));
            string actualOrderText = Selenide.GetText(driver, Util.GetLocator("trackreorderno_lab"), Selenide.ControlType.Label);

            string[] actualOrderId = actualOrderText.Split(new string[] { "Number" }, System.StringSplitOptions.RemoveEmptyEntries);

            if (!orderId.ToLower().Equals(actualOrderId[1].Trim().ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("Order Id numer not with Excepted. Actual Id: {0} <br> Excepted Id {1}", actualOrderId[0].Trim(), orderId));
            }
        }


        /// <summary>
        /// IsContactLens method verifies Is this order have contact lens.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderId">Order Number</param>
        /// <returns>true: If ContactLens exists in the order; false: If Contact lens not in order</returns>
        public static bool IsContactLens(RemoteWebDriver driver, Iteration reporter,
            string orderId)
        {
            if (Selenide.IsElementExists(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/ancestor::div[@class='order-history-info row ng-scope']/descendant::button[text()='reorder']", orderId))))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// AssertProductName method assert Product Name on Order Details wizard
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name to wish to assert</param>
        /// <param name="IsContactLens">true: Is ContactLens; False: for eyeglasses</param>
        public static void AssertProductName(RemoteWebDriver driver, Iteration reporter,
            string pName,
            bool IsContactLens = true)
        {
            // *** actualProductText name stores the ProductName, List is used because for multiple names. *** //
            List<string> actualProductText = new List<string>();

            reporter.Add(new Act("Verifying Product name on TrackOrder page"));

            // *** If Order contains Contact Lens, Prodcut Name should display 2 rows in the TrackerOrder  *** //
            if (IsContactLens)
            {
                for (int index = 1; index <= 2; index++)
                {
                    actualProductText.Add(Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='order-detail-info']/table/descendant::tbody/tr[{0}]/td", index)), Selenide.ControlType.Label));
                }
            }
            else
            {
                actualProductText.Add(Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
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
        /// AssertShippingAddress method assert Shipping Address on OrderTracking page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="shippinAddress">Shipping address wish to assert</param>
        public static void AssertShippingAddress(RemoteWebDriver driver, Iteration reporter,
            string shippinAddress)
        {
            reporter.Add(new Act("Verifying Shipping address on TrackOrder page"));
            string actualAddress = Selenide.GetText(driver, Util.GetLocator("shoppingaddress_lab"), Selenide.ControlType.Label);

            if (!(actualAddress.Trim().ToLower()).Contains(shippinAddress.ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("Shipping Address is not Excepted. Actual Id: {0} <br> Excepted Id {1}", actualAddress, shippinAddress));
            }
        }

        /// <summary>
        /// AssertBillingAddress method assert Billing address on OrderTracking page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="billingAddress">Billing address wish to assert</param>
        public static void AssertBillingAddress(RemoteWebDriver driver, Iteration reporter,
            string billingAddress)
        {
            reporter.Add(new Act("Verifying Billing address on TrackOrder page"));
            string actualAddress = Selenide.GetText(driver, Util.GetLocator("billingaddress_lab"), Selenide.ControlType.Label);

            if (!(actualAddress.Trim().ToLower()).Contains(billingAddress.ToLower()))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(string.Format("Billing address is not Excepted. Actual Id: {0} <br> Excepted Id {1}", actualAddress, billingAddress));
            }
        }

    }

}
