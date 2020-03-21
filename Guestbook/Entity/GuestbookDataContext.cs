using Guestbook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Guestbook.Entity
{
    public class GuestbookDataContext: DbContext
    {
        public DbSet<GuestbookItem> GuestbookItem { get; set; }

        public GuestbookDataContext(DbContextOptions<GuestbookDataContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
