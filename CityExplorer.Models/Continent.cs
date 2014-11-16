namespace CityExplorer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using CityExplorer.Data.Contracts;

    public class Continent : DeletableEntity
    {
        private ICollection<Country> countries;

        public Continent()
        {
            this.countries = new HashSet<Country>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Country> Countries
        {
            get
            {
                return this.countries;
            }

            set
            {
                this.countries = value;
            }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
