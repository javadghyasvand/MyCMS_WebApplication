using System;
using System.Web.Mvc;
using DataBase;

namespace MyCMS_WebApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly IPageGroupRepository _pageGroupRepository;
        private readonly IPageRepository _pageRepository;
        private readonly IPageCommentRepository _pageCommentRepository;

        private readonly MyCmsContext _cms = new MyCmsContext();

        public NewsController()
        {
            _pageRepository = new PageRepository(_cms);
            _pageGroupRepository = new PageGroupRepository(_cms);
            _pageCommentRepository=new PageCommentRepository(_cms);
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
        [Route("News/{id}")]
        public ActionResult ShowNews(long id)
        {
            var news=_pageRepository.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            _pageRepository.UpdatePage(news);
            _pageRepository.Save();
            return View(news);
        }

        public ActionResult AddComment(long id,string name,string email,string comment)
        {
            PageComment pageComment=new PageComment()
            {
                DateTime= DateTime.Now,
                PageId = id,
                Comment = comment,
                Email = email,
                Name = name,
                 
            };
            _pageCommentRepository.AddComment(pageComment);
            return PartialView("ShowComments",_pageCommentRepository.GetPageCommentsById(id));
        
        }

        public ActionResult ShowComments(long id)
        {
            return PartialView(_pageCommentRepository.GetPageCommentsById(id));
        }
    }
}