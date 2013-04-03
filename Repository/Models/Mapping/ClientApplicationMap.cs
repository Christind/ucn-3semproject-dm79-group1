using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ClientApplicationMap : EntityTypeConfiguration<ClientApplication>
    {
        public ClientApplicationMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.AppKey)
                .IsRequired()
                .HasMaxLength(64);

            this.Property(t => t.CryptoKey)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("ClientApplications");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AppKey).HasColumnName("AppKey");
            this.Property(t => t.CryptoKey).HasColumnName("CryptoKey");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
