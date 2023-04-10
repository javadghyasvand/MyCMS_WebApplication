 using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace DataBase
{
    public class Page
    {
        [Key]
        public long PageId { get; set; }

        [Display(Name = "گروه صفحه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public long GroupId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(250)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string PageTitle { get; set; }

        [Display(Name = "توضیحات مختصر")]
        [MaxLength(350)]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن خبر ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "بازدید")]
        public long Visit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

        public virtual PageGroup GroupPage { get; set; }

        public virtual List<PageComment> CommentPages { get; set; }

        public Page()
        {

        }
    }
}