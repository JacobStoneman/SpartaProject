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
	/// Interaction logic for ProductConfig.xaml
	/// </summary>
	public partial class ProductConfig : Window
	{
		GUILogic logic = new GUILogic();
		CRUDManagerProduct CrudProduct;
		public ProductConfig(CRUDManagerProduct crudProduct)
		{
			CrudProduct = crudProduct;
			InitializeComponent();
			InitialiseValues();
		}

		private void InitialiseValues()
		{
			if (CrudProduct.Selected != null)
			{
				textBlock_productID_value.Text = CrudProduct.Selected.ProductId.ToString();
				textBox_name_value.Text = CrudProduct.Selected.Name;
				textBox_price_value.Text = CrudProduct.Selected.Price.ToString();
				textBox_URL_value.Text = CrudProduct.Selected.Url.ToString();
			}
		}

		private void button_add_Click(object sender, RoutedEventArgs e)
		{
			(bool, decimal) priceInput = logic.CheckDecimalInput(textBox_price_value.Text);

			if (!priceInput.Item1)
			{
				MessageBox.Show("Price must be a numeric value");
				return;
			}
			using (ProjectContext db = new ProjectContext())
			{
				if (db.Products.Any(p => p.Name == textBox_name_value.Text))
				{
					MessageBox.Show($"Product: {textBox_name_value.Text} already exists");
					return;
				} 
			}
			CrudProduct.Create(textBox_name_value.Text, priceInput.Item2, textBox_URL_value.Text);
			MessageBox.Show($"Product: {textBox_name_value.Text} created");
		}

		private void button_update_Click(object sender, RoutedEventArgs e)
		{
			if (CrudProduct.Selected != null)
			{
				(bool, decimal) priceInput = logic.CheckDecimalInput(textBox_price_value.Text);

				if (!priceInput.Item1)
				{
					MessageBox.Show("Price must be a numeric value");
					return;
				}
				CrudProduct.Update(CrudProduct.Selected, textBox_name_value.Text, priceInput.Item2, textBox_URL_value.Text);
				MessageBox.Show($"Product: {textBox_name_value.Text} updated");
			} else
			{
				MessageBox.Show("Please select a product to update");
			}
		}

		private void button_delete_Click(object sender, RoutedEventArgs e)
		{
			if (CrudProduct.Selected != null)
			{
				CrudProduct.Delete(CrudProduct.Selected);
				using (ProjectContext db = new ProjectContext())
				{
				}
				MessageBox.Show($"Product: {textBox_name_value.Text} deleted");
				CrudProduct.Selected = null;
				textBlock_productID.Text = string.Empty;
				textBox_name_value.Text = string.Empty;
				textBox_price_value.Text = string.Empty;
				textBox_URL_value.Text = string.Empty;
				CustomEvents.current.ProductDeleted();
			} else
			{
				MessageBox.Show("Please select a product to delete");
			}
		}
	}
}
