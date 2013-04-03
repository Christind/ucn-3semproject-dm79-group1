using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Salt)
                .IsRequired()
                .HasMaxLength(256);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.APIKey)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Salt).HasColumnName("Salt");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.APIKey).HasColumnName("APIKey");
            this.Property(t => t.LocLat).HasColumnName("LocLat");
            this.Property(t => t.LocLong).HasColumnName("LocLong");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
