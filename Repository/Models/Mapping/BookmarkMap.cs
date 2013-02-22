using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class BookmarkMap : EntityTypeConfiguration<Bookmark>
    {
        public BookmarkMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(512);

            // Table & Column Mappings
            this.ToTable("Bookmarks");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.StartLat).HasColumnName("StartLat");
            this.Property(t => t.EndLat).HasColumnName("EndLat");
            this.Property(t => t.StartLong).HasColumnName("StartLong");
            this.Property(t => t.EndLong).HasColumnName("EndLong");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.Bookmarks)
                .HasForeignKey(d => d.UserId);

        }
    }
}
