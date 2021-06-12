using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RezervationSystem.Business.Model;
using RezervationSystem.Business.Postgre;
using Newtonsoft.Json;


namespace RezervationSystem.UI.Controllers
{
    //RandevulariGetir
    public class AdminController : Controller
    {
        PostgreServices postgreServices;

        public AdminController()
        {
            postgreServices = new PostgreServices();


        }
        public IActionResult Index()
        {

            return View();

        }

        public JsonResult Customerla()
        {
            List<Customers> customers = new List<Customers>();
            var randvevular = postgreServices.RandevulariGetir();
            foreach (var item in randvevular)
            {
                Customers cstm = new Customers();
                cstm.ad = item.ad;
                cstm.id = item.id;
                cstm.soyad = item.soyad;
                cstm.cocuksayisi = item.cocuksayisi;
                cstm.cocukvarmi = item.cocukvarmi;
                cstm.email = item.email;
                cstm.notlar = item.notlar;
                cstm.odanumarasi = item.odanumarasi;
                cstm.odaturu = item.odaturu;
                cstm.r_baslama = item.r_baslama;
                cstm.r_bitis = item.r_bitis;
                cstm.notlar = item.notlar;
                customers.Add(cstm);
            }
            var orders = customers;

            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                //total number of rows count   
                recordsTotal = orders.Count();
                //Paging   
                var data1 = orders.ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data1 });

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        //n in data)
        //    {
        //        Customers cstm = new Customers();
        //        cstm.ad = item.ad;
        //        cstm.id = item.id;
        //        cstm.soyad = item.soyad;
        //        cstm.cocuksayisi = item.cocuksayisi;
        //        cstm.cocukvarmi = item.cocukvarmi;
        //        cstm.email = item.email;
        //        cstm.notlar = item.notlar;
        //        cstm.odanumarasi = item.odanumarasi;
        //        cstm.odaturu = item.odaturu;
        //        cstm.r_baslama = item.r_baslama;
        //        cstm.r_bitis = item.r_bitis;
        //        cstm.notlar = item.notlar;
        //        customers.Add(cstm);


        //    }
        //    var orders = customers;

        //    try
        //    {
        //        var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
        //        // Skiping number of Rows count  
        //        var start = Request.Form["start"].FirstOrDefault();
        //        // Paging Length 10,20  
        //        var length = Request.Form["length"].FirstOrDefault();
        //        // Sort Column Name  
        //        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        //        // Sort Column Direction ( asc ,desc)  
        //        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        //        // Search Value from (Search box)  
        //        var searchValue = Request.Form["search[value]"].FirstOrDefault();

        //        //Paging Size (10,20,50,100)  
        //        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        //        int skip = start != null ? Convert.ToInt32(start) : 0;
        //        int recordsTotal = 0;


        //        //total number of rows count   
        //        recordsTotal = orders.Count();
        //        //Paging   
        //        var data1 = orders.ToList();
        //        //Returning Json Data  
        //        return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data1 });

        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }

        //}
        public JsonResult RezervasyonBitti(int id)
        {
            postgreServices.RezervasyonDone(id);
            return Json(true);
        }
        public JsonResult RezervasyonIptal(int id)
        {
            postgreServices.RezervasyonIptal(id);
            return Json(true);
        }

        public JsonResult CustomerlaBitmisler()
        {
            List<Customers> customers = new List<Customers>();
            var data = postgreServices.RandevulariGetirBitmis();

            foreach (var item in data)
            {
                Customers cstm = new Customers();
                cstm.ad = item.ad;
                cstm.id = item.id;
                cstm.soyad = item.soyad;
                cstm.cocuksayisi = item.cocuksayisi;
                cstm.cocukvarmi = item.cocukvarmi;
                cstm.email = item.email;
                cstm.notlar = item.notlar;
                cstm.odanumarasi = item.odanumarasi;
                cstm.odaturu = item.odaturu;
                cstm.r_baslama = item.r_baslama;
                cstm.r_bitis = item.r_bitis;
                cstm.notlar = item.notlar;
                customers.Add(cstm);
            }
            var orders = customers;
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                //total number of rows count   
                recordsTotal = orders.Count();
                //Paging   
                var data1 = orders.ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data1 });

            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public JsonResult CustomerlaIptal()
        {
            List<Customers> customers = new List<Customers>();
            var data = postgreServices.RandevulariGetirIptaller();

            foreach (var item in data)
            {
                Customers cstm = new Customers();
                cstm.ad = item.ad;
                cstm.id = item.id;
                cstm.soyad = item.soyad;
                cstm.cocuksayisi = item.cocuksayisi;
                cstm.cocukvarmi = item.cocukvarmi;
                cstm.email = item.email;
                cstm.notlar = item.notlar;
                cstm.odanumarasi = item.odanumarasi;
                cstm.odaturu = item.odaturu;
                cstm.r_baslama = item.r_baslama;
                cstm.r_bitis = item.r_bitis;
                cstm.notlar = item.notlar;
                customers.Add(cstm);
            }
            var orders = customers;
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                //total number of rows count   
                recordsTotal = orders.Count();
                //Paging   
                var data1 = orders.ToList();
                //Returning Json Data  
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data1 });

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}