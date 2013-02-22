using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Repository.Models.Mapping;

namespace Repository.Models
{
    public partial class BPDbContext : DbContext
    {
        static BPDbContext()
        {
            Database.SetInitializer<BPDbContext>(null);
        }

        public BPDbContext() : base("Name=BPDbContext")
        {
        }

        public DbSet<Archive> Archives { get; set; }
        public DbSet<ArchiveStation> ArchiveStations { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<BatteryCharging> BatteryChargings { get; set; }
        public DbSet<BatteryCollection> BatteryCollections { get; set; }
        public DbSet<BatteryStorage> BatteryStorages { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<ClientApplication> ClientApplications { get; set; }
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<StationMaintenance> StationMaintenances { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<StationType> StationTypes { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArchiveMap());
            modelBuilder.Configurations.Add(new ArchiveStationMap());
            modelBuilder.Configurations.Add(new BatteryMap());
            modelBuilder.Configurations.Add(new BatteryChargingMap());
            modelBuilder.Configurations.Add(new BatteryCollectionMap());
            modelBuilder.Configurations.Add(new BatteryStorageMap());
            modelBuilder.Configurations.Add(new BookmarkMap());
            modelBuilder.Configurations.Add(new CarModelMap());
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new ClientApplicationMap());
            modelBuilder.Configurations.Add(new MaintenanceTypeMap());
            modelBuilder.Configurations.Add(new ManufacturerMap());
            modelBuilder.Configurations.Add(new ReservationMap());
            modelBuilder.Configurations.Add(new StationMaintenanceMap());
            modelBuilder.Configurations.Add(new StationMap());
            modelBuilder.Configurations.Add(new StationTypeMap());
            modelBuilder.Configurations.Add(new UserCarMap());
            modelBuilder.Configurations.Add(new UserMap());
        }
    }
}
