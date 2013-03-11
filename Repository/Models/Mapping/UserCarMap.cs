using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class UserCarMap : EntityTypeConfiguration<UserCar>
    {
        public UserCarMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("UserCars");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.CarId).HasColumnName("CarId");

            // Relationships
            //this.HasRequired(t => t.Car)
            //    .WithMany(t => t.UserCars)
            //    .HasForeignKey(d => d.CarId);
            HasRequired(t => t.User)
                .WithMany(t => t.UserCars)
                .HasForeignKey(d => d.UserId);
        }
    }
}