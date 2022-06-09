using Microsoft.EntityFrameworkCore;

namespace BrogrammerChat.Data
{
    public class BrogrammerChatContext : DbContext
    {
        public DbSet<Content> Contents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
