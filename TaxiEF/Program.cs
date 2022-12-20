using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<TaxiDBData.TaxiDBContext>();
var options = optionsBuilder.Options;
using (TaxiDBData.TaxiDBContext context = new TaxiDBData.TaxiDBContext(options))
{
    Console.WriteLine(context.Cars.Count());
}
