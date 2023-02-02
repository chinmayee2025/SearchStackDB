using System;
using System.Collections.Generic;

#nullable disable

namespace SearchStackDatabase.DataDB
{
    public partial class TableNotification
    {
        public int NotiId { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string NotiHeader { get; set; }
        public string NotiBody { get; set; }
        public bool? IsRead { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
