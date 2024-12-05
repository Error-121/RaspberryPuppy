using System;
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
        public TripData(int id, int tagNr, string? location, string? humidity, int temperature, int timeOutside)
        {
            Id = id;
            TagNr = tagNr;
            Location = location;
            Humidity = humidity;
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
        public string? Humidity { get; set; }
        [Required]
        public int Temperature { get; set; }
        [Required]
        public int TimeOutside { get; set; }
    }
}
