/* **********************************************************
 * Description : MA_TC071.cs test case for 
 *               Sign into the application with credentials 
 *               Verify tabs and default Order History tab selected
 *               Click on prescriptions tab and verify if the user is able to 
 *               Add the selected prescriptions to the cart and remove from prescriptions tab
 * Prerequisites : Create new account and Create an Order by selcting the Prescription
 *                           
 *              
 * Date :  22-Mar-2016 
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.MyAccount
{
    /// <summary>
    /// Description :MA_TC071.cs test case for 
    /// Sign into the application with credentials
    /// Verify tabs and default Order History tab selected
    /// Click on prescriptions tab and verify if the user is able to 
    /// Add the selected prescriptions to the cart and remove from prescriptions tab
    /// Prerequisites : Create an Order by selcting the Prescription
    /// </summary>
    class MA_TC071 : BaseCase
    {

        private string emailid;
        private string passwd;
        private string OrderID;

        //assigning the value to a local variable to use in multiple places

        protected override void ExecuteTestCase()
        {
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Login into Americasbest application,verify all myaccount Tabs, View the created Order, Click Reorder, Change the Order details and complete the Checkout process";
            Step = "Opening browser and Navigating to the Application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Logging into application with the existing Credentials";
            CommonPage.ClickTopMenuLink(Driver, Reporter, "my account / register");

            Step = "Verifying Create new account register page";
            LoginPage.ClickCreateNewAccount(Driver, Reporter);
            AccountRegisterPage.AssertPageTitle(Driver, Reporter);
            emailid = dynamicEmail; // This email address use in multiple methods;
            passwd = standardPassword;

            AccountRegisterPage.CreateNewUserAccount(Driver, Reporter,
                newUserFName,
                newUserNName,
                emailid,
                passwd,
                passwd);

            CreateOrder();

            Step = "Loging into application and verifying user name on Myaccount page";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            LoginPage.Login(Driver, Reporter, emailid, passwd);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, newUserFName + " " + newUserNName);

            Step = "Verifying tabs in myaccount page and switch to all tabs";
            string[] tabnames = { "order history", "contact info", "my store", "address book", "patients", "prescriptions", "tryon" };
            MyAccountPage.AssertIsTabHighlighted(Driver, Reporter, "order history");
            MyAccountPage.AssertTabs(Driver, Reporter, tabnames);
            MyAccountPage.AssertGotoShopping(Driver, Reporter);
            MyAccountPage.AssertLogout(Driver, Reporter);

            Step = "Clicking on Prescriptions tab and verifying the prescriptions displayed";
            string[] tabnames1 = { "prescriptions" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountPrescriptionsPage.AssertPrescription(Driver, Reporter,
                TestData["PRODUCT"],               
                TestData["RPOWER"]);
            MyAccountPrescriptionsPage.AssertPrescription(Driver, Reporter,
                TestData["PRODUCT"],
                TestData["LPOWER"],
                "L");

            Step = "Selecting a prescription and adding to cart, Verifying the product is added to cart";
            MyAccountPrescriptionsPage.ClickAddonPrescription(Driver, Reporter,
                TestData["PRODUCT"]);
            MyAccountPrescriptionsPage.AssertAddSelectedToCartBtn(Driver, Reporter);
            MyAccountPrescriptionsPage.ClickAddSelectedToCartBtn(Driver, Reporter);
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyProductTitle(Driver, Reporter, 
                "contactlens",
                TestData["PRODUCT"]);

            Step = "Navigating to myaccount- prescriptions tab and verifying remove functionality";
            ShoppingCartPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountPrescriptionsPage.ClickRemoveButton(Driver, Reporter);
            MyAccountPrescriptionsPage.AssertRemoveCancelBtn(Driver, Reporter);
            MyAccountPrescriptionsPage.AssertRemoveConfirmBtn(Driver, Reporter);
            MyAccountPrescriptionsPage.ClickRemoveConfirmBtn(Driver, Reporter);
            MyAccountPrescriptionsPage.AssertPrescriptionRemoved(Driver, Reporter,
               TestData["PRODUCT"]);

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
            BeginOrderPage.EnterShippingAddress(Driver,Reporter,
                newUserFName,
                newUserNName, 
                newUserAdd1, 
                newUserAdd2, 
                newUserCity, 
                newUserState, 
                newUserZIP, 
                newUserCountry);
            BeginOrderPage.AssertDefaultMethodOption(Driver, Reporter);
            BeginOrderPage.SelectTermsChkBox(Driver, Reporter);

            Step = "Clicking Continue and Entering required details in EyeCareProvider Page";
            BeginOrderPage.ClickContinueRetCm(Driver, Reporter);
            EyeCareProviderPage.AssertPageTitle(Driver, Reporter);
            EyeCareProviderPage.VerifyContactLenseSec(Driver, Reporter,
                _product,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            EyeCareProviderPage.EnterPatientDetails(Driver, Reporter,
                newUserFName,
                "",
               newUserNName,
               patientmonth,
               patinetday,
               patinetyear);
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
