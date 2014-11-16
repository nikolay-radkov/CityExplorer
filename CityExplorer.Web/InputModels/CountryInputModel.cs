namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class CountryInputModel : IMapFrom<Country>
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public HttpPostedFileBase Photo { get; set; }
    }
}