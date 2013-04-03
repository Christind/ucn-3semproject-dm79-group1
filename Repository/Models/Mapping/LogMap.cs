using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class LogMap : EntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Logs");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Exception).HasColumnName("Exception");
            this.Property(t => t.ExceptionLocation).HasColumnName("ExceptionLocation");
            this.Property(t => t.ClientInformation).HasColumnName("ClientInformation");
            this.Property(t => t.LogType).HasColumnName("LogType");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
        }
    }
}
