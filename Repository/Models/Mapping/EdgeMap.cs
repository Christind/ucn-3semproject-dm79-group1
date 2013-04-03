using System.Data.Entity.ModelConfiguration;

namespace Repository.Models.Mapping
{
    public class EdgeMap : EntityTypeConfiguration<Edge>
    {
        public EdgeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Edges");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.StartStation).HasColumnName("StartStation");
            this.Property(t => t.EndStation).HasColumnName("EndStation");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.Time).HasColumnName("Time");
        }
    }
}
