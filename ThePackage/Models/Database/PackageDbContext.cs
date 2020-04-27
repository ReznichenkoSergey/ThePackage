using Microsoft.EntityFrameworkCore;
using ThePackage.Models.Entities;

namespace ThePackage.Models.Database
{
    public class PackageDbContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<Package> Package { get; set; }

        public DbSet<PackageType> PackageType { get; set; }

        public DbSet<Point> Point { get; set; }

        public DbSet<Units> Units { get; set; }

        public DbSet<Staff> Staff { get; set; }

        public DbSet<StaffToPoint> StaffToPoint { get; set; }

        public PackageDbContext(DbContextOptions<PackageDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Package>()
                .Property(x=>x.SumDeliver)
                .HasDefaultValue(0);
            modelBuilder.Entity<Package>()
                .Property(x => x.SumPayed)
                .HasDefaultValue(0);
            modelBuilder.Entity<Package>()
                .Property("DateInsert")
                .HasDefaultValueSql("GETDATE()");
            modelBuilder
                .Entity<PackageType>()
                .HasData(
                new PackageType[]
                {
                    new PackageType { Id=1, Name="Техника"},
                    new PackageType { Id=2, Name="Канцелярия"},
                    new PackageType { Id=3, Name="Стекло"},
                    new PackageType { Id=4, Name="Авто. детали"},
                    new PackageType { Id=5, Name="Одежда"},
                    new PackageType { Id=6, Name="Мебель"}

                });
            modelBuilder
                .Entity<Units>()
                .HasData(
                new Units[]
                {
                    new Units { Id=1, Name="К отправке", TypeId=0},
                    new Units { Id=2, Name="Отправлена", TypeId=0},
                    new Units { Id=3, Name="Получена на склад", TypeId=0},
                    new Units { Id=4, Name="Возврат", TypeId=0},
                    new Units{ Id =5, Name = "Выдана", TypeId=0}
                });
            modelBuilder
                .Entity<Units>()
                .HasData(
                new Units[]
                {
                    new Units { Id=10, Name="Менеджер", TypeId=1},
                    new Units { Id=11, Name="Кассир", TypeId=1},
                    new Units { Id=12, Name="Кладовщик", TypeId=1}
                });
        }
    }
}
