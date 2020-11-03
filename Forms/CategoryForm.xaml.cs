using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class CategoryForm : Window
    {
        Category item;
        List<Category> categories = new List<Category>();
        public CategoryForm(int id, int? parentId)
        {
            InitializeComponent();
            item = App.db.Categories.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new Category() { Id = 0, Parent = App.db.Categories.FirstOrDefault(p => p.Id == parentId) };
            }
            CategoriesFill(null);
            FldCategory.ItemsSource = categories;
            DataContext = item;
        }

        public void CategoriesFill(int? parentId)
        {
            foreach (var cat in App.db.Categories.Where(p => p.ParentId == parentId))
            {
                if (cat.Id != item.Id)
                {
                    categories.Add(cat);
                    if (cat.Categories.Count > 0)
                    {
                        CategoriesFill(cat.Id);
                    }
                }
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (item.Id == 0)
            {
                App.db.Categories.Add(item);
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

        private void BtnParentClear_Click(object sender, RoutedEventArgs e)
        {
            FldCategory.SelectedIndex = -1;
        }
    }
}