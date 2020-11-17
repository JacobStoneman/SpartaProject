using SpartaProjectDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
	}
}
