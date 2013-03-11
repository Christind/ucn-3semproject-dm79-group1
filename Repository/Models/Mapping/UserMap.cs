using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.Salt)
                .IsRequired()
                .HasMaxLength(256);

            Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(128);

            Property(t => t.APIKey)
                .IsRequired()
                .HasMaxLength(64);

            // Table & Column Mappings
            ToTable("Users");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.Salt).HasColumnName("Salt");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.APIKey).HasColumnName("APIKey");
            Property(t => t.LocLat).HasColumnName("LocLat");
            Property(t => t.LocLong).HasColumnName("LocLong");
            Property(t => t.IsActive).HasColumnName("IsActive");
            Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}