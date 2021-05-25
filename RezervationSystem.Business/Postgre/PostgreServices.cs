using Npgsql;
using RezervationSystem.Business.Model;
using RezervationSystem.DataAccess.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Business.Postgre
{
    public class PostgreServices : PGDatabase
    {


        public List<RoomModel> OdalariDoldur()
        {

            List<RoomModel> roomModels = new List<RoomModel>();
            using (PGDatabase dbd = new PGDatabase())
            {
                string command = "select rooms.* , odatype.odaturadi  as odaturu from rooms inner join odatype  on rooms.odatur  = odatype.id   ";
                NpgsqlDataReader reader = dbd.Reader(command);
                while (reader.Read())
                {
                    RoomModel roomModel = new RoomModel();
                    roomModel.RoomId = Convert.ToInt32(reader["roomid"]);
                    roomModel.kat = Convert.ToInt32(reader["kat"]);
                    roomModel.roomNumber = Convert.ToInt32(reader["roomnumber"]);
                    roomModel.odaTurAdi = (reader["odaturu"]).ToString();
                    roomModels.Add(roomModel);
                }

                reader.Close();
                dbd.connClose();
            }
            return roomModels;
        }
        public List<RoomTypeModel> OdaTurlerComboBoxDoldur()
        {

            List<RoomTypeModel> roomTypeModels = new List<RoomTypeModel>();
            using (PGDatabase dbd = new PGDatabase())
            {
                string command = "select * from odatype ";
                NpgsqlDataReader reader = dbd.Reader(command);
                while (reader.Read())
                {
                    RoomTypeModel roomType = new RoomTypeModel();
                    roomType.id = Convert.ToInt32(reader["id"]);
                    roomType.odaTurAdi = (reader["odaturadi"]).ToString();
                    roomTypeModels.Add(roomType);
                }
                reader.Close();
                dbd.connClose();
            }
            return roomTypeModels;
        }
        public List<RoomModel> odalarDonmeId(int id)
        {

            List<RoomModel> roomModels = new List<RoomModel>();
            using (PGDatabase dbd = new PGDatabase())
            {
                string command = "select rooms.* , odatype.odaturadi  as odaturu from rooms inner join odatype  on rooms.odatur  = odatype.id  where odatype.id = " + id;
                NpgsqlDataReader reader = dbd.Reader(command);
                while (reader.Read())
                {
                    RoomModel roomModel = new RoomModel();
                    roomModel.RoomId = Convert.ToInt32(reader["roomid"]);
                    roomModel.kat = Convert.ToInt32(reader["kat"]);
                    roomModel.roomNumber = Convert.ToInt32(reader["roomnumber"]);
                    roomModel.odaTurAdi = (reader["odaturu"]).ToString();
                    roomModels.Add(roomModel);
                }
                reader.Close();
                dbd.connClose();
            }
            return roomModels;
        }
        public void MusteriKaydet(string girisGun, string cikisGun, string musteriAd, string musteriSoyad, string ucretToplam, string gunToplam, string odaNumber, string email, string cocukSayisi, string not, bool chckMi)
        {
            int kayitIDsi = 0;
            PGDatabase pgdb = new PGDatabase();
            if (chckMi = false)
            {
                cocukSayisi = "0";

            }
            using (pgdb)
            {
                string commandsql = "";
                commandsql = ("insert into customers (haschildren,ucret,ad,soyad,cocuksayisi,kisiSayisi,roomNumber,r_baslama,r_bitis,kalicakgunsayisi,notlar,email) values("
                        + chckMi + ","
                        + Convert.ToInt32(ucretToplam) + ",'"
                        + musteriAd + "','"
                        + musteriSoyad + "',"
                        + Convert.ToInt32(cocukSayisi) + ","
                        + Convert.ToInt32(cocukSayisi) + ","
                        + Convert.ToInt32(odaNumber) + ",'"
                        + girisGun + "','"
                        + cikisGun + "',"
                        + Convert.ToInt32(gunToplam) + ",'"
                        + not + "','"
                        + email +
                           "')returning id");
                string token = pgdb.neSayisi(commandsql);
                int.TryParse(token, out kayitIDsi);
                pgdb.connClose();

            }


        }
        public List<Customers> RezervasyonlariGetirIdle(int roomId)
        {
            List<Customers> customers = new List<Customers>();

            string command = "select r_baslama,r_bitis,roomnumber from customers where roomnumber ="+roomId+ "";
            using (PGDatabase dbd = new PGDatabase())
            {
                NpgsqlDataReader reader = dbd.Reader(command);
                while (reader.Read())
                {
                    Customers customer = new Customers();
                    customer.roomId= Convert.ToInt32(reader["roomnumber"]);
                    customer.r_baslama = Convert.ToDateTime(reader["r_baslama"]);
                    customer.r_bitis = Convert.ToDateTime(reader["r_bitis"]);
                    customers.Add(customer);
                }
                reader.Close();
                dbd.connClose();
            }
            return customers;

        }
    }
}
