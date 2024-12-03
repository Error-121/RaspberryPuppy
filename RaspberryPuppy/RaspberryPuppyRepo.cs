using RaspberryPuppy.EFDbContext;
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
		private readonly PuppyDbContext _context;
		private readonly List<Puppy> _puppies = new List<Puppy>();

		public RaspberryPuppyRepo()
		{
			_context = new PuppyDbContext();
			_context.Database.EnsureCreated();
		}

		//public RaspberryPuppyRepo()
		//{
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Buddy", Race = "Golden Retriever", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Max", Race = "German Shepherd", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Charlie", Race = "Bulldog", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Bella", Race = "Poodle", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Lucy", Race = "Beagle", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Daisy", Race = "Rottweiler", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Luna", Race = "Yorkshire Terrier", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Cooper", Race = "Boxer", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Rocky", Race = "Dachshund", NeedToWalk = true, Sounds = Puppy.SoundSignal.QuietBarking });
		//	_puppies.Add(new Puppy() { ID = _nextID++, Name = "Lola", Race = "Siberian Husky", NeedToWalk = true, Sounds = Puppy.SoundSignal.LoudBarking });
		//}


		public List<Puppy> GetAll()
		{
			//before simply server
			//return new List<Puppy>(_puppies);

			return _context.Puppies.ToList();
		}
		
		public Puppy GetByID(int? id)
		{
			//before simply server
			//var puppyId = _puppies.Find(puppies => puppies.ID == id);
			//if (puppyId == null)
			//         {
			//	throw new ArgumentNullException("No item exists with this id");
			//         }
			//return puppyId;

			var puppy = _context.Puppies.Find(id);
			if (puppy == null)
			{
				throw new ArgumentNullException("No item exists with this id");
			}
			return puppy;
		}

		public Puppy Add(Puppy item)
		{
			//before simply server
			//item.ValidateValidate();
			//item.ID = _nextID++;
			//         _puppies.Add(item);
			//         return item;
			item.ValidateValidate();
			_context.Puppies.Add(item);
			_context.SaveChanges();
			return item;
		}

		public Puppy? Update(int id, Puppy item)
		{
			//before simply server
			//item.ValidateValidate();
			//Puppy? puppy = GetByID(id);
			//item.Name = puppy.Name;
			//item.Race = puppy.Race;
			//return item;

			item.ValidateValidate();
			var puppy = GetByID(id);
			if (puppy != null)
			{
				puppy.Name = item.Name;
				puppy.Race = item.Race;
				puppy.NeedToWalk = item.NeedToWalk;
				puppy.Sounds = item.Sounds;
				_context.SaveChanges();
			}
			return puppy;
		}

		public Puppy? Delete(int id)
		{
			//before simply server
			//Puppy? puppy = GetByID(id);
			//_puppies.Remove(puppy);
			//return puppy;

			var puppy = GetByID(id);
			if (puppy != null)
			{
				_context.Puppies.Remove(puppy);
				_context.SaveChanges();
			}
			return puppy;
		}
	}
}
