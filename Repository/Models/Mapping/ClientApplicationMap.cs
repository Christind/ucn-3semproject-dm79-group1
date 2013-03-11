using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class ClientApplicationMap : EntityTypeConfiguration<ClientApplication>
    {
        public ClientApplicationMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(64);

            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.AppKey)
                .IsRequired()
                .HasMaxLength(64);

            Property(t => t.CryptoKey)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            ToTable("ClientApplications");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Title).HasColumnName("Title");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.AppKey).HasColumnName("AppKey");
            Property(t => t.CryptoKey).HasColumnName("CryptoKey");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}