﻿using SpartaProjectDB;

namespace SpartaProjectModel.Services
{
	public interface ICustomerService : IUserService
	{
		public Customer GetCustomerById(int id);

		public Customer GetCustomerByUserId(int id);
	}
}
