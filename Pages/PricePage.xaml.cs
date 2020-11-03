using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Pages
{
    public partial class PricePage : Page
    {
        public PricePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.db.UndoChanges();
            // Предустановки фильтра
            FltrGrid.Visibility = Visibility.Collapsed;
            FltrDateCheck.IsChecked = false;
            FltrDateAt.SelectedDate = DateTime.Now;
            FltrDateTo.SelectedDate = DateTime.Now;
            FltrProductCheck.IsChecked = false;
            FltrProduct.ItemsSource = App.db.Products.ToList();
            FltrProduct.SelectedIndex = 0;
            //
            GrdItemsFill();
        }

        private void ShowEditFrom(int id)
        {
            Forms.PriceForm frm = new Forms.PriceForm(id);
            frm.ShowDialog();
            App.db.UndoChanges();
            GrdItemsFill();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            ShowEditFrom(0);
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                Price item = GrdItems.SelectedItem as Price;
                ShowEditFrom(item.Id);
            }
        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                Price item = GrdItems.SelectedItem as Price;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: №{0} от {1:dd.MM.yyyy}", item.Id, item.Date), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Prices.Remove(item);
                    try
                    {
                        App.db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        App.db.UndoChanges();
                        MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    GrdItemsFill();
                }
            }
        }

        private void MenuFilter_Click(object sender, RoutedEventArgs e)
        {
            if (FltrGrid.Visibility == Visibility.Visible)
            {
                FltrGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                FltrGrid.Visibility = Visibility.Visible;
            }
        }

        private void FltrBtn_Click(object sender, RoutedEventArgs e)
        {
            GrdItemsFill();
        }

        private void GrdItemsFill()
        {
            List<Price> fltrList = App.db.Prices.ToList();
            if (FltrDateCheck.IsChecked == true && FltrDateAt.SelectedDate <= FltrDateTo.SelectedDate)
            {
                fltrList = fltrList.Where(p => p.Date >= FltrDateAt.SelectedDate && p.Date <= FltrDateTo.SelectedDate).ToList();
            }
            else
            {
                FltrDateCheck.IsChecked = false;
            }
            if (FltrProductCheck.IsChecked == true && FltrProduct.SelectedItem != null)
            {
                Product product = FltrProduct.SelectedItem as Product;
                fltrList = fltrList.Where(p => p.ProductId == product.Id).ToList();
            }
            else
            {
                FltrProductCheck.IsChecked = false;
            }
            GrdItems.ItemsSource = fltrList;
        }

        private void FltrCancel_Click(object sender, RoutedEventArgs e)
        {
            FltrDateCheck.IsChecked = false;
            FltrProductCheck.IsChecked = false;
            GrdItemsFill();
        }
    }
}