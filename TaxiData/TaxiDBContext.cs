using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TaxiDomain;

namespace TaxiDBData
{
    public class TaxiDBContext : DbContext
    {
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<TaxiDepartment> TaxiDepartments { get; set; }
        public DbSet<RatingComment> RatingComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClasses { get; set; }
        public DbSet<Person> Persons { get; set; }

        private StreamWriter streamWriter = new StreamWriter("InfoLogs.log", append: false);
        private DbContextOptionsBuilder<TaxiDBContext> optionsBuilder;

        public TaxiDBContext(DbContextOptions options) : base(options)
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaxiDBContext).Assembly);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string? connectionString = config.GetConnectionString("MyConnection");

            optionsBuilder.UseSqlServer(connectionString!).
                LogTo(streamWriter.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information).
                EnableSensitiveDataLogging();
        }
        public override void Dispose()
        {
            streamWriter.Dispose();
            base.Dispose();
        }
    }
}