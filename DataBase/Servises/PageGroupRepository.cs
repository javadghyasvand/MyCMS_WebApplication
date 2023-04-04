using DataBase.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace DataBase
{
    public class PageGroupRepository:IPageGroupRepository
    {
        private readonly MyCmsContext _myCmsContext = new MyCmsContext();

        public IEnumerable<PageGroup> GetAllPageGroup()
        {
            return _myCmsContext.PageGroup;
        }

        public PageGroup GetPageGroupById(int id)
        {
            return _myCmsContext.PageGroup.Find(id);
        }

        public bool InsertGroup(PageGroup group)
        {
            try
            {
                _myCmsContext.PageGroup.Add(group);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateGroup(PageGroup group)
        {
            try
            {
                _myCmsContext.Entry(group).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(PageGroup group)
        {
            try
            {
                _myCmsContext.Entry(group).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(int id)
        {
            try
            {
                var group = GetPageGroupById(id);
                DeleteGroup(group);
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