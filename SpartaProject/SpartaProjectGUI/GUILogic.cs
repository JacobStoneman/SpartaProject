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
		const string defaultImage = "https://www.tibs.org.tw/images/default.jpg";
		public void InitialiseProductInfoGrid(TextBlock prodIdValue, TextBlock prodNameValue, TextBlock prodPriceValue, TextBlock prodRatingValue, Image image)
		{
			prodIdValue.Text = string.Empty;
			prodNameValue.Text = string.Empty;
			prodPriceValue.Text = string.Empty;
			prodRatingValue.Text = string.Empty;
			SetImage(image);
		}

		private void SetImage(Image image)
		{
			BitmapImage newImage = new BitmapImage(new Uri(defaultImage, UriKind.Absolute));
			image.Source = newImage;
		}

		private void SetImage(Image image, string URL)
		{
			BitmapImage newImage = new BitmapImage(new Uri(URL, UriKind.Absolute));
			image.Source = newImage;
		}

		public void DisplayProductInfoGrid(Product product, TextBlock prodIdValue, TextBlock prodNameValue, TextBlock prodPriceValue, TextBlock prodRatingValue, Image image, float averageRating)
		{
			prodIdValue.Text = product.ProductId.ToString();
			prodNameValue.Text = product.Name;
			prodPriceValue.Text = $"£{product.Price}";
			if (averageRating >= 0)
			{
				prodRatingValue.Text = averageRating.ToString();
			} else
			{
				prodRatingValue.Text = "-";
			}

			try
			{
				SetImage(image, product.Url);
			}
			catch (UriFormatException)
			{
				SetImage(image);
			}
		}

	}
}
