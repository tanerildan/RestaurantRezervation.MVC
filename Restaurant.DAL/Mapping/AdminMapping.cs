using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Mapping
{
   public class AdminMapping:EntityTypeConfiguration<Yonetim>
    {
        public AdminMapping()
        {
            Property(x => x.Email).
                IsRequired().
                HasColumnType("nvarchar");
            Property(x => x.Password).
                IsRequired().
                HasColumnType("nvarchar");
        }
    }
}
