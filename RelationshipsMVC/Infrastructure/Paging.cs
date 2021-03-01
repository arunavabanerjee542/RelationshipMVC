using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelationshipsMVC.Models
{
    public class Paging
    {
        public  int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }

    }
}
