using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ArchiveMap : EntityTypeConfiguration<Archive>
    {
        public ArchiveMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Archives");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.StartLat).HasColumnName("StartLat");
            this.Property(t => t.EndLat).HasColumnName("EndLat");
            this.Property(t => t.StartLong).HasColumnName("StartLong");
            this.Property(t => t.EndLong).HasColumnName("EndLong");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Archives)
                .HasForeignKey(d => d.UserId);

        }
    }
}
