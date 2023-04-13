using System.Data.Entity;

namespace DataBase
{
    public class MyCmsContext:DbContext
    {
        public DbSet<PageGroup> PageGroup { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
    }
}
