namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class PhotoInputModel : IMapFrom<Photo>
    {
        public int? Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int CityId { get; set; }
    }
}