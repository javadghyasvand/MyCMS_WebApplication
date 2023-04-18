using System;
using System.Collections.Generic;
using System.Web.DynamicData;

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
        new void Dispose();
        void Save();
        IEnumerable<Page> TopNews(int take=5);
        IEnumerable<Page> PageInSlider(int take=5);
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageGroupById(long id);
        IEnumerable<Page> SearchPage(string search);
    }
}