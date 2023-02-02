namespace SearchStackDatabase.Models
{
    public class SearchModel
    {
        public string searchText { get; set; }
        public List<SearchDetail> SearchDetailList { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalItems { get; set; }
    }

    public class SearchDetail
    {
        public string PostTitle { get; set; }
        public string PostDescription { get; set; }
        public string TotalVotes { get; set; }
        public string TotalAnswers { get; set; }

        public string User { get; set; }
        public int ReputationScore { get; set; }
        public string Badges { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
