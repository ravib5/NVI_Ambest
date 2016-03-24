/* **********************************************************
 * Description : MyAccountAdressBookPage.cs page contains
 *               Address details, add new address button, edit and remove address etc.
 *               
 * Date :  17-Mar-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class MyAccountAdressBookPage : MyAccountPage
    {
        /// <summary>
        /// AssertAddNewAddress method verify AddNewAddress presence on MyAccount Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddNewAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify AddNewAddress button visible on MyAccount Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-book ng-scope']/descendant::button[contains(@class,'btn mid add-new-address')]"));
        }
        /// <summary>
        /// AssertAddressEditButton assert edit button presence for all addresses in address book page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddressEditButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify edit button appears for all Addresses in MyAccount Page"));

            int index = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-book ng-scope']/descendant::div[starts-with(@class,'address-book-wrapper')]"));

            for (int position = 1; position <= index; position++)
            {
                // loop will break after verify 10 records else it will take so much time to assert the object
                if (position > 10)
                    break;

                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='address-book ng-scope']/descendant::button[text()=' Edit'][" + position + "]"));
            }
        }
        /// <summary>
        /// AssertAddressRemoveButton assert remove button presence for all addresses in address book page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddressRemoveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify remove button appears for all Addresses in MyAccount Page"));

            int index = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-book ng-scope']/descendant::div[starts-with(@class,'address-book-wrapper')]"));

            for (int position = 1; position <= index; position++)
            {
                // loop will break after verify 10 records else it will take so much time to assert the object
                if (position > 10)
                    break;

                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='address-book ng-scope']/descendant::button[text()=' Remove'][" + position + "]"));
            }
        }
        /// <summary>
        /// SelectAddress method Select Address using Full name
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fullname">Enter the full name of the patient wish to select</param>
        public static void SelectAddress(RemoteWebDriver driver,
          Iteration reporter,
          string fullname)
        {
            reporter.Add(new Act("select the Address using FullName"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//p[text()='{0}']/parent::div/preceding-sibling::div/descendant::input[starts-with(@id,'address')]", fullname)));
        }
        /// <summary>
        /// ClickAddNewAddress method Click on the AddNewAddress button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickAddNewAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click AddNewAddress button on MyAccount Page"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-book ng-scope']/descendant::button[contains(@class,'btn mid add-new-address')]"));
        }
        /// <summary>
        /// AssertSaveAddress method Verify SaveAddress button presence on MyAccount page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertSaveAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify SaveAddress button visible on MyAccount Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-form ng-scope']/descendant::button[starts-with(@class,'save-edit-address')]"));
        }
        /// <summary>
        /// AssertCancel method Verify Cancel button presence on MyAccount page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertCancel(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify cancel button visible on MyAccount Page"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-form ng-scope']/descendant::button[starts-with(@class,'cancel-edit-address')]"));
        }

        /// <summary>
        /// EnterNewAddress method enter the Address information for new Address creation
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="streetAdd1"></param>
        /// <param name="streetAdd2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <param name="country"></param>
        public static void EnterNewAddress(RemoteWebDriver driver, Iteration reporter,
            string firstName,
            string lastName,
            string streetAdd1,
            string streetAdd2,
            string city,
            string state,
            string zip,
            string country)
        {
            TypeUserFName(driver, reporter, firstName);
            TypeUserLName(driver, reporter, lastName);
            TypeUserAddress1(driver, reporter, streetAdd1);
            TypeAddress2(driver, reporter, streetAdd2);
            TypeUserCity(driver, reporter, city);
            SelectStateofUser(driver, reporter, state);
            TypeUserZIP(driver, reporter, zip);
            SelectCountryofUser(driver, reporter, country);
        }
        /// <summary>
        /// TypeUserFName method enter First name in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First name</param>
        public static void TypeUserFName(RemoteWebDriver driver, Iteration reporter,
           string firstName)
        {
            reporter.Add(new Act("Entered first name to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addfirstname_txt"), Selenide.ControlType.Textbox, firstName);
        }
        /// <summary>
        /// TypeUserLName method enter last name in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lastName">Lastname</param>
        public static void TypeUserLName(RemoteWebDriver driver, Iteration reporter,
            string lastName)
        {
            reporter.Add(new Act("Entered last name to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addlastname_txt"), Selenide.ControlType.Textbox, lastName);
        }
        /// <summary>
        /// TypeUserAddress1 method enter address details in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd1">Address1</param>
        public static void TypeUserAddress1(RemoteWebDriver driver, Iteration reporter,
           string streetAdd1)
        {
            reporter.Add(new Act("Entered street address details to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addstreetadd1_txt"), Selenide.ControlType.Textbox, streetAdd1);
        }
        /// <summary>
        /// TypeAddress2 method enter address details in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd2">Address2</param>
        public static void TypeAddress2(RemoteWebDriver driver, Iteration reporter,
            string streetAdd2)
        {
            reporter.Add(new Act("Entered street address details to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addstreetadd2_txt"), Selenide.ControlType.Textbox, streetAdd2);
        }
        /// <summary>
        /// TypeUserCity method enter city in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="city">City</param>
        public static void TypeUserCity(RemoteWebDriver driver, Iteration reporter,
           string city)
        {
            reporter.Add(new Act("Entered city details to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addcity_txt"), Selenide.ControlType.Textbox, city);
        }
        /// <summary>
        /// SelectStateofUser method select the state from dropdown
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="state">State</param>
        public static void SelectStateofUser(RemoteWebDriver driver, Iteration reporter,
           string state)
        {
            reporter.Add(new Act("Entered state details to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addstate_dd"), Selenide.ControlType.Listbox, state);
        }
        /// <summary>
        /// TypeUserZIP method enter Zip Code
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="zip">ZipCode</param>
        public static void TypeUserZIP(RemoteWebDriver driver, Iteration reporter,
           string zip)
        {
            reporter.Add(new Act("Entered ZIP details to create new Address"));
            Selenide.SetText(driver, Util.GetLocator("addzip_txt"), Selenide.ControlType.Textbox, zip);
        }
        /// <summary>
        /// SelectCountryofUser method Select Country From Drop down in address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="country"></param>
        public static void SelectCountryofUser(RemoteWebDriver driver, Iteration reporter,
            string country)
        {
            reporter.Add(new Act("Selected Country as " + country + " of new in address book"));
            Selenide.SetText(driver, Util.GetLocator("addcountry_dd"), Selenide.ControlType.Listbox, country);
        }
        /// <summary>
        /// ClickSaveAddress method Click on the SaveAddress button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSaveAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click SaveAddress button visible on MyAccount Page"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='address-form ng-scope']/descendant::button[starts-with(@class,'save-edit-address')]"));
        }
        /// <summary>
        /// ClickAdressEdit method Click on the Edit button of the recently added address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">Name</param>
        public static void ClickAddressEdit(RemoteWebDriver driver, Iteration reporter,
           string name)
        {
            reporter.Add(new Act("Click on edit button of " + name));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[text()='{0}']/parent::div/following-sibling::div/button[text()=' Edit']", name)));
        }

        /// <summary>
        /// AssertModifiedFirstName method verifies if the First name is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">Expected Name</param>
        public static void AssertFirstName(RemoteWebDriver driver, Iteration reporter,
           string name)
        {
            reporter.Add(new Act("Verify First name is updated after saving the new Address"));

            string firstname = Selenide.GetText(driver, Util.GetLocator("addeditfirstname_txt"), Selenide.ControlType.Textbox);

            if (!firstname.Equals(name))
                throw new Exception(String.Format(
                     "Expected name not matching in addressbook, Expected: {0}, Actual: {1}", name, firstname));
        }
        /// <summary>
        /// AssertModifiedLastName method verifies if the Last name is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">Expected name</param>
        public static void AssertLastName(RemoteWebDriver driver, Iteration reporter,
         string name)
        {
            reporter.Add(new Act("Verify Last name is updated after saving the new Address"));

            string lastname = Selenide.GetText(driver, Util.GetLocator("addeditlastname_txt"), Selenide.ControlType.Textbox);

            if (!lastname.Equals(name))
                throw new Exception(String.Format(
                     "Expected name not matching in addressbook, Expected: {0}, Actual: {1}", name, lastname));
        }
        /// <summary>
        /// AssertModifiedStreetAddress1 method verifies if the Street address is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">StreetAddress</param>
        public static void AssertStreetAddress1(RemoteWebDriver driver, Iteration reporter,
           string name)
        {
            reporter.Add(new Act("Verify street address1 is updated after saving the new Address"));

            string streetaddress1 = Selenide.GetText(driver, Util.GetLocator("addeditstreetadd1_txt"), Selenide.ControlType.Textbox);

            if (!streetaddress1.Equals(name))
                throw new Exception(String.Format(
                     "Expected streetaddress not matching in addressbook, Expected: {0}, Actual: {1}", name, streetaddress1));
        }
        /// <summary>
        /// AssertModifiedStreetAddress2 method verifies if the Street address is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">StreetAddress2</param>
        public static void AssertStreetAddress2(RemoteWebDriver driver, Iteration reporter,
          string name)
        {
            reporter.Add(new Act("Verify street address2 is updated after saving the new Address"));

            string streetaddress2 = Selenide.GetText(driver, Util.GetLocator("addeditstreetadd2_txt"), Selenide.ControlType.Textbox);

            if (!streetaddress2.Equals(name))
                throw new Exception(String.Format(
                     "Expected streetaddress not matching in addressbook, Expected: {0}, Actual: {1}", name, streetaddress2));
        }
        /// <summary>
        /// AssertModifiedCity method verifies if the city is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">City name</param>
        public static void AssertCity(RemoteWebDriver driver, Iteration reporter,
          string name)
        {
            reporter.Add(new Act("Verify City is updated after saving the new Address"));

            string city = Selenide.GetText(driver, Util.GetLocator("addeditcity_txt"), Selenide.ControlType.Textbox);

            if (!city.Equals(name))
                throw new Exception(String.Format(
                     "Expected city not matching in addressbook, Expected: {0}, Actual: {1}", name, city));
        }
        /// <summary>
        /// AssertModifiedState method verifies if the State is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">State name</param>
        public static void AssertSelectedStateValue(RemoteWebDriver driver, Iteration reporter,
          string name)
        {
            reporter.Add(new Act("Verify State is updated after saving the new Address"));

            string State = Selenide.GetText(driver, Util.GetLocator("addeditstate_dd"), Selenide.ControlType.Select);
            if (!State.Equals(name))
                throw new Exception(String.Format(
                     "Expected State not matching in addressbook, Expected: {0}, Actual: {1}", name, State));
        }
        /// <summary>
        /// AssertModifiedZip method verifies if the Zip code is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">Zip Code</param>
        public static void AssertZip(RemoteWebDriver driver, Iteration reporter,
          string Code)
        {
            reporter.Add(new Act("Verify Zip Code is updated after saving the new Address"));

            string Zip = Selenide.GetText(driver, Util.GetLocator("addeditzip_txt"), Selenide.ControlType.Textbox);

            if (!Zip.Equals(Code))
                throw new Exception(String.Format(
                     "Expected Zip Code not matching in addressbook, Expected: {0}, Actual: {1}", Code, Zip));
        }
        /// <summary>
        /// AssertModifiedCountry method verifies if the Country is reflecting after user is saved the address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">Country name</param>
        public static void AssertSelectedCountryValue(RemoteWebDriver driver, Iteration reporter,
          string name)
        {
            reporter.Add(new Act("Verify Country is updated after saving the new Address"));

            string Country = Selenide.GetText(driver, Util.GetLocator("addeditcountry_dd"), Selenide.ControlType.Select);

            if (!Country.Equals(name))
                throw new Exception(String.Format(
                     "Expected Country not matching in addressbook, Expected: {0}, Actual: {1}", name, Country));
        }

        /// <summary>
        /// ClickEditSaveAddress method Click on Save address button in Edit Options
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickEditSaveAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click AddNewAddress button on MyAccount Page"));
            Selenide.Click(driver, Util.GetLocator("addeditsaveaddress_btn"));
        }
        /// <summary>
        /// ClearFields method Clear the fields
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClearFields(RemoteWebDriver driver, Iteration reporter)
        {
            Selenide.Clear(driver, Util.GetLocator("addeditfirstname_txt"), Selenide.ControlType.Textbox);
            Selenide.Clear(driver, Util.GetLocator("addeditlastname_txt"), Selenide.ControlType.Textbox);
            Selenide.Clear(driver, Util.GetLocator("addeditstreetadd1_txt"), Selenide.ControlType.Textbox);
            Selenide.Clear(driver, Util.GetLocator("addeditstreetadd2_txt"), Selenide.ControlType.Textbox);
        }
        /// <summary>
        /// EnterUpdateAddress method Update the address details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">first name</param>
        /// <param name="lastName">last name</param>
        /// <param name="streetAdd1">street address1</param>
        /// <param name="streetAdd2">street address2</param>
        public static void EnterUpdateAddress(RemoteWebDriver driver, Iteration reporter,
            string firstName,
            string lastName,
            string streetAdd1,
            string streetAdd2)

        {
            TypeEditFName(driver, reporter, firstName);
            TypeEditLName(driver, reporter, lastName);
            TypeEditAddress1(driver, reporter, streetAdd1);
            TypeEditAddress2(driver, reporter, streetAdd2);
        }
        /// <summary>
        /// TypeEditFName method update the firstname
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">firstname</param>
        public static void TypeEditFName(RemoteWebDriver driver, Iteration reporter,
          string firstName)
        {
            reporter.Add(new Act("Entered first name to Updae new Address"));
            Selenide.SetText(driver, Util.GetLocator("addeditfirstname_txt"), Selenide.ControlType.Textbox, firstName);
        }
        /// <summary>
        /// TypeEditLName method update the lastname
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lastName">lastname</param>
        public static void TypeEditLName(RemoteWebDriver driver, Iteration reporter,
            string lastName)
        {
            reporter.Add(new Act("Entered last name to update new Address"));
            Selenide.SetText(driver, Util.GetLocator("addeditlastname_txt"), Selenide.ControlType.Textbox, lastName);
        }
        /// <summary>
        /// TypeEditAddress1 method update address1
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd1">Streetaddress1</param>
        public static void TypeEditAddress1(RemoteWebDriver driver, Iteration reporter,
           string streetAdd1)
        {
            reporter.Add(new Act("Entered street address details to update new Address"));
            Selenide.SetText(driver, Util.GetLocator("addeditstreetadd1_txt"), Selenide.ControlType.Textbox, streetAdd1);
        }
        /// <summary>
        /// TypeEditAddress2 method update Address2
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="streetAdd2">Street Address2</param>
        public static void TypeEditAddress2(RemoteWebDriver driver, Iteration reporter,
            string streetAdd2)
        {
            reporter.Add(new Act("Entered street address details to update new Address"));
            Selenide.SetText(driver, Util.GetLocator("addeditstreetadd2_txt"), Selenide.ControlType.Textbox, streetAdd2);
        }
        /// <summary>
        /// VerifyDefaultSaved method verifies the Default saved message should be displayed when we click on the radio button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="addressname"></param>
        public static void VerifyDefaultSaved(RemoteWebDriver driver, Iteration reporter, String addressname)
        {
            reporter.Add(new Act(String.Format("Page should display the Default Saved message when we select the radio button for {0}", addressname)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//p[text()='{0}']/parent::div/preceding-sibling::div/descendant::small[text()='Default Saved']", addressname)));
        }
        /// <summary>
        /// ClickRemove method click the remove button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name"></param>
        public static void ClickRemove(RemoteWebDriver driver, Iteration reporter,
           string name)
        {
            reporter.Add(new Act(String.Format("Click on Remove button of {0}", name)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[text()='{0}']/parent::div/following-sibling::div/button[text()=' Remove']", name)));
        }
        /// <summary>
        /// VerifyPopup method verify the confirmation popup when we click on Remove button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPopup(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Remove popup displayed successfully"));
            Selenide.VerifyVisible(driver, Util.GetLocator("removepopup_lab"));
        }
        /// <summary>
        /// VerifyCancelButton method verifies the Cancel button in Remove popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Cancel Button visible on Popup"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='account-confirm-delete']/descendant::button[text()='Cancel']"));
        }
        /// <summary>
        /// VerifyConfirmButton method verifies the Confirm button in Remove Popup
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyConfirmButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Confirm Button visible on Popup"));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='account-confirm-delete']/descendant::button[text()='Confirm']"));
        }

        /// <summary>
        /// ClickConfirm method Click on the Confirm button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickConfirm(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click delete confirm button"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='account-confirm-delete']/descendant::button[text()='Confirm']"));

            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// VerifyAddressDeleted method Verifies the Address deleted or not when we click on Confirm button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="name">name of the customer</param>
        public static void VerifyAddressDeleted(RemoteWebDriver driver, Iteration reporter, String name)
        {
            reporter.Add(new Act(String.Format("Verify {0} address deleted or not", name)));
            if (Selenide.IsElementExists(driver, Locator.Get(LocatorType.XPath, string.Format(@"//p[text()='{0}']", name))))
            {
                throw new Exception("Address Exists on the MyAccountAddressbookPage");
            }
        }
    }
}
