
/* **********************************************************
 * Description : EyeCareClubPage.cs contains the methods related to 
 *                contact lenses navigation and  and display of product when user selects eye care club under Contact lens offers
 *              
 * Date :  11-Feb-2016
 * 
 * **********************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;

namespace NationalVision.Automation.Pages
{
    public class EyecareClubPurchasePage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Purchase";
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }

        /// <summary>
        /// VerifyClubMemeberSections method verify become a new eye care club member is present
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyClubMemeberSections(RemoteWebDriver driver, Iteration reporter,
            string section)
        {
            reporter.Add(new Act(string.Format(@"Verify '{0}' on Club membership Page",section)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath, string.Format(@"//div[@class='title' and text()='{0}']", section)));
            reporter.Add(new Act(string.Format(@"Verify add to cart button in '{0}' section",section)));
            Selenide.VerifyVisible(driver, Util.GetLocator("addtocarteyecare_btn"));
        }

        ///// <summary>
        ///// ClickClubMemberShipAddToCart mehtod select Clubmembership to join
        ///// </summary>
        ///// <param name="driver"></param>
        ///// <param name="reporter"></param>
        ///// <param name="productName">product name</param>
        //public static void ClickClubMemberShipAddToCart(RemoteWebDriver driver, Iteration reporter,
        //    string productName)
        //{
        //    reporter.Add(new Act("Click on Add to Cart button eyecareclub purchase Page"));
        //    Selenide.Click(driver, Locator.Get(LocatorType.XPath,
        //   (string.Format(@"//span[text()='{0}']/parent::div/descendant::button[text()='Add To Cart']", productName))));
        //}

        /// <summary>
        /// ClickClubMemberShipAddToCart click on 'Add to Cart' button of specific membership selected by user.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="isThree">Defult:TRUE (3 years); False: 5 years membership </param>
        /// <param name="isNewMember">Default:TRUE (New Membership); False: Renewal Membership</param>
        public static void ClickClubMemberShipAddToCart(RemoteWebDriver driver, Iteration reporter,
            bool isThree = true,
            bool isNewMember = true)
        {
            reporter.Add(new Act("Click on Add to Cart button eyecareclub purchase Page"));
            string memberShip = null;

            if (isNewMember)
            {
                if (isThree)
                {
                    memberShip = "Eyecare Club 3 Year New";
                }
                else
                {
                    memberShip = "Eyecare Club 5 Year New";
                }
            }
            else
            {
                if (isThree)
                {
                    memberShip = "Eyecare Club 3 Year Renewal";
                }
                else
                {
                    memberShip = "Eyecare Club 5 Year Renewal";
                }
            }

            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
           (string.Format(@"//span[text()='{0}']/parent::div/descendant::button[text()='Add To Cart']", memberShip))));
        }

        /// <summary>
        /// VerifySelectedProductCart method veify Selected product should be added to the shopping cart
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySelectedProductCart(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify selected product should be added to the shopping cart"));
            Selenide.VerifyVisible(driver, Util.GetLocator("SelectedProduct"));

        }
    }
}
