using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ReservationMap : EntityTypeConfiguration<Reservation>
    {
        public ReservationMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("Reservations");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.StationId).HasColumnName("StationId");
            Property(t => t.ExpiredDate).HasColumnName("ExpiredDate");
            Property(t => t.CompletedDate).HasColumnName("CompletedDate");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            HasRequired(t => t.Station)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.StationId);
            HasRequired(t => t.User)
                .WithMany(t => t.Reservations)
                .HasForeignKey(d => d.UserId);
        }
    }
}