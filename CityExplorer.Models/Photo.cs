using CityExplorer.Data.Contracts;
using System.ComponentModel.DataAnnotations;
namespace CityExplorer.Models
{
    public class Photo : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}