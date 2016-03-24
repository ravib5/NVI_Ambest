/* **********************************************************
 * Description : MA_TC063.cs test case for 
 *               Create one new account
 *               Create order, confirm order store Order Confirmation Number
 *               Singout from the logout application 
 *               Sign into the application with credentials account
 *               Verify tabs and default Order History tab selected
 *               View Previous Order History
 *                           
 *              
 * Date :  16-Feb-2016 
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.MyAccount
{
    /// <summary>
    /// Description : MA_TC063.cs test case for 
    ///               Create one new account
    ///               Sign into the application with any existing account
    ///               Verify tabs and default Order History tab selected
    ///               View Previous Order History
    /// </summary>
    class MA_TC063 : BaseCase
    {
        private string emailid;
        private string passwd;
        private string OrderID;

        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Login into americasbest application and verify all myaccount Tabs";
            Step = "Open browser and create new user account";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);
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

            #region DEBUGGING PURPOSE USE BELOW CREDENTIALS
            //emailid = "QATestr20162718110256802@aclenscorp.com";
            //passwd = "Welcome123";
            //OrderID = "W73827383";
            #endregion

            LoginPage.Login(Driver, Reporter, emailid, passwd);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, newUserFName + " " + newUserNName);

            Step = "Verifying tabs in myaccount page and switch to all tabs";
            string[] tabnames = { "order history", "contact info", "my store", "address book", "patients", "prescriptions", "tryon" };
            MyAccountPage.AssertIsTabHighlighted(Driver, Reporter, "order history");
            MyAccountPage.AssertTabs(Driver, Reporter, tabnames);
            MyAccountPage.AssertGotoShopping(Driver, Reporter);
            MyAccountPage.AssertLogout(Driver, Reporter);

            Step = "Verifying all order history and Trackorder page";
            string[] tabnames1 = { "order history" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            bool IsContactlens = MyAccountTrackOrderPage.IsContactLens(Driver, Reporter, OrderID);
            MyAccountPage.ClickViewButton(Driver, Reporter, OrderID);
            MyAccountTrackOrderPage.AssertOrderNumber(Driver, Reporter, OrderID);
            MyAccountTrackOrderPage.AssertProductName(Driver, Reporter, TestData["PRODUCT"], IsContactlens);
            string SandB_Address = @"STestLNSTestLN
4265
Diplomacy Dr
Columbus, Ohio 43228
United States";

            MyAccountTrackOrderPage.AssertShippingAddress(Driver, Reporter, SandB_Address);
            MyAccountTrackOrderPage.AssertBillingAddress(Driver, Reporter, SandB_Address);
            MyAccountTrackOrderPage.AssertBacktoOrders(Driver, Reporter);
            MyAccountTrackOrderPage.AssertReOrder(Driver, Reporter);
        }


        public void CreateOrder()
        {
            Step = "Mouse Over on Contact Lenses and verify the sub tabs";
            AccountRegisterPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            AccountRegisterPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Click on a product, select the Eyecare Club membership";
            AccountRegisterPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);

            Step = "Enter the prescription, click on Addto Cart button.";
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter,
                TestData["RQTY"],
                TestData["LQTY"]);
            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Verify the discounted price, buttons in Shopping Cart page and click on start checkout";
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);

            Step = "Entering Account Information,Phone Number,Shipping Method and Special Comments";
            Step = "Entering Shipping Address details";
            BeginOrderPage.EnterShippingAddress(Driver, Reporter,
                newUserFName,
                newUserNName,
                newUserAdd1,
                newUserAdd2,
                newUserCity,
                newUserState,
                newUserZIP,
                newUserCountry);
            BeginOrderPage.EnterPhoneNumDetails(Driver, Reporter, newUserPH);
            BeginOrderPage.SelectShippingMethod(Driver, Reporter);
            BeginOrderPage.EnterSpecialComments(Driver, Reporter, "Testing");

            Step = "Selecting the required checkboxes and click continue button";
            BeginOrderPage.SelectTermsChkBox(Driver, Reporter);
            BeginOrderPage.ClickContinue(Driver, Reporter);

            Step = "Entering the patients details";
            EyeCareProviderPage.EnterPatientDetails(Driver, Reporter,
                newUserFName,
                "",
                newUserNName,
                patientmonth,
                patinetday,
                patinetyear);

            Step = "Selecting state from 'Select a State' dropdown and select a state";
            EyeCareProviderPage.SelectState(Driver, Reporter, "Alabama (8 locations)");
            EyeCareProviderPage.SelectStore(Driver, Reporter, "Homewood");

            Step = "Clicking continue and verifying the club membership";
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);

            Step = "Entering payment details,billing address and special comments";
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               CCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.CheckReOrder(Driver, Reporter);
            PaymentPage.ClickCompleteOrder(Driver, Reporter);

            // *** OrderID value stored and assert in later login *** //
            OrderID = OrderConfirmationPage.GetOrderNumber(Driver, Reporter);
            OrderConfirmationPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            MyAccountPage.WaitLoadingComplete(Driver);
            MyAccountPage.clickLogout(Driver, Reporter);
        }
    }
}
