using SpartaProjectBusiness;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace SpartaProjectGUI
{
	/// <summary>
	/// Interaction logic for ReviewConfig.xaml
	/// </summary>
	public partial class ReviewConfig : Window
	{
		Review Selected;
		Customer Reviewer;
		Product Product;
		CRUDManagerReview CrudReview = new CRUDManagerReview();
		InputValidator validator = new InputValidator();
		public ReviewConfig(Review selected, Customer customer, Product product)
		{
			Selected = selected;
			Reviewer = customer;
			Product = product;
			InitializeComponent();
			InitialiseValues();
		}

		private void InitialiseValues()
		{
			if (Selected == null)
			{
				button_add.IsEnabled = true;
				button_delete.IsEnabled = false;
				button_update.IsEnabled = false;
			}
			else
			{
				button_add.IsEnabled = false;
				button_delete.IsEnabled = true;
				button_update.IsEnabled = true;

				textBox_comment_value.Text = Selected.Comment;
				textBox_rating_value.Text = Selected.Rating.ToString();
			}
		}

		private void Button_add_Click(object sender, RoutedEventArgs e)
		{
			(bool, int) ratingInput = validator.CheckIntInput(textBox_rating_value.Text);

			if (!ratingInput.Item1)
			{
				MessageBox.Show("Rating must be an integer");
			} 
			else if (ratingInput.Item2 <= 0 || ratingInput.Item2 > 5)
			{
				MessageBox.Show("Rating must be between 1 and 5");
			} 
			else
			{
				CrudReview.Create(ratingInput.Item2, textBox_comment_value.Text, Reviewer, Product);
				Close();
			}

		}

		private void button_update_Click(object sender, RoutedEventArgs e)
		{
			(bool, int) ratingInput = validator.CheckIntInput(textBox_rating_value.Text);

			if (!ratingInput.Item1)
			{
				MessageBox.Show("Rating must be an integer");
			}
			else if (ratingInput.Item2 <= 0 || ratingInput.Item2 > 5)
			{
				MessageBox.Show("Rating must be between 1 and 5");
			}
			else
			{
				CrudReview.Update(Selected, ratingInput.Item2, textBox_comment_value.Text);
				MessageBox.Show("Your review has been updated");
			}
		}

		private void button_delete_Click(object sender, RoutedEventArgs e)
		{
			CrudReview.Delete(Selected);
			MessageBox.Show("Your review has been deleted");
			Close();
		}
	}
}
