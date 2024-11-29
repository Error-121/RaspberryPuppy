using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
	public class RaspberryPuppyRepo
	{
		private int _nextID = 1;
		private readonly List<Puppy> _puppies = new List<Puppy>();

        public RaspberryPuppyRepo(List<Puppy> puppies)
        {
            _puppies = puppies;
        }
        public RaspberryPuppyRepo()
		{
			_puppies.Add(new Puppy("Buddy", "Golden Retriever", true, Puppy.SoundSignal.LoudBarking));
			_puppies.Add(new Puppy("Max", "German Shepherd", true, Puppy.SoundSignal.LoudBarking));
			_puppies.Add(new Puppy("Charlie", "Bulldog", true, Puppy.SoundSignal.LoudBarking));
			_puppies.Add(new Puppy("Bella", "Poodle", true, Puppy.SoundSignal.QuietBarking));
			_puppies.Add(new Puppy("Lucy", "Beagle", true, Puppy.SoundSignal.QuietBarking));
			_puppies.Add(new Puppy("Daisy", "Rottweiler", true, Puppy.SoundSignal.LoudBarking));
			_puppies.Add(new Puppy("Luna", "Yorkshire Terrier", true, Puppy.SoundSignal.QuietBarking));
			_puppies.Add(new Puppy("Cooper", "Boxer", true, Puppy.SoundSignal.LoudBarking));
			_puppies.Add(new Puppy("Rocky", "Dachshund", true, Puppy.SoundSignal.QuietBarking));
			_puppies.Add(new Puppy("Lola", "Siberian Husky", true, Puppy.SoundSignal.LoudBarking));
		}


        public List<Puppy> GetAll()
		{
			if (_puppies.Count == 0)
            {
                throw new ArgumentException("No items in list");
            }
            else
            {
                return new List<Puppy>(_puppies);	
            }
		}
		
		public Puppy? GetByID(int id)
		{
			var equalsId = _puppies.Find(_puppies => _puppies.ID == id);
			if (equalsId != null)
            {
				throw new ArgumentNullException("No item exists with this id");
            }
			return equalsId;
        }

		public Puppy Add(Puppy item)
		{
            item.ValidateValidate();
			item.ID = _nextID++;
            _puppies.Add(item);
            return item;
		}

		public Puppy? Update(int id, Puppy item)
		{
			item.ValidateValidate();
			Puppy? puppy = GetByID(id);
			item.Name = puppy.Name;
			item.Race = puppy.Race;
			return item;
		}

		public Puppy? Delete(int id)
		{
			Puppy? puppy = GetByID(id);
			_puppies.Remove(puppy);
			return puppy;
		}
	}
}
