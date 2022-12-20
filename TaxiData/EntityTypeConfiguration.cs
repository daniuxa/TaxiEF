using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaxiDomain;

namespace TaxiData
{
    public class CarTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.VIN);
            builder.Property(x => x.VIN).HasMaxLength(17);
            builder.HasOne(x => x.CarClass).WithMany(y => y.Cars).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.CarType).WithMany(y => y.Cars).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.LicensePlate).HasMaxLength(8);
        }
    }

    public class DriverTypeConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(x => x.Phone).HasMaxLength(10);
            builder.HasOne(x => x.TaxiDepartment).WithMany(y => y.drivers).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Car).WithMany(y => y.Drivers).OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.Phone).HasMaxLength(8);
        }
    }

    public class WorkShiftTypeConfiguration : IEntityTypeConfiguration<WorkShift>
    {
        public void Configure(EntityTypeBuilder<WorkShift> builder)
        {
            builder.HasKey(y => new { y.DriverID, y.NumberWorkShift });
        }
    }
    public class OrderShiftTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(x => x.Client).WithMany(x => x.orders).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Driver).WithMany(y => y.orders).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class RatingCommentTypeConfiguration : IEntityTypeConfiguration<RatingComment>
    {
        public void Configure(EntityTypeBuilder<RatingComment> builder)
        {
            builder.HasKey(x => x.OrderID);
            builder.HasOne(x => x.Order).WithMany(x => x.RatingComments).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
