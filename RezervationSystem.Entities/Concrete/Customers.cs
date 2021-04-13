using RezervationSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Entities.Concrete
{
   public class Customers:IEntity
    {
        public int CustomerId{ get; set; }
        public bool HasChildren{ get; set; }
        public double Ucret{ get; set; }
        public string Ad{ get; set; }
        public string Soyad{ get; set; }
        public int Cocuksayisi{ get; set; }
        public int KisiSayisi{ get; set; }
        public Rooms rooms { get; set; }

    }
}
