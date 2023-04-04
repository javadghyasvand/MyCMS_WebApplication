using DataBase.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace DataBase
{
    public class PageRepository:IPageRepository
    {
        private readonly MyCmsContext _myCmsContext = new MyCmsContext();
        public IEnumerable<Page> GetAllPage()
        {
            return _myCmsContext.Page;
        }

        public Page GetPageById(int id)
        {
            return _myCmsContext.Page.Find(id);
        }

        public bool InsertPage(Page page)
        {
            try
            {
                _myCmsContext.Page.Add(page);
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
                _myCmsContext.Entry(page).State = EntityState.Modified;
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
                _myCmsContext.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeletePage(int id)
        {
            try
            {
                var page = GetPageById(id);
                _myCmsContext.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            _myCmsContext.SaveChanges();
        }
    }
}