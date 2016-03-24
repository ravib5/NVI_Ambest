/* **********************************************************
 * Description : CLO_TC009.cs order Contact Lens with existing Club membership 
 *               for existing user; Enter Lens Power, Color, Qty, BC and DIA
 *               Click order checkOut, select patient, Verify Product details prior to 
 *               Confirm order and check Order details after confirmation.     
 *              
 * Date :  24-Feb-2015
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.ContactLensOrder
{
    /// <summary>
    /// Description : CLO_TC009.cs order Contact Lens with Club membership for existing user; 
    ///             Enter Lens Power, Qty, Color, BC and DIA; Click order checkOut; select patient, 
    ///             Verify Product details prior to confirm order;           
    ///             and Check Order details after confirmation.  
    /// </summary>
    class CLO_TC009 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying ContactLenses Order for existing user with existing EyeCare Club Membership";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "Shop by Brand", "Shop by Type", "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting a brand and verifying the brand name and price displayed";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            ContactLensShelfPage.AssertProductNamePrice(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Clicking on a product, select Already Eyecare Club member option";
            ContactLensShelfPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensesProductDisplayPage.SelectAlreadyMember(Driver, Reporter);
            ContactLensesProductDisplayPage.VerifyAlreadyMember(Driver, Reporter);
            
            Step = "Entering Prescription and Adding to Cart";
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionColor(Driver, Reporter,
                TestData["RCOLOR"],
                TestData["LCOLOR"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter,
                TestData["RQTY"],
                TestData["LQTY"]);
            ContactLensesProductDisplayPage.EnterPrescriptionBaseCurve(Driver, Reporter, 
                TestData["RBC"], 
                TestData["LBC"]);
            ContactLensesProductDisplayPage.SelectPrescriptionDiameter(Driver, Reporter, 
                TestData["RDIA"], 
                TestData["RDIA"]);

            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Verifying buttons in Shopping Cart page and click on start checkout";
            //Discounted price validation is not included here as it's unavailable in the application
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
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

            Step = "Selecting State and Store details and clicking Continue in EyeCareProvider Page";
            EyeCareProviderPage.SelectPrescriptionOption(Driver, Reporter, "stores");
            EyeCareProviderPage.SelectState(Driver, Reporter,
                TestData["S_STATE"]);
            EyeCareProviderPage.SelectStore(Driver, Reporter,
                TestData["STORE"]);
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);

            Step = "Clicking continue and verifying the sections in Payment Page";
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.VerifyPaymentMethodSec(Driver, Reporter);
            PaymentPage.VerifyReOrderSec(Driver, Reporter);
            PaymentPage.VerifyRemindMe(Driver, Reporter);
            PaymentPage.VerifyCompleteOrder(Driver, Reporter);

            Step = "Entering payment details,billing address, special comments and selecting RemindMe Frequency";
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               CCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.ChooseBillingAdd(Driver, Reporter);
            PaymentPage.EnterComments(Driver, Reporter, "testing");
            PaymentPage.CheckRemindMe(Driver, Reporter);
            PaymentPage.SelectRemindFreq(Driver, Reporter, TestData["REMINDFREQ"]);

            Step = "Clicking Complete Order and verifying details in order confirmation page";
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
