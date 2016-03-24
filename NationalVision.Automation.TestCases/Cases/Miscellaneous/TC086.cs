/* **********************************************************
 * Description : TC086.cs: Verify msg when Shopping Cart is empty, add featured product to Cart and verify 
 *                         the pricing information and verify Keep shopping and Add to cart buttons navigation
 *                             
 * Date :  17-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using NationalVision.Automation.Pages;


namespace NationalVision.Automation.Tests.Cases.Miscellaneous
{
    class TC086 : BaseCase
    {
        /// <summary>
        /// Description : TC086.cs: Verify msg when Shopping Cart is empty, add featured product to Cart and verify 
        ///             the pricing information and verify Keep shopping and Add to cart buttons navigation
        /// </summary>
        protected override void ExecuteTestCase()
        {
            // **** Assigning product value to local variable to use mulitple place in same class ****//
            string product = TestData["PRODUCT"];
            string rSphere = TestData["RPOWER"];
            string lSphere = TestData["LPOWER"];
            string rQty = TestData["RQTY"];
            string lQty = TestData["LQTY"];
            string rCYL = TestData["RCYL"];
            string lCYL = TestData["LCYL"];
            string rAxis = TestData["RAXIS"];
            string lAxis = TestData["LAXIS"];

            Reporter.Chapter.Title = "Verifying Shopping Cart, when no products added, add product from featured products, verify pricing details,Keep Shopping and Start CheckOut in Shopping Cart Page";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Verifying the message in ShoppingCart Page if there are no items added";
            string Items = ContactHomePage.CheckTotalItemsInCart(Driver, Reporter);
            ContactHomePage.ClickShoppingCart(Driver, Reporter);
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyCartEmptyMsg(Driver, Reporter, Items);

            Step = "Mouse Over on Contact Lenses and verifying the sub tabs";
            ShoppingCartPage.MouseOverHomePageTabs(Driver, Reporter, TestData["TABNAME"]);
            
            Step = "Selecting a brand, Clicking on a product, enter the prescription and click on Addto Cart button";
            ShoppingCartPage.ClickSubMenuLink(Driver, Reporter, TestData["SUB_LINKS"]);
            ContactLensShelfPage.ClickContactLenseProduct(Driver, Reporter, product);
            string regularPrice = ContactLensesProductDisplayPage.GetProductRegularPrice(Driver, Reporter);
            ContactLensesProductDisplayPage.SelectPrescriptionPower(Driver, Reporter,
                rSphere,
                lSphere);
            ContactLensesProductDisplayPage.SelectPrescriptionQuantity(Driver, Reporter,
                rQty,
                lQty);
            ContactLensesProductDisplayPage.SelectPrescriptionCylinder(Driver, Reporter,
                rCYL,
                lCYL);
            ContactLensesProductDisplayPage.SelectPrescriptionAxis(Driver, Reporter,
                rAxis,
                lAxis);
            ContactLensesProductDisplayPage.ClickAddToCart(Driver, Reporter);

            Step = "Verifying ContactLenses details, Edit, Remove and SubTotal in Shopping Cart Page";
            ShoppingCartPage.VerifyContactDetailsInShoppingCart(Driver, Reporter,
                product,
                TestData["RQTY"],
                regularPrice);
            ShoppingCartPage.VerifySphereValues(Driver, Reporter,
               product,
               rSphere,
               "R");
            ShoppingCartPage.VerifyCYLValues(Driver, Reporter,
               product,
               rCYL,
               "R");
            ShoppingCartPage.VerifyAxisValues(Driver, Reporter,
               product,
               rAxis,
               "R");
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "contactlens", product);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "contactlens", product);

            ShoppingCartPage.VerifyContactDetailsInShoppingCart(Driver, Reporter,
                product,
                TestData["LQTY"],
                regularPrice, 2);
            ShoppingCartPage.VerifySphereValues(Driver, Reporter,
               product,
               lSphere,
               "L");
            ShoppingCartPage.VerifyCYLValues(Driver, Reporter,
               product,
               lCYL,
               "L");
            ShoppingCartPage.VerifyAxisValues(Driver, Reporter,
               product,
               lAxis,
               "L");
            ShoppingCartPage.AssertEditProduct(Driver, Reporter, "contactlens", product,2);
            ShoppingCartPage.AssertRemoveProduct(Driver, Reporter, "contactlens", product,2);
            ShoppingCartPage.VerifySubTotal(Driver, Reporter);

            Step = "Verifying Keep Shopping,Add to Cart buttons and featured products";
            ShoppingCartPage.VerifyKeepShoppingButton(Driver, Reporter);
            ShoppingCartPage.VerifyStartCheckOutButton(Driver, Reporter);
            ShoppingCartPage.VerifyFeaturedProducts(Driver, Reporter);

            Step = "Clicking on a featured product and Adding to Cart";
            string featuredProd = ShoppingCartPage.ClickFeaturedProducts(Driver, Reporter, 2);
            EyeGlassesProductDisplayPage.ClickAddLensAndAddToCart(Driver, Reporter);

            Step = "Verifying the product is added to ShoppinCart Page";
            ContactHomePage.ClickShoppingCart(Driver, Reporter);
            ShoppingCartPage.AssertPageTitle(Driver, Reporter);
            ShoppingCartPage.VerifyFeaturedProd(Driver, Reporter, featuredProd);

            //Popup is displyed as the frames without Lenses added to Shopping Cart from Featured Products
            Step = "Clicking on Checkout and verifying AddLenses popup";
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);
            ShoppingCartPage.VerifyAddLensesPopUp(Driver, Reporter);

            #region THIS CODE COMMENTED FOR FUTURE USE
            //Commenting the below code as this is for future reference
            /*Step = "Click on Add Lenses and add the lenses and Click on Checkout";
            ShoppingCartPage.AddLensesInPopUp(Driver, Reporter);
            EyeGlassWizardPage.AssertPageTitle(Driver, Reporter);
            EyeGlassWizardPage.SelectPairs(Driver, Reporter, false);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectPatientAge(Driver, Reporter, true);
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectPatientInfoOption(Driver, Reporter, "browsing");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectLensPackage(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.SelectLensOptions(Driver, Reporter, "no");
            EyeGlassWizardPage.ClickNext(Driver, Reporter);
            EyeGlassWizardPage.ClickCheckOutButton(Driver, Reporter);

            Step = "Clicking on Start Checkout and Verifying all sections in BeginOrder page is present";
            ShoppingCartPage.ClickStartCheckOut(Driver, Reporter);
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

            Step = "Entering Account Information, PhoneNumber, Shipping Method and Special Comments";
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
            EyeCareProviderPage.VerifyPrescriptionOptionSection(Driver, Reporter);
            EyeCareProviderPage.VerifySelectStoreSection(Driver, Reporter);
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

            Step = "Clicking continue and verifying the sections in Payment Page";
            EyeCareProviderPage.ClickContinueBtn(Driver, Reporter);
            PaymentPage.AssertPageTitle(Driver, Reporter);
            PaymentPage.VerifyPaymentMethodSec(Driver, Reporter);
            PaymentPage.VerifyReOrderSec(Driver, Reporter);
            PaymentPage.VerifyRemindMe(Driver, Reporter);
            PaymentPage.VerifyCompleteOrder(Driver, Reporter);

            Step = "Entering payment details,billing address and special comments";
            PaymentPage.EnterPaymentDetails(Driver, Reporter,
               CCName,
               CCNumber,
               CCExpMonth,
               CCExpYear);
            PaymentPage.ChooseBillingAdd(Driver, Reporter);
            PaymentPage.EnterComments(Driver, Reporter, "testing");

            Step = "Clicking Complete Order and verifying details in order confirmation page";
            PaymentPage.ClickCompleteOrder(Driver, Reporter);
            OrderConfirmationPage.AssertPageTitle(Driver, Reporter);
            OrderConfirmationPage.VerifyThankYou(Driver, Reporter);
            OrderConfirmationPage.VerifyPrintReceipt(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderNumber(Driver, Reporter);
            OrderConfirmationPage.VerifyEstDelivery(Driver, Reporter);
            OrderConfirmationPage.VerifyOrderTotal(Driver, Reporter); */
            #endregion

        }
    }
}
