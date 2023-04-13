using DataBase;
using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace DataBase
{
    public class PageRepository:IPageRepository
    {
        private MyCmsContext cms;

        public PageRepository(MyCmsContext context)
        {
            this.cms = context;
        }

        public IEnumerable<Page> GetAllPage()
        {
            return cms.Page;
        }

        public Page GetPageById(long id)
        {
            return cms.Page.Find(id);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                cms.Page.Add(page);
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
                cms.Entry(page).State = EntityState.Modified;
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
                cms.Entry(page).State = EntityState.Deleted;
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
                cms.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            cms.Dispose();
        }


        public void Save()
        {
            cms.SaveChanges();
        }
    }
}