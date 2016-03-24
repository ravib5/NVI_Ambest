/* **********************************************************
 * Description : MA_TC064.cs test case for 
 *               Create order with existing account, confirm order store Order Confirmation Number
 *               Singout from the application 
 *               Sign into the application with credentials 
 *               Verify tabs and default Order History tab selected
 *               Choose an Order from 'Your Order History' View the Order and Click on Reorder
 *               Edit and modify the Prescription details,Shipping Address, Shipping Method and 
 *               Click on 'update&place order now' and complete the Checkout process
 * Prerequisites : Existing credentials and ContactLenses Order with AutoReorder Option enabled                 
 *                           
 *              
 * Date :  09-Mar-2016 
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.MyAccount
{
    /// <summary>
    /// Prerequisites : Existing credentials and ContactLenses Order with AutoReorder Option enabled
    /// Description :MA_TC064.cs test case for 
    /// Create order, confirm order store Order Confirmation Number
    /// Singout from the application
    /// Sign into the application with credentials
    /// Verify tabs and default Order History tab selected
    /// Choose an Order from 'Your Order History' View the Order and Click on Reorder
    /// Edit and modify the Prescription details,Shipping Address, Shipping Method and
    /// Click on 'update&place order now' and complete the Checkout process
    /// </summary>
    class MA_TC064 : BaseCase
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

            Step = "Verifying all order history in Trackorder page";
            string[] tabnames1 = { "order history" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            bool IsContactlens = MyAccountTrackOrderPage.IsContactLens(Driver, Reporter, OrderID);
            MyAccountPage.ClickViewButton(Driver, Reporter, OrderID);
            MyAccountTrackOrderPage.AssertOrderNumber(Driver, Reporter, OrderID);
            MyAccountTrackOrderPage.AssertProductName(Driver, Reporter,
                _product, 
                IsContactlens);
            string SandB_Address = 
@"STestLNSTestLN
4265
Diplomacy Dr
Columbus, Ohio 43228
United States";

            MyAccountTrackOrderPage.AssertShippingAddress(Driver, Reporter, 
                SandB_Address);
            MyAccountTrackOrderPage.AssertBillingAddress(Driver, Reporter, 
                SandB_Address);
            MyAccountTrackOrderPage.AssertBacktoOrders(Driver, Reporter);
            MyAccountTrackOrderPage.AssertReOrder(Driver, Reporter);

            Step = "Clicking on Reorder and verify all the Sections";
            MyAccountTrackOrderPage.ClickReOrder(Driver, Reporter);
            MyAccountReOrderPage.AssertReOrderDetailsSection(Driver, Reporter);
            MyAccountReOrderPage.AssertReOrderEditButton(Driver, Reporter);
            MyAccountReOrderPage.AssertDoctorInfoCheckBox(Driver, Reporter);
            MyAccountReOrderPage.AssertShippingInfoSection(Driver, Reporter);
            MyAccountReOrderPage.AssertBillingInfoSection(Driver, Reporter);
            MyAccountReOrderPage.AssertAdditionalInfo(Driver, Reporter);
            MyAccountReOrderPage.AssertPlaceOrderButton(Driver, Reporter);

            Step = "Clicking Edit in ReorderDetails section and Verifying the buttons";
            MyAccountReOrderPage.ClickEditButton(Driver, Reporter,
                _product);
            MyAccountReOrderPage.AssertPrescriptionEdited(Driver, Reporter,
                _product);
            MyAccountReOrderPage.AssertSaveButton(Driver, Reporter);
            MyAccountReOrderPage.AssertCancelButton(Driver, Reporter);
            MyAccountReOrderPage.AssertReOrderEditButton(Driver, Reporter);

            Step = "Changing the Prescription options and Save, Verifying the changes in Prescription";
            MyAccountReOrderPage.SelectPower(Driver, Reporter, 
                TestData["POWER"]);
            MyAccountReOrderPage.SelectQuantity(Driver, Reporter, 
                TestData["NEWQTY"]);
            MyAccountReOrderPage.ClickSaveButton(Driver, Reporter);
            MyAccountReOrderPage.AssertModifiedPower(Driver, Reporter, 
                TestData["POWER"],
                _product);
            MyAccountReOrderPage.AssertModifiedQty(Driver, Reporter, 
                TestData["NEWQTY"],
                _product);

            Step = "Changing the Shipping Address and Shipping Method";
            MyAccountReOrderPage.ClickShippingAddChangeBtn(Driver, Reporter);
            MyAccountReOrderPage.AssertEditShippingAddBtn(Driver, Reporter);
            MyAccountReOrderPage.AssertRemoveShippingAddBtn(Driver, Reporter);
            MyAccountReOrderPage.AssertNewShippingAddBtn(Driver, Reporter);
            MyAccountReOrderPage.ClickEditShippingAddBtn(Driver, Reporter);

            //Commenting below lines as clarification needed on editing shipping address
            // MyAccountReOrderPage.AssertSaveAddressBtn(Driver, Reporter);
            // MyAccountReOrderPage.AssertCancelAddressBtn(Driver, Reporter);
            // MyAccountReOrderPage.EnterAddress1(Driver, Reporter,
            //     TestData["ADD1"]);
            //MyAccountReOrderPage.ClickSaveAddressBtn(Driver, Reporter);
            //Verifying the address change code is not inserted, as functionality need to be confirmed once

            MyAccountReOrderPage.SelectShippingMethod(Driver, Reporter);

            Step = "Entering Comments, Verifying Remind Me check box is checked and clicking on 'place order now' button";
            MyAccountReOrderPage.EnterComments(Driver, Reporter, "Reorder Comments");
            MyAccountReOrderPage.CheckUpdatePymtInfo(Driver, Reporter);
            MyAccountReOrderPage.AssertRemindMeChecked(Driver, Reporter);
            MyAccountReOrderPage.ClickPlaceOrderNowBtn(Driver, Reporter);

            Step = "Entering the card details and clicking complete order";
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               NewCCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.ChooseBillingAdd(Driver, Reporter);
            PaymentPage.ClickCompleteOrder(Driver, Reporter);

            Step = "Verifying Order details in order confirmation page";
            OrderConfirmationPage.VerifyThankYou(Driver, Reporter);
            OrderConfirmationPage.VerifyPrintReceipt(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderNumber(Driver, Reporter);
            OrderConfirmationPage.VerifyEstDelivery(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderTotal(Driver, Reporter);
            OrderConfirmationPage.StoreOrderCopy(Driver, resultsPath);
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
                TestData["ADDRESS1"]);
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
