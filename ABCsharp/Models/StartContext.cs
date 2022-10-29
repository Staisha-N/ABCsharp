using Microsoft.EntityFrameworkCore;

namespace ABCsharp.Models
{
    public class StartContext : DbContext
    {
        public DbSet<ConceptModel>? Concepts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite(@"Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), "ConceptData.db"));
    }
}
