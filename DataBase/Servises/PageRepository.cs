using System.Collections.Generic;
using System.Data.Entity;
using System;
using System.Linq;

namespace DataBase
{
    public class PageRepository : IPageRepository
    {
        private readonly MyCmsContext _cms;

        public PageRepository(MyCmsContext context)
        {
            this._cms = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return _cms.Page;
        }

        public Page GetPageById(long id)
        {
            return _cms.Page.Find(id);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                _cms.Page.Add(page);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePage(Page page)
        {
            try
            {
                _cms.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(Page page)
        {
            try
            {
                _cms.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(long id)
        {
            try
            {
                var page = GetPageById(id);
                _cms.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            _cms.Dispose();
        }


        public void Save()
        {
            _cms.SaveChanges();
        }

        public IEnumerable<Page> TopNews(int take = 5)
        {
            return _cms.Page.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PageInSlider(int take = 5)
        {
            return _cms.Page.Where(p => p.ShowInSlider).Take(take);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return _cms.Page.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageGroupById(long id)
        {
            return _cms.Page.Where(p => p.GroupId == id);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return _cms.Page.Where(p =>
                p.PageTitle.Contains(search) || p.ShortDescription.Contains(search) || p.Description.Contains(search) ||
                p.Tags.Contains(search)).Distinct();
        }
    }
}