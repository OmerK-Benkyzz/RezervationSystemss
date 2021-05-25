using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RezervationSystem.Models;
using RezervationSystem.Business;
using RezervationSystem.Business.Postgre;
using RezervationSystem.UI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace RezervationSystem.Controllers
{
    public class HomeController : Controller
    {

        PostgreServices postgreServices;

        public HomeController()
        {
            postgreServices = new PostgreServices();


        }
        public IActionResult Index()
        {
            var gelen = OdalariDoldur();
            return View();
        }

        public IActionResult PaymentStart()
        {
            return View();
        }

        public JsonResult OdalariDoldur()
        {
            List<RoomViewModel> roomViews = new List<RoomViewModel>();
            var odalar = postgreServices.OdalariDoldur();
            foreach (var item in odalar)
            {
                RoomViewModel _roomViewModels = new RoomViewModel();
                _roomViewModels.RoomId = item.RoomId;
                _roomViewModels.odaTurAdi = item.odaTurAdi;
                _roomViewModels.roomNumber = item.roomNumber;
                _roomViewModels.kat = item.kat;
                roomViews.Add(_roomViewModels);
            }
            return Json(new
            {
                roomViews
            });
        }

        public JsonResult ComboBoxaListele()
        {
            List<RoomTypeViewModel> roomTypes = new List<RoomTypeViewModel>();
            var odaTurleriListele = postgreServices.OdaTurlerComboBoxDoldur();
            foreach (var item in odaTurleriListele)
            {
                RoomTypeViewModel odaTurler = new RoomTypeViewModel();
                odaTurler.odaTurAdi = item.odaTurAdi;
                odaTurler.id = item.id;
                roomTypes.Add(odaTurler);
            }
            return Json(new
            {
                roomTypes
            });
        }


        public JsonResult MusteriKaydet(string girisGun, string cikisGun, string musteriAd, string musteriSoyad,string ucretToplam,string gunToplam,string odaNumber,string email,string cocukSayisi,string not,bool chckMi)
        {

            //string parseGunGiris = girisGun.Replace('/', '-');  
            //string parseGunCikis = cikisGun.Replace('/', '-');
            //DateTime _girisGun = Convert.ToDateTime(girisGun);
            //DateTime _cikisGun = Convert.ToDateTime(cikisGun);
            string parseGunGiris = DateTime.ParseExact(girisGun, "yyyy-d-M", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            string parseGunCikis = DateTime.ParseExact(cikisGun, "yyyy-d-M", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
            string _parseGunGiris = parseGunGiris.Replace('.', '-');
            string _parseGunCikis = parseGunCikis.Replace('.', '-');
            //DateTime parseGunCikis = DateTime.ParseExact(cikisGun, "dd/MM/yyyy", null);
            postgreServices.MusteriKaydet(_parseGunGiris, _parseGunCikis,  musteriAd,  musteriSoyad,  ucretToplam,  gunToplam,  odaNumber,  email,  cocukSayisi,  not, chckMi);
            return Json(true);

        }

        public JsonResult RezervasyonMusaitMi(int roomId,string girisGun,string cikisGun)
        {
            //string parseGunGiris = girisGun.Replace('/', '.');
            var gelenNe = postgreServices.RezervasyonlariGetirIdle(1);
            //DateTime gelenGun =  Convert.ToDateTime(girisGun);
            DateTime date = DateTime.ParseExact(girisGun, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime dateDeneme = DateTime.ParseExact("05/13/2021", "MM/dd/yyyy", CultureInfo.InvariantCulture);
            //var bune = DateTime.ParseExact(girisGun, "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy");
            //DateTime gelenGun = Convert.ToDateTime(bune);
            var a = gelenNe.Where(x => x.roomId == roomId).Any(r => r.r_baslama <= date && r.r_bitis >= date);
            var b = gelenNe.Where(x => x.roomId == roomId).Any(r => r.r_bitis == date);
            if (a == true)
            {
                    if (b == true && a == true)
                {

                    return Json(true);
                }
                return Json(false);

            }
            return Json(true);
        }

        public JsonResult OdalariListele(int odaIdsi)
        {
            List<RoomViewModel> rooms = new List<RoomViewModel>();
            var odaTurleriListele = postgreServices.odalarDonmeId(odaIdsi);
            foreach (var item in odaTurleriListele)
            {
                RoomViewModel odalar = new RoomViewModel();
                odalar.roomNumber = item.roomNumber;
                odalar.RoomId = item.RoomId;
                rooms.Add(odalar);
            }
            return Json(new
            {
                rooms
            });
        }



        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
