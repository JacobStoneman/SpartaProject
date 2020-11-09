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
			//TODO: Abstract this
			decimal price;
			bool isDecimal = decimal.TryParse(textBox_price_value.Text, out price);
			if (!isDecimal)
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
			CrudProduct.Create(textBox_name_value.Text, price, textBox_URL_value.Text);
			MessageBox.Show($"Product: {textBox_name_value.Text} created");
		}

		private void button_update_Click(object sender, RoutedEventArgs e)
		{
			//TODO: Abstract this
			decimal price;
			bool isDecimal = decimal.TryParse(textBox_price_value.Text, out price);
			if (!isDecimal)
			{
				MessageBox.Show("Price must be a numeric value");
				return;
			}
			CrudProduct.Update(CrudProduct.Selected.ProductId, textBox_name_value.Text, price,textBox_URL_value.Text);
			MessageBox.Show($"Product: {textBox_name_value.Text} updated");
		}

		private void button_delete_Click(object sender, RoutedEventArgs e)
		{
			CrudProduct.Delete(CrudProduct.Selected.ProductId);
			MessageBox.Show($"Product: {textBox_name_value.Text} deleted");
			CrudProduct.Selected = null;
			textBlock_productID.Text = string.Empty;
			textBox_name_value.Text = string.Empty;
			textBox_price_value.Text = string.Empty;
			textBox_URL_value.Text = string.Empty;
			CustomEvents.current.ProductDeleted();
		}
	}
}
