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
			options.UseSqlServer(@"Data Source=mssql9.unoeuro.com;Initial Catalog=error121_dk_db_devsquardv2;User ID=error121_dk;Password=hk9ynDAed52brftzpcG3;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
			//options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RaspPuppyDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
		}

		public DbSet<Personality> Personalities { get; set; }
        public DbSet<TripData> Trips { get; set; }
    }
}
