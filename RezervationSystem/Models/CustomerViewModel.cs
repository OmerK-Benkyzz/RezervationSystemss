using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervationSystem.UI.Models
{
    public class CustomerViewModel
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
