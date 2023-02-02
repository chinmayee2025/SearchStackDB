using System;
using System.Collections.Generic;

#nullable disable

namespace SearchStackDatabase.DataDB
{
    public partial class QuestionAnswer
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? VoteCount { get; set; }
        public int? AnswerCount { get; set; }
        public string DisplayName { get; set; }
        public int Reputation { get; set; }
        public string Badges { get; set; }
    }
}
