namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class PhotoViewModel  : IMapFrom<Photo>
    {
        public int? Id { get; set; }

        [Required]
        public string Url { get; set; }
    }
}