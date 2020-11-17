using SpartaProjectBusiness;
using SpartaProjectGUI.Pages;
using SpartaProjectDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpartaProjectGUI.Pages
{
	/// <summary>
	/// Interaction logic for ProductPage.xaml
	/// </summary>
	public partial class ProductPage : Page
	{
		GUILogic logic = new GUILogic();
		
		CRUDManagerUser CrudUser;
		CRUDManagerProduct CrudProduct = new CRUDManagerProduct();
		CRUDManagerOrder CrudOrder = new CRUDManagerOrder();

		ProductGrid pGrid;

		public ProductPage(CRUDManagerUser crudUser)
		{
			CrudUser = crudUser;
			InitializeComponent();
			pGrid = new ProductGrid(textBlock_product_id_value, textBlock_product_name_value, textBlock_product_price_value, textBlock_product_rating_value, image_product);
			InitialiseValues();
			PopulateProductList();
		}

		private void InitialiseValues()
		{
			pGrid.InitialiseProductInfoGrid();
			button_review.IsEnabled = false;

			if (CrudUser.Selected.AccountType == 0)
			{
				button_configure_product.IsEnabled = true;
				button_configure_product.Visibility = Visibility.Visible;
				button_order_product.IsEnabled = false;
				button_order_product.Visibility = Visibility.Hidden;
			} else if (CrudUser.Selected.AccountType == 1)
			{
				button_configure_product.IsEnabled = false;
				button_configure_product.Visibility = Visibility.Hidden;
				button_order_product.IsEnabled = true;
				button_order_product.Visibility = Visibility.Visible;
			}
		}

		private void PopulateProductList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				List<Product> allProducts = CrudProduct.RetrieveAll<Product>();
				if (textBox_product_search.Text == string.Empty)
				{
					listBox_product.ItemsSource = allProducts;
				}
				else
				{
					List<Product> searchResults = new List<Product>();
					foreach (Product prod in allProducts)
					{
						string nameUpper = prod.Name.ToUpper();
						if (nameUpper.Contains(textBox_product_search.Text.ToUpper()))
						{
							searchResults.Add(prod);
						}
					}
					listBox_product.ItemsSource = searchResults;
				}
			}
		}

		private void PopulateReviewList()
		{
			using (ProjectContext db = new ProjectContext())
			{
				if (CrudProduct.Selected != null)
				{
					List<Review> prodReviews = (from r in db.Reviews where r.ProductId == CrudProduct.Selected.ProductId select r).ToList();
					listBox_reviews.ItemsSource = prodReviews;
				} else
				{
					listBox_reviews.ItemsSource = null;
				}
			}
		}

		private void SetProductValues()
		{
			if (CrudProduct.Selected == null)
			{
				InitialiseValues();
			}
			else
			{
				pGrid.Focus = CrudProduct.Selected;
			}
		}

		private float GetAverageRating()
		{
			float avRating = 0;
			using (ProjectContext db = new ProjectContext())
			{
				List<Review> allReviews = (from r in db.Reviews where r.ProductId == CrudProduct.Selected.ProductId select r).ToList();
				if (allReviews.Count == 0)
				{
					avRating = -1;
				}
				else
				{
					foreach (Review r in allReviews)
					{
						avRating += r.Rating;
					}
					avRating /= allReviews.Count();
				}
				return avRating;
			}
		}

		private void button_configure_product_Click(object sender, RoutedEventArgs e)
		{
			ProductConfig config = new ProductConfig(CrudProduct);
			config.Closed += ProductConfigClosed;
			config.ShowDialog();
		}

		private void ProductConfigClosed(object sender, EventArgs e)
		{
			PopulateProductList();
			CrudProduct.Selected = null;
		}

		private void listBox_product_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CrudProduct.Selected = CrudProduct.SetSelected<Product>(listBox_product.SelectedItem);
			SetProductValues();
			if(CrudUser.Selected.AccountType == 1)
			{
				button_review.IsEnabled = true;
			}
			PopulateReviewList();
		}

		private void textBox_product_search_TextChanged(object sender, TextChangedEventArgs e)
		{
			PopulateProductList();
		}

		private void button_order_product_Click(object sender, RoutedEventArgs e)
		{
			if (CrudProduct.Selected == null)
			{
				MessageBox.Show("Please select a product");
			}
			else
			{
				using (ProjectContext db = new ProjectContext())
				{
					Customer currentCustomer = db.Customers.Where(c => c.UserId == CrudUser.Selected.UserId).FirstOrDefault();
					CrudOrder.Create(CrudProduct.Selected, currentCustomer);
				}
				MessageBox.Show("Order Placed");
				CustomEvents.current.NewOrderPlaced();
			}
		}

		private void button_review_Click(object sender, RoutedEventArgs e)
		{
			using (ProjectContext db = new ProjectContext())
			{
				Review customerReview = db.Reviews.Where(r => r.ProductId == CrudProduct.Selected.ProductId && r.Customer.User.UserId == CrudUser.Selected.UserId).FirstOrDefault();
				Customer currentCustomer = db.Customers.Where(c => c.UserId == CrudUser.Selected.UserId).FirstOrDefault();
				ReviewConfig config = new ReviewConfig(customerReview, currentCustomer,CrudProduct.Selected);
				config.Closed += ReviewConfigClosed;
				config.ShowDialog();
			}
		}

		private void ReviewConfigClosed(object sender, EventArgs e)
		{
			if (CrudProduct.Selected != null)
			{
				PopulateReviewList();
				pGrid.Focus = CrudProduct.Selected;
			}
		}
	}
}
