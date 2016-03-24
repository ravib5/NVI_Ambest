/* **********************************************************
 * Description : MA_TC066.cs test case for 
 *               Sign into the application with credentials 
 *               Verify tabs and default Order History tab selected
 *               Edit an Order from 'Your Auto Reorders' 
 *               Click 'PlaceOrderNow' and verify nrew order is placed in 'Your Auto Reorders' page
 * Prerequisites : Existing credentials and Create an Order with AutoReorder enabled
 *                           
 *              
 * Date :  16-Mar-2016 
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.MyAccount
{
    /// <summary>
    /// Description :MA_TC066.cs test case for 
    /// Sign into the application with credentials
    /// Verify tabs and default Order History tab selected
    /// Edit an Order from 'Your Auto Reorders' 
    /// Click 'PlaceOrderNow' and verify nrew order is placed in 'Your Auto Reorders' page
    /// Prerequisites : Create an Order with AutoReorder enabled
    /// </summary>
    class MA_TC066 : BaseCase
    {
        private string OrderID ;

        //assigning the value to a local variable to use in multiple places

        protected override void ExecuteTestCase()
        {
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Login into Americasbest application,verify all myaccount Tabs, View the created Order, Click Reorder, Change the Order details and complete the Checkout process";
            Step = "Opening browser and Navigating to the Application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Logging into application with the existing Credentials";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            LoginPage.Login(Driver, Reporter, exsitingUserAccount, exsitingUserAccountPassword);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, newUserFName + " " + newUserNName);

            CreateOrder();

            Step = "Loging into application and verifying user name on Myaccount page";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            LoginPage.Login(Driver, Reporter, exsitingUserAccount, exsitingUserAccountPassword);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, newUserFName + " " + newUserNName);

            Step = "Verifying tabs in myaccount page and switch to all tabs";
            string[] tabnames = { "order history", "contact info", "my store", "address book", "patients", "prescriptions", "tryon" };
            MyAccountPage.AssertIsTabHighlighted(Driver, Reporter, "order history");
            MyAccountPage.AssertTabs(Driver, Reporter, tabnames);
            MyAccountPage.AssertGotoShopping(Driver, Reporter);
            MyAccountPage.AssertLogout(Driver, Reporter);

            Step = "Verifying 'Your Auto Orders', 'Your Order History' sections under 'order history' tab";
            MyAccountPage.AssertAutoReorder(Driver, Reporter);
            MyAccountPage.AssertEditButton(Driver, Reporter);
            MyAccountPage.AssertOrderHistory(Driver, Reporter);
            MyAccountPage.AssertViewButton(Driver, Reporter);

            Step = "Clicking Edit button of AutoReorder section and verifying all the sections";
            string[] tabnames1 = { "order history" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            bool IsContactlens = MyAccountTrackOrderPage.IsContactLens(Driver, Reporter, OrderID);
            MyAccountPage.ClickAutoReorderEdit(Driver, Reporter,
                OrderID);
            MyAccountAutoReorderPage.AssertScheduledAutoReorder(Driver, Reporter);
            MyAccountAutoReorderPage.VerifyAutoReorderNumber(Driver, Reporter, OrderID);
            MyAccountAutoReorderPage.AssertAdditionalInfo(Driver, Reporter);
            MyAccountAutoReorderPage.AssertAutoReorderDetails(Driver, Reporter);
            MyAccountAutoReorderPage.AssertReorderProductName(Driver, Reporter,
                _product,
                IsContactlens);
            MyAccountAutoReorderPage.AssertShippingInfo(Driver, Reporter);
            string SandB_Address =
@"STestLNSTestLN
4265
Diplomacy Dr
Columbus, OH 43228";

            MyAccountAutoReorderPage.AssertReOrderShippingAddress(Driver, Reporter,
                SandB_Address);
            MyAccountAutoReorderPage.AssertPaymentInfo(Driver, Reporter);
            MyAccountAutoReorderPage.AssertReOrderBillingAddress(Driver, Reporter,
                SandB_Address);
            MyAccountAutoReorderPage.AssertDeactivateAutoReorderBtn(Driver, Reporter);
            MyAccountAutoReorderPage.AssertPlaceOrderNowBtn(Driver, Reporter);

            Step = "Clicking on 'Place Order Now' button and verify the OrderConfirmation";
            MyAccountAutoReorderPage.ClickPlaceOrderNowBtn(Driver, Reporter);
            MyAccountAutoReorderPage.AssertPlaceOrderPopUp(Driver, Reporter);
            MyAccountAutoReorderPage.AssertCancelOnPopUp(Driver, Reporter);
            MyAccountAutoReorderPage.AssertPlaceOrderOnPopUp(Driver, Reporter);
            MyAccountAutoReorderPage.ClickPlaceOrderOnPopUp(Driver, Reporter);

            Step = "Verifying the Order in OrderConfirmation Page and in Order History";
            OrderConfirmationPage.AssertPageTitle(Driver, Reporter);
            OrderID = OrderConfirmationPage.GetOrderNumber(Driver, Reporter);
            OrderConfirmationPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            MyAccountPage.WaitLoadingComplete(Driver);
            MyAccountPage.AssertNewAutoReOrder(Driver, Reporter, OrderID);
                
        }
        public void CreateOrder()
        {
            string _product = TestData["PRODUCT"];
            Step = "Mouse Over on Contact Lenses and Selecting the Product";
            AccountRegisterPage.MouseOverHomePageTabs(Driver, Reporter,
                TestData["TABNAME"]);
            AccountRegisterPage.ClickSubMenuLink(Driver, Reporter,
                TestData["SUB_LINKS"]);

            Step = "Clicking on a product, entering the prescription and clicking on Addto Cart button";
            AccountRegisterPage.ClickContactLenseProduct(Driver, Reporter,
                _product);
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter,
                TestData["RQTY"],
                TestData["LQTY"]);
            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Clicking Start checkout button, Selecting Shiiping Address and Shipping Method in BeginOrder Page";
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);
            BeginOrderPage.SelectShippingAddress(Driver, Reporter,
                "");
            BeginOrderPage.AssertDefaultMethodOption(Driver, Reporter);

            Step = "Clicking Continue and Entering required details in EyeCareProvider Page";
            BeginOrderPage.ClickContinueRetCm(Driver, Reporter);
            EyeCareProviderPage.AssertPageTitle(Driver, Reporter);
            EyeCareProviderPage.VerifyContactLenseSec(Driver, Reporter,
                _product,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            EyeCareProviderPage.AssertDefaultPatient(Driver, Reporter);
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "stores");
            EyeCareProviderPage.SelectState(Driver, Reporter,
                TestData["S_STATE"]);
            EyeCareProviderPage.SelectStore(Driver, Reporter,
                TestData["STORE"]);

            Step = "Clicking Continue, Entering required details in Payment Page and Selecting 'Reorder Reminder'";
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               CCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.CheckReOrder(Driver, Reporter);
            PaymentPage.ClickCompleteOrder(Driver, Reporter);
            OrderConfirmationPage.StoreOrderCopy(Driver, resultsPath);

            Step = "Verifying the Order details and Clicking Logout";
            // *** OrderID value stored and assert in later login *** //
            OrderID = OrderConfirmationPage.GetOrderNumber(Driver, Reporter);
            OrderConfirmationPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            MyAccountPage.WaitLoadingComplete(Driver);
            MyAccountPage.clickLogout(Driver, Reporter);
        }
    }
}
