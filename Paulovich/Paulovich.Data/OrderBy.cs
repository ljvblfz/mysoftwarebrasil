using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Paulovich.Data
{
    public class OrderBy
    {
        public string Member { get; set; }
        public ListSortDirection SortDirection { get; set; }

        public OrderBy()
        {
            
        }

        public OrderBy(string member, ListSortDirection sortDirection)
        {
            this.Member = member;
            this.SortDirection = sortDirection;
        }
    }
}
