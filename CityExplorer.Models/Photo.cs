using System.ComponentModel.DataAnnotations;
namespace CityExplorer.Models
{
    public class Photo
    {
        public int Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int PlaceId { get; set; }

        public virtual Place Place { get; set; }
    }
}