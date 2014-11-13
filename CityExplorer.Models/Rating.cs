namespace CityExplorer.Models
{
    using CityExplorer.Data.Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating : IDeletableEntity
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
        
        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set;}
    }
}
