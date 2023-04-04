using System.ComponentModel.DataAnnotations;
using System;

namespace DataBase
{
    public class PageComment
    {
        [Key]
        public long CommentId { get; set; }

        [Display(Name = "خبر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long PageId { get; set; }

        [Display(Name = "نام")]
        [MaxLength(150)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "سایت")]
        public string WebSite { get; set; }

        [Display(Name = "نظر")]
        [MaxLength(500)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Comment { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime DateTime { get; set; }

        public virtual Page Page { get; set; }

        public PageComment()
        {

        }
    }
}