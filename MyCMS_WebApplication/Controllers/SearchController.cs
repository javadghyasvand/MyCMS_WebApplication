using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Controllers
{
    public class SearchController : Controller
    {
       private readonly  IPageRepository _pageRepository;
       private readonly  MyCmsContext _cmsContext=new MyCmsContext();

        public SearchController()
        {
            _pageRepository = new PageRepository(_cmsContext);
        }

        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.name=q;
            return View(_pageRepository.SearchPage(q));
        }
    }
}