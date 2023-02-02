using System;
using System.Collections.Generic;

#nullable disable

namespace SearchStackDatabase.DataDB
{
    public partial class VotesDatum
    {
        public string PostType { get; set; }
        public string DayOfTheWeek { get; set; }
        public int? TotalPost { get; set; }
        public string VoteType { get; set; }
        public int? Total { get; set; }
    }
}
