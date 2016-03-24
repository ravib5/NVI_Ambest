/* **********************************************************
 * Description : CLO_TC003.cs Order Contact Lens with Club Membership
 *               Enter Lens Power & Qty 
 *               Click order checkOut
 *               Create New user (Shipping address, Phone, Payment details)
 *               Add Patient details
 *               Verify Product details prior to confirm order
 *               Confirm order and check Order details after confirmation.     
 *              
 * Date :  12-Feb-2015
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;

namespace NationalVision.Automation.Tests.Cases.ContactLensOrder
{
    /// <summary>
    ///  CLO_TC003.cs Order Contact Lens with Club Membership; Enter Lens Power & Qty; Click order checkOut
    ///     Create New user (Shipping address, Phone, Payment details); Add Patient details
    ///     Verify Product details prior to confirm order; Confirm order and check Order details after confirmation.
    /// </summary>
    class CLO_TC003 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verifying ContactLense Order by taking Eye Care Club Membership for a new account";
            Step = "Open browser and navigate to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Mouse Over on Contact Lenses and verify the sub tabs";
            CommonPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            string[] sections = { "Shop by Brand", "Shop by Type", "Contact Lens Offers" };
            CommonPage.AssertSubSections(Driver, Reporter, sections);

            Step = "Selecting a brand and verifying the brand name and price displayed";
            CommonPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            ContactLensShelfPage.AssertProductNamePrice(Driver, Reporter, TestData["SUB_LINKS"]);

            Step = "Clicking on a product, select the Eyecare Club membership";
            ContactLensShelfPage.ClickContactLenseProduct(Driver, Reporter, TestData["PRODUCT"]);
            ContactLensesProductDisplayPage.SelectMembershipOptions(Driver, Reporter, true);
            ContactLensesProductDisplayPage.VerifyIsClubMemberShipSelected(Driver, Reporter, true);
            string membershipCost = ContactLensesProductDisplayPage.GetClubMemberShipPrice(Driver, Reporter, true);

            Step = "Enter the prescription, click on Addto Cart button.";
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter,
                TestData["RPOWER"],
                TestData["LPOWER"]);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter,
                TestData["RQTY"],
                TestData["LQTY"]);
            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Verifying the discounted price, buttons in Shopping Cart page and click on start checkout";
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

            Step = "Entering Account Information,Phone Number,Shipping Method and Special Comments";
            BeginOrderPage.EnterAcctInfo(Driver, Reporter, dynamicEmail,
                standardPassword,
                standardPassword);
            BeginOrderPage.EnterPhoneNumDetails(Driver, Reporter, newUserPH);
            BeginOrderPage.SelectShippingMethod(Driver, Reporter);
            BeginOrderPage.EnterSpecialComments(Driver, Reporter, "Testing");

            Step = "Clicking continue and verifying the error messages when mandatory checkboxes are not checked";
            BeginOrderPage.ClickContinue(Driver, Reporter);
            BeginOrderPage.VerifyTermsErrorMsg(Driver, Reporter);
            BeginOrderPage.VerifyAgeErrorMsg(Driver, Reporter);

            Step = "Selecting the required checkboxes and click continue button";
            BeginOrderPage.SelectTermsChkBox(Driver, Reporter);
            BeginOrderPage.SelectAgeChkBox(Driver, Reporter);
            BeginOrderPage.VerifyOffersChkBoxStatus(Driver, Reporter);
            BeginOrderPage.ClickContinue(Driver, Reporter);

            Step = "Verifying all the sections and buttons in EyeCareProvider Page";
            EyeCareProviderPage.AssertPageTitle(Driver, Reporter);
            EyeCareProviderPage.VerifyContactLenseSec(Driver, Reporter,
                TestData["PRODUCT"],
                TestData["RPOWER"],
                TestData["LPOWER"]);
            EyeCareProviderPage.VerifyPatientSecction(Driver, Reporter);
            EyeCareProviderPage.VerifyPrescriptionOptionWizard(Driver, Reporter);            
            EyeCareProviderPage.VerifyGoBackLink(Driver, Reporter);
            EyeCareProviderPage.VerifyContinueBtn(Driver, Reporter);

            Step = "Entering the patients details";
            EyeCareProviderPage.EnterPatientDetails(Driver, Reporter,
                TestData["PATIENTFNAME"],
                TestData["PATIENTMNAME"],
                TestData["PATIENTLNAME"],
                TestData["PATIENTMONTH"],
                TestData["PATIENTDAY"],
                TestData["PATIENTYEAR"]);

            Step = "Selecting state from 'Select a State' dropdown and select a state";
            EyeCareProviderPage.SelectState(Driver, Reporter, TestData["S_STATE"]);
            EyeCareProviderPage.SelectStore(Driver, Reporter, TestData["STORE"]);

            Step = "Clicking continue and verifying the club membership";
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);
            EyeCareClubpage.VerifyClubMembership(Driver, Reporter, true);
            EyeCareClubpage.SelectPatient(Driver, Reporter, TestData["PATIENTFNAME"]);
            EyeCareClubpage.ClickContiune(Driver, Reporter);

            Step = "Clicking continue and verifying the sections in Payment Page";
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.VerifyPaymentMethodSec(Driver, Reporter);
            PaymentPage.VerifyReOrderSec(Driver, Reporter);
            PaymentPage.VerifyRemindMe(Driver, Reporter);
            PaymentPage.VerifyCompleteOrder(Driver, Reporter);

            Step = "Entering payment details,billing address, special comments and selecting remind me freq";
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

