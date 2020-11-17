﻿using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpartaProjectBusiness
{
	public class CRUDManagerCustomer : CRUDManager
	{
		public Customer Selected { get; set; }

		public Customer Create(User user)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Customer newCustomer = new Customer()
				{
					User = user,
					UserId = user.UserId
				};

				db.Customers.Add(newCustomer);

				db.SaveChanges();
				return newCustomer;
			}
		}
	}
}
