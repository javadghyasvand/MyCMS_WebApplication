using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase
{
    public class PageGroup
    {
        [Key]
        public long GroupId { get; set; }

        [Display(Name = "عنوان ")]
        [MaxLength(150)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string GroupTitle { get; set; }

        public virtual List<Page> Pages { get; set; }
        public PageGroup()
        {

        }
    }
}        