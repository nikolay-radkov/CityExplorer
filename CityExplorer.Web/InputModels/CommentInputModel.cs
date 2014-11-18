namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CommentInputModel : IMapFrom<Comment>
    {
        [Required]
        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
  
        [Display(Name = "Comment")]
        [UIHint("MultilineText")]
        public string Text { get; set; }

        public int? CityId { get; set; }
    }
}