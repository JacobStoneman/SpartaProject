using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using SpartaProjectModel.Services;
using System.Collections.Generic;
using System.Linq;

namespace SpartaProjectBusiness
{
	public abstract class CRUDManager
	{
		private IService _service;

		public CRUDManager()
		{
			_service = new Service(new ProjectContext());
		}

		public CRUDManager(IService service)
		{
			_service = service;
		}

		public T SetSelected<T>(object selectedItem)
		{
			T Selected = (T)selectedItem;
			return Selected;
		}

		public List<T> RetrieveAll<T>() where T : class
		{
			return _service.RetrieveAll<T>();
		}

		public void Delete<T>(ProjectContext db, DbSet<T> set, T obj) where T : class
		{
			set.Remove(obj);
			db.SaveChanges();
		}
	}
}
