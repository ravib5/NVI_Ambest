/* **********************************************************
 * Description : COLOR_POPUP.cs for Verifying PopUp when Right and Left
 *               Color values are not similar in prescription under
 *               ContactLensesProductDisplay Page
 *               
 *                               
 * Date :  23-Feb-2016
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.Miscellaneous
{
    /// <summary>
    ///  COLOR_POPUP.cs Verifying PopUp when Right and Left Color values are not similar in prescription under
    ///  ContactLensesProductDisplay Page
    /// </summary>
    class CLO_TC007_COLOR_ALERT : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying PopUp When Right Color, Left Color is not same in the Prescription";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "Shop by Brand", "Shop by Type", "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting a brand and verifying the brand name and price under each product";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            ContactLensShelfPage.AssertProductNamePrice(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Clicking on a product, enter the prescription and click on Addto Cart button";
            ContactLensShelfPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter, TestData["RPOWER"], TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter, TestData["RQTY"], TestData["LQTY"]);
            ContactLensesProductDisplayPage.SelectPrescriptionColor(Driver, Reporter, TestData["RCOLOR"], TestData["LCOLOR"]);

            Step = "Verifying and accepting the PopUp";
            ContactLensesProductDisplayPage.VerifyColorAlertMessage(Driver, Reporter);
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);

            Step = "Verifying all section in BeginOrder page is present";
            BeginOrderPage.AssertPageTitle(Driver, Reporter);
            BeginOrderPage.VerifyShippingAddSection(Driver, Reporter);
            BeginOrderPage.VerifyAccInfoSection(Driver, Reporter);
            BeginOrderPage.VerifyPhNumSection(Driver, Reporter);
            BeginOrderPage.VerifyShippingMethodSection(Driver, Reporter);
            BeginOrderPage.VerifySpecialCommentsSection(Driver, Reporter);
            BeginOrderPage.VerifyReturnCustomerForm(Driver, Reporter);

            Step = "Entering Valid details in Returning Custoner section to login";
            BeginOrderPage.EnterReturnCustomerEmail(Driver, Reporter, exsitingUserAccount);
            BeginOrderPage.EnterReturnCustomerPwd(Driver, Reporter, exsitingUserAccountPassword);
            BeginOrderPage.ClickReturnCustomerLogin(Driver, Reporter);

            Step = "Verifying the sections and default options in BeginOrder Page after Login and Clicking Continue";
            BeginOrderPage.VerifyShipAddSecRet(Driver, Reporter);
            BeginOrderPage.AssertDefaultAddOption(Driver, Reporter);
            BeginOrderPage.VerifyShipMetSecRet(Driver, Reporter);
            BeginOrderPage.AssertDefaultMethodOption(Driver, Reporter);
            BeginOrderPage.VerifyCommentsRet(Driver, Reporter);
            BeginOrderPage.ClickContinueRetCm(Driver, Reporter);

            Step = "Verifying the section in EyeCareProvider Page";
            EyeCareProviderPage.AssertPageTitle(Driver, Reporter);
            EyeCareProviderPage.VerifyContactLenseSec(Driver, Reporter,
                 TestData["PRODUCT"],
                 TestData["RPOWER"],
                 TestData["LPOWER"]);
            EyeCareProviderPage.VerifyPatientSecction(Driver, Reporter);
            EyeCareProviderPage.AssertDefaultPatient(Driver, Reporter);
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter);
            EyeCareProviderPage.VerifyGoBackLink(Driver, Reporter);
            EyeCareProviderPage.VerifyContinueBtn(Driver, Reporter);

            Step = "Verifying the Prescription options and selecting one from them";
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "stores");
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter, "stores");
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "search");
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter, "search");
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "enter");
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter, "enter");
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "fax");
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter, "fax");
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "email");
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter, "email");

            //Selecting Search for doctor option
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "search");

            EyeCareProviderPage.SearchDoctor(Driver, Reporter, TestData["DOCLASTNAME"]);
            EyeCareProviderPage.SelectDoctor(Driver, Reporter, TestData["DOCFULLNAME"]);
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);

            Step = "Verifying the sections in Payment Page";
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.VerifyPaymentMethodSec(Driver, Reporter);
            PaymentPage.VerifyReOrderSec(Driver, Reporter);
            PaymentPage.VerifyRemindMe(Driver, Reporter);
            PaymentPage.VerifyCompleteOrder(Driver, Reporter);

            Step = "Entering payment details,billing address,special comments and selecting remind me freq";
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               CCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.ChooseBillingAdd(Driver, Reporter);
            PaymentPage.EnterComments(Driver, Reporter, "testing");
            PaymentPage.CheckRemindMe(Driver, Reporter);
            PaymentPage.SelectRemindFreq(Driver, Reporter, TestData["REMINDFREQ"]);

            Step = "Click Complete Order and verify details in order confirmation page";
            PaymentPage.ClickCompleteOrder(Driver, Reporter);
            OrderConfirmationPage.AssertPageTitle(Driver, Reporter);
            OrderConfirmationPage.VerifyThankYou(Driver, Reporter);
            OrderConfirmationPage.VerifyPrintReceipt(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderNumber(Driver, Reporter);
            OrderConfirmationPage.VerifyEstDelivery(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderTotal(Driver, Reporter);
            OrderConfirmationPage.StoreOrderCopy(Driver, resultsPath);
        }
    }
}
