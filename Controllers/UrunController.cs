using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;


namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db=new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler= db.TBLURUNLER.ToList();
            return View(degerler);
           
        }

                                            

        [HttpGet]
        public ActionResult YenıUrun()
        {
            List<SelectListItem> degerrler = (from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KATEGORIAD,
                                                  Value = i.KATEGORIID.ToString()
                                              }).ToList();
            ViewBag.dgr = degerrler;
            return View();
           
        }
        [HttpPost]
        public ActionResult YenıUrun(TBLURUNLER p1)
        {
            var ktgr = db.TBLKATEGORILER.Where(m=>m.KATEGORIID==p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORILER=ktgr;
            db.TBLURUNLER.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public  ActionResult SIL(int id)
        {
            var urunler=db.TBLURUNLER.Find(id);
            db.TBLURUNLER.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult UrunGetır(int id)
        {
            var urungt= db.TBLURUNLER.Find(id);
            List<SelectListItem> degerrler = (from i in db.TBLKATEGORILER.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = i.KATEGORIAD,
                                                  Value = i.KATEGORIID.ToString()
                                              }).ToList();
            ViewBag.dgr = degerrler;
        
            return View("UrunGetır",urungt);

        }
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            var urun=db.TBLURUNLER.Find(p1.URUNID);
            urun.URUNAD = p1.URUNAD;
            //urun.URUNKATAGORI = p1.URUNKATAGORI;
            urun.MARKA = p1.MARKA;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORIID == p1.TBLKATEGORILER.KATEGORIID).FirstOrDefault();
            urun.URUNKATAGORI = ktgr.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
       

        }
    }

}