namespace CityExplorer.Web.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Started On")]
        public DateTime DateStarted { get; set; }

        [Display(Name = "Finished On")]
        public DateTime? DateFinished { get; set; }

        [Display(Name = "Event Type")]
        public EventType EventType { get; set; }

        [Display(Name="City Name")]
        public string CityName { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
               .ForMember(c => c.CityName, opt => opt.MapFrom(c => c.City.Name))
               .ReverseMap();
        }
    }
}