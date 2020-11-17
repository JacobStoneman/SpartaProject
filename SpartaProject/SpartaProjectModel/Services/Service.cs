using SpartaProjectDB;
using System.Collections.Generic;
using System.Linq;

namespace SpartaProjectModel.Services
{
	public class Service : IService
	{
		private readonly ProjectContext db;

		public Service(ProjectContext context)
		{
			db = context;
		}

		public List<T> RetrieveAll<T>() where T : class
		{
			return db.Set<T>().ToList();
		}

		public void Delete<T>(T obj) where T : class
		{
			db.Set<T>().Remove(obj);
			db.SaveChanges();
		}

		public void Create<T>(T obj) where T : class
		{
			db.Set<T>().Add(obj);
			db.SaveChanges();
		}

		public void SaveChanges()
		{
			db.SaveChanges();
		}
	}
}
