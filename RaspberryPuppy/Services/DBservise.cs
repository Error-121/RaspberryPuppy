//using Microsoft.EntityFrameworkCore;
//using RaspberryPuppy.EFDbContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RaspberryPuppy
//{
//	public class DBservise
//	{
//		public async Task<List<Personality>> GetPuppies()
//		{
//			using (var context = new PuppyDbContext())
//			{
//				return await context.Puppies.ToListAsync();
//			}
//		}

//		public async Task AddPuppy(Personality puppy)
//		{
//			using (var context = new PuppyDbContext())
//			{
//				context.Puppies.Add(puppy);
//				context.SaveChanges();
//			}
//		}

//		public async Task SavePuppies(List<Personality> puppies)
//		{
//			using (var context = new PuppyDbContext())
//			{
//				foreach (Personality puppy in puppies)
//				{
//					context.Puppies.Add(puppy);
//					context.SaveChanges();
//				}

//				context.SaveChanges();
//			}
//		}
//	}
//}
