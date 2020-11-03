using Sales.Entities;
using System.Linq;
using System.Windows;

namespace Sales.Forms
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LstUsers.ItemsSource = App.db.Users.Where(p => p.Enabled).ToList();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LstUsers.SelectedItem != null)
            {
                User user = LstUsers.SelectedItem as User;
                if (user.Password.Equals(Infrastructure.Auth.GetMD5(FldPassword.Password)))
                {
                    Hide();
                    App.user = user;
                    Main frm = new Main();
                    frm.ShowDialog();
                    Close();
                }
                else
                {
                    FldPassword.Password = "";
                    MessageBox.Show("Неверный пароль!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
                MessageBox.Show("Необходимо выбрать пользователя!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
