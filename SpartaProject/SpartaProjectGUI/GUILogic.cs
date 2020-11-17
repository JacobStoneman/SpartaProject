using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using SpartaProjectDB;

namespace SpartaProjectGUI
{
	public class GUILogic
	{
		public (bool, decimal) CheckDecimalInput(string input)
		{
			decimal num;
			bool isDecimal = decimal.TryParse(input, out num);
			return (isDecimal, num);
		}

		public (bool,int) CheckIntInput(string input)
		{
			int num;
			bool isInt = int.TryParse(input, out num);
			return (isInt, num);
		}
	}
}
