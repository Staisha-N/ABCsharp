using Microsoft.EntityFrameworkCore;

namespace ABCsharp.Models
{
    public class StartContext : DbContext
    {
        public DbSet<ConceptModel>? Concepts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite(@"Data Source=C:\Users\cprrc\OneDrive\Desktop\Coding\ConceptData.db");
    }
}
