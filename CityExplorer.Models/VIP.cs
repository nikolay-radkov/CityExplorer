using CityExplorer.Data.Contracts;
using System.ComponentModel.DataAnnotations;
namespace CityExplorer.Models
{
    public class VIP : IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Profession { get; set; }

        public string Website { get; set; }

        [Required]
        public string Photo { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
