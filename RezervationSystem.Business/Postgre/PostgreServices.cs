using Npgsql;
using RezervationSystem.Business.Model;
using RezervationSystem.DataAccess.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace RezervationSystem.Business.Postgre
{
  public  class PostgreServices :PGDatabase
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
                    roomModel.roomNumber= Convert.ToInt32(reader["roomnumber"]);
                    roomModel.odaTurAdi = (reader["odaturu"]).ToString();
                    roomModels.Add(roomModel);
                }
                reader.Close();
                dbd.connClose();
            }
            return roomModels;
        }
    }
}
