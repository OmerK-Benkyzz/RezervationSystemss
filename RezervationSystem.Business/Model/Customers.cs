using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Business.Model
{
    public class Customers
    {
        public int id { get; set; }

        public string ad { get; set; }

        public string soyad { get; set; }

        public bool cocukvarmi { get; set; }

        public int roomId { get; set; }

        public DateTime r_baslama { get; set; }

        public DateTime r_bitis { get; set; }

        public string kalinacakGunSayisi { get; set; }

        public string notlar { get; set; }

        public string email { get; set; }
    }
}
