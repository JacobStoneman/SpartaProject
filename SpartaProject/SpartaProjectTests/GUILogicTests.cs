using NUnit.Framework;
using SpartaProjectBusiness;
using SpartaProjectDB;
using System.Linq;
using SpartaProjectGUI;

namespace SpartaProjectTests
{
	public class GUILogicTests
	{
		GUILogic logic = new GUILogic();

		[TestCase("3", true, 3)]
		[TestCase("3.5", false, 0)]
		[TestCase("test", false, 0)]
		public void IntInputCheck(string input, bool expectedBool, int expectedInt)
		{
			(bool, int) result = logic.CheckIntInput(input);
			Assert.AreEqual(expectedBool, result.Item1);
			Assert.AreEqual(expectedInt, result.Item2);
		}

		[TestCase("3", true, 3)]
		[TestCase("3.5", true, 3.5)]
		[TestCase("test", false, 0)]
		public void DecimalInputCheck(string input, bool expectedBool, decimal expectedDecimal)
		{
			(bool, decimal) result = logic.CheckDecimalInput(input);
			Assert.AreEqual(expectedBool, result.Item1);
			Assert.AreEqual(expectedDecimal, result.Item2);
		}
	}
}
