using System.Collections.Generic;

namespace DataBase
{
    public interface IPageGroupRepository
    {
        IEnumerable<PageGroup> GetAllPageGroup();
        PageGroup GetPageGroupById(int id);
        bool InsertGroup(PageGroup group);
        bool UpdateGroup(PageGroup group);
        bool DeleteGroup(PageGroup group);
        bool DeleteGroup(int Id);
        void Save();
    }
}