using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageGroupRepository _pageGroupRepository;
        private readonly IPageRepository _pageRepository;
        private readonly MyCmsContext _cms = new MyCmsContext();

        public NewsController()
        {
            _pageRepository = new PageRepository(_cms);
            _pageGroupRepository = new PageGroupRepository(_cms);
        }

        // GET: New
        public ActionResult ShowGroups()
        {
            return PartialView(_pageGroupRepository.GetShowGroups());
        }

        public ActionResult PageGroupsInMenu()
        {
            return PartialView(_pageGroupRepository.GetAllPageGroup());
        }

        public ActionResult TopNews()
        {
            return PartialView(_pageRepository.TopNews());
        }

        public ActionResult LatesNews()
        {
            return PartialView(_pageRepository.LastNews());
        }
        [Route("Archive")]
        public ActionResult ArchiveNew()
        {
            return View(_pageRepository.GetAllPage());
        }

        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(long id,string title)
        {
            ViewBag.name=title;
            return View(_pageRepository.ShowPageGroupById(id));
        }
    }
}