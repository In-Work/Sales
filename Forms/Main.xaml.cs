using System.Windows;

namespace Sales.Forms
{
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            LblUser.Text = App.user.Name;
            if (!(App.user.RoleId == 1))
            {
                MenuUsers.Visibility = Visibility.Collapsed;
            }
            if (App.user.RoleId == 3)
            {
                MenuNomenclature.Visibility = Visibility.Collapsed;
                MenuMeasures.Visibility = Visibility.Collapsed;
                MenuStores.Visibility = Visibility.Collapsed;
                MenuPurchase.Visibility = Visibility.Collapsed;
                MenuTransfer.Visibility = Visibility.Collapsed;
                MenuPrice.Visibility = Visibility.Collapsed;
                MenuReportSales.Visibility = Visibility.Collapsed;
                MenuReportPurchases.Visibility = Visibility.Collapsed;
            }
            FrameMain.Navigate(new Pages.NomenclaturePage());
            LblStatus.Text = "Номенклатура";
        }

        private void FrameMain_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            FrameMain.NavigationService.RemoveBackEntry();
        }

        private void MenuNomenclature_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.NomenclaturePage());
            LblStatus.Text = "Номенклатура";
        }

        private void MenuStores_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.StoresPage());
            LblStatus.Text = "Склады";
        }

        private void MenuPartners_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.PartnersPage());
            LblStatus.Text = "Контрагенты";
        }

        private void MenuMeasures_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.MeasuresPage());
            LblStatus.Text = "Единицы измерения";
        }

        private void MenuUsers_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.UsersPage());
            LblStatus.Text = "Пользователи";
        }

        private void MenuPurchase_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.BidsListPage(1));
            LblStatus.Text = "Закупки";
        }

        private void MenuSale_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.BidsListPage(2));
            LblStatus.Text = "Продажи";
        }

        private void MenuPrice_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.PricePage());
            LblStatus.Text = "Цены";
        }

        private void MenuTransfer_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Pages.TransferPage());
            LblStatus.Text = "Перемещения";
        }

        private void MenuReportStores_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Reports.ReportStoresPage());
            LblStatus.Text = "Товары на складах";
        }

        private void MenuReportPrice_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Reports.ReportPricePage());
            LblStatus.Text = "Прайс-лист";
        }

        private void MenuReportSales_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Reports.ReportBidsPage(2));
            LblStatus.Text = "Продажи";
        }

        private void MenuReportPurchases_Click(object sender, RoutedEventArgs e)
        {
            FrameMain.Navigate(new Reports.ReportBidsPage(1));
            LblStatus.Text = "Закупки";
        }
    }
}
