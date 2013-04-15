using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class UserCarMap : EntityTypeConfiguration<UserCar>
    {
        public UserCarMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("UserCars");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CarId).HasColumnName("CarId");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.Car)
                .WithMany(t => t.UserCars)
                .HasForeignKey(d => d.CarId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.UserCars)
                .HasForeignKey(d => d.UserId);

        }
    }
}
