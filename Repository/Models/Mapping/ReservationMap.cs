using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Reservations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StationId).HasColumnName("StationId");
            this.Property(t => t.ExpiredDate).HasColumnName("ExpiredDate");
            this.Property(t => t.CompletedDate).HasColumnName("CompletedDate");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.Station)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.StationId);
            this.HasRequired(t => t.User)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.UserId);

        }
    }
}
