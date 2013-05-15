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
            this.Property(t => t.StartStationId).HasColumnName("StartStationId");
            this.Property(t => t.EndStationId).HasColumnName("EndStationId");
            this.Property(t => t.Distance).HasColumnName("Distance");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.IsActive).HasColumnName("IsActive");

            // Relationships
            this.HasRequired(t => t.EndStation)
                .WithMany(t => t.Edges)
                .HasForeignKey(d => d.EndStationId);

            //this.HasOptional(t => t.StartStation).WithMany(x => x.Edges)
            //.HasForeignKey(t => t.StartStationId);
        }
    }
}
