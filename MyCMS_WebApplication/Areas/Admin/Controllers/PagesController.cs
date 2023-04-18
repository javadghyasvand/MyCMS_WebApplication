using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DataBase;

namespace MyCMS_WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
       
        private readonly IPageRepository _pageRepository;
        private readonly IPageGroupRepository _pageGroupRepository;
        private readonly MyCmsContext _cms = new MyCmsContext();

        public PagesController()
        {
            _pageRepository = new PageRepository(_cms);
            _pageGroupRepository = new PageGroupRepository(_cms);
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

            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupId = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupId", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include =
                "PageId,GroupId,PageTitle,ShortDescription,Description,Visit,ImageName,ShowInSlider,CreateDate,Tags")]
            Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                if (imgUp != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }

                _pageRepository.InsertPage(page);
                _pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupId", "GroupTitle",
                page.GroupId);
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

            ViewBag.GroupId = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupId", "GroupTitle",
                page.GroupId);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include =
                "PageId,GroupId,PageTitle,ShortDescription,Description,Visit,ImageName,ShowInSlider,CreateDate,Tags")]
            Page page, HttpPostedFileBase imgUp)
        {
            if (ModelState.IsValid)
            {
                if (imgUp != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }

                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUp.FileName);
                    imgUp.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }

                _pageRepository.UpdatePage(page);
                _pageRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupId = new SelectList(_pageGroupRepository.GetAllPageGroup(), "GroupId", "GroupTitle",
                page.GroupId);
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
            var page = _pageRepository.GetPageById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }

            _pageRepository.DeletePage(page);
            _pageRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pageGroupRepository.Dispose();
                _pageRepository.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}