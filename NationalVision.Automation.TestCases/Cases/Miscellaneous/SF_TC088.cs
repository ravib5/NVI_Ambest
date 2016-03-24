/* **********************************************************
 * Description : SF_TC088.cs for Search Functionality
 *               Search for product and verify same keyword attributes on resutls Page
 *               
 *                               
 * Date :  17-Feb-2016
 * **********************************************************
 */
using Automation.Mercury;
using NationalVision.Automation.Pages;


namespace NationalVision.Automation.Tests.Cases.Miscellaneous
{
    /// <summary>
    ///  SF_TC088.cs for Search Functionality and verify the attributes in the Search results page
    /// </summary>
    class SF_TC088 : BaseCase
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Chapter.Title = "Verify Search Functionality and Verify the attributes in Search results page";
            Step = "Opening browser and navigating to the application";
            CommonPage.NavigateTo(Driver, Reporter, Util.EnvironmentSettings["Server"]);

            Step = "Entering Valid Keyword in Search field and Clicking on Search button";
            string[] search_keywords = { "commotion", "goggles", "acuvue", "rayban" };

            foreach (string search_keyword in search_keywords)
            {
                CommonPage.TypeSearchText(Driver, Reporter, search_keyword);
                CommonPage.ClickSearch(Driver, Reporter);
                SearchResutls(search_keyword);
            }

            //@TODO Test Recent searches
            //Browser always not holding Recent search results there may be chance to test case failure
            //** This condition verify when multiple searchs keywords **//
            //** Considering String.Length-1 becuase last search keyword not added to the recent searhes
            if (search_keywords.Length > 1)
            {
                for (int count = 0; count < search_keywords.Length-1; count++)
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
            Selenide.Wait(Driver, 0.5, true); //Added sleep method, else user unable to view the line/grid view
            GetSearchResultsPage.SelectGridorLineView(Driver, Reporter);
           
            Step = "Verifying Review Stars are availble for the Product";  
            GetSearchResultsPage.AssertSearchProductReview(Driver, Reporter, _keyword);           

            Step = "Selecting a valid keyword from suggestion box";
            GetSearchResultsPage.SelectSuggestion(Driver, Reporter, _keyword);
        }
    }
}
