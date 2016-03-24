/* **********************************************************
 * Description : SF_TC089.cs for Search Functionality,
 *               Search for product and verify search again for an item by entering keyword in Try another search form
 *               and verify the attributes in search Results Page
 *                               
 * Date :  22-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;


namespace NationalVision.Automation.Tests.Cases.Miscellaneous
{
    /// <summary>
    ///  SF_TC089.cs for Search Functionality,
    /// Search for product and verify search again for an item by entering keyword in Try another search form
    /// and verify the attributes in search Results Page
    /// </summary>
    class SF_TC089 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verify Search Functionality and Verify the attributes in Search results page";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Entering Valid Keyword in Search field and Clicking on Search button";
            /**** Searching for goggles only to navigate to search Page
            // you can replace 'goggles with any value ****/
            CommonPage.TypeSearchText(Driver, Reporter, TestData["KEYWORD"]);
            CommonPage.ClickSearch(Driver, Reporter);

            string[] search_keywords = { "dailies", "skecher", "frames rimless", "no line bifocals" };
            foreach (string search_keyword in search_keywords)
            {
                GetSearchResultsPage.TypeTryAnotherSearch(Driver, Reporter, search_keyword);
                GetSearchResultsPage.ClickSearchAgain(Driver, Reporter);
                SearchResutls(search_keyword);
            }

            //@TODO Test Recent searches
            //Browser always not holding Recent search results there may be chance to test case failure
            //** This condition verify when multiple searchs keywords **//
            if (search_keywords.Length > 1)
            {
                for (int count = 0; count < search_keywords.Length - 1; count++)
                {
                    GetSearchResultsPage.RecentSearches(Driver, Reporter, search_keywords[count]);
                }
            }
        }


        public void SearchResutls(string _keyword)
        {
            Step = "Verifying attributes in Get Search results Page";
            CommonPage.VerifyEyeCareClubLearnMore(Driver, Reporter);
            GetSearchResultsPage.AssertPageTitle(Driver, Reporter);
            GetSearchResultsPage.VerifySearchProductFor(Driver, Reporter, _keyword);
            GetSearchResultsPage.VerifyProductsFoundCount(Driver, Reporter);
            GetSearchResultsPage.VerifyContentPagesFoundCount(Driver, Reporter);
            GetSearchResultsPage.AssertKeywordName(Driver, Reporter);
            GetSearchResultsPage.VerifyGridListWithSort(Driver, Reporter);

            Step = "Verifying the pagination in the GetSearch Results Page";
            GetSearchResultsPage.VerifySearchPagination(Driver, Reporter);

            Step = "Verifying SortBy Option and Select SortBy features";
            GetSearchResultsPage.VerifySearchSortBy(Driver, Reporter);
            GetSearchResultsPage.SelectSearchSortBy(Driver, Reporter, "high");

            Step = "Verifying Product attributes like name, image in the GetSearchResults page";
            GetSearchResultsPage.AssertSearchProductImage(Driver, Reporter);
            GetSearchResultsPage.AssertSearchProductName(Driver, Reporter);
            GetSearchResultsPage.SelectGridorLineView(Driver, Reporter, false);
            GetSearchResultsPage.SelectGridorLineView(Driver, Reporter);

            Step = "Selecting a valid keyword from TryAnotherSearchsuggestion box";
            GetSearchResultsPage.SelectSuggestionInTryAnotherSearch(Driver, Reporter, _keyword);
        }
    }
}
