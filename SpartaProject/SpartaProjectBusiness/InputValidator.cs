namespace SpartaProjectBusiness
{
	public class InputValidator
	{
		public (bool, decimal) CheckDecimalInput(string input)
		{
			decimal num;
			bool isDecimal = decimal.TryParse(input, out num);
			return (isDecimal, num);
		}

		public (bool, int) CheckIntInput(string input)
		{
			int num;
			bool isInt = int.TryParse(input, out num);
			return (isInt, num);
		}
	}
}
