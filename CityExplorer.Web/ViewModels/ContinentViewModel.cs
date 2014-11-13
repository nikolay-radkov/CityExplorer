using CityExplorer.Models;
using CityExplorer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CityExplorer.Web.ViewModels
{
    public class ContinentViewModel : IMapFrom<Continent>
    {
        [Required]
        public string Name { get; set; }
    }
}