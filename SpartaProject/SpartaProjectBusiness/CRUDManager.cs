using Microsoft.EntityFrameworkCore;
using SpartaProjectDB;
using System.Collections.Generic;
using System.Linq;

namespace SpartaProjectBusiness
{
	public abstract class CRUDManager
	{
		public T SetSelected<T>(object selectedItem)
		{
			T Selected = (T)selectedItem;
			return Selected;
		}

		public List<T> RetrieveAll<T>(DbSet<T> set) where T : class
		{
			using (ProjectContext db = new ProjectContext())
			{
				return set.ToList();
			}
		}
	}
}
