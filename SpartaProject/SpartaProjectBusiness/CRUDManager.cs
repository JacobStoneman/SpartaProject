using SpartaProjectDB;
using SpartaProjectModel.Services;
using System.Collections.Generic;

namespace SpartaProjectBusiness
{
	public abstract class CRUDManager
	{
		protected IService _service;

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

		public virtual void Delete<T>(T obj) where T : class
		{
			_service.Delete(obj);
		}
	}
}
