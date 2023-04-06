using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        private readonly IPageRepository _pageRepository;
        private readonly IPageGroupRepository _pageGroupRepository;
        readonly MyCmsContext _myCmsContext = new MyCmsContext();

        public PagesController()
        {
            _pageGroupRepository = new PageGroupRepository(_myCmsContext);
            _pageRepository = new PageRepository(_myCmsContext);
        }


        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(_pageRepository.GetAllPage());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = _pageRepository.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return PartialView(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GropID = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageId,PageGroupsId,PageTitle,ShortDescription,Description,Visit,ImageName,ShowInSlider,CreateDate")] Page page,HttpPostedFile ImgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate= DateTime.Now;
                if (ImgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(ImgUp.FileName);
                    ImgUp.SaveAs(Server.MapPath("/PageImages/"+page.ImageName));
                }
                _pageRepository.InsertPage(page);
                _pageRepository.Save();
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
            Page page = _pageRepository.GetPageById(id.Value);
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
                _pageRepository.UpdatePage(page);
                _pageRepository.Save();
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
            Page page = _pageRepository.GetPageById(id.Value);
            _pageRepository.DeletePage(page);
            _pageRepository.Save(); 
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
            Page page = _pageRepository.GetPageById(id);
            _pageRepository.DeletePage(page);
            _pageRepository.Save();
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
