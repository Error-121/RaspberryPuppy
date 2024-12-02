﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace RaspberryPuppy
{
    public class Puppy
    {
        public enum SoundSignal
        {
            Silent,
            LoudBarking,
            QuietBarking
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        [Required]
		[StringLength(50, MinimumLength = 2)]
		public string Name { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2)]
		public string Race { get; set; }
		[Required]
		public bool NeedToWalk { get; set; }
		[Required]
		public SoundSignal Sounds { get; set; }

        public Puppy()
        {

        }

        public Puppy(string name, string race, bool needToWalk, SoundSignal sounds)
        {
            Name = name;
            Race = race;
            NeedToWalk = needToWalk;
            Sounds = sounds;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Race)}={Race}, {nameof(NeedToWalk)}={NeedToWalk}, {nameof(Sounds)}={Sounds.ToString()}}}";
        }

        public void ValidateName()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentNullException("Name is required");
            }

            else if (Name.Length < 2 || Name.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Name must have at least 2 characters");
            }
            else if(false == Name.All(char.IsLetter))
            {
                throw new FormatException("Name cannot contain special characters nor numbers");
            }
        }

        public void ValidateRace()
        {
            if (string.IsNullOrEmpty(Race))
            {
                throw new ArgumentNullException("Race is required");
            }
            else if (Race.Length < 2 || Race.Length > 50)
            {
                throw new ArgumentOutOfRangeException("Race must be atleast 2 characters");
            }
            else if(false == Race.All(char.IsLetter))
            {
                throw new FormatException("Race cannot contain special characters nor numbers");
            }
        }

        public void ValidateValidate()
        {
            ValidateName();
            ValidateRace();
        }


    }

}

