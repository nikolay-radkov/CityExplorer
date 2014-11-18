namespace CityExplorer.Web.Areas.Administration.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CityViewModel : IMapFrom<City>
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public double Area { get; set; }

        public long Population { get; set; }

        public string Website { get; set; }

        public string SettledYear { get; set; }

        public string Description { get; set; }
    }
}