using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JW;

namespace Guestbook.Models
{
    public class GuestBookViewModel
    {
        public GuestbookItem[] GuestbookItems { get; set; }
        public Pager Pagination { get; set; }
    }
}
