using Sales.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Pages
{
    public partial class NomenclaturePage : Page
    {
        public NomenclaturePage()
        {
            InitializeComponent();
            TrvCategories.ItemsSource = App.db.Categories.Where(p => p.ParentId == null).ToList();
        }

        private void ShowCatEditForm(int id)
        {
            int? parentId = null;
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem as Category;
                parentId = item.Id;
            }
            Forms.CategoryForm frm = new Forms.CategoryForm(id, parentId);
            frm.ShowDialog();
            App.db.UndoChanges();
            TrvCategories.ItemsSource = App.db.Categories.Where(p => p.ParentId == null).ToList();
        }

        private void MenuCatAdd_Click(object sender, RoutedEventArgs e)
        {
            ShowCatEditForm(0);
        }

        private void MenuCatEdit_Click(object sender, RoutedEventArgs e)
        {
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem as Category;
                ShowCatEditForm(item.Id);
            }
        }

        private void MenuCatDelete_Click(object sender, RoutedEventArgs e)
        {
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem as Category;
                if (item.Products.Count > 0 || item.Categories.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить объект, т.к. на него имеются ссылки!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show(string.Format("Вы действительно хотите удалить: {0}", item.Name), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.db.Categories.Remove(item);
                        try
                        {
                            App.db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            App.db.UndoChanges();
                            MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        TrvCategories.ItemsSource = App.db.Categories.Where(p => p.ParentId == null).ToList();
                    }
                }
            }
        }

        private void ShowNomEditForm(int id)
        {
            int? parentId = null;
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem as Category;
                parentId = item.Id;
            }
            Forms.ProductForm frm = new Forms.ProductForm(id, parentId);
            frm.ShowDialog();
            App.db.UndoChanges();
            GrdItems.ItemsSource = App.db.Products.Where(p => p.ParentId == parentId).ToList();
        }

        private void MenuNomAdd_Click(object sender, RoutedEventArgs e)
        {
            ShowNomEditForm(0);
        }

        private void MenuNomEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                var item = GrdItems.SelectedItem as Product;
                ShowNomEditForm(item.Id);
            }
        }

        private void MenuNomDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdItems.SelectedItem != null)
            {
                var item = GrdItems.SelectedItem as Product;
                if (item.BidProducts.Count > 0 || item.Orders.Count > 0 || item.Transfers.Count > 0 || item.Prices.Count > 0)
                {
                    MessageBox.Show("Нельзя удалить объект, т.к. на него имеются ссылки!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show(string.Format("Вы действительно хотите удалить: {0}", item.Name), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        App.db.Products.Remove(item);
                        try
                        {
                            App.db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            App.db.UndoChanges();
                            MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        int? parentId = null;
                        if (TrvCategories.SelectedItem != null)
                        {
                            var parent = TrvCategories.SelectedItem as Category;
                            parentId = parent.Id;
                        }
                        GrdItems.ItemsSource = App.db.Products.Where(p => p.ParentId == parentId).ToList();
                    }
                }
            }
        }

        private void TrvCategories_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem as Category;
                GrdItems.ItemsSource = App.db.Products.Where(p => p.ParentId == item.Id).ToList();
            }
        }

        private void MenuCatClear_Click(object sender, RoutedEventArgs e)
        {
            if (TrvCategories.SelectedItem != null)
            {
                var item = TrvCategories.SelectedItem;
                var tvi = GetContainerFromItem(TrvCategories, item);
                if (tvi != null)
                {
                    tvi.IsSelected = false;
                }
                GrdItems.ItemsSource = App.db.Products.Where(p => p.ParentId == null).ToList();
            }
        }

        private static TreeViewItem GetContainerFromItem(TreeView treeView, object item)
        {
            TreeViewItem containerItem = treeView.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
            if (containerItem == null)
            {
                return GetContainerFromItem(treeView.ItemContainerGenerator, treeView.Items, item);
            }
            else
            {
                return containerItem;
            }
        }

        private static TreeViewItem GetContainerFromItem(ItemContainerGenerator containerGenerator, ItemCollection items, object item)
        {
            foreach (object child in items)
            {
                TreeViewItem parentContainer = containerGenerator.ContainerFromItem(child) as TreeViewItem;
                if (parentContainer == null)
                {
                    return null;
                }
                TreeViewItem containerItem = parentContainer.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
                if (containerItem == null)
                {
                    TreeViewItem recContainer = GetContainerFromItem(parentContainer.ItemContainerGenerator, parentContainer.Items, item);
                    if (recContainer != null)
                    {
                        return recContainer;
                    }
                }
                else
                {
                    return containerItem;
                }
            }
            return null;
        }
    }
}
