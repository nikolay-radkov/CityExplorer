namespace CityExplorer.Models
{
    using CityExplorer.Data.Contracts;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City : DeletableEntity
    {
        private ICollection<VIP> vips;
        private ICollection<Place> places;
        private ICollection<Event> events;
        private ICollection<User> users;
        private ICollection<Comment> comments;
        private ICollection<Rating> ratings;

        public City()
        {
            this.vips = new HashSet<VIP>();
            this.places = new HashSet<Place>();
            this.events = new HashSet<Event>();
            this.users = new HashSet<User>();
            this.comments = new HashSet<Comment>();
            this.ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        public string Name { get; set; }

        public double Area { get; set; }

        public long Population { get; set; }

        public string Website { get; set; }

        public string SettledYear { get; set; }

        public string Description { get; set; }

        public string Video { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<VIP> VIPs
        {
            get { return vips; }
            set { vips = value; }
        }


        public virtual ICollection<Place> Places
        {
            get { return places; }
            set { places = value; }
        }

        public virtual ICollection<Event> Events
        {
            get { return events; }
            set { events = value; }
        }

        public virtual ICollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    
        public virtual ICollection<Comment> Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public virtual ICollection<Rating> Raitings
        {
            get { return ratings; }
            set { ratings = value; }
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
