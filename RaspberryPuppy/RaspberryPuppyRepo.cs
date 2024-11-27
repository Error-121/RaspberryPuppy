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

		public List<Puppy> GetAllPuppies()
		{
			return new List<Puppy>(_puppies);
		}
		
		public Puppy? GetPuppyByID(int id)
		{
			return _puppies.Find(_puppies => _puppies.ID == id);
		}

		public Puppy AddPuppy(Puppy item)
		{
			item.ValidateValidate();
			item.ID = _nextID++;
			_puppies.Add(item);
			return item;
		}

		public Puppy? Update(int id, Puppy item)
		{
			item.ValidateValidate();
			Puppy? puppy = GetPuppyByID(id);
			if (puppy == null)
			{
				return null;
			}
			item.Name = puppy.Name;
			item.Race = puppy.Race;
			return item;
		}

		public Puppy? Delete(int id)
		{
			Puppy? puppy = GetPuppyByID(id);
			if (puppy == null)
			{
				return null;
			}
			_puppies.Remove(puppy);
			return puppy;
		}
	}
}
