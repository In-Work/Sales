using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Sales.Pages
{
    public partial class BidsListPage : Page
    {
        int dirId;
        public BidsListPage(int dirId)
        {
            InitializeComponent();
            this.dirId = dirId;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.db.UndoChanges();
            // Предустановки фильтра
            FltrGrid.Visibility = Visibility.Collapsed;
            FltrDateCheck.IsChecked = false;
            FltrDateAt.SelectedDate = DateTime.Now;
            FltrDateTo.SelectedDate = DateTime.Now;
            FltrPartnerCheck.IsChecked = false;
            if (dirId == 1)
            {
                FltrPartner.ItemsSource = App.db.Partners.Where(p => p.IsSupplier == true).ToList();
            }
            else
            {
                FltrPartner.ItemsSource = App.db.Partners.Where(p => p.IsPurchaser == true).ToList();
            }
            FltrPartner.SelectedIndex = 0;
            FltrStoreCheck.IsChecked = false;
            FltrStore.ItemsSource = App.db.Stores.ToList();
            FltrStore.SelectedIndex = 0;
            //
            GrdItemsFill();
        }

        private void ShowEditFrom(int id)
        {
            NavigationService.Navigate(new BidPage(id, dirId));
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
                Bid item = GrdItems.SelectedItem as Bid;
                ShowEditFrom(item.Id);
            }
        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                Bid item = GrdItems.SelectedItem as Bid;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: №{0} от {1:dd.MM.yyyy}", item.Id, item.Date), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Bids.Remove(item);
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
            List<Bid> fltrList = App.db.Bids.Where(p => p.DirectionId == dirId).ToList();
            if (FltrDateCheck.IsChecked == true && FltrDateAt.SelectedDate <= FltrDateTo.SelectedDate)
            {
                fltrList = fltrList.Where(p => p.Date >= FltrDateAt.SelectedDate && p.Date <= FltrDateTo.SelectedDate).ToList();
            }
            else
            {
                FltrDateCheck.IsChecked = false;
            }
            if (FltrPartnerCheck.IsChecked == true && FltrPartner.SelectedItem != null)
            {
                Partner partner = FltrPartner.SelectedItem as Partner;
                fltrList = fltrList.Where(p => p.PartnerId == partner.Id).ToList();
            }
            else
            {
                FltrPartnerCheck.IsChecked = false;
            }
            if (FltrStoreCheck.IsChecked == true && FltrStore.SelectedItem != null)
            {
                Store store = FltrStore.SelectedItem as Store;
                fltrList = fltrList.Where(p => p.StoreId == store.Id).ToList();
            }
            else
            {
                FltrStoreCheck.IsChecked = false;
            }
            GrdItems.ItemsSource = fltrList;
        }

        private void FltrCancel_Click(object sender, RoutedEventArgs e)
        {
            FltrDateCheck.IsChecked = false;
            FltrPartnerCheck.IsChecked = false;
            FltrStoreCheck.IsChecked = false;
            GrdItemsFill();
        }
    }
}