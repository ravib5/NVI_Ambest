/* *******************************************************
 * Description : ContactLensesProductDisplayPage.cs contains all the methods, objects related to ContactLensesProductDisplayPage
 *               like entering the prescription, clicking add to cart button         
 *               
 * Date : 08-Feb-2016
 * 
 * *******************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class ContactLensesProductDisplayPage : CommonPage
    {
        #region BELOW METHOD ARE USED FOR ENTER THE PRESCRIPTION VALUES IN CONTACT VALUES

        /// <summary>
        /// EnterPrescriptionPower method enter the lens Power in Contact lens Prescription details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightsphere">Enter the right sphere power</param>
        /// <param name="leftsphere">Enter the reft sphere power</param>
        public static void SelectPrescriptionPower(RemoteWebDriver driver, Iteration reporter,
            string rightSphere,
            string leftSphere)
        {
            reporter.Add(new Act("Select the Sphere value of ContactLense in Prescription Table"));
            Selenide.SetText(driver, Util.GetLocator("rightsphere_dd"), Selenide.ControlType.Select, rightSphere);
            Selenide.SetText(driver, Util.GetLocator("leftsphere_dd"), Selenide.ControlType.Select, leftSphere);
        }

        /// <summary>
        /// EnterPrescriptionQuantity method enter quantity details in Contact lens Prescription details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeQty">Enter right eye lens quantity</param>
        /// <param name="leftEyeQty">Enter left eye lens quantity</param>
        public static void SelectPrescriptionQuantity(RemoteWebDriver driver, Iteration reporter,
            string rightEyeQty, string leftEyeQty)
        {
            reporter.Add(new Act("Select the Quantity value of ContactLense in prescription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyeqty_dd"), Selenide.ControlType.Select, rightEyeQty);
            Selenide.SetText(driver, Util.GetLocator("lefteyeqty_dd"), Selenide.ControlType.Select, leftEyeQty);
        }

        /// <summary>
        /// SelectPrescriptionColor mehtod select color contact lens in Prescription Details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeColor">Enter the Color of right eye contact lens wish to select</param>
        /// <param name="leftEyeColor">Enter the color of left eye contact lens wish to select</param>
        public static void SelectPrescriptionColor(RemoteWebDriver driver, Iteration reporter,
            string rightEyeColor,
            string leftEyeColor)
        {
            reporter.Add(new Act("Select the Color of contact lense in precscription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyecolor_dd"), Selenide.ControlType.Select, rightEyeColor);
            Selenide.SetText(driver, Util.GetLocator("lefteyecolor_dd"), Selenide.ControlType.Select, leftEyeColor);
        }

        /// <summary>
        /// SelectPrescriptionBaseCurve method select BC value of Contact lens in Prescription Details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeBC">Select the BC value of right eye</param>
        /// <param name="leftEyeBC">Select the BC value of left eye</param>
        public static void SelectPrescriptionBaseCurve(RemoteWebDriver driver, Iteration reporter,
            string rightEyeBC, string leftEyeBC)
        {
            reporter.Add(new Act("Select the Base Curve value of ContactLense In precription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyebasecurve_dd"), Selenide.ControlType.Select, rightEyeBC);
            Selenide.SetText(driver, Util.GetLocator("lefteyebasecurve_dd"), Selenide.ControlType.Select, leftEyeBC);
        }

        /// <summary>
        /// EnterPrescriptionBaseCurve method is used to enter BC value of Contact lens in Prescription Details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeBC">Enter the BC value of rightEye</param>
        /// <param name="leftEyeBC">Enter the BC value of leftEye</param>
        public static void EnterPrescriptionBaseCurve(RemoteWebDriver driver, Iteration reporter,
          string rightEyeBC, string leftEyeBC)
        {
            reporter.Add(new Act("Select the Base Curve value of ContactLense In precription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyebasecurve_dd"), Selenide.ControlType.Textbox, rightEyeBC);
            Selenide.SetText(driver, Util.GetLocator("lefteyebasecurve_dd"), Selenide.ControlType.Textbox, leftEyeBC);
        }

        /// <summary>
        /// SelectPrescriptionAddPower method select BC value of Contact lens in Prescription Details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightAddPower">Enter the AddPower value of right eye</param>
        /// <param name="leftAddPower">Enter the AddPower value of left eye</param>
        public static void SelectPrescriptionAddPower(RemoteWebDriver driver, Iteration reporter,
            string rightAddPower, string leftAddPower)
        {
            reporter.Add(new Act("Select the AddPower value of ContactLense In precription table"));
            Selenide.SetText(driver, Util.GetLocator("leftaddpower_dd"), Selenide.ControlType.Select, rightAddPower);
            Selenide.SetText(driver, Util.GetLocator("rightaddpower_dd"), Selenide.ControlType.Select, leftAddPower);
        }

        /// <summary>
        /// SelectPrescriptionAxis method select axis value of contact lens
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeAxis">right eye axis value</param>
        /// <param name="leftEyeAxis">left eye axis value</param>
        public static void SelectPrescriptionAxis(RemoteWebDriver driver, Iteration reporter,
            string rightEyeAxis,
            string leftEyeAxis)
        {
            reporter.Add(new Act("Select the Axis value of ContactLense In precription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyeaxis_dd"), Selenide.ControlType.Select, rightEyeAxis);
            Selenide.SetText(driver, Util.GetLocator("lefteyeaxis_dd"), Selenide.ControlType.Select, leftEyeAxis);
        }

        /// <summary>
        /// SelectPrescriptionCylinder method select Cylinder value in prescription value
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeCylinder">Right eye cylider value</param>
        /// <param name="leftEyeCylinder">Left eye cylinder value</param>
        public static void SelectPrescriptionCylinder(RemoteWebDriver driver, Iteration reporter,
            string rightEyeCylinder,
            string leftEyeCylinders)
        {
            reporter.Add(new Act("Select the Axis value of Contact lens In precription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyecylinder_dd"), Selenide.ControlType.Select, rightEyeCylinder);
            Selenide.SetText(driver, Util.GetLocator("lefteyecylinder_dd"), Selenide.ControlType.Select, leftEyeCylinders);
        }


        /// <summary>
        ///VerifyPopUp method is used to verify whether the pop up is present when the BC/Color values are different for RightEye and LeftEye 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="right">Value of BC/Color which user is selected, generally comes from TestData</param>
        /// <param name="left">Value of BC/Color which user is selected, generally comes from TestData</param>
        /// <param name="Expmessage">Expected message on alert</param>
        public static void VerifyAlertandAccept(RemoteWebDriver driver, Iteration reporter,
            string right,
            string left,
            string Expmessage)
        {
            reporter.Add(new Act("Verifying alert message and accept alert"));
            // *** Below condition check for right and left eye value.
            // If right, left eye values are different, application should display alert message
            if (!right.Equals(left))
            {
                Selenide.Wait(driver, 0.3, true); // Sleep 0.3 is manditory to display the alert by the application

                // ** For PhantomJS switchTo.alert() not support. Just accept method
                if (driver.Capabilities.BrowserName.ToUpper().Equals("PHANTOMJS"))
                {
                    Selenide.JS.AcceptAlert(driver);
                    ClickAddToCart(driver, reporter);
                }

                else
                {
                    string alertMessage = Selenide.SwitchToAlertandGetAlertText(driver);
                    if (alertMessage.Trim().ToLower().Equals(Expmessage.ToLower()))
                        Selenide.AcceptorDismissAlert(driver);
                    else
                    {
                        //@@ TODO this action need to check with Eli; IF expected alert not appear
                        Selenide.AcceptorDismissAlert(driver, false);
                    }
                }
            }
        }
        /// <summary>
        /// SelectPrescriptionDiameter method is used to select Diameter in prescription table
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeDIA">Right Eye Diameter value</param>
        /// <param name="leftEyeDIA">Left Eye Diameter value</param>
        public static void SelectPrescriptionDiameter(RemoteWebDriver driver, Iteration reporter,
           string rightEyeDIA,
           string leftEyeDIA)
        {
            reporter.Add(new Act("Select the Axis value of Contact lens In precription table"));
            Selenide.SetText(driver, Util.GetLocator("righteyedia_dd"), Selenide.ControlType.Select, rightEyeDIA);
            Selenide.SetText(driver, Util.GetLocator("lefteyedia_dd"), Selenide.ControlType.Select, leftEyeDIA);
        }

        /// <summary>
        /// VerifyColorAlertMessage method verifying alert message on Color and accepts/Dismiss the alert
        /// This method only for contact lens Color alert message assertion
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyColorAlertMessage(RemoteWebDriver driver, Iteration reporter)
        {
            //*** Get select the values from right & left eye in the prescription 
            string rEye = Selenide.GetText(driver, Util.GetLocator("righteyecolor_dd"), Selenide.ControlType.Select);
            string lEye = Selenide.GetText(driver, Util.GetLocator("lefteyecolor_dd"), Selenide.ControlType.Select);

            // *** Store above varibale values before hit the shooping cart button ***//
            ClickAddToCart(driver, reporter);

            /* 3rd parameter value alert display message hard coded because is standard to color.*/
            VerifyAlertandAccept(driver, reporter, rEye, lEye,
                @"Different color values were selected. Click 'OK' to continue or 'Cancel' to change the color values.");
        }


        /// <summary>
        /// VerifyBaseCurveAlertMessage method verifying alert messgae for base-curve and accepts/Dismiss the alert
        /// This method sepecific to the contact lens base curve alert message
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyBaseCurveAlertMessage(RemoteWebDriver driver, Iteration reporter)
        {
            //*** Get select the values from right & left eye in the prescription 
            string rEye = Selenide.GetText(driver, Util.GetLocator("righteyebasecurve_dd"), Selenide.ControlType.Select);
            string lEye = Selenide.GetText(driver, Util.GetLocator("lefteyebasecurve_dd"), Selenide.ControlType.Select);

            // *** Store above varibale values before hit the shooping cart button ***//
            ClickAddToCart(driver, reporter);

            /* 3rd paramerter hord coded because it standard for BC alert message*/
            VerifyAlertandAccept(driver, reporter, rEye, lEye,
                @"It is unusual to have a prescription for two different Base Curves (BC). Please check your prescription and correct if necessary. Click 'OK' to continue or 'Cancel' to change the Base Curve (BC) parameter.");
        }

        #endregion

        /// <summary>
        /// ClickAddToCart method click on Add-to-cart button on ProductDetails Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickAddToCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on add to cart button"));
            Selenide.Click(driver, Util.GetLocator("addtocart_btn"));
        }

        /// <summary>
        /// AssertAddToCart method verify 'add to cart' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddToCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert add-to-cart button on Product details page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("addtocart_btn"));
        }

        #region BELOW METHOD ARE USED FOR ASSERT PRODUCT DETAILS

        /// <summary>
        /// ProductPageDetails method is to verify all product deatils
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ProductPageDetails(RemoteWebDriver driver, Iteration reporter,
            string pName)
        {
            VerifyProductName(driver, reporter, pName);
            AssertProductImage(driver, reporter);
            AssertImageZoomandDesc(driver, reporter);
            AssertandGetBestValuePrice(driver, reporter);
            AssertandGetRegularPrice(driver, reporter);
            AssertandGetDiscountPrice(driver, reporter);
            AssertClubMemberPrice(driver, reporter);
            AssertFlexLink(driver, reporter);
            /* Below method commented because for some prodcucts not showing stockInfo. 
            //AssertStockInfo(driver, reporter);  */
            AssertPrescriptionTable(driver, reporter);
            AssertPrescriptionHelp(driver, reporter);
            AssertAddToCart(driver, reporter);
        }

        /// <summary>
        /// VerifyProductName method verify name of the prodct display correct or not
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName"></param>
        public static void VerifyProductName(RemoteWebDriver driver, Iteration reporter, string productName)
        {
            reporter.Add(new Act(string.Format("Verifing Name : '{0}' on product details page", productName)));
            string actText = Selenide.GetText(driver, Locator.Get(LocatorType.XPath, "//section/div/h1"), Selenide.ControlType.Label);

            if (!actText.ToLower().Equals(productName.ToLower()))
            {
                throw new Exception(string.Format("Product name not match, Expected : {0} ; Actual : {1}", productName, actText));
            }
        }

        /// <summary>
        /// AssertProductImage method verify the image displays on Product Display page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertProductImage(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert product Image presence in Product details page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("productimage_img"));
        }

        /// <summary>
        /// AssertImageZoomandDesc method verify the Zoom icon displays on Product Display page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertImageZoomandDesc(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert zoom icon presence in Product details page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("zoomanddescri_icon"));
        }

        /// <summary>
        /// ClickImageZoomandDesc click on zoom icon to open product zoom and description pop-up
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickImageZoomandDesc(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("click on zoom in Product details page"));
            Selenide.Click(driver, Util.GetLocator("zoomanddescri_icon"));
        }

        /// <summary>
        /// AssertandGetBestValuePrice method verify best value price of the product and Get Bestvalue
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertandGetBestValuePrice(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert best value price of the displayed product"));
            if (Selenide.VerifyVisible(driver, Util.GetLocator("bestvalue_price_lab")))
            {
                reporter.Add(new Act(string.Format("Best Value : {0}",
                  Selenide.GetText(driver, Util.GetLocator("bestvalue_price_lab"), Selenide.ControlType.Label))));
            }
        }

        /// <summary>
        /// AssertandGetRegularPrice method verify regular price presence and get the regular price
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertandGetRegularPrice(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert regular price of product"));
            if (Selenide.VerifyVisible(driver, Util.GetLocator("regularprice_lab")))
            {
                reporter.Add(new Act(string.Format("Regular Price  : {0}",
                  Selenide.GetText(driver, Util.GetLocator("regularprice_lab"), Selenide.ControlType.Label))));
            }
        }

        /// <summary>
        /// AssertandGetRegularPrice method verify regular price presence and get the regular price
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static string GetProductRegularPrice(RemoteWebDriver driver, Iteration reporter)
        {
            string acuText = Selenide.GetText(driver, Util.GetLocator("regularprice_lab"), Selenide.ControlType.Label);

            string[] getPricePerBox = acuText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            string[] regularPrice = getPricePerBox[1].Split(new Char[] { '$', '/' }, StringSplitOptions.RemoveEmptyEntries);
            return regularPrice[0];
        }

        /// <summary>
        /// AssertandGetDiscountPrice method verify discount price of the product and get the discount price
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertandGetDiscountPrice(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert discount price of product"));
            if (Selenide.VerifyVisible(driver, Util.GetLocator("discountedprice_lab")))
            {
                reporter.Add(new Act(string.Format("Discount Price  : {0}",
                  Selenide.GetText(driver, Util.GetLocator("discountedprice_lab"), Selenide.ControlType.Label))));
            }
        }

        /// <summary>
        /// AssertClubMemberPrice method verify club member price of the product
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertClubMemberPrice(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert discount price of product"));
            Selenide.VerifyVisible(driver, Util.GetLocator("clubmemberprice_lab"));
        }

        /// <summary>
        /// AssertFlexLink method assert Flex link presence in Product display page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertFlexLink(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert 'Flex Spending Eligible' link presence in Product Display page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("flexspendingeligibility_lnk"));
        }

        /// <summary>
        /// ClickFlexLink method click on FSA link
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickFlexLink(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click 'Flex Spending Eligible FSA' link it display FSA pop-up"));
            Selenide.Click(driver, Util.GetLocator("flexspendingeligibility_lnk"));
        }

        /// <summary>
        /// AssertStockInfo method verify stock info and delivery information product displaypage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertStockInfo(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert In- stock and Product delivery information"));
            Selenide.VerifyVisible(driver, Util.GetLocator("instockinfo_lab"));
        }

        /// <summary>
        /// AssertPrescriptionTable method verify Priscription table to presence in Product details page to enter the Prescription.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPrescriptionTable(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert Priscription table in Product details page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("lensprescription_tbl"));
        }

        /// <summary>
        /// AssertPrescriptionHelp method verify Priscription-Help link to presence in Product details page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPrescriptionHelp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert Priscription-help link below the prescription table"));
            Selenide.VerifyVisible(driver, Util.GetLocator("prescriptionhelp_lnk"));
        }

        /// <summary>
        /// ClickPrescriptionHelp method click Prescriptiop-Help link to open Prescription Pop-up
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickPrescriptionHelp(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Priscription Help link"));
            Selenide.Click(driver, Util.GetLocator("prescriptionhelp_lnk"));
        }

        #endregion


        #region BELOW ALL METHODS ARE RELATED TO CLUB MEMBERSHIP SELECTIONS

        /// <summary>
        /// VerifyNoMemberShip method is used to verify if No membership radio button is selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyNoMemberShip(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("nomembership_rb")))
                reporter.Add(new Act("'No, I do not wish to join the Eyecare Club' is selected"));
        }

        /// <summary>
        /// SelectAlreadyMember method is used to select I am already Member radio
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void SelectAlreadyMember(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Select 'I am already an EyeCare Member' radio"));
            Selenide.Click(driver, Util.GetLocator("alreadymember_rb"));
        }

        /// <summary>
        /// VerifyAlreadyMember method is used to verify if 'I am alreadyan EyeCare Member' is selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyAlreadyMember(RemoteWebDriver driver, Iteration reporter)
        {
            if (Selenide.GetCheckedStatus(driver, Util.GetLocator("alreadymember_rb")))
                reporter.Add(new Act("'I am already an EyeCare Member' is selected"));
        }

        /// <summary>
        /// SelectNewMembership method select Club membership options (New, renew)
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="three_years">TRUE: 3 years; FALSE: 5 years</param>
        /// <param name="isNewMember">TRUE: NEW MEMBERSHIP; FALSE: RENEW OLD MEMBERSHIP</param>
        public static void SelectMembershipOptions(RemoteWebDriver driver, Iteration reporter,
            bool three_years = true,
            bool isNewMember = true)
        {
            // *** idCode value used for findelement on memberships, otherwise to difficult to Identify the elements
            // *** only idCode changes differ for the membership radio buttons
            string idCode = null;

            if (isNewMember)
            {
                if (!three_years)
                {
                    idCode = "18247";
                    reporter.Add(new Act("Selected 'Yes, sign me up for a 5 year membership for $139.00'"));
                    Selenide.Click(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode)));
                }
                else
                {
                    idCode = "18246";
                    reporter.Add(new Act("Selected 'Yes, sign me up for a 3 year membership for $99.00'"));
                    Selenide.Click(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode)));
                }
            }
            else
            {
                if (!three_years)
                {
                    idCode = "18251";
                    reporter.Add(new Act("Selected 'Yes, renew my 5 year membership for $139.00'"));
                    Selenide.Click(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode)));
                }
                else
                {
                    idCode = "18250";
                    reporter.Add(new Act("Selected 'Yes, renew my 3 year membership for $99.00'"));
                    Selenide.Click(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode)));
                }
            }
        }

        /// <summary>
        /// VerifyNewMemberShip method verify user opted membership selected or not
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="three_years">TRUE: 3 years; FALSE: 5 years</param>
        /// <param name="isNewMember">TRUE: NEW MEMBERSHIP; FALSE: RENEW OLD MEMBERSHIP</param>
        public static void VerifyIsClubMemberShipSelected(RemoteWebDriver driver, Iteration reporter,
            bool three_years = true,
            bool isNewMember = true)
        {
            // *** idCode value used for findelement on memberships, otherwise to difficult to Identify the elements
            // *** only idCode changes differ for the membership radio buttons
            string idCode = null;
            if (isNewMember)
            {
                if (!three_years)
                {
                    idCode = "18247";
                    reporter.Add(new Act("Verifing 5 year membership selected"));
                    if (!Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode))))
                    {
                        reporter.Chapter.Step.Action.IsSuccess = false;
                        throw new Exception("New 5 year membership not selected");
                    }
                }
                else
                {
                    idCode = "18246";
                    reporter.Add(new Act("Verifing new 3 year membership selected"));
                    if (!Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode))))
                    {
                        reporter.Chapter.Step.Action.IsSuccess = false;
                        throw new Exception("New 3 year membership not selected");
                    }
                }
            }
            else
            {
                if (!three_years)
                {
                    idCode = "18251";
                    reporter.Add(new Act("Verifing renew 5 year membership Selected"));
                    if (!Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode))))
                    {
                        reporter.Chapter.Step.Action.IsSuccess = false;
                        throw new Exception("Renew 5 year membership not selected");
                    }
                }
                else
                {
                    idCode = "18250";
                    reporter.Add(new Act("Verifing renew 3 year membership selected"));
                    if (!Selenide.GetCheckedStatus(driver, Locator.Get(LocatorType.ID, string.Format("addaccessory{0}", idCode))))
                    {
                        reporter.Chapter.Step.Action.IsSuccess = false;
                        throw new Exception("Renew 3 year membership not selected");
                    }
                }
            }
        }

        /// <summary>
        /// GetClubMemberShipPrice method retrive the membership price and return that price value as sting
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="three_years">TRUE: 3 years; FALSE: 5 years</param>
        /// <param name="isNewMember">TRUE: NEW MEMBERSHIP; FALSE: RENEW OLD MEMBERSHIP</param>
        /// <returns>returns membership price value</returns>
        public static string GetClubMemberShipPrice(RemoteWebDriver driver, Iteration reporter,
            bool three_years = true,
            bool isNewMember = true)
        {
            // *** memberDetails string variable changes in the membership label it helps use to identify the object on the page
            string memberDetails = null;
            string memberShipPriceText = null;

            if (isNewMember)
            {
                if (three_years)
                {
                    memberDetails = "Yes, sign me up for a 3 year";
                }
                else
                {
                    memberDetails = "Yes, sign me up for a 5 year";
                }
            }
            else
            {
                if (three_years)
                {
                    memberDetails = "Yes, renew my 3 year";
                }
                else
                {
                    memberDetails = "Yes, renew my 5 year";
                }
            }

            reporter.Add(new Act("Retriving the membership price"));
            memberShipPriceText = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//label[starts-with(@for,'addaccessory') and contains(text(),'{0}')]", memberDetails)),
                Selenide.ControlType.Label);

            string[] memberShipPrice = memberShipPriceText.Split('$');

            return memberShipPrice[1].Trim();
        }
        #endregion
    }
}
