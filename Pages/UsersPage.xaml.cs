using Sales.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Pages
{
    public partial class UsersPage : Page
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            GrdItems.ItemsSource = App.db.Users.ToList();
        }

        private void ShowEditForm(int id)
        {
            Forms.UserForm frm = new Forms.UserForm(id);
            frm.ShowDialog();
            App.db.UndoChanges();
            GrdItems.ItemsSource = App.db.Users.ToList();
        }

        private void MenuAdd_Click(object sender, RoutedEventArgs e)
        {
            ShowEditForm(0);
        }

        private void MenuEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                var item = GrdItems.SelectedItem as User;
                ShowEditForm(item.Id);
            }
        }

        private void MenuDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                var item = GrdItems.SelectedItem as User;
                if (item.Id == App.user.Id)
                {
                    MessageBox.Show("Нельзя удалить собственную запись!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (item.Bids.Count > 0 || item.Orders.Count > 0 || item.Payments.Count > 0 || item.Prices.Count > 0 || item.Transfers.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить объект, т.к. на него имеются ссылки!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show(string.Format("Вы действительно хотите удалить: {0}", item.Name), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.db.Users.Remove(item);
                        try
                        {
                            App.db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            App.db.UndoChanges();
                            MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        GrdItems.ItemsSource = App.db.Users.ToList();
                    }
                }
            }
        }
    }
}
