using System;
using System.Collections.Generic;
using System.Text;

namespace SpartaProjectModel.Services
{
	public interface IService
	{
		List<T> RetrieveAll<T>() where T : class;
	}
}
