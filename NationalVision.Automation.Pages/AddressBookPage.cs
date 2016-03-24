/* **********************************************************
 * Description : AddressBookPage.cs having functions, methods and Objects of AddressBook
 *               Edit, remove existing addressbook, and add new Addressbook.
 * 
 * Date: 07-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;


namespace NationalVision.Automation.Pages
{
    public class AddressBookPage : MyAccountPage
    {

        /// <summary>
        /// EditAddressBook method click on Edit button of respective Patient 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patName">Patient Name wish to edit address</param>
        public static void EditAddressBook(RemoteWebDriver driver, Iteration reporter,
            string patName)
        {
            reporter.Add(new Act("Click on Edit button of respective  patient "));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/parent::div/parent::div/descendant::button[contains(text(),'Edit')]", patName)));
        }

        /// <summary>
        /// clickRemoveAddress method click on remove button of respective Patient
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patName">Patient Name wish to delete</param>
        public static void clickRemoveAddress(RemoteWebDriver driver, Iteration reporter,
            string patName)
        {
            reporter.Add(new Act("Click on remove button of respective  patient "));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/parent::div/parent::div/descendant::button[contains(text(),'Remove')]", patName)));
        }

        /// <summary>
        /// clickRemoveConfirm method click on delete confirm button to remove the address from address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patName">Name of the patient wish to delete</param>
        /// <param name="index">If same address present to delete 2nd address mention index=2; Index default value=1</param>
        public static void clickRemoveConfirm(RemoteWebDriver driver, Iteration reporter,
            string patName,
            int index = 1)
        {
            reporter.Add(new Act("Click on Confirm button to Remove address from address book"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='address-book ng-scope']/descendant::div[starts-with(@class,'item-address-name')][{0}]
                /p[normalize-space()='{1}']/ancestor::div[@class= 'address-book-wrapper sortable ng-scope']/div[@class='account-confirm-delete']/descendant::button[normalize-space()='Confirm']", index, patName)));
        }

        /// <summary>
        /// ClickRemoveCancel method click on Cancel button to address book delete confirmation
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patName">Name of the Patient</param>
        /// <param name="index">Default:1</param>
        public static void ClickRemoveCancel(RemoteWebDriver driver, Iteration reporter,
            string patName,
            int index = 1)
        {
            reporter.Add(new Act("Click on Cancel button to remove address from address book"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='address-book ng-scope']/descendant::div[starts-with(@class,'item-address-name')][{0}]
/p[normalize-space()='{1}']/ancestor::div[@class= 'address-book-wrapper sortable ng-scope']/div[@class='account-confirm-delete']/descendant::button[normalize-space()='Cancel']", index, patName)));
        }

        /// <summary>
        /// SelectAddress is method select address book from the list
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="patName">Enter name wish to select the address book.</param>
        public static void SelectAddress(RemoteWebDriver driver, Iteration reporter,
            string patName)
        {
            reporter.Add(new Act("Select address radio button"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//p[normalize-space()='{0}']/parent::div/preceding-sibling::div/p/descendant::input[contains(@id,'address')]", patName)));
        }

        /// <summary>
        /// ClickNewAddress method click on 'add new address' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickNewAddress(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Add new address button on Address book page"));
            Selenide.Click(driver, Util.GetLocator("addnewaddress_btn"));
        }

        /// <summary>
        /// ClickCancleAddress method click on cancel button for new address 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickCancleAddress(RemoteWebDriver driver,
            Iteration reporter)
        {
            reporter.Add(new Act("Click on Cancel button to cancel new address"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//form[@name='addressForm']/descendant::div[@class='row']/descendant::button[@class='cancel-edit-address cancel-button']"));
        }

        /// <summary>
        /// ClickSaveAddress click on save button to save new address into new address book.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSaveAddress(RemoteWebDriver driver,
            Iteration reporter)
        {
            reporter.Add(new Act("Click on Save button for new address"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                "//form[@name='addressForm']/descendant::div[@class='row']/descendant::button[@class='save-edit-address button']"));
        }

        /// <summary>
        /// TypeFirstName method enter first name in new address book.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="fname">Enter the First name wish to enter the new address book</param>
        public static void TypeFirstName(RemoteWebDriver driver,
            Iteration reporter,
            string fname)
        {
            reporter.Add(new Act("Enter first name in add new address book"));
            Selenide.SetText(driver, Util.GetLocator("newfname_txt"), Selenide.ControlType.Textbox, fname);
        }

        /// <summary>
        /// TypeLastName method enter last name in new address book.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lname">Enter the Last name wish to enter the new address book</param>
        public static void TypeLastName(RemoteWebDriver driver,
        Iteration reporter,
        string lname)
        {
            reporter.Add(new Act("Enter Last name in add new address book"));
            Selenide.SetText(driver, Util.GetLocator("newlname_txt"), Selenide.ControlType.Textbox, lname);
        }

        /// <summary>
        /// TypeAddress1 method for enter address1 in new address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="add1">Enter the address1 wish to enter the new address book</param>
        public static void TypeAddress1(RemoteWebDriver driver,
           Iteration reporter,
           string add1)
        {
            reporter.Add(new Act("Enter address#1 in add new address book"));
            Selenide.SetText(driver, Util.GetLocator("newstraddress1_txt"), Selenide.ControlType.Textbox, add1);
        }

        /// <summary>
        /// TypeAddress2 method for enter address2 in new address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="add2">Enter the address2 wish to enter the new address book </param>
        public static void TypeAddress2(RemoteWebDriver driver,
           Iteration reporter,
           string add2)
        {
            reporter.Add(new Act("Enter address#2 in add new address book"));
            Selenide.SetText(driver, Util.GetLocator("newstraddress2_txt"), Selenide.ControlType.Textbox, add2);
        }

        /// <summary>
        /// TypeCity method enter city name in new address book 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="city">Enter the city wish to enter the new address book</param>
        public static void TypeCity(RemoteWebDriver driver,
           Iteration reporter,
           string city)
        {
            reporter.Add(new Act("Enter city in add new address details"));
            Selenide.SetText(driver, Util.GetLocator("newcity_txt"), Selenide.ControlType.Textbox, city);
        }

        /// <summary>
        /// TypeZip method enter ZIP code in new address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="zip">Enter the Zip Code</param>
        public static void TypeZip(RemoteWebDriver driver,
           Iteration reporter,
           string zip)
        {
            reporter.Add(new Act("Enter Zip code in add new address details"));
            Selenide.SetText(driver, Util.GetLocator("newzip_txt"), Selenide.ControlType.Textbox, zip);
        }

        /// <summary>
        /// SelectState method select state in new address book
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="statecode">Enter the State Code</param>
        public static void SelectState(RemoteWebDriver driver,
           Iteration reporter,
           string statecode)
        {
            reporter.Add(new Act("select state code for add new address details"));
            Selenide.SetText(driver, Util.GetLocator("newstateID_dd"), Selenide.ControlType.Select, statecode);
        }

        /// <summary>
        /// SelectCountry method to select the country in new address book.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="country">Enter the Country</param>
        public static void SelectCountry(RemoteWebDriver driver,
           Iteration reporter,
           string country)
        {
            reporter.Add(new Act("select Country in add new address details"));
            Selenide.SetText(driver, Util.GetLocator("newcountry_dd"), Selenide.ControlType.Select, country);
        }
    }
}
