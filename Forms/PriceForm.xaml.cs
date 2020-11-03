using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class PriceForm : Window
    {
        Price item;
        public PriceForm(int id)
        {
            InitializeComponent();
            item = App.db.Prices.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new Price()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Value = 1,
                    User = App.db.Users.Find(App.user.Id)
                };
            }
            FldProduct.ItemsSource = App.db.Products.ToList();
            DataContext = item;
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (item.Id == 0)
            {
                App.db.Prices.Add(item);
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
