using NUnit.Framework;
using SpartaProjectBusiness;

namespace SpartaProjectTests
{
	public class InputValidatorTests
	{
		InputValidator validator = new InputValidator();

		[TestCase("3", true, 3)]
		[TestCase("3.5", false, 0)]
		[TestCase("test", false, 0)]
		public void IntInputCheck(string input, bool expectedBool, int expectedInt)
		{
			(bool, int) result = validator.CheckIntInput(input);
			Assert.AreEqual(expectedBool, result.Item1);
			Assert.AreEqual(expectedInt, result.Item2);
		}

		[TestCase("3", true, 3)]
		[TestCase("3.5", true, 3.5)]
		[TestCase("test", false, 0)]
		public void DecimalInputCheck(string input, bool expectedBool, decimal expectedDecimal)
		{
			(bool, decimal) result = validator.CheckDecimalInput(input);
			Assert.AreEqual(expectedBool, result.Item1);
			Assert.AreEqual(expectedDecimal, result.Item2);
		}
	}
}
