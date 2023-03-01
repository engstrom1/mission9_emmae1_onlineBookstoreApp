using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineBookstoreApp.Models
{
    public class PageInfo
    {
        public int TotalNumEntries { get; set; }
        public int EntriesPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int) Math.Ceiling((double) TotalNumEntries / EntriesPerPage);
    }
}
