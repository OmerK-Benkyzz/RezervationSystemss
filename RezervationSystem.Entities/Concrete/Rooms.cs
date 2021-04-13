using RezervationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Entities.Concrete
{
  public class Rooms:IEntity
    {
        public int RoomId{ get; set; }
        public DateTime RezervasyonBaslangic{ get; set; }
        public DateTime RezervasyonBitis{ get; set; }
        public bool dolumu{ get; set; }
        public int MusteriId{ get; set; }
        public Customers customers { get; set; }
    }
}
