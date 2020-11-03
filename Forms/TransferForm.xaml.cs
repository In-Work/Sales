using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class TransferForm : Window
    {
        Transfer item;
        public TransferForm(int id)
        {
            InitializeComponent();
            item = App.db.Transfers.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new Transfer()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Quantity = 1,
                    User = App.db.Users.Find(App.user.Id)
                };
            }
            FldStoreAt.ItemsSource = App.db.Stores.ToList();
            FldStoreTo.ItemsSource = App.db.Stores.ToList();
            FldProduct.ItemsSource = App.db.Products.ToList();
            DataContext = item;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (item.Id == 0)
            {
                App.db.Transfers.Add(item);
            }
            else
            {
                App.db.Entry(item).State = EntityState.Modified;
            }
            try
            {
                App.db.SaveChanges();
            }
            catch (Exception ex)
            {
                App.db.UndoChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
