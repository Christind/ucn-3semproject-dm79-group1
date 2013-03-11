using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BookmarkMap : EntityTypeConfiguration<Bookmark>
    {
        public BookmarkMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(512);

            // Table & Column Mappings
            ToTable("Bookmarks");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.StartLat).HasColumnName("StartLat");
            Property(t => t.EndLat).HasColumnName("EndLat");
            Property(t => t.StartLong).HasColumnName("StartLong");
            Property(t => t.EndLong).HasColumnName("EndLong");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            HasRequired(t => t.User)
                .WithMany(t => t.Bookmarks)
                .HasForeignKey(d => d.UserId);
        }
    }
}