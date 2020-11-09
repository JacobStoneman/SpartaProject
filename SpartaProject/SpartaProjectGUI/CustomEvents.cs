using System;
using System.Collections.Generic;
using System.Text;

namespace SpartaProjectGUI
{
	public class CustomEvents
	{
		public static CustomEvents current = new CustomEvents();

		public event Action OnNewOrderPlaced;
		public void NewOrderPlaced()
		{
			OnNewOrderPlaced?.Invoke();
		}

		public event Action OnProductDeleted;
		public void ProductDeleted()
		{
			OnProductDeleted?.Invoke();
		}
	}
}
