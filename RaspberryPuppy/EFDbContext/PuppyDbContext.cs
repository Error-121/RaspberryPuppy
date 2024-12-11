using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy.EFDbContext
{
	public class PuppyDbContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			
		}

		public DbSet<Personality> Personalities { get; set; }
        public DbSet<TripData> Trips { get; set; }
    }
}
