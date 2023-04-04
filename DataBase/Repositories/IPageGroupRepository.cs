using System;
using System.Collections.Generic;

namespace DataBase
{
    public interface IPageGroupRepository:IDisposable
    {
        IEnumerable<PageGroup> GetAllPageGroup();
        PageGroup GetPageGroupById(long id);
        bool InsertGroup(PageGroup group);
        bool UpdateGroup(PageGroup group);
        bool DeleteGroup(PageGroup group);
        bool DeleteGroup(long Id);
        void Save();
    }
}