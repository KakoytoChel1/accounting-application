using Microsoft.EntityFrameworkCore;

namespace AccountingApp.Model
{
    class ApplicationContext : DbContext
    {
        public DbSet<FinanceItem> FinanceItems => Set<FinanceItem>();
        public DbSet<CategoryItem> CategoryItems => Set<CategoryItem>();
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mainDB.db");
        }
    }
}
