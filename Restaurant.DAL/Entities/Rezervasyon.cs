using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
   public  class Rezervasyon
    {
        public int ID { get; set; }
        public DateTime? RezGunu { get; set; }
        public int RezSaati { get; set; }
        public int RezBitSaati { get; set; }
        public string MusteriAd { get; set; }
        public string MusteriSoyad { get; set; }
        public string MusteriTel { get; set; }
        public int MasaId { get; set; }

        public virtual Masalar Masa { get; set; }
    }
}
