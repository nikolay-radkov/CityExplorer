using CityExplorer.Data.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
namespace CityExplorer.Models
{
    public class Comment : IDeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
