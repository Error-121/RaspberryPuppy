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
		private PuppyDbContext _context;
		private List<Personality> _puppies = new List<Personality>();
		public List<RaspberryPuppyRepo> _puppyRepo = new List<RaspberryPuppyRepo>();
		List<Personality> _puppyMock = Mocking.GetAllPup();
		public RaspberryPuppyRepo()
		{
			_context = new PuppyDbContext();
			_context.Database.EnsureCreated();
			//	foreach (var puppy in _puppyMock)
			//	{
			//		_context.Puppies.Add(puppy);
			//	}
			//          _context.SaveChanges();
			//}

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


			List<Personality> GetAll()
			{
				//before simply server
				//return new List<Puppy>(_puppies);
				return _context.Puppies.ToList();
			}

			Personality GetByID(int? id)
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

			Personality Add(Personality item)
			{
				//before simply server
				//item.ValidateValidate();
				//item.ID = _nextID++;
				//         _puppies.Add(item);
				//         return item;
				item.ValidateValidate();
				item.ID = 1;
				_context.Puppies.Add(item);
				_context.SaveChanges();
				return item;
			}

			Personality? Update(int id, Personality item)
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

			Personality? Delete(int id)
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
}
