namespace CityExplorer.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;

    public class CreateFeedbackInputModel : IMapFrom<Feedback>
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Content")]
        [UIHint("MultilineText")]
        public string Content { get; set; }
    }
}
