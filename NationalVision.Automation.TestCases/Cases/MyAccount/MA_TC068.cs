/* **********************************************************
 * Description : MA_TC068.cs test case for 
 *               verify if the user is able to view, add, edit, make any address default and remove an address
 *               Sign into the application with credentials 
 *               Verify tabs and default Order History tab selected
 *               Click addressbok tab and Click on Add new address
 *               Fill the Form and Click on Save
 *               Click Edit button and Update all Fields and Click Save Address button
 *               Click Remove Button of the newly created address 
 *               Click Confirm button in address delete confirmation popup
 * Prerequisites : Existing credentials and should have placed an order already and should have atleast one address                
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
    /// Prerequisites : Existing credentials and should have placed an order already and should have atleast one address
    /// Description : MA_TC068.cs test case for
    /// verify if the user is able to view, add, edit, make any address default and remove an address
    /// Sign into the application with credentials
    /// Verify tabs and default Order History tab selected
    /// Click addressbok tab and Click on Add new address
    /// Fill the Form and Click on Save
    /// Click Edit button and Update all Fields and Click Save Address button
    /// Click Remove Button of the newly created address 
    /// Click Confirm button in address delete confirmation popup
    /// </summary>
    class MA_TC068 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Login into Americasbest application,verify all myaccount Tabs, View the created Order, Click Reorder, Change the Order details and complete the Checkout process";
            Step = "Opening browser and Navigating to the Application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Logging into application with the existing Credentials";
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

            Step = "Verifying address book buttons in My account page";
            string[] tabnames1 = { "address book" };
            MyAccountPage.SwitchTabs(Driver, Reporter, tabnames1);
            MyAccountAdressBookPage.AssertAddNewAddress(Driver, Reporter);
            MyAccountAdressBookPage.AssertAddressEditButton(Driver, Reporter);
            MyAccountAdressBookPage.AssertAddressRemoveButton(Driver, Reporter);
            MyAccountAdressBookPage.SelectAddress(Driver, Reporter, TestData["FULLNAME"]);

            Step = "Click on AddNewAddress button and Verifying SaveAddress button and Cancel button";
            MyAccountAdressBookPage.ClickAddNewAddress(Driver, Reporter);
            MyAccountAdressBookPage.AssertSaveAddress(Driver, Reporter);
            MyAccountAdressBookPage.AssertCancel(Driver, Reporter);

            Step = "Fill the Form and Click Save button";
            string _timestamp = System.DateTime.Now.ToString("hhmmssfff");
            MyAccountAdressBookPage.EnterNewAddress(Driver, Reporter,
                newUserFName + _timestamp,
                newUserNName + _timestamp,
                newUserAdd1,
                newUserAdd2,
                newUserCity,
                newUserState,
                newUserZIP,
                newUserCountry);
            MyAccountAdressBookPage.ClickSaveAddress(Driver, Reporter);

            Step = "Click on the Edit button and Verifying the changes in the Address book";
            MyAccountAdressBookPage.ClickAddressEdit(Driver, Reporter,
                newUserFName + _timestamp + " " + newUserNName + _timestamp);
            MyAccountAdressBookPage.AssertFirstName(Driver, Reporter, newUserFName + _timestamp);
            MyAccountAdressBookPage.AssertLastName(Driver, Reporter, newUserNName + _timestamp);
            MyAccountAdressBookPage.AssertStreetAddress1(Driver, Reporter, newUserAdd1);
            MyAccountAdressBookPage.AssertStreetAddress2(Driver, Reporter, newUserAdd2);
            MyAccountAdressBookPage.AssertCity(Driver, Reporter, newUserCity);
            MyAccountAdressBookPage.AssertSelectedStateValue(Driver, Reporter, newUserState);
            MyAccountAdressBookPage.AssertZip(Driver, Reporter, newUserZIP);
            MyAccountAdressBookPage.AssertSelectedCountryValue(Driver, Reporter, newUserCountry);
            MyAccountAdressBookPage.AssertSaveAddress(Driver, Reporter);
            MyAccountAdressBookPage.AssertCancel(Driver, Reporter);

            Step = "Update all fields and Click save button";
            _timestamp = System.DateTime.Now.ToString("hhmmssfff");
            MyAccountAdressBookPage.ClearFields(Driver, Reporter);
            MyAccountAdressBookPage.EnterUpdateAddress(Driver, Reporter,
                newUserFName + _timestamp,
                newUserNName + _timestamp,
                "Edit_" + newUserAdd1,
                "Edit_" + newUserAdd2);
            MyAccountAdressBookPage.ClickEditSaveAddress(Driver, Reporter);

            Step = "Click Radio button of newly created address and Verify the Default saved text";
            MyAccountAdressBookPage.SelectAddress(Driver, Reporter,
                newUserFName + _timestamp + " " + newUserNName + _timestamp);
            MyAccountAdressBookPage.VerifyDefaultSaved(Driver, Reporter,
               newUserFName + _timestamp + " " + newUserNName + _timestamp);

            Step = "Click Remove button of newly created address and verify popup with Confirm and cancel buttons";
            MyAccountAdressBookPage.ClickRemove(Driver, Reporter,
               newUserFName + _timestamp + " " + newUserNName + _timestamp);
            MyAccountAdressBookPage.VerifyPopup(Driver, Reporter);
            MyAccountAdressBookPage.VerifyCancelButton(Driver, Reporter);
            MyAccountAdressBookPage.VerifyConfirmButton(Driver, Reporter);

            Step = "Click Confirm button and verify that page should delete the default address";
            MyAccountAdressBookPage.ClickConfirm(Driver, Reporter);
            MyAccountAdressBookPage.VerifyAddressDeleted(Driver, Reporter,
                 newUserFName + _timestamp + " " + newUserNName + _timestamp);

        }
    }
}
