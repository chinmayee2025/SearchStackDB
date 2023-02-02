using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchStackDatabase.DataDB;
using SearchStackDatabase.Models;
using System.Diagnostics;
using cloudscribe.Pagination.Models;


namespace SearchStackDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SearchModel searchModel = new SearchModel();
        public static string searchTextValue ;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            
            
            searchModel.SearchDetailList = new List<SearchDetail>();
            StackOverflow2010Context stackOverFlow2010Context = new StackOverflow2010Context();
            if (searchTextValue != null)
            {
                searchModel.TotalItems = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchTextValue) ||
                    m.Description.Contains(searchTextValue)).Count();
                if (searchModel.TotalItems > 10)
                {


                    var searchData = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchTextValue) ||
                     m.Description.Contains(searchTextValue)).Skip(ExcludeRecords).Take(pageSize).ToList();
                    
                    searchModel.PageNumber = pageNumber;
                    searchModel.PageSize = pageSize;
                    foreach (var item in searchData)
                    {
                        searchModel.SearchDetailList.Add(new SearchDetail
                        {
                            PostTitle = item.Title,
                            PostDescription = item.Description,
                            TotalVotes = item.VoteCount.ToString(),
                            TotalAnswers = item.AnswerCount.ToString(),
                            User = item.DisplayName,
                            ReputationScore = item.Reputation,
                            Badges = item.Badges.Count().ToString(),
                        });

                    }
                }
                else
                {
                    var searchData = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchTextValue) ||
                     m.Description.Contains(searchTextValue)).ToList();
                    foreach (var item in searchData)
                    {
                        searchModel.SearchDetailList.Add(new SearchDetail
                        {
                            PostTitle = item.Title,
                            PostDescription = item.Description,
                            TotalVotes = item.VoteCount.ToString(),
                            TotalAnswers = item.AnswerCount.ToString(),
                            User = item.DisplayName,
                            ReputationScore = item.Reputation,
                            Badges = item.Badges.Count().ToString(),
                        });

                    }
                }
            }
            else
            {
                searchModel.TotalItems = 0;
                searchModel.PageNumber = 0;
                searchModel.PageSize = 10;
            }
           

            return View(searchModel);
        }
        [HttpPost]
        public IActionResult Index(SearchModel searchModel, int pageNumber = 1, int pageSize = 10)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            searchTextValue = searchModel.searchText;
            SearchModel searchDetailList = new SearchModel();
            searchModel.SearchDetailList = new List<SearchDetail>();
            StackOverflow2010Context stackOverFlow2010Context = new StackOverflow2010Context();
            searchModel.TotalItems = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchModel.searchText) ||
             m.Description.Contains(searchModel.searchText)).Count();
            //var searchData;
            if (searchModel.TotalItems > 10)
            {
                var searchData = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchModel.searchText) ||
                 m.Description.Contains(searchModel.searchText)).Skip(ExcludeRecords).Take(pageSize).ToList();
                foreach (var item in searchData)
                {
                    searchModel.SearchDetailList.Add(new SearchDetail
                    {
                        PostTitle = item.Title,
                        PostDescription = item.Description,
                        TotalVotes = item.VoteCount.ToString(),
                        TotalAnswers = item.AnswerCount.ToString(),
                        User = item.DisplayName,
                        ReputationScore = item.Reputation,
                        Badges = item.Badges.Count().ToString(),
                    });
                }

            }
            else
            {
                var searchData = stackOverFlow2010Context.QuestionAnswers.Where(m => m.Title.Contains(searchModel.searchText) ||
                   m.Description.Contains(searchModel.searchText)).ToList();
                foreach (var item in searchData)
                {
                    searchModel.SearchDetailList.Add(new SearchDetail
                    {
                        PostTitle = item.Title,
                        PostDescription = item.Description,
                        TotalVotes = item.VoteCount.ToString(),
                        TotalAnswers = item.AnswerCount.ToString(),
                        User = item.DisplayName,
                        ReputationScore = item.Reputation,
                        Badges = item.Badges.Count().ToString(),
                    });
                }

            }
            
            searchModel.PageNumber = pageNumber;
            searchModel.PageSize = pageSize;
            
            
            
            return View(searchModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}