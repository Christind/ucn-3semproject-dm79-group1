using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ArchiveMap : EntityTypeConfiguration<Archive>
    {
        public ArchiveMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            ToTable("Archives");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.StartLat).HasColumnName("StartLat");
            Property(t => t.EndLat).HasColumnName("EndLat");
            Property(t => t.StartLong).HasColumnName("StartLong");
            Property(t => t.EndLong).HasColumnName("EndLong");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            HasRequired(t => t.User)
                .WithMany(t => t.Archives)
                .HasForeignKey(d => d.UserId);
        }
    }
}