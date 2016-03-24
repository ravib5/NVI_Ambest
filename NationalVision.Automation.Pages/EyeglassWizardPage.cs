/* **********************************************************
 * Description : EyeGlassWizardPage.cs contains the methods related to EyeglassWizardPage
 *                 like choosing a second pair
 *              
 * Date :  09-Feb-2015
 * 
 * **********************************************************
 */
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    public class EyeGlassWizardPage : CommonPage
    {
        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Eyeglass Lens Configuration Wizard";
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// SelectParis select 2 Pair or 1 pair option on Eyeglass wizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="isPaired">isPaired default=false means select only 1 pair</param>
        public static void SelectPairs(RemoteWebDriver driver, Iteration reporter, bool isPaired = false)
        {
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath, "//div[@class='option-item__container']/h3"));

            if (isPaired)
            {
                reporter.Add(new Act("choose 2 Pair option"));
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='option-item__container']/h3[normalize-space()='Yes, I want to save money by choosing a 2nd pair']"));

                //  *** If user select 2nd pair then click on Next, it will redirect to EyeGlassWizardTwoPairOrderPage.cs class 
            }
            else
            {
                reporter.Add(new Act("Select only 1 Pair"));
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='option-item__container']/h3[normalize-space()='No, I only want to buy 1 pair']"));
            }
        }

        /// <summary>
        /// ClickNext method click on Next button in EyeGlassWizard
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickNext(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Next button in EyeGlassWizard page"));
            Selenide.WaitForElementClickble(driver, Util.GetLocator("next_btn"));
            Selenide.Click(driver, Util.GetLocator("next_btn"));
            Selenide.Wait(driver, 1, true);
        }

        /// <summary>
        /// SelectPatientAge method select whether patient age is 13 or youger / over 13.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="over_13">Default=true means patient is over 13 age, else over_13=false</param>
        public static void SelectPatientAge(RemoteWebDriver driver, Iteration reporter,
            bool over_13 = true)
        {
            if (!over_13)
            {
                reporter.Add(new Act("Select Patient age is 13 or younger'"));
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='option-item__container']/h3[normalize-space()='Patient is 13 or younger']"));
                VerifyPopup(driver, reporter);
            }
            else
            {
                reporter.Add(new Act("Select Patient age is over 13"));
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='option-item__container']/h3[normalize-space()='Patient is over 13']"));


            }
        }

        /// <summary>
        /// VerifyPopup method is to verify the pop-up message when user select age 13 or youger 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPopup(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("pop up displayed successfully"));
            Selenide.VerifyVisible(driver, Util.GetLocator("childrenpopup_lab"));
        }

        #region PATIENT INFORMATION

        /// <summary>
        /// CheckPatientInfoOption verify all the Patient Prescription Options in EyeglassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckPatientInfoOption(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyPatientInfoOption(driver, reporter, "browsing");
            VerifyPatientInfoOption(driver, reporter, "donotknow");
            VerifyPatientInfoOption(driver, reporter, "know");
        }

        /// <summary>
        /// VerifyPatientInfoOption method verifies the different options in Patient Information Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">browsing; donotknow; know</param>
        public static void VerifyPatientInfoOption(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "browsing":
                    option_title = "Just Browsing";
                    break;
                case "donotknow":
                    option_title = "I don't know the patient's prescription";
                    break;
                case "know":
                    option_title = "I know the patient's prescription";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Verifying Patinent Information Option '{0}' at step-2  EyeglassWizard Page", option_title)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }

        /// <summary>
        /// SelectPatientInfoOption method select (check box) options in Patient Information Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">browsing; donotknow; know</param>
        public static void SelectPatientInfoOption(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "browsing":
                    option_title = "Just Browsing";
                    break;
                case "donotknow":
                    option_title = "I don't know the patient's prescription";
                    break;
                case "know":
                    option_title = "I know the patient's prescription";
                    break;
            }
            reporter.Add(new Act(string.Format("Selected (checked) Option '{0}' at Patinent Information step-2 on EyeglassWizard Page", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(), ""{0}"")]", option_title)));
        }
        #endregion

        #region LENS PACKAGES

        /// <summary>
        /// CheckLensPackage verify Lens Packages in EyeGlasseswizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckLensPackage(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyLensPackage(driver, reporter, "no");
            VerifyLensPackage(driver, reporter, "basic");
            VerifyLensPackage(driver, reporter, "verilite");
        }

        /// <summary>
        /// SelectLensPackage method select (check) Lens Packages in step-3; EyeGlassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, basic, verilite</param>
        public static void SelectLensPackage(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Package";
                    break;
                case "basic":
                    option_title = "Basic Package";
                    break;
                case "verilite":
                    option_title = "Verilite Package";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Selected (checked) option '{0}' at lens packages step-3 on the EyeglassWizard Page", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }

        /// <summary>
        /// VerifyLensPackage method verify available Lens Packages in step-3; EyeGlassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, basic, verilite</param>
        public static void VerifyLensPackage(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Package";
                    break;
                case "basic":
                    option_title = "Basic Package";
                    break;
                case "verilite":
                    option_title = "Verilite Package";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Verifing option '{0}' at lens packages step-3 on the EyeglassWizard Page", option_title)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }

        #endregion

        #region LENS OPTIONS

        /// <summary>
        /// CheckLensOptions method LensOptions in EyeGlassesWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckLensOptions(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyLensOptions(driver, reporter, "no");
            VerifyLensOptions(driver, reporter, "scratch");
            VerifyLensOptions(driver, reporter, "basic");
        }

        /// <summary>
        /// SelectLensOptions method select (check) available Lens options in step-4 EyeGlassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, scratch, basic</param>
        public static void SelectLensOptions(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Package Uncoated";
                    break;
                case "scratch":
                    option_title = "Scratch Resistant Lens Coating";
                    break;
                case "basic":
                    option_title = "Basic Package";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Selected (checked) option '{0}' at lens options step-4 on EyeglassWizard Page", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }

        /// <summary>
        /// VerifyLensPackage method verify available Lens Options in step-4 EyeGlassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, scratch, basic</param>
        public static void VerifyLensOptions(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Package Uncoated";
                    break;
                case "scratch":
                    option_title = "Scratch Resistant Lens Coating";
                    break;
                case "basic":
                    option_title = "Basic Package";
                    break;
            }
            reporter.Add(new Act(string.Format("Verifing option '{0}' at lens options step-4 on the EyeglassWizard Page", option_title)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(), ""{0}"")]", option_title)));
        }

        #endregion

        #region LENS TINT OPTIONS

        /// <summary>
        /// CheckLensTintOptions method verify Tint Options on EyeGlassesWizard Pages
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckLensTintOptions(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyLensTintOptions(driver, reporter, "no");
            VerifyLensTintOptions(driver, reporter, "fashion");
            VerifyLensTintOptions(driver, reporter, "sunglass");
        }
        /// <summary>
        /// CheckVeriliteLensTintOptions method verify Verilite Tint Options on EyeGlassesWizard Pages
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckVeriliteLensTintOptions(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyLensTintOptions(driver, reporter, "no");
            VerifyLensTintOptions(driver, reporter, "fashion");
        }

        /// <summary>
        /// SelectLensTintOptions method select (check) Lens Tint options like (No, Fashion, Sunglass) at Step-5
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, fashion, sunglass</param>
        public static void SelectLensTintOptions(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Tint";
                    break;
                case "fashion":
                    option_title = "Fashion Tint";
                    break;
                case "sunglass":
                    option_title = "Sunglass Tint";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Selected (checked) option '{0}' at lens Tint step-5 on the EyeglassWizard Page", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }

        /// <summary>
        /// VerifyLensTintOptions method verify available Lens Tint Options (No, Fashion, Sunglass) at step-5 EyeGlassWizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="option">no, fashion, sunglass</param>
        public static void VerifyLensTintOptions(RemoteWebDriver driver,
            Iteration reporter,
            string option)
        {
            string option_title = null;

            switch (option.ToLower())
            {
                case "no":
                    option_title = "No Tint";
                    break;
                case "fashion":
                    option_title = "Fashion Tint";
                    break;
                case "sunglass":
                    option_title = "Sunglass Tint";
                    break;
            }
            reporter.Add(new Act(string.Format(@"Verifing option '{0}' at lens packages step-5 on the EyeglassWizard Page", option_title)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(),""{0}"")]", option_title)));
        }
        #endregion

        #region ANTI-REFLECTIVE

        /// <summary>
        /// CheckAntiReflectiveOption check anti-reflect options on eyeglasswizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void CheckAntiReflectiveOption(RemoteWebDriver driver,
            Iteration reporter)
        {
            VerifyAntiReflectiveOption(driver, reporter);
            VerifyAntiReflectiveOption(driver, reporter, false);
        }

        /// <summary>
        /// SelectAntiReflectOptions method select Anti-Reflective at step-6 in EyeGlasswizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="anti_refelct">Defult: TRUE if user want add Anti-Reflective; False: No Anti-Reflective</param>
        public static void SelectAntiReflectiveOption(RemoteWebDriver driver,
            Iteration reporter,
            bool anti_refelct = true)
        {
            string option_title = null;

            if (!anti_refelct)
            {
                option_title = "No A/R";
            }
            else
            {
                option_title = "Add A/R";
            }
            reporter.Add(new Act(string.Format("Selected (checked) Anti-Reflective: '{0}' step-6 on the EyeglassWizard Page", option_title)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(), ""{0}"")]", option_title)));
        }

        /// <summary>
        /// VerifyAntiReflectiveOption method verify Anti-Reflective (yes/ no) options step-6 in eyeglasswizard page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="anti_refelct">Defult: TRUE if user want add Anti-Reflective; False: No Anti-Reflective</param>
        public static void VerifyAntiReflectiveOption(RemoteWebDriver driver,
            Iteration reporter,
            bool anti_refelct = true)
        {
            string option_title = null;
            if (!anti_refelct)
            {
                option_title = "No A/R";
            }
            else
            {
                option_title = "Add A/R";
            }
            reporter.Add(new Act(string.Format(@"Verifing Anti-Reflective: '{0}' step-6 on eyeglasswizard page", option_title)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//h3[starts-with(@class, 'option-item__title') and contains(text(), ""{0}"")]", option_title)));
        }

        /// <summary>
        /// VerifySubTintOption method is used to verify whether the SubTint options displayed when FashionTint or SunGlassTint is selected
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySubTintOption(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Sub Tint Options is present"));
            Selenide.VerifyVisible(driver, Util.GetLocator("subtintoptions_sec"));
        }

        #endregion

        #region BELOW METHOD ARE RELATED SUMMARY PAGE. PAGE BEFORE CHECKOUT; IT DISPLAY PRODUCT DETAILS ALONG WITH OPTION SELECTED FOR EYE GLASSES
        /// <summary>
        /// AssertReviewYourSelection method assert Review Your Selection page after user selects the NoPackageUhncoated Option.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="textToAssert">Enter the string 'page header' wish to assert</param>
        public static void AssertPageHeading(RemoteWebDriver driver, Iteration reporter,
            string textToAssert)
        {
            reporter.Add(new Act("Assert page heading: " + textToAssert));
            string actualText = Selenide.GetText(driver, Util.GetLocator("reviewyourselection_lab"), Selenide.ControlType.Label);

            if (!textToAssert.Equals(actualText))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(String.Format(
                    "Expected Label not appears in EyeGlassesWizard Page, Expected: {0}, Actual: {1}", textToAssert, actualText));
            }
        }

        /// <summary>
        /// VerifyAntiReflectiveForFrame method is to verify for which frame 'Anti-Reflective Coating option' is displayed
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="frame">Options : Frame 1, Frame 2 default:Frame 1</param>
        public static void VerifyAntiReflectiveForFrame(RemoteWebDriver driver, Iteration reporter,
            string frame = "Frame 1")
        {
            reporter.Add(new Act("Assert 'AntiReflective Coating'For Frame :" + frame));
            string actualFrame = Selenide.GetText(driver, Util.GetLocator("arforframe_lbl"), Selenide.ControlType.Label);
            string[] actualFrameSplit = actualFrame.ToString().Split(new char[] { '(', ')' });
            if (!frame.Equals(actualFrameSplit[1]))
            {
                reporter.Chapter.Step.Action.IsSuccess = false;
                throw new Exception(String.Format(
                    "Add an 'AntiReflective Coating' is Expected for: {0}, Actual: {1}", frame, actualFrameSplit[1]));
            }
        }
        
        /// <summary>
        /// VerifyPrintToStore method verify the Print to Store Button in Review Your Selections page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyPrintToStore(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Print To Store button in the Review Your Selections page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("printtostore_btn"));
        }

        /// <summary>
        /// VerifyBackButton method verify the Back Button in Review Your Selections page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyBackButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Back button in the Review Your Selections page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("back_btn"));
        }

        /// <summary>
        /// ClickBackButton method verify the Back Button in Review Your Selections page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickBackButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click Back button in the Review Your Selections page"));
            Selenide.Click(driver, Util.GetLocator("back_btn"));
        }

        /// <summary>
        /// VerifyCheckOutButton method verify the CheckOut Button in Review Your Selections page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyCheckOutButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify CheckOut button in the Review Your Selections page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("checkout_btn"));
        }

        /// <summary>
        /// VerifyReviewProductName method compare the selected product name displaying on the Review Your Selections page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name wish to verify on Review Your Selections page</param>
        public static void VerifyReviewProductName(RemoteWebDriver driver, Iteration reporter,
            string pName,
            int position = 1)
        {
            reporter.Add(new Act("Verify the product name on Review Your Selections"));

            string actuName = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                    string.Format("//ul[@class='summary-page__list']/li[{0}]/descendant::span[@class='summary-item__name ng-binding']", position)), Selenide.ControlType.Label);

            if (!pName.Equals(actuName))
                throw new Exception(string.Format("Product name not match, Expected : {0} <br> Actual : {1}", pName, actuName));
        }

        /// <summary>
        /// ClickCheckOutButton method Click the CheckOut Button in Review Your Selections page
        /// CheckOut will redirect to ShoppingCart Page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickCheckOutButton(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click CheckOut button in the Review Your Selections page"));
            Selenide.Click(driver, Util.GetLocator("checkout_btn"));

            Selenide.WaitForAjax(driver);
            // *** OnClick CheckOut will redirect to ShoppingCart Page.  ***//
        }
        #endregion

        #region BELOW METHOD ARE USED FOR ENTER THE PRESCRIPTION VALUES IN EyeGlasses VALUES

        /// <summary>
        /// EnterEyePrescriptionPower method enter the EyeGlasses Power in EyeGlass Prescription details
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightsphere">Enter the right sphere power</param>
        /// <param name="leftsphere">Enter the reft sphere power</param>
        public static void SelectEyePrescriptionPower(RemoteWebDriver driver, Iteration reporter,
            string rightSphere,
            string leftSphere)
        {
            reporter.Add(new Act("Select the Sphere value of EyeGlasses in Prescription Table"));
            Selenide.SetText(driver, Util.GetLocator("eyerightsphere_dd"), Selenide.ControlType.Select, rightSphere);
            Selenide.SetText(driver, Util.GetLocator("eyeleftsphere_dd"), Selenide.ControlType.Select, leftSphere);
        }

        /// <summary>
        /// SelectEyePrescriptionCylinder method select Cylinder value in prescription value
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeCylinder">Right eye cylider value</param>
        /// <param name="leftEyeCylinder">Left eye cylinder value</param>
        public static void SelectEyePrescriptionCylinder(RemoteWebDriver driver, Iteration reporter,
            string rightEyeCylinder,
            string leftEyeCylinder)
        {
            reporter.Add(new Act("Select the Cylinder value of EyeGlasses in precription table"));
            Selenide.SetText(driver, Util.GetLocator("eyerightcylinder_dd"), Selenide.ControlType.Select, rightEyeCylinder);
            Selenide.SetText(driver, Util.GetLocator("eyeleftcylinder_dd"), Selenide.ControlType.Select, leftEyeCylinder);
        }

        /// <summary>
        /// SelectEyePrescriptionAxis method select axis value of EyeGlasses
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="rightEyeAxis">right eye axis value</param>
        /// <param name="leftEyeAxis">left eye axis value</param>
        public static void SelectEyePrescriptionAxis(RemoteWebDriver driver, Iteration reporter,
            string rightEyeAxis,
            string leftEyeAxis)
        {
            reporter.Add(new Act("Select the Axis value of EyeGlasses in precription table"));
            Selenide.SetText(driver, Util.GetLocator("eyerightaxis_dd"), Selenide.ControlType.Select, rightEyeAxis);
            Selenide.SetText(driver, Util.GetLocator("eyeleftaxis_dd"), Selenide.ControlType.Select, leftEyeAxis);
        }

        /// <summary>
        /// SelectEyePrescriptionPD method select PD value of EyeGlasses
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="EyePD">eye PD</param>
        public static void SelectEyePrescriptionPD(RemoteWebDriver driver, Iteration reporter,
            string EyePD)
        {
            reporter.Add(new Act("Select the PD value of EyeGlasses in precription table"));
            Selenide.SetText(driver, Util.GetLocator("eyepd_dd"), Selenide.ControlType.Select, EyePD);
        }

        #endregion
    }
}


