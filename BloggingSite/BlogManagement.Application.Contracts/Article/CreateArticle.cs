using _0_Framework.Application.Attribute;
using _0_Framework.Application.Message;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        [Display(Name = "عنوان مقاله")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }

        [Display(Name = "توضیحات کوتاه")]
        [MaxLength(1000, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string ShortDescription { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Description { get; set; }

        [Display(Name = "تصویر")]
        [FileExtentionLimitation(new string[] { "image/jpeg", "image/png", "image/jpg" }, ErrorMessage = ValidationMessages.InvalidFileFormat)]
        [MaxFileSize(3 * 1024 * 1024, ErrorMessage = ValidationMessages.MaxFileSize)]
        public IFormFile? Picture { get; set; }

        [Display(Name = "Alt")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.SeoWarning)]
        public string PictureAlt { get; set; }

        [Display(Name = "عنوان عکس")]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.SeoWarning)]
        public string PictureTitle { get; set; }

        [Display(Name = "اسلاگ")]
        [MaxLength(750, ErrorMessage = ValidationMessages.MaxLength)]
        [Required(ErrorMessage = ValidationMessages.SeoWarning)]
        public string Slug { get; set; }
    }
}