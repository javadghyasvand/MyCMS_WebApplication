using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBase;
using DataBase.Context;

namespace MyCMS_WebApplication.Areas.Admin.Controllers
{
    public class PagesController : Controller
    {
        private readonly MyCmsContext _myCmsContext=new MyCmsContext();


        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(_myCmsContext.Page.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = _myCmsContext.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return PartialView(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,PageGroupsId,PageTitle,ShortDescription,Description,Visit,ImageName,ShowInSlider,CreateDate")] Page page)
        {
            if (ModelState.IsValid)
            {
                _myCmsContext.InsertPage(page);
                _myCmsContext.Save();
                return RedirectToAction("Index");
            }

            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = _myCmsContext.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageId,PageGroupsId,PageTitle,ShortDescription,Description,Visit,ImageName,ShowInSlider,CreateDate")] Page page)
        {
            if (ModelState.IsValid)
            {
                _myCmsContext.UpdatePage(page);
                _myCmsContext.Save();
                return RedirectToAction("Index");
            }
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = _myCmsContext.GetPageById(id.Value);
            _myCmsContext.DeletePage(page);
            _myCmsContext.Save(); 
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Page page = _myCmsContext.GetPageById(id);
            _myCmsContext.DeletePage(page);
            _myCmsContext.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _myCmsContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
