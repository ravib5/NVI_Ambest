/* **********************************************************
 * Description : MyAccountPage.cs maily having the methods once user logged into the application.
 *               SwitchTabs like Order History, Concact Info.. etc, view order, reorder and logout.
 *               
 * Date :  05-Feb-2015
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using System;
using OpenQA.Selenium.Remote;

namespace NationalVision.Automation.Pages
{
    public class MyAccountPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "My Account";
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
            // ** Spinner displays in myaccount page, wait until spinner disappears. **//
            WaitLoadingComplete(driver);
        }

        /// <summary>
        /// AssertWelcomeNote method assert Welcome NOTE after user logged into the application.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckCutomerName(RemoteWebDriver driver, Iteration reporter,
            string textToAssert)
        {
            reporter.Add(new Act("Assert User Name after user logged into application"));
            string actualText = Selenide.GetText(driver, Util.GetLocator("welcomenote_lab"), Selenide.ControlType.Label);

            if (!textToAssert.Equals(actualText))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(String.Format(
                    "Expected user name not appears in MyAccount Page, Expected: {0}, Actual: {1}", textToAssert, actualText));
            }
        }

        /// <summary>
        /// SwitchTabs method to switch TABs once user logged into the application;
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="tabName">TAB name where user wish to switch</param>
        public static void SwitchTabs(RemoteWebDriver driver, Iteration reporter,
            string[] tabNames)
        {
            foreach (string tabName in tabNames)
            {
                reporter.Add(new Act("In myaccount switching to tab: " + tabName));
                // Below line of code convert first letter into Upper case
                string tabname = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tabName.ToLower());
                WaitUnitlSpinnerDisappears(driver);
		Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath, "//div[@class='account-nav-wrapper']/ul/descendant::a[text()='" + tabname + "']"));
		
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//div[@class='account-nav-wrapper']/ul/descendant::a[text()='{0}']", tabname)));
            }

            // *** This method redirects to approiate Tabs on Myaccount page.
        }

        /// <summary>
        /// AssertIsTabHighlighted method assert tab is highlighted or not
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="tabName">Tab name wish to assert eg:  Order History</param>
        public static void AssertIsTabHighlighted(RemoteWebDriver driver, Iteration reporter,
            string tabName)
        {
            reporter.Add(new Act("Assert that is tab highlighted"));

            // Below line of code convert first letter to Upper case in each word then reassign to tab name
            tabName = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tabName.ToLower());
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//a[text()='" + tabName + "']/parent::span/parent::li[@class='showing']"));
        }

        /// <summary>
        /// AssertTabs method to assert all tabs names on MyAccountPage.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="tabNames">Tab name wish to assert on Myaccount Page</param>
        public static void AssertTabs(RemoteWebDriver driver, Iteration reporter,
            string[] tabNames)
        {
            reporter.Add(new Act("Verifying available tabs on MyAccount Page"));
            foreach (string tabName in tabNames)
            {
                // *** Below line of code convert first letter to Upper case in each word then reassign to tab name //
                string Tab_Name = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(tabName.ToLower());
                if (Tab_Name.Equals("Tryon"))
                {
                    Tab_Name = "TryOn";
                }

                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    String.Format(@"//ul[@class='tabs']/descendant::a[text()='{0}']", Tab_Name)));
            }
        }

        /// <summary>
        /// AssertAutoReorder method verify Auto Reorder presence on MyAccount Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAutoReorder(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Auto Reorder list visible on MyAccount Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='auto-reorder-title row']/descendant::span[text()='Your Auto Reorder']"));
        }

        /// <summary>
        /// ClickReorder method click on reorder button of respective OrderId
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderID">OrderID wish to reorder</param>
        public static void ClickReorder(RemoteWebDriver driver, Iteration reporter,
            string orderID)
        {
            reporter.Add(new Act("Click on reorder for OrderID : " + orderID));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/ancestor::div[@class='order-history-info row ng-scope']/descendant::button[text()='reorder']",orderID )));
        }

        /// <summary>
        /// AssertEditButton method assert edit button presence for all orders in "Your Order History"
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertEditButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify edit button appears for all orders in MyAccount Page"));

            int index = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='auto-reorders ng-scope']/descendant::div[contains(@class,'auto-reorder-wrapper')]"));

            for (int position = 1; position <= index; position++)
            {
                // loop will break after verify 10 records else it will take so much time to assert the object
                if (position > 10)
                    break;

                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='auto-reorders ng-scope']/descendant::div[contains(@class,'auto-reorder-wrapper')][" + position + "]/descendant::p/a"));
            }
        }

        /// <summary>
        /// AssertOrderHistory method assert Order History presence
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertOrderHistory(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Previous Order History list visible on MyAccount Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='order-history ng-scope']/div[text()='Your Order History']"));
        }

        /// <summary>
        /// This method assert View button prescens for all the orders on MyAccount Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertViewButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify View button appears for all orders on MyAccount Page"));

            int index = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='order-history ng-scope']/descendant::div[contains(@class,'order-history-wrapper ng-scope')]/div[starts-with(@class,'order-history-info')]"));

            for (int position = 1; position <= index; position++)
            {
                // Breaking loop because to many records in the view
                if (position > 10)
                    break;

                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@class='order-history ng-scope']/descendant::div[contains(@class,'order-history-wrapper ng-scope')]
                                /div[starts-with(@class,'order-history-info')][{0}]/descendant::button[text()='view']", position)));
            }
        }

        /// <summary>
        /// ClickViewButton method for click on view button for an Order, on myaccount Page. Using index number
        /// Means if there are 3 orders in myaccount page, if user want to open 2 order, index=2
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="index">Index default value =1</param>
        public static void ClickViewButton(RemoteWebDriver driver, Iteration reporter,
            int index = 1)
        {
            reporter.Add(new Act("Click on view button for an order"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//div[@class='order-history ng-scope']/descendant::div[contains(@class,'order-history-wrapper ng-scope')]/
                            div[starts-with(@class,'order-history-info')][{0}]/descendant::button[text()='view']", index)));
        }

        /// <summary>
        /// ClickViewButton mehtod click on view button for specific order, using orderID
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderID">Type OrderID wish to view</param>
        public static void ClickViewButton(RemoteWebDriver driver, Iteration reporter,
            string orderID)
        {
            reporter.Add(new Act("Click on view button for orderID: " + orderID));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/parent::div/parent::div[@class='row']/parent::div/following-sibling::div/descendant::button[text()='view']", orderID)));
        }

        /// <summary>
        /// clickLogout method click on logout button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void clickLogout(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on  Logout button"));
            Selenide.WaitForElementNotVisible(driver, Util.GetLocator("spinner_loader_ico"));             
            Selenide.Click(driver, Util.GetLocator("acclogout_btn"));

            // *** Once User logout it redirects to ContactLens Home page *** //
        }

        /// <summary>
        /// AssertLogout mehtod assert Logout button on Myaccount Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertLogout(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying Logout button on Myaccount Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("acclogout_btn"));
        }

        /// <summary>
        /// AssertGotoShopping method assert GotoShopping button on MyaccountPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertGotoShopping(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying GotoShopping button on Myaccount Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("goshopping_btn"));
        }

        /// <summary>
        /// Click on Gotoshopping button on myaccount page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickGotoShopping(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Clicking on GotoShopping button on Myaccount Page"));
            Selenide.Click(driver, Util.GetLocator("goshopping_btn"));

            // *** This method redirects to ContactLens Home page (/shop). *** //
        }

        /// <summary>
        /// ClickAutoReorderEdit method is used to click on the Edit button of 'Auto Reorder'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="index">index of the Order of which Edit button should be clicked</param>
        public static void ClickAutoReorderEdit(RemoteWebDriver driver, Iteration reporter, 
            int index=1)
        {
            reporter.Add(new Act("Click on Edit button of AutoReorder"));
            int totalOrders = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath, 
                "//div[@ng-repeat='autoReorder in vm.autoReorders']"));
            if (totalOrders > 0)
            {
                if (index <= totalOrders)
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath, 
                        string.Format("//div[@ng-repeat='autoReorder in vm.autoReorders'][{0}]/descendant::a[text()='edit']", index)));
                else
                {
                    reporter.Add(new Act("Click on Edit button of 'AutoReorder' first product"));
                    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format("//div[@ng-repeat='autoReorder in vm.autoReorders'][1]/descendant::a[text()='edit']")));
                }
            }
            else
                throw new Exception("There are no orders under 'AutoReorder' section");
        }

        /// <summary>
        /// ClickAutoReorderEdit method is used to click on the Edit button of 'AutoReorders' of the given 'OrderID'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderID">orderID which needs to be edited</param>
        public static void ClickAutoReorderEdit(RemoteWebDriver driver, Iteration reporter,
            string orderID)
        {
            reporter.Add(new Act("Click on view button for orderID: " + orderID));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[contains(text(),'{0}')]/parent::div/parent::div/descendant::a[text()='edit']", orderID)));
        }


        /// <summary>
        /// AssertAutoReOrderStatus method is to assert the status of the AutoReorder in MyAccount Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="status">status of the AutoReOrder</param>
        public static void AssertAutoReOrderStatus(RemoteWebDriver driver, Iteration reporter, 
            string status)
        {
            reporter.Add(new Act("Verify the order status as " + status));
            if (!status.Equals("Inactive"))
                throw new Exception("Auto ReOrder status is not changed to 'Inactive'");
        }

        /// <summary>
        /// AssertNewAutoReOrder method is used to verify the order presence under 'Your Order History' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="orderId">OrderID which needs to be verified</param>
        public static void AssertNewAutoReOrder(RemoteWebDriver driver, Iteration reporter, 
            string orderId)
        {
            reporter.Add(new Act("Verify the Order " + orderId + " present under 'Your Order History'"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='order-history ng-scope']/descendant::p[contains(text(),'{0}')]", orderId)));
        }
    }
}
