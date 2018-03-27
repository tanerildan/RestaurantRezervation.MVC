using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.DAL.Entities
{
    public class Masalar
    {
        public Masalar()
        {
            Tarih = DateTime.Now;
        }
        public int ID { get; set; }
        public string MasaAdi { get; set; }
        public int BaslangicSaati { get; set; }
        public int BitisSaati { get; set; }
        public DateTime Tarih { get; set; }
        public Boolean Rezervemi { get; set; }

        public virtual ICollection<Rezervasyon> Rezervasyonlar { get; set; }
    }
}
