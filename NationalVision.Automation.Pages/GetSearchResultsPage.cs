/* *******************************************************
 * Description : GetSearchResultsPage.cs having all methods, function and objects 
 *               related to search results page. 
 *               
 * Date : 17-Feb-2016
 * 
 * *******************************************************
 */

using Automation.Mercury;
using Automation.Mercury.Report;
using OpenQA.Selenium.Remote;
using System;

namespace NationalVision.Automation.Pages
{
    /// <summary>
    /// Description : GetSearchResultsPage.cs having all methods, function and objects 
    ///               related to search results page. 
    /// </summary>
    public class GetSearchResultsPage : CommonPage
    {

        // *** PageTitle varible store the Title of this page,
        // *** If user call AssertPageTitle pageTitle value will be passed.
        protected static string pageTitle = "Search Results";
        /// <summary>
        /// AssertPageTitle method assert page title
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertPageTitle(RemoteWebDriver driver, Iteration reporter)
        {
            AssertPageTitle(driver, reporter, pageTitle);
        }
        /// <summary>
        /// VerifySearchProductFor method verify name of the prodct display correct or not
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="searchKeyWord">Search key word</param>
        public static void VerifySearchProductFor(RemoteWebDriver driver, Iteration reporter,
            string searchKeyWord)
        {
            reporter.Add(new Act(string.Format(@"Verifying Your Searcg For:""{0}"" on Search Results page", searchKeyWord)));
            string actText = Selenide.GetText(driver, Locator.Get(LocatorType.XPath, "//div[@class='search-for']/span"),
                Selenide.ControlType.Label);

            String[] SearchText = actText.Split('"');
            if (!SearchText[1].ToLower().Equals(searchKeyWord.ToLower()))
            {
                throw new Exception(string.Format("Keyword name not match, Expected : {0} ; Actual : {1}", searchKeyWord, actText));
            }
        }

        /// <summary>
        /// VerifyProductsFoundCount method verify Products found in the GetSearchResultsPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyProductsFoundCount(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Products-Found: count on search results page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("productfound_lbl"));
        }

        /// <summary>
        /// VerifyContentPagesFoundCount method verify ContentPages found GetSearchResultsPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyContentPagesFoundCount(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify Content pages Found label in GetSearchResultsPage"));
            Selenide.VerifyVisible(driver, Util.GetLocator("contentpagesfound_lbl"));
        }

        /// <summary>
        /// VerifyTryAnotherSearch method verify TryAnotherSearch label in GetSearchResultsPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyTryAnotherSearch(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify TryAnotherSearch label in GetSearchResultsPage"));
            Selenide.VerifyVisible(driver, Util.GetLocator("tryanothersearch_lbl"));
        }

        /// <summary>
        /// AssertKeyWordName method verify whether Keyword matching products label are dispalyed or not 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertKeywordName(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify products matching your searches for label in GetSearchResultsPage"));
            Selenide.VerifyVisible(driver, Util.GetLocator("productmatches_lbl"));
        }
        /// <summary>
        /// VerifyGridListWithSort method verify GridList and Sort Options in GetSearchResultsPage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifyGridListWithSort(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verify GridList and Sort Options in GetSearchResultsPage"));
            Selenide.VerifyVisible(driver, Util.GetLocator("gridlistsort_lbl"));
        }
        /// <summary>
        /// VerifySearchPagination method verify if Sort by is present on the GetSearchResultspage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySearchPagination(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying Pagination available on GetSearchResults page"));
            string totalText = Selenide.GetText(driver, Locator.Get(LocatorType.XPath, "//div[@class='category-paging']/b"), Selenide.ControlType.Label);
            string rangeCount = Selenide.GetText(driver, Locator.Get(LocatorType.XPath, "//div[@class='category-paging']/descendant::span[@class='accent-color-red']"), Selenide.ControlType.Label);

            string[] totalImageCount = totalText.Split(new string[] { "of" }, System.StringSplitOptions.RemoveEmptyEntries);
            string[] currentPageCount = rangeCount.Split('-');

            // *** Below condition verify the Is pagenation available on GetSearchResults page 
            if (int.Parse(currentPageCount[1]) < int.Parse(totalImageCount[1]))
            {
                Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                    "//div[@class='category-paging']/descendant::div[@class='page-numbers']"));
            }

        }
        /// <summary>
        /// NavigateNextSearchPageandVerify method click on pagination and verify next page is navigated on GetSearch Results Page.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void NavigateNextSearchPageandVerify(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Clicking on pagination arrow-button to see the next pages"));
            // *** currentPage1 variable store the current page number;
            string currentPage1 = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='page-numbers']/a[@class='search-paging-link current-page']"), Selenide.ControlType.Label);

            // *** Now click on Pagination Icon to navigate next page..
            Selenide.Click(driver, Locator.Get(LocatorType.XPath, "//div[@class='page-numbers']/a[span[@class='icon-circle-right']]"));

            WaitLoadingComplete(driver);

            // *** currentSelected2 variable store the page number after click on pagination 
            string currentPage2 = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                "//div[@class='page-numbers']/a[@class='search-paging-link current-page']"), Selenide.ControlType.Label);

            if (!(int.Parse(currentPage2) > int.Parse(currentPage1)))
            {
                throw new Exception("Pagination not working properly");
            }
        }
        /// <summary>
        /// VerifySortBy method verify if Sort by is present on the GetSearchResultspage
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void VerifySearchSortBy(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Verifying 'Sort-by' option available in GetSearchResults page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("sortby_dd"));
        }

        /// <summary>
        /// SelectSortBy method select the sort by value;
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="sortBy">default values: relevance; brand, popularity, lowest, highest, Productname</param>
        public static void SelectSearchSortBy(RemoteWebDriver driver,
            Iteration reporter,
            string sortBy = "name")
        {
            string sortvalue = null;
            Selenide.Wait(driver, 5, true);
            switch (sortBy.ToLower())
            {
                case "name":
                    sortvalue = "Product Name";
                    break;
                case "brand":
                    sortvalue = "Product Brand";
                    break;
                case "popularity":
                    sortvalue = "Most Popular";
                    break;
                case "low":
                    sortvalue = "Price: Lowest First";
                    break;
                case "high":
                    sortvalue = "Price: Highest First";
                    break;
                default:
                    sortvalue = "Relevance";
                    break;
            }
            reporter.Add(new Act(string.Format("GetSearchResults page results sorted-by: '{0}'", sortvalue)));
            Selenide.SetText(driver, Util.GetLocator("sortby_dd"), Selenide.ControlType.Select, sortvalue);
            WaitLoadingComplete(driver);
        }

        /// <summary>
        /// AssertSearchProductImage method verify if the Product image is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void AssertSearchProductImage(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("productimage is available in GetSearchResults Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("searchproductimage_img"));
        }

        /// <summary>
        /// AssertSearchProductName method Verify if the product name is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>        
        public static void AssertSearchProductName(RemoteWebDriver driver, Iteration reporter)
        {
            //@@ TODO Locator value need to modifiy for timebeing its working
            reporter.Add(new Act("productname is available in GetSearchResults Page"));
            Selenide.VerifyVisible(driver, Util.GetLocator("searchproductname_lbl"));
        }

        /// <summary>
        /// RecentSearches method verifies recent searches string(words) on search results page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="keyword"></param>
        public static void RecentSearches(RemoteWebDriver driver, Iteration reporter,
            string keyword)
        {
            reporter.Add(new Act(string.Format(@"Verify recent search Keyword: {0}", keyword)));
            Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath,
                string.Format(@"//div[@id='recent-searches']/span[@class='recent-search']/a[contains(text(),'{0}')]", keyword)));
        }

        /// <summary>
        /// AssertSearchProductPrice method Verify if the product price is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>        
        public static void AssertSearchProductPrice(RemoteWebDriver driver, Iteration reporter)
        {
            Selenide.VerifyVisible(driver, Util.GetLocator("searchproductprice_lbl"));
            reporter.Add(new Act("productprice is available in GetSearchResults Page"));
        }

        /// <summary>
        /// AssertSearchProductReview method Verify the product review star is available
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>        
        public static void AssertSearchProductReview(RemoteWebDriver driver, Iteration reporter, string keyword)
        {
            reporter.Add(new Act(String.Format("Verify Review Stars are present for {0}", keyword)));
            int count = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath, "//div[@class='icon-star-container']"));
            if (count == 0)
            {
                reporter.Add(new Act("Review Stars are not present in the GetSearchResults"));
            }
            else
            {
                for (int i = 1; i <= count; i++)
                {
                    Selenide.VerifyVisible(driver, Locator.Get(LocatorType.XPath, "//div[@class='icon-star-container'][" + i + "]"));
                }
            }

        }

        /// <summary>
        /// SelectGridorLineView method select Grid /List view in search results page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="selectGrid"></param>
        public static void SelectGridorLineView(RemoteWebDriver driver, Iteration reporter,
            bool selectGrid = true)
        {
            reporter.Add(new Act("Grid/List View is available in GetSearchResults Page"));
            if (selectGrid)
            {
                Selenide.Click(driver, Locator.Get(LocatorType.XPath, "//span[@class='icon-view-module']"));
            }
            else
            {
                Selenide.Click(driver, Locator.Get(LocatorType.XPath, "//span[@class='icon-view-headline']"));
            }
            //@ TODO need to check resutls grid modified as selected
        }

        /// <summary>
        /// TypeTryAnotherSearch method Type another search keyword in textbox
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param> 
        /// <param name="trysearchKey">another search keyword we wish to enter</param> 
        public static void TypeTryAnotherSearch(RemoteWebDriver driver, Iteration reporter, String trysearchKey)
        {
            Selenide.Clear(driver, Util.GetLocator("typetryanothersearch_txt"), Selenide.ControlType.Textbox);
            reporter.Add(new Act(string.Format(@"Type search key word '{0}' at Search Text box", trysearchKey)));
            Selenide.SetText(driver, Util.GetLocator("typetryanothersearch_txt"), Selenide.ControlType.Textbox, trysearchKey);
        }

        /// <summary>
        /// ClickSearchAgain method Click SearchAgain button in the GetSearchResults Page
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        public static void ClickSearchAgain(RemoteWebDriver driver, Iteration reporter)
        {
            reporter.Add(new Act("Click on Search Again button"));
            Selenide.Click(driver, Util.GetLocator("clicksearchagain_btn"));
        }

        /// <summary>
        /// SelectSuggestion method type each character in the search text box and select a one of the auto suggetions displaying.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="searchKey">string wish to search</param>
        public static void SelectSuggestion(RemoteWebDriver driver, Iteration reporter,
            string searchKey)
        {
            int autoSuggCount = 0;
            bool flag = false; //flag value used to break external for-loop

            // eachCharater variable used for type the each charater in text box, else selenium type all whole string(word) at a time. 
            char[] eachCharater = searchKey.ToCharArray();

            reporter.Add(new Act("Select a keyword from suggestion box"));
            foreach (char singlechar in eachCharater)
            {
                TypeSearchText(driver, reporter, singlechar.ToString());

                // *** Search text box have a JQuery loading  ***//
                Selenide.WaitForAjax(driver); 

                autoSuggCount = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                                "//div[@class='row clearfix logo-store-row']/descendant::div[@id='suggestDiv']/a"));

                for (int index = 1; index <= autoSuggCount; index++)
                {
                    string suggestions = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='row clearfix logo-store-row']/descendant::div[@id='suggestDiv']/a[{0}]", index)),
                        Selenide.ControlType.Label);
                    if (searchKey.ToLower().Equals(suggestions.Trim().ToLower()))
                    {
                        Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[@class='row clearfix logo-store-row']/descendant::div[@id='suggestDiv']/a[{0}]", index)));
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            ClearSearchText(driver, reporter);
            Selenide.WaitForAjax(driver);
        }

        /// <summary>
        /// SelectSuggestionInTryAnotherSearch method type each charater in  Try-Another-Search and select of the autosuggetions displaying.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="reporter"></param>
        /// <param name="searchKey"></param>
        public static void SelectSuggestionInTryAnotherSearch(RemoteWebDriver driver, Iteration reporter,
           string searchKey)
        {
            int autoSuggCount = 0;
            bool flag = false; //flag value used to break external for-loop

            reporter.Add(new Act("Selct a keyword from TryAnotherSearchsuggestion box"));

            for (int chrcount = 1; chrcount <= searchKey.Length; chrcount++)
            {
                Selenide.Clear(driver, Util.GetLocator("typetryanothersearch_txt"), Selenide.ControlType.Textbox);
                Selenide.SetText(driver, Util.GetLocator("typetryanothersearch_txt"), Selenide.ControlType.Textbox, searchKey.Substring(0, chrcount));

                // *** Search text box have a JQuery loading  ***//
                Selenide.WaitForAjax(driver);

                autoSuggCount = Selenide.GetElementCount(driver, Locator.Get(LocatorType.XPath,
                    "//div[starts-with(@class, 'search-box-wrapper')]/descendant::div[@id='suggestDiv']/a"));

                for (int index = 1; index <= autoSuggCount; index++)
                {
                    string suggestions = Selenide.GetText(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[starts-with(@class, 'search-box-wrapper')]/descendant::div[@id='suggestDiv']/a[{0}]", index)),
                        Selenide.ControlType.Label);
                    if (searchKey.ToLower().Equals(suggestions.Trim().ToLower()))
                    {
                        Selenide.Click(driver, Locator.Get(LocatorType.XPath,
                        string.Format(@"//div[starts-with(@class, 'search-box-wrapper')]/descendant::div[@id='suggestDiv']/a[{0}]", index)));
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    break;
            }
            Selenide.Clear(driver, Util.GetLocator("typetryanothersearch_txt"), Selenide.ControlType.Textbox);
            
            // *** Search text box have a JQuery loading  ***//
            Selenide.WaitForAjax(driver);
        }
    }
}
