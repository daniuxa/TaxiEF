using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaxiDBData;
using TaxiDomain;
namespace TaxiEF
{
    public static class RequestsToDB
    {
        static public void Add(DbContextOptions options)
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                CarClass econom = new() { Name = "Econom" };
                CarClass standart = new() { Name = "Standart" };
                CarClass lux = new() { Name = "Lux" };

                context.CarClasses.AddRange(econom, standart, lux);

                CarType sedan = new() { Name = "Sedan", AmountSeats = 4 };
                CarType suv = new() { Name = "SUV", AmountSeats = 4 };
                CarType cabriolet = new() { Name = "Cabriolet", AmountSeats = 1 };

                context.CarTypes.AddRange(suv, cabriolet, sedan);

                Car AudiA7 = new()
                { VIN = "AWERTYUIOP1234567", Brand = "Audi", Model = "A7", ProdYear = 2017, CarClass = lux, Mileage = 100000, LastDateMaintenance = new(2018, 12, 1), LicensePlate = "AA0000CC", CarType = sedan };
                Car BMWX5 = new()
                { VIN = "BWERTYUIOP1234567", Brand = "BMW", Model = "X5", ProdYear = 2018, CarClass = lux, Mileage = 100000, LastDateMaintenance = new(2018, 12, 1), LicensePlate = "AB0000CC", CarType = suv };
                Car SkodaOctavia = new()
                { VIN = "SWERTYUIOP1234567", Brand = "Skoda", Model = "Octavia", ProdYear = 2015, CarClass = standart, Mileage = 200000, LastDateMaintenance = new(2018, 12, 1), LicensePlate = "AC0000CC", CarType = sedan };

                context.Cars.AddRange(AudiA7, BMWX5, SkodaOctavia);

                context.SaveChanges();
            }
        }

        static public void Update(DbContextOptions options)
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                var auto = context.Cars.Where(x => x.VIN == "AWERTYUIOP1234567").FirstOrDefault();
                if (auto != null)
                {
                    auto.ProdYear = 2018;
                    context.SaveChanges();
                }
            }
        }

        static public void SelectFst(DbContextOptions options)
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                var Distinct = context.Cars.Select(y => new
                {
                    Brand = y.Brand
                }).Distinct();

                foreach (var item in Distinct)
                {
                    Console.WriteLine(item.Brand);
                }

                Console.WriteLine(new String('-', 40));

                var Second = context.Cars.Skip(1).Take(1);
                foreach (var item in Second)
                {
                    Console.WriteLine(item.VIN);
                }

                Console.WriteLine(new String('-', 40));

                var third = context.Cars.Include(x => x.CarType).Where(x => x.ProdYear < 2018).ToList();

                foreach (var item in third)
                {
                    Console.WriteLine(item.CarType.Name);
                }

                Console.WriteLine(new String('-', 40));

                var frth = context.Cars.
                    Join(context.CarTypes,
                    x => x.CarTypeID, 
                    y => y.CarTypeID, 
                    (x,y) => new {Brand = x.Brand, Model = x.Model, Type = y.Name} ).ToList();
                
                foreach (var item in frth)
                {
                    Console.WriteLine(item.Brand);
                }

                Console.WriteLine(new String('-', 40));

                var fifth = context.Cars.Where(x => EF.Functions.Like(x.Brand, "BM%")).ToList();

                foreach (var item in fifth)
                {
                    Console.WriteLine(item.Brand);
                }
            }
        }

        static public void SelectSnd(DbContextOptions options)
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                var Union = context.Drivers.Select(p => new { Phone = p.Phone }).Union(context.TaxiDepartments.Select(y => new { Phone = y.Phone })).ToList();

                foreach (var item in Union)
                {
                    Console.WriteLine(item.Phone);
                }

                Console.WriteLine(new String('-', 40));

                var GroupBy = from car in context.Cars
                              join type in context.CarTypes on car.CarTypeID equals type.CarTypeID
                              group car by car.CarType into g
                              select new
                              {
                                  g.Key,
                                  Count = g.Count()
                              };
                foreach (var item in GroupBy)
                {
                    Console.WriteLine(item.Key + " " + item.Count);
                }

                Console.WriteLine(new String('-', 40));

                var GroupByInclude = context.Cars.Include(x => x.CarType).GroupBy(x => x.CarType).Select(x => new
                {
                    Key = x.Key,
                    Count = x.Count()
                });

                foreach (var item in GroupByInclude)
                {
                    Console.WriteLine(item.Key + " " + item.Count);
                }
            }
        }
        static public void SelectAgregate(DbContextOptions options)
        {
            using (TaxiDBContext context = new TaxiDBContext(options))
            {
                int AmountCars = context.Cars.Count();
                Console.WriteLine(AmountCars);

                Console.WriteLine(new String('-', 80));

                int MinMilage = (int)context.Cars.Min(x => x.Mileage);
                int MaxMilage = (int)context.Cars.Max(x => x.Mileage);
                int AvgMilage = (int)context.Cars.Average(x => x.Mileage);
                int SumMilage = (int)context.Cars.Sum(x => x.Mileage);
                Console.WriteLine("Min: " + MinMilage);
                Console.WriteLine("Max: " + MaxMilage);
                Console.WriteLine("Avg: " + AvgMilage);
                Console.WriteLine("Sum: " + SumMilage);
            }
        }
    }      
}
