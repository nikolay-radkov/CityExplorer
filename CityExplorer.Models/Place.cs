namespace CityExplorer.Models
{
    using CityExplorer.Data.Contracts;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Place : DeletableEntity
    {
        private ICollection<Photo> photos;

        public Place()
        {
            this.photos = new HashSet<Photo>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Photo> Photos
        {
            get
            {
                return this.photos;
            }

            set
            {
                this.photos = value;
            }
        }

        public bool IsDeleted { get; set; }

        public System.DateTime? DeletedOn { get; set; }
    }
}
