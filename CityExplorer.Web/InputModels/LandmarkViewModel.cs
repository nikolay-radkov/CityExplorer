namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using CityExplorer.Web.ViewModels;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class LandmarkInputModel : IMapFrom<Place>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public HttpPostedFileBase Photo { get; set; }
    }
}