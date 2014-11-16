namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class LandmarkViewModel : IMapFrom<Place>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }

        public ICollection<PhotoViewModel> Photos { get; set; }
    }
}