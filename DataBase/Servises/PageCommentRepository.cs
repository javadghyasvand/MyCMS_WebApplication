 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class PageCommentRepository:IPageCommentRepository
    {
        private readonly MyCmsContext _cms;

       public PageCommentRepository(MyCmsContext context)
       {
           _cms = context;
       }
        public IEnumerable<PageComment> GetPageCommentsById(long pageId)
        {
            return _cms.PageComments.Where(p => p.PageId == pageId);
        }

        public bool AddComment(PageComment pageComment)
        {
            try
            {
                _cms.PageComments.Add(pageComment);
                _cms.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
