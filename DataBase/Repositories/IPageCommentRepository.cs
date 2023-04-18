using System.Collections.Generic;

namespace DataBase
{
    public interface IPageCommentRepository
    {
       IEnumerable<PageComment> GetPageCommentsById(long pageId);
       bool AddComment(PageComment pageComment);

    }
}