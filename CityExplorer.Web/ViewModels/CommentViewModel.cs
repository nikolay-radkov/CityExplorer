namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [Required]
        [Display(Name = "Comment")]
        public string Text { get; set; }

        public DateTime DateCreated { get; set; }

        public UserViewModel User { get; set; }
    }
}