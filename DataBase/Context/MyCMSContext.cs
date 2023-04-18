using System.Data.Entity;
using DataBase.Models;

namespace DataBase
{
    public class MyCmsContext:DbContext
    {
        public DbSet<PageGroup> PageGroup { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageComment> PageComments { get; set; }

        public DbSet<Login> Logins { get; set; }
    }
}
