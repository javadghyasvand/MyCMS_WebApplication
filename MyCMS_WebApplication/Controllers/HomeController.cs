using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPageRepository _pageRepository;
        private readonly MyCmsContext _cms =new MyCmsContext();
        public HomeController()
        {
            _pageRepository = new PageRepository(_cms);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            return PartialView(_pageRepository.PageInSlider());
        }
    }
}