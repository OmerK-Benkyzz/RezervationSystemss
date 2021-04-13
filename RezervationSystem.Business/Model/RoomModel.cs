using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Business.Model
{
   public class RoomModel
    {
        public int RoomId { get; set; }
        public int kat{ get; set; }
        public int roomNumber { get; set; }
        public int odaTur {get; set; }
        public string odaTurAdi { get; set; }
    }
}
