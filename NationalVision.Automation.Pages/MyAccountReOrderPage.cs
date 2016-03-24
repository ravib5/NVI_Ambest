/* **********************************************************
 * Description : MyAccountReOrderPage.cs page contains
 *               Edit ReOrder details,Edit Shipping Address, Edit Billing Address,
 *               and PlaceOrder
 *               
 * Date :  10-Mar-2016
 * 
 * **********************************************************
 */


using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// MyAccountReOrderPage is internal page of the Myaccount.
    /// So MyAccountReOrderPage class inherites MyaccountPage methods
    /// </summary>
    public class MyAccountReOrderPage : MyAccountPage
    {
        /// <summary>
        /// AssertReOrderDetailsSection method is to verify the ReOrder Details Section presence
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertReOrderDetailsSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Reorder Details Section is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("reorder_lab"));
        }

        /// <summary>
        /// AssertReOrderEditButton method is to verify if the Edit button appears for all the Lense
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertReOrderEditButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Edit button appears for all the Lens"));

            int index = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                "//table[@ng-show='vm.shoppingCart.lensCartDetails.length']/tbody/tr"));

            for (int position = 1; position <= index; position++)
            {
                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//table[@ng-show='vm.shoppingCart.lensCartDetails.length']/tbody/tr[{0}]/descendant::button[contains(.,'Edit')]", position)));
            }
        }

        /// <summary>
        /// AssertDoctorInfoCheckBox method is to verify the presense of Doctor Information CheckBox
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertDoctorInfoCheckBox(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify the CheckBox 'Check this box if your Doctor Information has changed' appears"));
            Selenide.VerifyVisible(driver, Util.GetLocator("docinfo_chk"));
        }

        /// <summary>
        /// AssertShippingInfoSection method is to verify if the Shipping Information section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertShippingInfoSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Shipping Information section is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shippinginfo_sec"));
        }

        /// <summary>
        /// AssertBillingInfoSection method is to verify if the Billing Information section is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertBillingInfoSection(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Billing Information section is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("billinginfo_chk"));
        }

        /// <summary>
        /// AssertAdditionalInfo method is to verify if Additional Information section is present.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAdditionalInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Additional Information section is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("additionalinfo_lbl"));
        }

        /// <summary>
        /// AssertPlaceOrderButton method is to verify Place order now button is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPlaceOrderButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'place order now' button is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("placeordernow_btn"));
        }

        /// <summary>
        /// ClickPlaceOrderNowBtn method is to click on place order button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPlaceOrderNowBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on 'update and place order now' button"));
            Selenide.Click(driver, Util.GetLocator("placeordernow_btn"));

        }

        /// <summary>
        /// ClickEdit method is used to click on the Edit button of the given product
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="product">Product of which Edit button need to be clicked</param>
        /// <param name="Eye">options:'R','L' default option is 'R'</param>
        public static void ClickEditButton(RemoteWebDriver driver, Iteration reporter,
            string product, 
            string Eye = "R")
        {
            reporter.Add(new Act("Click on Edit of given Product"));

            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[text()='{0}']/following::td[1][text()='{1}']/preceding-sibling::td/button[text()=' Edit']", product, Eye)));
        }

        /// <summary>
        /// AssertPrescriptionEdited method is to verify if the Prescription is in Edit mode once the user clicks on Edit
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="product">Product of which Edit button is clicked</param>
        /// <param name="Eye">options:'R','L' default option is 'R'</param>
        public static void AssertPrescriptionEdited(RemoteWebDriver driver, Iteration reporter,
            string product, 
            string Eye = "R")
        {
            reporter.Add(new Act("Lens Prescription is in Edit mode"));

            string attributeValue = Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[text()='{0}']/following::td[1][text()='{1}']/parent::tr", product, Eye)), "class");

            if (!attributeValue.Contains("editing"))
                throw new Exception("Lens Prescription is not in Edit mode");
        }

        /// <summary>
        /// AssertSaveButton method is used to verify save button exists
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Save button exists once the Prescription is Edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("save_btn"));
        }

        /// <summary>
        /// AssertRemoveButton method is used to verify save button exists
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertRemoveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Remove button existis once the Prescription is Edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("removeLens_btn"));
        }

        /// <summary>
        /// AssertCancelButton method is used to verify save button exists
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertCancelButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Cancel button existis once the Prescription is Edited"));
            Selenide.VerifyVisible(driver, Util.GetLocator("cancel_btn"));
        }

        /// <summary>
        /// SelectPower method is to select the new Power in the Prescription
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="power">Power which user wants to select</param>
        public static void SelectPower(RemoteWebDriver driver, Iteration reporter, string power)
        {
            reporter.Add(new Act("Select Power from the dropdown"));
            Selenide.SetText(driver, Util.GetLocator("power_sel"), Selenide.ControlType.Select, power);
        }

        /// <summary>
        /// SelectQuantity method is to select the new quantity in the Prescription
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="qty">Quantity which user wants to select</param>
        public static void SelectQuantity(RemoteWebDriver driver, Iteration reporter, string qty)
        {
            reporter.Add(new Act("Select Quantity from the dropdown"));
            Selenide.SetText(driver, Util.GetLocator("qty_sel"), Selenide.ControlType.Select, qty);
        }

        /// <summary>
        /// ClickSaveButton method is to Click on Save button of the Prescription
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSaveButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Save button of Lens Prescription"));
            Selenide.Click(driver, Util.GetLocator("save_btn"));
        }

        /// <summary>
        /// AssertModifiedPower method verifies if the new Power is reflecting after user is saved the Prescription 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="power">New Power entered by the user</param>
        /// <param name="product">Product of which Edit button is clicked</param>
        /// <param name="Eye">options:'R','L' default option is 'R'</param></param>        
        public static void AssertModifiedPower(RemoteWebDriver driver, Iteration reporter, 
            string power,
            string product,
            string Eye = "R")
        {
            reporter.Add(new Act("Verify Power is updated after saving the new Prescription"));

            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[text()='{0}']/following::td[1][text()='{1}']/preceding-sibling::td/button[text()=' Edit']", product, Eye)));

            string actualPower = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[text()='{0}']/following::td[1][text()='{1}']/following-sibling::td[@ng-if='vm.shoppingCart.showSphereHeader']/span", product, Eye)), Selenide.ControlType.Label);

            if (!actualPower.Equals(power))
                throw new Exception(String.Format(
                     "Expected power not matching in Prescription, Expected: {0}, Actual: {1}", power, actualPower));
        }

        /// <summary>
        /// AssertModifiedQty method verifies if the new Quantity is reflecting after user is saved the Prescription 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="qty">New qty entered by the user</param>
        /// <param name="product">Product of which Edit button is clicked</param>
        /// <param name="Eye">options:'R','L' default option is 'R'</param></param>
        public static void AssertModifiedQty(RemoteWebDriver driver, Iteration reporter, 
            string qty,
            string product, 
            string Eye = "R")
        {
            reporter.Add(new Act("Verify Quantity is updated after saving the new Prescription"));

            string actualQty = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//a[text()='{0}']/following::td[1][text()='{1}']/following-sibling::td/span[@ng-hide='lensCartDetail.editMode']", product, Eye)), Selenide.ControlType.Label);

            // If quantity not maches with expected it will throw exception
            if (!actualQty.Equals(qty))
                throw new Exception(String.Format(
                     "Expected power not matching in Prescription, Expected: {0}, Actual: {1}", qty, actualQty));
        }

        /// <summary>
        /// ClickShippingAddChangeBtn method is to click on Shipping Address Change button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickShippingAddChangeBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Shipping Address change button"));
            Selenide.Click(driver, Util.GetLocator("shipaddchange_btn"));
        }

        /// <summary>
        /// AssertEditShippingAddBtn method is used to verify Edit button is present in Shipping Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertEditShippingAddBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Edit button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shipaddedit_btn"));
        }

        /// <summary>
        /// ClickEditShippingAddBtn method is used to click on Edit button of Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickEditShippingAddBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Edit button of Shipping Address"));
            Selenide.Click(driver, Util.GetLocator("shipaddedit_btn"));
        }

        /// <summary>
        /// AssertRemoveShippingAddBtn method is used to verify Remove button is present in Shipping Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertRemoveShippingAddBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Remove button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("shipaddremove_btn"));
        }

        /// <summary>
        /// ClickRemoveShippingAddBtn method is used to click on Remove button of Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickRemoveShippingAddBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Remove button of Shipping Address"));
            Selenide.Click(driver, Util.GetLocator("shipaddremove_btn"));
        }

        /// <summary>
        /// AssertNewShippingAddBtn method is used to verify New Address button is present in Shipping Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertNewShippingAddBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify New Address button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("newaddress_btn"));
        }

        /// <summary>
        /// ClickNewAddressBtn method is used to click on New Address button of Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickNewAddressBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on New Address button of Shipping Address"));
            Selenide.Click(driver, Util.GetLocator("newaddress_btn"));
        }

        /// <summary>
        /// AssertSaveAddressBtn method is used to verify Save Address button is present after clicking Edit/New Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertSaveAddressBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Save Address button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("saveaddress_btn"));
        }

        /// <summary>
        /// ClickSaveAddressBtn method is ised to click Save Address button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSaveAddressBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click Save Address button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("saveaddress_btn"));
        }
        /// <summary>
        /// AssertCancelAddressBtn method is used to verify Cancel Address button is present after clicking Edit/New Address
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertCancelAddressBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Cancel Address button of Shipping Address is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("canceladress_btn"));
        }

        /// <summary>
        /// EnterFirstName method is used to enter the FirstName in Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName"> Enter First Name </param>
        public static void EnterFirstName(RemoteWebDriver driver, Iteration reporter, 
            string firstName)
        {
            reporter.Add(new Act("Enter customer First Name in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reorderfirstname_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reorderfirstname_txt"), Selenide.ControlType.Textbox, firstName);
        }

        /// <summary>
        /// EnterLastName method is used to enter the LastName in Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="lastName">Enter Last Name</param>
        public static void EnterLastName(RemoteWebDriver driver, Iteration reporter,
            string lastName)
        {
            reporter.Add(new Act("Enter customer Last Name in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reorderlasttname_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reorderlasttname_txt"), Selenide.ControlType.Textbox, lastName);
        }

        /// <summary>
        /// EnterAddress1 method is used to enter Street Address1 in Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="Address1">Enter Address1</param>
        public static void EnterAddress1(RemoteWebDriver driver, Iteration reporter, 
            string Address1)
        {
            reporter.Add(new Act("Enter Shipping Address1 in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reorderaddress1_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reorderaddress1_txt"), Selenide.ControlType.Textbox, Address1);
        }

        /// <summary>
        /// EnterAddress2 method is used to enter Street Address2 in Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="Address2">Enter Address2</param>
        public static void EnterAddress2(RemoteWebDriver driver, Iteration reporter,
            string Address2)
        {
            reporter.Add(new Act("Enter Shipping Address2 in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reorderaddress2_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reorderaddress2_txt"), Selenide.ControlType.Textbox, Address2);
        }

        /// <summary>
        /// EnterCity method is used to enter the City in Shipping Addres section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="city">Enter City</param>
        public static void EnterCity(RemoteWebDriver driver, Iteration reporter,
            string city)
        {
            reporter.Add(new Act("Enter City in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reordercity_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reordercity_txt"), Selenide.ControlType.Textbox, city);
        }

        /// <summary>
        /// EnterState method is used to enter the State in Shipping Addres section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="state">Enter State</param>
        public static void EnterState(RemoteWebDriver driver, Iteration reporter, 
            string state)
        {
            reporter.Add(new Act("Enter State in Shipping Address"));
            Selenide.SetText(driver, Util.GetLocator("reorderstate_dd"), Selenide.ControlType.Listbox, state);
        }


        /// <summary>
        /// EnterZipCode method is used to enter the zipCode in Shipping Addres section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="zipCode">Enter ZipCode</param>
        public static void EnterZipCode(RemoteWebDriver driver, Iteration reporter,
            string zipCode)
        {
            reporter.Add(new Act("Enter zipCode in Shipping Address"));
            Selenide.Clear(driver, Util.GetLocator("reorderzipcode_txt"), Selenide.ControlType.Textbox);
            Selenide.SetText(driver, Util.GetLocator("reorderzipcode_txt"), Selenide.ControlType.Textbox, zipCode);
        }


        /// <summary>
        /// EnterCountry method is used to enter country in Shipping Address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">Enter Country</param>
        public static void EnterCountry(RemoteWebDriver driver, Iteration reporter,
            string country)
        {
            reporter.Add(new Act("Enter country in Shipping Address"));
            Selenide.SetText(driver, Util.GetLocator("reordercountry_dd"), Selenide.ControlType.Listbox, country);
        }

        /// <summary>
        /// This method is used to enter the new Address details in shipping address section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="firstName">First name of user</param>
        /// <param name="lastName">Last name of user</param>
        /// <param name="address1">Address line1 of user</param>
        /// <param name="address2">Address line2 of user</param>
        /// <param name="city">City details of user</param>
        /// <param name="state">State details of user</param>
        /// <param name="zipCode">ZIP code of user</param>
        /// <param name="country">Country of user</param>
        public static void EnterNewAddress(RemoteWebDriver driver, Iteration reporter,
            string firstName,
            string lastName,
            string address1,
            string address2,
            string city,
            string state,
            string zipCode,
            string country)
        {
            EnterFirstName(driver, reporter, firstName);
            EnterLastName(driver, reporter, lastName);
            EnterAddress1(driver, reporter, address1);
            EnterAddress2(driver, reporter, address2);
            EnterCity(driver, reporter, city);
            EnterState(driver, reporter, state);
            EnterZipCode(driver, reporter, zipCode);
            EnterCountry(driver, reporter, country);
        }

        /// <summary>
        /// SelectShippingMethod method is used to change the Shipping Method option
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="method"></param>
        public static void SelectShippingMethod(RemoteWebDriver driver, Iteration reporter, string method = "US - Expedited (3 to 5 days) $11.95")
        {
            reporter.Add(new Act("Select the Shipping method option"));
            Selenide.SetText(driver, Util.GetLocator("shipmethod_dd"), Selenide.ControlType.Listbox, method);
        }

        /// <summary>
        /// EnterComments method is used to enter the comments in 'Comments or Special Instructions' section
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="comments">Comments</param>
        public static void EnterComments(RemoteWebDriver driver, Iteration reporter, string comments)
        {
            reporter.Add(new Act("Enter comments in 'Comments or Special Instructions' section"));
            Selenide.SetText(driver, Util.GetLocator("reordercomments_txt"), Selenide.ControlType.Textbox, comments);
        }

        /// <summary>
        /// CheckUpdatePymtInfo method is to check the checkbox 'I need to update my Payment Information'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckUpdatePymtInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Check 'I need to update my Payment Information' checkbox"));
            Selenide.Click(driver, Util.GetLocator("updatepymtinfo_chk"));
        }
        
        /// <summary>
        /// AssertRemindMeChecked method is used to verify if the Reorder checkbox is checked  by default
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertRemindMeChecked(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Remine Me' checkbox is checked by default"));
            if (!Selenide.GetCheckedStatus(driver, Util.GetLocator("reorderremindme_chk")))
                throw new Exception(string.Format("'Remind Me' check box is not checked"));
        }
    }
}


