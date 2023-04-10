using System;
using System.Collections.Generic;

namespace DataBase
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(long id);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(long id);
        void Dispose();
        void Save();
    }
}