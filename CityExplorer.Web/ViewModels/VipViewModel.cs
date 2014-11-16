namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class VipViewModel : IMapFrom<VIP>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Profession { get; set; }

        [Required]
        public string Photo { get; set; }

        public string Website { get; set; }

    }
}