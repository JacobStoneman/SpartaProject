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

		private void button_add_Click(object sender, RoutedEventArgs e)
		{
			CrudReview.Create(int.Parse(textBox_rating_value.Text), textBox_comment_value.Text, Reviewer, Product);
			Close();
		}

		private void button_update_Click(object sender, RoutedEventArgs e)
		{
			CrudReview.Update(Selected.ReviewId, int.Parse(textBox_rating_value.Text), textBox_comment_value.Text);
			MessageBox.Show("Your review has been updated");
		}

		private void button_delete_Click(object sender, RoutedEventArgs e)
		{
			CrudReview.Delete(Selected.ReviewId);
			MessageBox.Show("Your review has been deleted");
			Close();
		}
	}
}
