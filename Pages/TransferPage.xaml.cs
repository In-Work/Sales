using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Pages
{
    public partial class TransferPage : Page
    {
        public TransferPage()
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
            FltrStoreAtCheck.IsChecked = false;
            FltrStoreAt.ItemsSource = App.db.Stores.ToList();
            FltrStoreAt.SelectedIndex = 0;
            FltrStoreToCheck.IsChecked = false;
            FltrStoreTo.ItemsSource = App.db.Stores.ToList();
            FltrStoreTo.SelectedIndex = 0;
            FltrProductCheck.IsChecked = false;
            FltrProduct.ItemsSource = App.db.Products.ToList();
            FltrProduct.SelectedIndex = 0;
            //
            GrdItemsFill();
        }

        private void ShowEditFrom(int id)
        {
            Forms.TransferForm frm = new Forms.TransferForm(id);
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
                Transfer item = GrdItems.SelectedItem as Transfer;
                ShowEditFrom(item.Id);
            }
        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                Transfer item = GrdItems.SelectedItem as Transfer;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: №{0} от {1:dd.MM.yyyy}", item.Id, item.Date), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Transfers.Remove(item);
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
            List<Transfer> fltrList = App.db.Transfers.ToList();
            if (FltrDateCheck.IsChecked == true && FltrDateAt.SelectedDate <= FltrDateTo.SelectedDate)
            {
                fltrList = fltrList.Where(p => p.Date >= FltrDateAt.SelectedDate && p.Date <= FltrDateTo.SelectedDate).ToList();
            }
            else
            {
                FltrDateCheck.IsChecked = false;
            }
            if (FltrStoreAtCheck.IsChecked == true && FltrStoreAt.SelectedItem != null)
            {
                Store storeAt = FltrStoreAt.SelectedItem as Store;
                fltrList = fltrList.Where(p => p.StoreAtId == storeAt.Id).ToList();
            }
            else
            {
                FltrStoreAtCheck.IsChecked = false;
            }
            if (FltrStoreToCheck.IsChecked == true && FltrStoreTo.SelectedItem != null)
            {
                Store storeTo = FltrStoreTo.SelectedItem as Store;
                fltrList = fltrList.Where(p => p.StoreToId == storeTo.Id).ToList();
            }
            else
            {
                FltrStoreToCheck.IsChecked = false;
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
            FltrStoreAtCheck.IsChecked = false;
            FltrStoreToCheck.IsChecked = false;
            FltrProductCheck.IsChecked = false;
            GrdItemsFill();
        }
    }
}