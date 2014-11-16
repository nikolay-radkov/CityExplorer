namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CityInputModel : IMapFrom<City>
    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Area { get; set; }

        public long Population { get; set; }

        public string Website { get; set; }

        public string SettledYear { get; set; }

        [Required]
        public string Description { get; set; }

        public string Video { get; set; }

        public int? CountryId { get; set; }
    }
}