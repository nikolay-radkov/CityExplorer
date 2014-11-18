namespace CityExplorer.Web.InputModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EventInputModel : IMapFrom<Event>
    {
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
    }
}