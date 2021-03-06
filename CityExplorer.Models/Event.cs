﻿namespace CityExplorer.Models
{
    using CityExplorer.Data.Contracts;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DateStarted { get; set; }

        public DateTime? DateFinished { get; set; }

        public EventType EventType { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
