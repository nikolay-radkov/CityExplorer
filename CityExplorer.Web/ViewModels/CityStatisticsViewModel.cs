namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;

    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    public class CityStatisticsViewModel : IMapFrom<City>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Country Name")]
        public string CountryName { get; set; }

        [Display(Name = "Continent Name")]
        public string ContinentName { get; set; }

        public long Population { get; set; }

        public double Rating { get; set; }

        [Display(Name = "Comments Number")]
        public int CommentsNumber { get; set; }

        [Display(Name = "Visited By")]
        public int VisitedBy { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<City, CityStatisticsViewModel>()
               .ForMember(c => c.CountryName, opt => opt.MapFrom(c => c.Country.Name))
               .ForMember(c => c.ContinentName, opt => opt.MapFrom(c => c.Country.Continent.Name))
               .ForMember(c => c.Rating, opt => opt.MapFrom(c => c.Raitings.Sum(r => r.Number / (double)c.Raitings.Count())))
               .ForMember(c => c.CommentsNumber, opt => opt.MapFrom(c => c.Comments.Count()))
               .ForMember(c => c.VisitedBy, opt => opt.MapFrom(c => c.Users.Count()))

               .ReverseMap();
        }
    }
}