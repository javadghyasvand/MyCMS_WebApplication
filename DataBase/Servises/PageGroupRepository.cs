using DataBase.Context;
using System.Collections.Generic;
using System.Data.Entity;
using System;

namespace DataBase
{
    public class PageGroupRepository:IPageGroupRepository
    {
       private MyCmsContext cms;

       public PageGroupRepository(MyCmsContext context)
       {
           this.cms=context;
       }

       public IEnumerable<PageGroup> GetAllPageGroup()
        {
            return cms.PageGroup;
        }

        public PageGroup GetPageGroupById(long id)
        {
            return cms.PageGroup.Find(id);
        }


        public bool InsertGroup(PageGroup group)
        {
            try
            {
                cms.PageGroup.Add(group);
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
                cms.Entry(group).State = EntityState.Modified;
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
                cms.Entry(group).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteGroup(long id)
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
            cms.SaveChanges();
        }

        public void Dispose()
        {
          cms.Dispose();

        }
    }
}