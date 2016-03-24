/* **********************************************************************
 * Description : CommonPage.cs class having methods and objects common to all pages.
 *        Header links, Footer links, Menu Tabs, Search window objects.
 *        
 * Date  :  02-Feb-2016
 * 
 * **********************************************************************
 */

using System;
using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;

namespace NationalVision.Automation.Pages
{
    public class CommonPage
    {
        // otherLinks list to filter the eye glasses submenu links with otherlinks
        private static List<string> otherLinks = new List<string>();

        /// <summary>
        /// This method naviagte the url
        /// </summary>
        /// <param name="driver">Initialized RemoteWebDriver instance</param>
        /// <param name="reporter">Initialized report instance</param>
        /// <param name="url">URL of the application</param>
        public static void NavigateTo(RemoteWebDriver driver, Iteration reporter, String url)
        {
            Selenide.NavigateTo(driver, url);
        }

        /// <summary>
        /// RefreshBrowser method for Refreshs The Browser
        /// </summary>
        /// <param name="Driver">Initialized RemoteWebDriver instance</param>
        /// <param name="reporter">Initialized report instance</param>
        /// <param name="location">Location to navigate</param>
        public static void RefreshBrowser(RemoteWebDriver driver, Iteration reporter)
        {
            Selenide.BrowserRefresh(driver);
        }

        /// <summary>
        /// AssertPageTitle verify page title macth
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pageTitle"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter,
            string pTitle = "Contacts & Eyeglasses | Prescription Glasses | Contact Lenses")
        {

            //Selenide.WaitForTitle(driver,pTitle);
            string title = Selenide.GetTitle(driver);
            title = title.Replace("'", "");
            if (!title.ToLower().Contains(pTitle.ToLower()))
            {
                reporter.Add(new Act("Asserting current page title"));
                throw new Exception(string.Format(@"Page Title not matched: Expected Title: ""{0}"" <br> Current Page Title: ""{1}""", pTitle, title));
            }
            else
            {
                reporter.Add(new Act("Asserted current page title : " + title));
            }
        }

        /// <summary>
        /// ClickTopMenuLink Method used to click on top menu links in Home page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="menuItem">Links appears on the top the page eg: faq</param>
        public static void ClickTopMenuLink(RemoteWebDriver driver, Iteration reporter,
            string menuItem)
        {
            reporter.Add(new Act("Click on link : " + menuItem));
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//ul/li/a[normalize-space()='{0}']", menuItem)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//ul/li/a[normalize-space()='{0}']", menuItem)));
        }

        /// <summary>
        /// ClickHomePageTabs method click on Home Page tabs
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="tabName">Tab Name where User wish to switch</param>
        public static void ClickHomePageTabs(RemoteWebDriver driver, Iteration reporter,
            string tabName)
        {
            reporter.Add(new Act("Click on Home Page Tab: " + tabName));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath, string.Format(@"//ul/descendant::a[text()='{0}']", tabName)));
        }

        /// <summary>
        /// MouseOverHomePageTabs method move the mouse foucs to the TAB on home page. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="tabName">Tab names wish to click on Home Page Eg: Eyeglasses; Contact Lens</param>
        public static void MouseOverHomePageTabs(RemoteWebDriver driver, Iteration reporter,string tabName)
        {
            reporter.Add(new Act("Mouse over on : " + tabName));
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,string.Format(@"//ul/descendant::a[text()='{0}']", tabName)));

            Selenide.Focus(driver, Locator.Get(LocatorType.XPath,string.Format(@"//ul/descendant::a[text()='{0}']", tabName)));
            
        }

        /// <summary>
        /// ClickSubMenuLink method click on submenu links Eg: Eyeglasses --> Women's Glasses
        /// </summary>       /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="linkName">Link name wish to click eg: men's glasses </param>
        public static void ClickSubMenuLink(RemoteWebDriver driver, Iteration reporter,
            string linkName)
        {
            reporter.Add(new Act("Click on submenu link : " + linkName));
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
            string.Format(@"//div[starts-with(@class,'dropdown')]/descendant::li/a[text()=""{0}""]", linkName)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
             string.Format(@"//div[starts-with(@class,'dropdown')]/descendant::li/a[text()=""{0}""]", linkName)));

            /* ***** otherlinks list have seperate html code when user click on submenulinks
            // ***** below list page titles have //div[@id='mainBody']/h1
            // ***** Using this otherlinks I am checking page header /title once user application navigate to the Shelf pages.
            // ***** If new links comes in future need to add in this list. */
            otherLinks.Add("Eyecare Club");
            otherLinks.Add("$13.99 Contacts");
            otherLinks.Add("Contact Lens Exam");
            otherLinks.Add("2 Pairs for $69.95");
            otherLinks.Add("2 Bifocals for $99.95");
            otherLinks.Add("2 Pairs of Progressives");
            otherLinks.Add("Free Eye Exam");
            otherLinks.Add("$13.99 Contact Lenses");
            otherLinks.Add("Vision Insurance");
            otherLinks.Add("Protection Plan");
            otherLinks.Add("Warranty");

            if (otherLinks.Contains(linkName)) // **** This code checks if links belog to othelinks or not
            {
                Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath, "//div[@id='mainBody']/h1"));
            }
            else
            {
                // **** Below condition wait until page load completes
                // **** All glasses is skipping because this page doesn't have title. 
                if (!linkName.Equals("all glasses"))
                {
                    // ***** Below line is commented because of some execution issue once it stable, it will be deleted.
                    Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                        "//section[starts-with(@class,'standard-left-col')]/descendant::h1[not(ancestor::div[@id='vtoWrapper'])]"));
                }
            }
            /* *** This method redirect the respective shelf pages. 
            // *** If links under eyeglasses - It will redirects EyeGlassesshelfPage.cd
            // *** if links under Contactlens  -- It will redirects to ContactLensShelfPage.cs */
        }

        /// <summary>
        /// TypeSearchText method type search key words in Search text box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="searchKey">Keywords wish to search</param>
        public static void TypeSearchText(RemoteWebDriver driver, Iteration reporter,
            String searchKey)
        {
            reporter.Add(new Act(String.Format("Type '{0}' search keyword(s)/ character(s)  at Search Text box", searchKey)));
            Selenide.SetText(driver, Util.GetLocator("search_txt"), Selenide.ControlType.Textbox, searchKey);
        }

        /// <summary>
        /// ClearSearchText method clear text box
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClearSearchText(RemoteWebDriver driver, Iteration reporter)
        {
            Selenide.Clear(driver, Util.GetLocator("search_txt"), Selenide.ControlType.Textbox);
        }

        /// <summary>
        /// ClicksSearch method click on Search button 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSearch(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Search button"));
            Selenide.Click(driver, Util.GetLocator("search_btn"));
        }

        /// <summary>
        /// AssertSubSections method is to verify the sub tabs like shop by brand, shop by type
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="sections">These are sub sections which needs to be verified </param>
        public static void AssertSubSections(RemoteWebDriver driver, Iteration reporter, String[] sections)
        {
            reporter.Add(new Act("Verifying the sub-sections under main menu"));
            foreach (string sectionName in sections)
            {
                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//ul[@class='desktop-nav col-md-12']/descendant::li[@class='nav-head'][text()='{0}']", sectionName)));
            }
        }

        /// <summary>
        /// ClickContactLenseProduct method click on the product on Product list, it redirects ContactLensesProductDisplayPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="pName">Product name wish to click Contact lens shelf</param>
        public static void ClickContactLenseProduct(RemoteWebDriver driver, Iteration reporter,
            string pName)
        {
            reporter.Add(new Act(string.Format(@"Selected product '{0}' from ContactLensShelf page", pName)));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//div[@class='product-row row']/descendant::span[@class='product-name' and contains(.,'{0}')]", pName)));

            // *** This click mehtod redirect to ContactLensProductDisplayPage.cs  **** //
        }

        /// <summary>
        /// ClickEyeGlassProduct method click on selective product from Product List page and it redirects to Product details page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="productName">Product name on which it should click</param>
        public static void ClickEyeGlassProduct(RemoteWebDriver driver, Iteration reporter,
            string productName)
        {
            reporter.Add(new Act(string.Format(@"Selected eyeglass '{0}' from eyeglassesshelf page", productName)));
            Selenide.WaitForElementClickble(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='product-desktop-row']/descendant::span[text()='{0}']", productName)));

            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='product-desktop-row']/descendant::span[text()='{0}']", productName)));
        }

        /// <summary>
        /// ClickLeftMenuLinks click on left menu links displyed on Contact lens shelf page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="linkText">eg: Acuvue, Daily Disposable, Eyecare Club</param>
        public static void ClickLeftMenuLinks(RemoteWebDriver driver, Iteration reporter,
                    string linkText)
        {
            reporter.Add(new Act(string.Format(@"Navigating to '{0}' products page from  left menu", linkText)));
            Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//div[@class='left-nav' or @class='home-left-column' or @class='search-left-column row']/descendant::a[normalize-space()=""{0}""]", linkText)));

            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
               string.Format(@"//div[@class='left-nav' or @class='home-left-column' or @class='search-left-column row']/descendant::a[normalize-space()=""{0}""]", linkText)));

            // Spinner is visible while loading page, wait until spinner disappears
            WaitLoadingComplete(driver);
        }


        public static void ClickLeftFilters(RemoteWebDriver driver, Iteration reporter,
                   string linkText)
        {
            if (!linkText.Equals(""))
            {
                Selenide.WaitForElementVisible(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@class='left-nav' or @class='home-left-column' or @class='search-left-column row']/descendant::a[@class='facet' and normalize-space()=""{0}""]", linkText)));

                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                   string.Format(@"//div[@class='left-nav' or @class='home-left-column' or @class='search-left-column row']/descendant::a[@class='facet' and normalize-space()=""{0}""]", linkText)));

                // Spinner is visible while loading page, wait until spinner disappears
                WaitLoadingComplete(driver);
            }
        }

        /// <summary>
        /// ClickLeftMenuLinks click on left menu links.
        /// This method written for Page_SEO purpose, this method works Java Script for click on object
        /// before using this method please take care, there is chance to fail.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="position">Position of link on page</param>
        public static void ClickLeftMenuLinks(RemoteWebDriver driver, Iteration reporter,
                    int position)
        {
            reporter.Add(new Act("Navigating to left menu pages"));
            Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='left-nav' or @class='home-left-column']/descendant::li[@class='facet-container Eyeglasses']/descendant::a[{0}]", position)));

            // Spinner is visible while loading page, wait until spinner disappears
            WaitLoadingComplete(driver);
        }


        /// <summary>
        /// AssertLeftMenuLinks verify left menu links are visible in Contact Lens page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertLeftMenuLinks(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Assert left menu links are presence in ContactlensShelf page "));
            int menucount = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath, "//div[@class='left-nav']/descendant::li/a"));
            if (menucount == 0)
            {
                reporter.Add(new Act("In Contact Lens Page Left menu lust not visible"));
                throw new Exception("Custom Exception Message : In Contact Lens Page Left menu lust not visible");
            }
        }

        /// <summary>
        /// WaitLoadingComplete method load until spinner disappers
        /// Use for EyeGlassesshelfpage, MyaccountPage for loading
        /// This method wait until spinner disappers, default time 30sec
        /// Spinner appears in Ajax calls also.
        /// </summary>
        /// <param name="driver"></param>
        public static void WaitLoadingComplete(RemoteWebDriver driver)
        {
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// WaitUnitlSpinnerDisappears method waits until spinner disappers  
        /// when user select Store state, below spinner appears.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        public static void WaitUnitlSpinnerDisappears(RemoteWebDriver driver,
            string locator = null)
        {
            locator = !string.IsNullOrEmpty(locator) ? locator : "//div[@class='spinner-indicator generic-spinner']/descendant::svg";
            Selenide.WaitForElementNotVisible(driver, Locator.Get(LocatorType.XPath, locator));
        }

        /// <summary>
        /// VerifyEyeCareClubLearnMore method verify EyeCareClub Logo and Learnmore in HomePage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyEyeCareClubLearnMore(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify EyecareClub Logo and Learnmore in HomePage"));
            Selenide.VerifyVisible(driver, Util.GetLocator("eyecareclublearnmore_lbl"));
        }


        /// <summary>
        /// PageSEOInfo method get information about the below SEO details 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="screenshotName">Name of screenshot (Screenshot) save this name</param>
        /// <param name="saveTo">results folder where test results are stored (This is standrad value retrive form BaseCase)</param>
        public static void PageSEOInfo(RemoteWebDriver driver, Iteration reporter,
            string screenshotName,
            string saveTo)
        {
            reporter.Add(new Act(string.Format(@"1. <b><font color=blue>Pretty-URL</font></b> : {0}", Selenide.GetCurrentPageUrl(driver))));

            reporter.Add(new Act(string.Format(@"2. <b><font color=blue>OG-URL</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@property='og:url']"), "content"))));

            reporter.Add(new Act(string.Format(@"3. <b><font color=blue>Twitter-URL</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@name='twitter:url']"), "content"))));

            reporter.Add(new Act(string.Format(@"4. <b><font color=blue>Canonical-URL</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//link[@rel='canonical']"), "href"))));

            reporter.Add(new Act(string.Format(@"5. <b><font color=orange>Page-Title:</font></b> {0}", Selenide.GetTitle(driver))));

            reporter.Add(new Act(string.Format(@"6. <b><font color=orange>OG-Title</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@property='og:title']"), "content"))));

            reporter.Add(new Act(string.Format(@"7. <b><font color=orange>Twitter-Title</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@name='twitter:title']"), "content"))));

            reporter.Add(new Act(string.Format(@"8. <b><font color=green>Description</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@name='description']"), "content"))));

            reporter.Add(new Act(string.Format(@"9. <b><font color=green>OG-Description</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@property='og:description']"), "content"))));

            reporter.Add(new Act(string.Format(@"10. <b><font color=green>Twitter-Description</font></b> : {0}",
                Selenide.GetAttributeValue(driver, Locator.Get(LocatorType.XPath, "//meta[@name='twitter:description']"), "content"))));

            Selenide.takeScreenshot(driver, screenshotName, saveTo);
        }

        /// <summary>
        /// GetLeftMenuLinksCount method returns no.of links on Contact Home
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <returns>Count of left menu links</returns>
        public static int GetLeftMenuLinksCount(RemoteWebDriver driver, Iteration reporter)
        {
            return Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                @"//aside[starts-with(@class,'standard-left-col')]/descendant::li[starts-with(@class,'facet-container')]/descendant::a[@class='facet']"));

            /* This is method returns count of All left menu links on Contacts Home page*/
        }

        /// <summary>
        /// GetLeftMenuLinkText return link text of left menu links 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="postion">Position of the link </param>
        /// <returns></returns>
        public static string GetLeftMenuLinkText(RemoteWebDriver driver, Iteration reporter,
            int postion)
        {
            return Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                 string.Format(@"//div[@class='left-nav' or @class='home-left-column']/descendant::li[starts-with(@class,'facet-container')]/descendant::a[@class='facet'][{0}]", postion)),
                 Selenide.ControlType.Label);

            /* This is method returns link text of All left menu links on Contacts Home page*/
        }

        /// <summary>
        /// ClickShowAllBrands method click on show all brands link if it available.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="filterOn">Defult value:brand; Frame-Color: filterOn=frame-color </param>
        public static void ClickShowAllBrands(RemoteWebDriver driver, Iteration reporter,
            string filterOn = "brand")
        {
            if (Selenide.IsElementExists(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@class='left-nav']/descendant::ul[@class='{0}']/descendant::a[@class='show-more-btn' and starts-with(text(),'Show All')]", filterOn))))
                Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                    string.Format(@"//div[@class='left-nav']/descendant::ul[@class='{0}']/descendant::a[@class='show-more-btn' and starts-with(text(),'Show All')]", filterOn)));

            Selenide.Wait(driver, 0.5, true);
        }

        /// <summary>
        /// LeftMenuCategory method verify left menu categories
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="category">Eg: Price, Brand, Color, etc..</param>
        public static void LeftMenuCategory(RemoteWebDriver driver,
            Iteration reporter,
            string category)
        {
            reporter.Add(new Act(string.Format("Verify Left menu categories: {0}", category)));

            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
         string.Format(@"//div[@class='left-nav' or @class='home-left-column']/descendant::li[starts-with(@class,'facet-container')]/descendant::ul[@data-category='{0}']", category)));
        }

    }
}

