using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class StationMap : EntityTypeConfiguration<Station>
    {
        public StationMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(128);

            // Table & Column Mappings
            ToTable("Stations");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.TypeId).HasColumnName("TypeId");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.StationLat).HasColumnName("StationLat");
            Property(t => t.StationLong).HasColumnName("StationLong");
            Property(t => t.IsOperational).HasColumnName("IsOperational");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            //this.HasRequired(t => t.StationType)
            //    .WithMany(t => t.Stations)
            //    .HasForeignKey(d => d.TypeId);
        }
    }
}