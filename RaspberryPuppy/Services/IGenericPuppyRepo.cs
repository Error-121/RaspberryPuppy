using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy.Services
{
	public interface IGenericPuppyRepo<T> where T : class
	{
		List<T> GetAll();
		T GetByID(int? id);
		T Add(T item);
		T? Update(int id, T item);
		T? Delete(int id);
	}
}
