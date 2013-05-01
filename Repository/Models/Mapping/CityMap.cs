using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models.Mapping
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            // Primary Key
            this.HasKey(t => t.CityId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Cities");
            this.Property(t => t.CityId).HasColumnName("CityId");
            this.Property(t => t.CityName).HasColumnName("CityName");
            this.Property(t => t.ZipCode).HasColumnName("ZipCode");
        }
    }
}
