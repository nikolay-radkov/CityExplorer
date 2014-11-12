using System.ComponentModel.DataAnnotations;
namespace CityExplorer.Models
{
    public class VIP
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Profession { get; set; }

        public string Website { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
