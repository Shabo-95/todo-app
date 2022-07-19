using Microsoft.EntityFrameworkCore;

namespace todo_app_server.Data
{
    internal sealed class DatabaseContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder) => dbContextOptionsBuilder.UseSqlite("Data Source=./Data/Database.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            Entry[] staticEntries = new Entry[5];

            for (int i = 1; i<= 5; i++)
            {
                staticEntries[i - 1] = new Entry
                {
                    TodoID = i,
                    TodoTitel = $"Todo Item {i}",
                    TodoIsFinished = false,
                };
            }

            modelBuilder.Entity<Entry>().HasData(staticEntries);
        }
    }
}
