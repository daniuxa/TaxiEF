using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TaxiDBData;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace TaxiData
{
    public class TaxiContextFactory : IDesignTimeDbContextFactory<TaxiDBContext>
    {
        public TaxiDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaxiDBContext>();

            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            IConfigurationRoot config = builder.Build();

            string? connectionString = config.GetConnectionString("MyConnection");
            optionsBuilder.UseSqlServer(connectionString!);
            return new TaxiDBContext(optionsBuilder.Options);
        }
    }
}
