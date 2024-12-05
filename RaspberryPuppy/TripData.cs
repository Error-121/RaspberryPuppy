﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
    public class TripData
    {
        public TripData()
        {
            
        }
        public TripData(string? location, decimal temperature, int timeOutside)
        {
            Location = location;
            Temperature = temperature;
            TimeOutside = timeOutside;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Personality")]
        public int TagNr { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string? Location { get; set; }
        [Required]
        public decimal Temperature { get; set; }
        [Required]
        public int TimeOutside { get; set; }
    }
}
