using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Mapping
{
    public class MasalarMapping:EntityTypeConfiguration<Masalar>
    {
        public MasalarMapping()
        {
            HasKey<int>(x => x.ID);

            Property(x => x.MasaAdi).
                IsRequired().
                HasColumnType("nvarchar").
                HasMaxLength(5);


            Property(x => x.Rezervemi).
                IsRequired().
                HasColumnType("bit");

            Property(x => x.BaslangicSaati).
                IsRequired().
                HasColumnType("int");

            Property(x => x.BitisSaati).
                IsRequired().
                HasColumnType("int");

            Property(x => x.Tarih).IsRequired().
                HasColumnType("date");
        }
    }
}
