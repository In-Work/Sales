﻿using Sales.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class UserForm : Window
    {
        User item;
        public UserForm(int id)
        {
            InitializeComponent();
            item = App.db.Users.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new User() { Id = 0, Role = App.db.Roles.First(p => p.Id == 2) };
                ChngPassword.IsChecked = true;
                ChngPassword.Visibility = Visibility.Collapsed;
                FldPassword.IsEnabled = true;
            }
            FldRole.ItemsSource = App.db.Roles.ToList();
            DataContext = item;
        }

        private void СhngPassword_Click(object sender, RoutedEventArgs e)
        {
            if (ChngPassword.IsChecked == true)
            {
                FldPassword.IsEnabled = true;
            }
            else
            {
                FldPassword.Password = "";
                FldPassword.IsEnabled = false;
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (ChngPassword.IsChecked == true && FldPassword.Password.Length == 0)
            {
                MessageBox.Show("Необходимо указать пароль!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                if (item.Id == 0)
                {
                    item.Password = Infrastructure.Auth.GetMD5(FldPassword.Password);
                    App.db.Users.Add(item);
                }
                else
                {
                    if (ChngPassword.IsChecked == true)
                    {
                        item.Password = Infrastructure.Auth.GetMD5(FldPassword.Password);
                    }
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
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
