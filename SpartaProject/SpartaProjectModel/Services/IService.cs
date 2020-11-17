using System;
using System.Collections.Generic;
using System.Text;

namespace SpartaProjectModel.Services
{
	public interface IService
	{
		List<T> RetrieveAll<T>() where T : class;

		void Delete<T>(T obj) where T : class;

		void Create<T>(T obj) where T : class;

		void SaveChanges();
	}
}
