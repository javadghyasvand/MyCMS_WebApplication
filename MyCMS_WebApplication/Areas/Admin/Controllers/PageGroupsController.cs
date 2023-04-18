using System.Net;
using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Areas.Admin.Controllers
{
    [Authorize]
    public class PageGroupsController : Controller
    {
       private readonly IPageGroupRepository _pageGroupRepository;
       private readonly MyCmsContext _cms = new MyCmsContext();  
       public PageGroupsController()
       {
           _pageGroupRepository = new PageGroupRepository(_cms);
       }

       // GET: Admin/PageGroups
        public ActionResult Index()
        {
            return View(_pageGroupRepository.GetAllPageGroup());
        } 

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PageGroup pageGroup = _pageGroupRepository.GetPageGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _pageGroupRepository.InsertGroup(pageGroup);
                _pageGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return PartialView(pageGroup);
        }
        
        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = _pageGroupRepository.GetPageGroupById(id.Value);


            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,GroupTitle")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                _pageGroupRepository.UpdateGroup(pageGroup);   
                _pageGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return PartialView(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = _pageGroupRepository.GetPageGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return  PartialView( pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            _pageGroupRepository.DeleteGroup(id);
            _pageGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _pageGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
