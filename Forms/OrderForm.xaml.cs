using Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Sales.Forms
{
    public partial class OrderForm : Window
    {
        Order order;
        public OrderForm(Order order)
        {
            InitializeComponent();
            this.order = order;
            List<Product> products = new List<Product>();
            foreach (var bidProduct in order.Bid.BidProducts)
            {
                products.Add(App.db.Products.Find(bidProduct.ProductId));
            }
            FldProduct.ItemsSource = products;
            DataContext = this.order;
        }

        public Order SelectResult
        {
            get { return order; }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}