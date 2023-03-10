// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaxiDBData;

#nullable disable

namespace TaxiData.Migrations
{
    [DbContext(typeof(TaxiDBContext))]
    partial class TaxiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaxiDomain.Car", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarClassID")
                        .HasColumnType("int");

                    b.Property<int>("CarTypeID")
                        .HasColumnType("int");

                    b.Property<int>("ChildSeat")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastDateMaintenance")
                        .HasColumnType("datetime2");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdYear")
                        .HasColumnType("int");

                    b.HasKey("VIN");

                    b.HasIndex("CarClassID");

                    b.HasIndex("CarTypeID");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("TaxiDomain.CarClass", b =>
                {
                    b.Property<int>("CarClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarClassID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarClassID");

                    b.ToTable("CarClasses");
                });

            modelBuilder.Entity("TaxiDomain.CarType", b =>
                {
                    b.Property<int>("CarTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarTypeID"));

                    b.Property<int>("AmountSeats")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarTypeID");

                    b.ToTable("CarTypes");
                });

            modelBuilder.Entity("TaxiDomain.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<string>("AdressFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdressTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<float>("DriverPercent")
                        .HasColumnType("real");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("PaymentMethode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PriceOfOrder")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StatusOfOrder")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("ClientID");

                    b.HasIndex("DriverID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("TaxiDomain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TaxiDomain.RatingComment", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderID1")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.HasKey("OrderID");

                    b.HasIndex("OrderID1");

                    b.ToTable("RatingComments");
                });

            modelBuilder.Entity("TaxiDomain.TaxiDepartment", b =>
                {
                    b.Property<int>("TaxiDepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxiDepartmentID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Home")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaxiDepartmentID");

                    b.ToTable("TaxiDepartments");
                });

            modelBuilder.Entity("TaxiDomain.WorkShift", b =>
                {
                    b.Property<int>("DriverID")
                        .HasColumnType("int");

                    b.Property<int>("NumberWorkShift")
                        .HasColumnType("int");

                    b.Property<int>("AmountOrders")
                        .HasColumnType("int");

                    b.Property<float>("EarnMoney")
                        .HasColumnType("real");

                    b.Property<DateTime>("TimeFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeTo")
                        .HasColumnType("datetime2");

                    b.HasKey("DriverID", "NumberWorkShift");

                    b.ToTable("WorkShifts");
                });

            modelBuilder.Entity("TaxiDomain.Client", b =>
                {
                    b.HasBaseType("TaxiDomain.Person");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("TaxiDomain.Driver", b =>
                {
                    b.HasBaseType("TaxiDomain.Person");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CarVIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(17)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxiDepartmentID")
                        .HasColumnType("int");

                    b.HasIndex("CarVIN");

                    b.HasIndex("TaxiDepartmentID");

                    b.HasDiscriminator().HasValue("Driver");
                });

            modelBuilder.Entity("TaxiDomain.Car", b =>
                {
                    b.HasOne("TaxiDomain.CarClass", "CarClass")
                        .WithMany("Cars")
                        .HasForeignKey("CarClassID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaxiDomain.CarType", "CarType")
                        .WithMany("Cars")
                        .HasForeignKey("CarTypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CarClass");

                    b.Navigation("CarType");
                });

            modelBuilder.Entity("TaxiDomain.Order", b =>
                {
                    b.HasOne("TaxiDomain.Client", "Client")
                        .WithMany("orders")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaxiDomain.Driver", "Driver")
                        .WithMany("orders")
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TaxiDomain.RatingComment", b =>
                {
                    b.HasOne("TaxiDomain.Order", "Order")
                        .WithMany("RatingComments")
                        .HasForeignKey("OrderID1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("TaxiDomain.WorkShift", b =>
                {
                    b.HasOne("TaxiDomain.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("TaxiDomain.Driver", b =>
                {
                    b.HasOne("TaxiDomain.Car", "Car")
                        .WithMany("Drivers")
                        .HasForeignKey("CarVIN")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TaxiDomain.TaxiDepartment", "TaxiDepartment")
                        .WithMany("drivers")
                        .HasForeignKey("TaxiDepartmentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("TaxiDepartment");
                });

            modelBuilder.Entity("TaxiDomain.Car", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("TaxiDomain.CarClass", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("TaxiDomain.CarType", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("TaxiDomain.Order", b =>
                {
                    b.Navigation("RatingComments");
                });

            modelBuilder.Entity("TaxiDomain.TaxiDepartment", b =>
                {
                    b.Navigation("drivers");
                });

            modelBuilder.Entity("TaxiDomain.Client", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("TaxiDomain.Driver", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
