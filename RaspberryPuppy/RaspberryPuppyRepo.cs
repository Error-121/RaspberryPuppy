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

        public RaspberryPuppyRepo()
		{
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Buddy", Race = "Golden Retriever", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking } );
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Max", Race = "German Shepherd", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking } );
            _puppies.Add(new Puppy() { ID = _nextID++, Name= "Charlie", Race = "Bulldog", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking } );
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Bella", Race = "Poodle", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking } );
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Lucy", Race = "Beagle", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking } );
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Daisy", Race = "Rottweiler", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Luna", Race = "Yorkshire Terrier", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Cooper", Race = "Boxer", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Rocky", Race = "Dachshund", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
			_puppies.Add(new Puppy() { ID = _nextID++, Name = "Lola", Race = "Siberian Husky", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		}


        public List<Puppy> GetAll()
		{
            return new List<Puppy>(_puppies);	
		}
		
		public Puppy GetByID(int? id)
		{
			var puppyId = _puppies.Find(puppies => puppies.ID == id);
			if (puppyId == null)
            {
				throw new ArgumentNullException("No item exists with this id");
            }
			return puppyId;
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
