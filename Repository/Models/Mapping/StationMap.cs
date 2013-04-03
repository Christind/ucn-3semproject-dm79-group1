using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationMap : EntityTypeConfiguration<Station>
    {
        public StationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            this.ToTable("Stations");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.TypeId).HasColumnName("TypeId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StationLat).HasColumnName("StationLat");
            this.Property(t => t.StationLong).HasColumnName("StationLong");
            this.Property(t => t.IsOperational).HasColumnName("IsOperational");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.StationType)
                .WithMany(t => t.Stations)
                .HasForeignKey(d => d.TypeId);

        }
    }
}
