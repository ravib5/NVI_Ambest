/* **********************************************************
 * Description : MA_TC067.cs test case for 
 *               Sign into the application with credentials 
 *               Verify tabs and default Order History tab selected
 *               Click Contact Info tab and edit the contact information and 
 *               User also able to make changes to the type of emails would like to receive
 * Prerequisites : Existing credentials and Create an Order
 *                           
 *              
 * Date :  18-Mar-2016 
 * **********************************************************
 */


using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.MyAccount
{
    /// <summary>
    /// Description :MA_TC067.cs test case for 
    /// Sign into the application with credentials
    /// Verify tabs and default Order History tab selected
    /// Click Contact Info tab and edit the contact information and 
    /// User able to make changes to the type of emails would like to receive
    /// Prerequisites : Existing credentials and ContactLenses Order with AutoReorder Option enabled
    /// </summary>
    class MA_TC067 : BaseCase
    {

        //assigning the value to a local variable to use in multiple places
        private string OrderID ;

        protected override void ExecuteTestCase()
        {
            string _product = TestData["PRODUCT"];
            Reporter.Chapter.Title = "Login into Americasbest application,verify all myaccount Tabs, View the created Order, Click Reorder, Change the Order details and complete the Checkout process";
            Step = "Opening browser and Navigating to the Application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "logging into application with the existing credentials";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            //Hardcoding the values here as we need to change the user login details in future
            LoginPage.Login(Driver, Reporter, "satyanarayana.ch@cigniti.com", "112233a");
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, "Satya" + " " + "Ch");

            CreateOrder();

            Step = "Loging into application and verifying user name on Myaccount page";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            //Hardcoding the values here as we need to change the user login details in future
            LoginPage.Login(Driver, Reporter, "satyanarayana.ch@cigniti.com", "112233a");
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.CheckCutomerName(Driver, Reporter, "Satya" + " " + "Ch");

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

            Step = "Clicking ContactInfo tab and verifying all the sections";
            string[] tabnames1 = { "contact info" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountContactInfoPage.AssertContactInfo(Driver, Reporter);
            MyAccountContactInfoPage.AssertTypeOfEmail(Driver, Reporter);
            MyAccountContactInfoPage.AssertContactName(Driver, Reporter);
            MyAccountContactInfoPage.AssertContactPhoneNum(Driver, Reporter);
            MyAccountContactInfoPage.AssertContactEmailAdd(Driver, Reporter);
            MyAccountContactInfoPage.AssertContactPassword(Driver, Reporter);

            Step = "Editing Name and verifying all the fields and updating";
            MyAccountContactInfoPage.ClickNameEdit(Driver, Reporter);
            MyAccountContactInfoPage.AssertFirstName(Driver, Reporter);
            MyAccountContactInfoPage.AssertLastName(Driver, Reporter);
            MyAccountContactInfoPage.AssertSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertNameCancelButton(Driver, Reporter);
            MyAccountContactInfoPage.EnterFirstName(Driver, Reporter,
                TestData["FIRSTNAME"]);
            MyAccountContactInfoPage.EnterLastName(Driver, Reporter,
                TestData["LASTNAME"]);
            MyAccountContactInfoPage.ClickSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertNameAfterSave(Driver, Reporter,
                TestData["FIRSTNAME"],
                TestData["LASTNAME"]);

            Step = "Editing PhoneNumber and verifying all the fields and updating";
            MyAccountContactInfoPage.ClickPhoneNumberEdit(Driver, Reporter);
            MyAccountContactInfoPage.AssertPhoneNumber(Driver, Reporter);
            MyAccountContactInfoPage.AssertExtension(Driver, Reporter);
            MyAccountContactInfoPage.AssertNumSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertNumCancelButton(Driver, Reporter);
            MyAccountContactInfoPage.EnterPhoneNumber(Driver, Reporter,
                TestData["PHONENUM"]);
            MyAccountContactInfoPage.EnterExtension(Driver, Reporter,
                TestData["EXTN"]);
            MyAccountContactInfoPage.ClickNumSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertNumberAfterSave(Driver, Reporter,
               TestData["PHONENUM"],
               TestData["EXTN"]);

            Step = "Editing Email Address and verifying all the fields and updating";
            MyAccountContactInfoPage.ClickEmailAddEdit(Driver, Reporter);
            MyAccountContactInfoPage.AssertNewEmail(Driver, Reporter);
            MyAccountContactInfoPage.AssertConfirmEmail(Driver, Reporter);
            MyAccountContactInfoPage.AssertEmailPassword(Driver, Reporter);
            MyAccountContactInfoPage.AssertEmailSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertEmailCancelButton(Driver, Reporter);
            MyAccountContactInfoPage.EnterNewEmail(Driver, Reporter,
                TestData["NEWEMAIL"]);
            MyAccountContactInfoPage.EnterConfirmEmail(Driver, Reporter,
                TestData["NEWEMAIL"]);
            MyAccountContactInfoPage.EnterEmailPwd(Driver, Reporter,
                TestData["EMAILPWD"]);
            MyAccountContactInfoPage.ClickEmailSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertEmailAfterSave(Driver, Reporter, 
                TestData["NEWEMAIL"]);

            Step = "Clicking on Logout button in MyAccount Page";
            MyAccountPage.clickLogout(Driver, Reporter);

            Step = "Logging into application with the new User details and verifying the OrderHistory";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            LoginPage.Login(Driver, Reporter, 
                TestData["NEWEMAIL"],
                TestData["EMAILPWD"]);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.AssertIsTabHighlighted(Driver, Reporter, "order history");
            MyAccountPage.AssertAutoReorder(Driver, Reporter);
            MyAccountPage.AssertOrderHistory(Driver, Reporter);
            MyAccountPage.AssertNewAutoReOrder(Driver, Reporter, OrderID);

            Step = "Navigating to ConatctInfo tab and Editing password and verifying all the fields and updating";
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountContactInfoPage.ClickPasswordEdit(Driver, Reporter);
            MyAccountContactInfoPage.AssertCurrentPwd(Driver, Reporter);
            MyAccountContactInfoPage.AssertNewPwd(Driver, Reporter);
            MyAccountContactInfoPage.AssertConfirmPwd(Driver, Reporter);
            MyAccountContactInfoPage.AssertPwdSaveButton(Driver, Reporter);
            MyAccountContactInfoPage.AssertPwdCancelButton(Driver, Reporter);
            MyAccountContactInfoPage.EnterCurrentPwd(Driver, Reporter,
               TestData["EMAILPWD"]);
            MyAccountContactInfoPage.EnterNewPassword(Driver, Reporter,
               TestData["NEWPWD"]);
            MyAccountContactInfoPage.EnterConfirmPwd(Driver, Reporter,
               TestData["NEWPWD"]);
            MyAccountContactInfoPage.ClickPwdSaveButton(Driver, Reporter);

            Step = "Clicking on Logout button in MyAccount Page";
            MyAccountPage.clickLogout(Driver, Reporter);

            Step = "Logging into application with the new User password and verifying the OrderHistory";
            AccountRegisterPage.ClickTopMenuLink(Driver, Reporter, "my account / register");
            LoginPage.Login(Driver, Reporter,
                TestData["NEWEMAIL"],
                TestData["NEWPWD"]);
            MyAccountPage.AssertPageTitle(Driver, Reporter);
            MyAccountPage.AssertIsTabHighlighted(Driver, Reporter, "order history");
            MyAccountPage.AssertAutoReorder(Driver, Reporter);
            MyAccountPage.AssertOrderHistory(Driver, Reporter);
            MyAccountPage.AssertNewAutoReOrder(Driver, Reporter, OrderID);

            Step = "Navigating to ConatctInfo tab and Selecting 'type of Email' checkbox";
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountContactInfoPage.ClickTypeOfEmailCheckBox(Driver, Reporter);
            MyAccountContactInfoPage.SaveTypeOfEmailBtn(Driver, Reporter);
            MyAccountContactInfoPage.CancelTypeOfEmailBtn(Driver, Reporter);
            MyAccountContactInfoPage.ClickTypeOfEmailBtn(Driver, Reporter);


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
            BeginOrderPage.AssertDefaultAddOption(Driver, Reporter);
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
