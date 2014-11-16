namespace CityExplorer.Web.Areas.Administration.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Areas.Administration.ViewModels.Base;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web;
    using System.Web.Mvc;

    public class CountryViewModel : IMapFrom<Country>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

        public string Image { get; set; }

        public string  ContinentName { get; set; }

        public int ContinentId { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Country, CountryViewModel>()
               .ForMember(c => c.ContinentName, opt => opt.MapFrom(c => c.Continent.Name))
               .ReverseMap();
        }
    }
}