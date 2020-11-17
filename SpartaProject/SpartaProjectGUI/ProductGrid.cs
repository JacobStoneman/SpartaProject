using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using SpartaProjectDB;

namespace SpartaProjectGUI
{
	public class ProductGrid
	{
		const string DefaultImage = "https://www.tibs.org.tw/images/default.jpg";

		private TextBlock _prodIdValue;
		private TextBlock _prodNameValue;
		private TextBlock _prodPriceValue;
		private TextBlock _prodRatingValue;
		private Image _image;

		private Product _focus;

		public Product Focus
		{
			get
			{
				return _focus;
			}
			set
			{
				_focus = value;
				DisplayProductInfoGrid();
			}
		}

		public ProductGrid(TextBlock id, TextBlock name, TextBlock price, TextBlock rating, Image image)
		{
			_prodIdValue = id;
			_prodNameValue = name;
			_prodPriceValue = price;
			_prodRatingValue = rating;
			_image = image;
		}

		private void SetImage(Image image)
		{
			BitmapImage newImage = new BitmapImage(new Uri(DefaultImage, UriKind.Absolute));
			image.Source = newImage;
		}

		private void SetImage(Image image, string URL)
		{
			BitmapImage newImage = new BitmapImage(new Uri(URL, UriKind.Absolute));
			image.Source = newImage;
		}

		public void InitialiseProductInfoGrid()
		{
			_prodIdValue.Text = string.Empty;
			_prodNameValue.Text = string.Empty;
			_prodPriceValue.Text = string.Empty;
			_prodRatingValue.Text = string.Empty;
			SetImage(_image);
		}

		private void DisplayProductInfoGrid()
		{
			float averageRating = _focus.GetAverageRating();
			_prodIdValue.Text = _focus.ProductId.ToString();
			_prodNameValue.Text = _focus.Name;
			_prodPriceValue.Text = $"£{_focus.Price}";
			if (averageRating >= 0)
			{
				_prodRatingValue.Text = averageRating.ToString();
			}
			else
			{
				_prodRatingValue.Text = "-";
			}

			try
			{
				SetImage(_image, _focus.Url);
			}
			catch (UriFormatException)
			{
				SetImage(_image);
			}
		}
	}
}
