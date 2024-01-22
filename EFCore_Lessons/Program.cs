using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace EFCore_Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection")).Options;

            //using (ApplicationContext db = new ApplicationContext(options))
            //{
            //    db.Database.EnsureDeleted();
            //    db.Database.EnsureCreated();
            //}

            //using (ApplicationContext db = new ApplicationContext(options))
            //{
            //    User[] users = [
            //        new User
            //        {
            //            Name = "John Doe",
            //            Age = 30,
            //            Email = "john.doe@example.com"
            //        },
            //        new User
            //        {
            //            Name = "Jane Smith",
            //            Age = 25,
            //            Email = "jane.smith@example.com"
            //        },
            //        new User
            //        {
            //            Name = "Robert Johnson",
            //            Age = 35,
            //            Email = "robert.johnson@example.com"
            //        },
            //    ];

            //    db.Users.AddRange(users);
            //    db.SaveChanges();
            //}

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var allUsers = db.Users.ToList();
            }


        }
    }
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
