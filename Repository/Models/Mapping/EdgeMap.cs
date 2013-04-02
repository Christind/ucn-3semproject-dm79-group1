using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mapping
{
    public class EdgeMap : EntityTypeConfiguration<Edge>
    {
        public EdgeMap()
        {
            // Primary Key
            HasKey(t => t.Id);

            // Table & Column Mappings
            ToTable("Edges");
            Property(t => t.Id).HasColumnName("ID");
            Property(t => t.StartStation.ID).HasColumnName("StartStation");
            Property(t => t.EndStation.ID).HasColumnName("EndStation");
            Property(t => t.Distance).HasColumnName("Distance");
            Property(t => t.Time).HasColumnName("Time");
        }
    }
}
