namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class VipInputModel : IMapFrom<VIP>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Profession { get; set; }

        public string Website { get; set; }

        [Required]
        public HttpPostedFileBase Photo { get; set; }
    }
}