using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Mapping
{
   public class RezervasyonMapping:EntityTypeConfiguration<Rezervasyon>
    {
        public RezervasyonMapping()
        {
            HasKey<int>(x => x.ID);


            Property(x => x.RezGunu).
               IsRequired().
                HasColumnType("datetime");
            
            Property(x => x.RezSaati).
               IsRequired().
                HasColumnType("int");
            
            Property(x => x.RezBitSaati).
              IsRequired().
                HasColumnType("int");

            Property(x => x.MusteriAd).
             IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(15);

            Property(x => x.MusteriSoyad).
               IsRequired().
               HasColumnType("nvarchar").
               HasMaxLength(15);

            Property(x => x.MusteriTel).
              IsRequired().
              HasColumnType("nvarchar").
              HasMaxLength(15);

            Property(x => x.MasaId).
                IsRequired().
                HasColumnType("int");

        }
    }
}
