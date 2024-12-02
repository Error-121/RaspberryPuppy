using Microsoft.EntityFrameworkCore;
using RaspberryPuppy.EFDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy.Services
{
	public class DBservise
	{
		public async Task<List<Puppy>> GetPuppies()
		{
			using (var context = new PuppyDbContext())
			{
				return await context.Puppies.ToListAsync();
			}
		}

		public async Task AddPuppy(Puppy puppy)
		{
			using (var context = new PuppyDbContext())
			{
				context.Puppies.Add(puppy);
				context.SaveChanges();
			}
		}

		public async Task SavePuppies(List<Puppy> puppies)
		{
			using (var context = new PuppyDbContext())
			{
				foreach (Puppy puppy in puppies)
				{
					context.Puppies.Add(puppy);
					context.SaveChanges();
				}

				context.SaveChanges();
			}
		}
	}
}
