using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Controllers
{
    public class NewsController : Controller
    {
        
        private readonly  IPageGroupRepository _pageGroupRepository;
        private readonly MyCmsContext cms = new MyCmsContext();
        public NewsController()
        { _pageGroupRepository = new PageGroupRepository(cms);
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
    }
}