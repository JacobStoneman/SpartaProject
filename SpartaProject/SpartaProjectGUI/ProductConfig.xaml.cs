using SpartaProjectBusiness;
using System;
using System.Collections.Generic;
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
		}
	}
}
