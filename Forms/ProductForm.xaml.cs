using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class ProductForm : Window
    {
        Product item;
        List<Category> categories = new List<Category>();
        public ProductForm(int id, int? parentId)
        {
            InitializeComponent();
            item = App.db.Products.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new Product() { Id = 0, Measure = App.db.Measures.FirstOrDefault(), Parent = App.db.Categories.FirstOrDefault(p => p.Id == parentId) };
            }
            CategoriesFill(null);
            FldCategory.ItemsSource = categories;
            FldMeasure.ItemsSource = App.db.Measures.ToList();
            DataContext = item;
        }

        public void CategoriesFill(int? parentId)
        {
            foreach (var cat in App.db.Categories.Where(p => p.ParentId == parentId))
            {
                categories.Add(cat);
                if (cat.Categories.Count > 0)
                {
                    CategoriesFill(cat.Id);
                }
            }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (item.Id == 0)
            {
                App.db.Products.Add(item);
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
