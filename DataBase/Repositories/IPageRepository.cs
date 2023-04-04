using System;
using System.Collections.Generic;

namespace DataBase
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetAllPage();
        Page GetPageById(int id);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int id);
        void Save();
    }
}