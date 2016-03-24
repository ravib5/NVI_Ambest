/* **********************************************************
 * Description : MyAccountPrescriptionsPage.cs page contains
 *               methods related to editing and removing prescriptions 
 *               
 * Date :  22-Mar-2016
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
    /// MyAccountPrescriptionsPage is internal page of the Myaccount.
    /// So MyAccountAutoReorderPage class inherites MyaccountPage methods
    /// </summary>
    public class MyAccountPrescriptionsPage : MyAccountPage
    {
        /// <summary>
        /// AssertPrescription method is used to verify if the prescription is present under prescriptions tab
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the product which we want to assert</param>
        /// <param name="Eye">Eye which we want to assert Default:'R' values:'L','R'</param>
        /// <param name="Sphere">Sphere which we want to assert</param>
        public static void AssertPrescription(RemoteWebDriver driver, Iteration reporter,
            string productName,           
            string Sphere, 
            string Eye="R")
        {
            reporter.Add(new Act(string.Format(@"Verify the prescription is present for {0} {1} Eye under 'prescription' tab", productName,Eye)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//td[text()='{0}']/following-sibling::td[text()='{1}']/following-sibling::td[text()='{2}']",productName,Eye,Sphere)));
        }

        /// <summary>
        /// ClickAddonPrescription method is used to click on Add button of the selected prescription
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Name of the product which we want to Add</param>
        /// <param name="Eye">Eye which we want to Add Default:'R' values:'L','R'</param>
        public static void ClickAddonPrescription(RemoteWebDriver driver, Iteration reporter,
            string productName,
            string Eye = "R")
        {
            reporter.Add(new Act(string.Format(@"Click Add button for the prescription of the product {0} for {1} Eye",productName,Eye)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//td[text()='{0}']/following-sibling::td[text()='{1}']/following-sibling::td/input", productName, Eye)));
        }

        /// <summary>
        /// AssertAddSelectedToCartBtn method is used to verify the presense of button 'add selected to cart'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertAddSelectedToCartBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify the presense of button 'add selected to cart'"));
            Selenide.VerifyVisible(driver, Util.GetLocator("addselectedtocart_btn"));
        }

        /// <summary>
        /// ClickAddSelectedToCartBtn method is used to click on the button 'add selected to cart'
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickAddSelectedToCartBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on the button 'add selected to cart'"));
            Selenide.Click(driver, Util.GetLocator("addselectedtocart_btn"));
        }

        /// <summary>
        /// ClickRemoveButton method is used to click on the button 'Remove' in MyAccounPrescriptions page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="index">index of the product of which remove button to be clicked default:1</param>
        public static void ClickRemoveButton(RemoteWebDriver driver, Iteration reporter,
            int index=1)
        {
            reporter.Add(new Act("Click on Remove button of the prescription"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='prescription-row row ng-scope'][{0}]/descendant::button[text()='Remove']",index)));
        }

        /// <summary>
        /// AssertRemoveCancelBtn method is used to Verify 'Cancel' button is present after clicked on'Remove' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertRemoveCancelBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Cancel' button is present after clicked on'Remove' button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("removecancel_btn"));
        }

        /// <summary>
        /// AssertRemoveConfirmBtn method is used to Verify 'Confirm' button is present after clicked on'Remove' button
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertRemoveConfirmBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify 'Confirm' button is present after clicked on'Remove' button"));
            Selenide.VerifyVisible(driver, Util.GetLocator("removeconfirm_btn"));
        }

        /// <summary>
        /// ClickRemoveConfirmBtn method is used to click on Confirm button to remove the prescription
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickRemoveConfirmBtn(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Confirm button to Remove the prescription"));
            Selenide.Click(driver, Util.GetLocator("removeconfirm_btn"));
        }

        /// <summary>
        /// AssertPrescriptionRemoved method is used to verify if the prescription is removed from the 'prescriptions' tab
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">ProductName of which prescription to be removed</param>
        public static void AssertPrescriptionRemoved(RemoteWebDriver driver, Iteration reporter,
            string productName)
        {
            reporter.Add(new Act("Verify the selected prescription is removed from the list"));
            Boolean exists = Selenide.IsElementExists(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//td[text()='{0}']/ancestor::table", productName)));
            if (exists)
                throw new Exception("The Prescription is not removed from 'prescriptions' tab");
        }
    }
}
