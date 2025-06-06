﻿using System.ComponentModel.DataAnnotations;

namespace Bounder.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
    }
}
