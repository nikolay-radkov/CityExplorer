namespace CityExplorer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CityExplorer.Data.Contracts;
    using CityExplorer.Models;

    public class Feedback : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
