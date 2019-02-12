using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewData["Message"] = "my message";
            TempData["Message"] = "gecici bilgi";
            int deg = 15;
            return View(deg);

           
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult TahminEt(int? tahmin)
        {
            if (Session["TuttugumSayi"] == null) {
                Session["TuttugumSayi"] = new Random().Next(10) + 1;

            }

            if (tahmin.HasValue) {

               
               

                if (tahmin == int.Parse(Session["TuttugumSayi"].ToString()))
                {

                    // return Content("Tebrikler,bildiniz");
                    ViewBag.Message = "Tebrikler,Bildiniz";
                    ViewBag.IsSuccess = true;
                }
                else
                {

                    // return Content($"Malesef bilemediniz :(Tutugum Sayi{tutugumSayi} idi.");
                    // ViewBag.Message = $"Malesef bilemediniz sayi{tutugumSayi} idi.";
                    ViewBag.Message = "Malesef Bilemediniz :( Lütfen Tekrar Deneyiniz";
                    ViewBag.IsSuccess = false;
                }



            }
            return View();
        }
        public ActionResult Replay()
        {
            Session["TuttugumSayi"] = new Random().Next(10) + 1;
            return RedirectToAction("TahminEt");


            
        }




        /*
         *
         *  public ActionResult TahminEt()
        {
            

            return View();
        }
  [HttpPost]
           public ActionResult TahminEt(int tahmin)
           {
           POST

               int tutugumSayi = new Random().Next(10) + 1;

               if (tahmin == tutugumSayi)
               {

                   return Content("Tebrikler,bildiniz");
               }
               else {

                   return Content($"Malesef bilemediniz :(Tutugum Sayi{tutugumSayi} idi.");
               }
           }*/
    }
}