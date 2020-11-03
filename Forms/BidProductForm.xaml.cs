using Sales.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Sales.Forms
{
    public partial class BidProductForm : Window
    {
        BidProduct bidProduct;
        public BidProductForm(BidProduct bidProduct)
        {
            InitializeComponent();
            this.bidProduct = bidProduct;
            FldProduct.ItemsSource = App.db.Products.ToList();
            DataContext = this.bidProduct;
        }

        public BidProduct SelectResult
        {
            get { return bidProduct; }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void FldProduct_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FldProduct.SelectedItem != null)
            {
                Product product = FldProduct.SelectedItem as Product;
                FldPrice.Value = product.ActualPrice;
            }
        }
    }
}
