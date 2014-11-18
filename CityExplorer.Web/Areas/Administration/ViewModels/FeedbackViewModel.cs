namespace CityExplorer.Web.Areas.Administration.ViewModels
{
    using CityExplorer.Models;
    using CityExplorer.Web.Infrastructure.Mapping;
    using System;

    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {

        public int Id { get; set; }
        
        public string AuthorName { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
               .ForMember(f => f.AuthorName, opt => opt.MapFrom(c => c.Author.UserName));
        }
    }
}