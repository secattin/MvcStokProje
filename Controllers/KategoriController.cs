using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using PagedList;
using PagedList.Mvc;


namespace MvcStok.Controllers
{
  
    public class KategoriController : Controller
    {

        // GET: Kategori,
        readonly MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler= db.TBLKATEGORILER.ToList();
            var degerler = db.TBLKATEGORILER.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenikategori(TBLKATEGORILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.TBLKATEGORILER.Add(p1);
            db.SaveChanges();
            return View();

        }
        public  ActionResult SIL(int id)
        {
            var kategori=db.TBLKATEGORILER.Find(id);
            db.TBLKATEGORILER.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr=db.TBLKATEGORILER.Find(id);
            return View("KategoriGetir",ktgr);
        }
        public ActionResult GUNCELLE(TBLKATEGORILER p1)
        {
            var ktg=db.TBLKATEGORILER.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
            

    }
}