using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezervationSystem.UI.Models
{
    public class RoomViewModel
    {

        public int RoomId { get; set; }
        public int kat { get; set; }
        public int roomNumber { get; set; }
        public int odaTur { get; set; }
        public string odaTurAdi { get; set; }
    }
}
