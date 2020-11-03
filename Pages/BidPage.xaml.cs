using Sales.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Sales.Pages
{
    public partial class BidPage : Page
    {
        Bid item;
        public BidPage(int id, int dirId)
        {
            InitializeComponent();
            item = App.db.Bids.FirstOrDefault(p => p.Id == id);
            if (item == null)
            {
                item = new Bid()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Direction = App.db.Directions.Find(dirId),
                    Partner = (dirId == 1) ? App.db.Partners.First(p => p.IsSupplier == true) : App.db.Partners.First(p => p.IsPurchaser == true),
                    Store = App.db.Stores.First(),
                    DeliveryTime = 0,
                    PaymentTime = 0,
                    User = App.db.Users.Find(App.user.Id)
                };
            }
            if (dirId == 1)
            {
                FldPartner.ItemsSource = App.db.Partners.Where(p => p.IsSupplier == true).ToList();
            }
            else
            {
                FldPartner.ItemsSource = App.db.Partners.Where(p => p.IsPurchaser == true).ToList();
            }
            FldStore.ItemsSource = App.db.Stores.ToList();
            DataContext = item;
            GrdProducts.ItemsSource = item.BidProducts;
            GrdPayments.ItemsSource = item.Payments;
            GrdOrders.ItemsSource = item.Orders;
            SetBalance();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (item.BidProducts.Count > 0)
            {
                if (item.Id == 0)
                {
                    App.db.Bids.Add(item);
                }
                else
                {
                    App.db.Entry(item).State = EntityState.Modified;
                }
                try
                {
                    App.db.SaveChanges();
                    NavigationService.Navigate(new BidsListPage(item.DirectionId));
                }
                catch (Exception ex)
                {
                    App.db.UndoChanges();
                    MessageBox.Show(
                        ex.Message,
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Не указаны данные для расчета! Заполните табличную часть...",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BidsListPage(item.DirectionId));
        }

        private void MenuProductAdd_Click(object sender, RoutedEventArgs e)
        {
            BidProduct bidProduct = new BidProduct()
            {
                Bid = item,
                Product = App.db.Products.First(),
                Quantity = 1M,
                Price = 1M
            };
            Forms.BidProductForm frm = new Forms.BidProductForm(bidProduct);
            if (frm.ShowDialog() == true)
            {
                bidProduct = frm.SelectResult;
                App.db.BidProducts.Add(bidProduct);
                GrdProducts.Items.Refresh();
                SetBalance();
            }
        }

        private void MenuProductEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdProducts.SelectedItem != null)
            {
                BidProduct bidProduct = GrdProducts.SelectedItem as BidProduct;
                Forms.BidProductForm frm = new Forms.BidProductForm(bidProduct);
                if (frm.ShowDialog() != true)
                {
                    bidProduct = frm.SelectResult;
                    App.db.Entry(bidProduct).State = EntityState.Unchanged;
                }
                GrdProducts.Items.Refresh();
                SetBalance();
            }
        }

        private void MenuProductDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdProducts.SelectedItem != null)
            {
                BidProduct bidProduct = GrdProducts.SelectedItem as BidProduct;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: {0} {1:f3} {2}", bidProduct.Product.Name, bidProduct.Quantity, bidProduct.Product.Measure.Name), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.BidProducts.Remove(bidProduct);
                    GrdProducts.Items.Refresh();
                    SetBalance();
                }
            }
        }

        private void MenuOrderAdd_Click(object sender, RoutedEventArgs e)
        {
            if (item.BidProducts.Count > 0)
            {
                Order order = new Order()
                {
                    Date = DateTime.Now,
                    Bid = item,
                    Product = item.BidProducts.First().Product,
                    Quantity = 1,
                    User = App.db.Users.Find(App.user.Id)
                };
                Forms.OrderForm frm = new Forms.OrderForm(order);
                if (frm.ShowDialog() == true)
                {
                    order = frm.SelectResult;
                    App.db.Orders.Add(order);
                    GrdOrders.Items.Refresh();
                }
            }
        }

        private void MenuOrderEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdOrders.SelectedItem != null)
            {
                Order order = GrdOrders.SelectedItem as Order;
                Forms.OrderForm frm = new Forms.OrderForm(order);
                if (frm.ShowDialog() != true)
                {
                    order = frm.SelectResult;
                    App.db.Entry(order).State = EntityState.Unchanged;
                }
                GrdOrders.Items.Refresh();
            }
        }

        private void MenuOrderDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdOrders.SelectedItem != null)
            {
                Order order = GrdOrders.SelectedItem as Order;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: №{0} от {1:dd.MM.yyyy}", order.Id, order.Date), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Orders.Remove(order);
                    GrdOrders.Items.Refresh();
                }
            }
        }

        private void MenuPaymentAdd_Click(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment()
            {
                Date = DateTime.Now,
                Direction = App.db.Directions.Find(item.DirectionId),
                Bid = item,
                Summa = item.BidProducts.Sum(p => p.Summa) - item.Payments.Sum(p => p.Summa),
                User = App.db.Users.Find(App.user.Id)
            };
            Forms.PaymentForm frm = new Forms.PaymentForm(payment);
            if (frm.ShowDialog() == true)
            {
                payment = frm.SelectResult;
                App.db.Payments.Add(payment);
                GrdPayments.Items.Refresh();
                SetBalance();
            }
        }

        private void MenuPaymentEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GrdPayments.SelectedItem != null)
            {
                Payment payment = GrdPayments.SelectedItem as Payment;
                Forms.PaymentForm frm = new Forms.PaymentForm(payment);
                if (frm.ShowDialog() != true)
                {
                    payment = frm.SelectResult;
                    App.db.Entry(payment).State = EntityState.Unchanged;
                }
                GrdPayments.Items.Refresh();
                SetBalance();
            }
        }

        private void MenuPaymentDelete_Click(object sender, RoutedEventArgs e)
        {
            if (GrdPayments.SelectedItem != null)
            {
                Payment payment = GrdPayments.SelectedItem as Payment;
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить: №{0} от {1:dd.MM.yyyy}", payment.Id, payment.Date), "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    App.db.Payments.Remove(payment);
                    GrdPayments.Items.Refresh();
                    SetBalance();
                }
            }
        }

        private void SetBalance()
        {
            decimal summa = item.BidProducts.Sum(p => p.Summa);
            decimal balance = summa - item.Payments.Sum(p => p.Summa);
            LblSumma.Text = string.Format("{0:f2}", summa);
            LblBalance.Text = string.Format("{0:f2}", balance);
        }
    }
}