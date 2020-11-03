using Sales.Entities;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class PaymentForm : Window
    {
        Payment payment;
        public PaymentForm(Payment payment)
        {
            InitializeComponent();
            this.payment = payment;
            FldDirection.ItemsSource = App.db.Directions.ToList();
            DataContext = this.payment;
        }

        public Payment SelectResult
        {
            get { return payment; }
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
