using Sales.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Reports
{
    public partial class ReportBidsPage : Page
    {
        string title;
        int dirId;
        public ReportBidsPage(int dirId)
        {
            InitializeComponent();
            this.dirId = dirId;
            if (dirId == 1)
            {
                title = "Закупки";
            }
            else
            {
                title = "Продажи";
            }
            DateTime dateAt = DateTime.Now;
            FldDateAt.SelectedDate = new DateTime(dateAt.Year, dateAt.Month, dateAt.Day, 0, 0, 0);
            FldDateTo.SelectedDate = new DateTime(dateAt.Year, dateAt.Month, dateAt.Day, 23, 59, 59);
            ReportCreate();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var doc = fldBrowser.Document as mshtml.IHTMLDocument2;
                doc.execCommand("Print", true, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка печати", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            ReportCreate();
        }

        private string CreateTBody(int dirId, int? id, DateTime dateAt, DateTime dateTo)
        {
            string res = "";
            foreach (var product in App.db.Products.Where(p => p.ParentId == id))
            {
                var bidProducts = App.db.BidProducts.Where(p => p.ProductId == product.Id && p.Bid.Date >= dateAt && p.Bid.Date <= dateTo && p.Bid.DirectionId == dirId).ToList();
                if (bidProducts.Count > 0)
                {
                    var orders = App.db.Orders.Where(p => p.ProductId == product.Id && p.Bid.Date >= dateAt && p.Bid.Date <= dateTo && p.Bid.DirectionId == dirId).ToList();
                    res += HtmlReport.Tr(new string[] {
                        product.Name + ", " + product.Measure.Name,
                        string.Format("{0:f2}", bidProducts.Sum(p => p.Quantity)),
                        string.Format("{0:f2}", orders.Sum(p => p.Quantity)),
                        string.Format("{0:f2}", bidProducts.Sum(p => p.Summa) / bidProducts.Sum(p => p.Quantity)),
                        string.Format("{0:f2}", bidProducts.Sum(p => p.Summa)),
                    });
                }
            }
            foreach (var cat in App.db.Categories.Where(p => p.ParentId == id))
            {
                res += CreateTBody(dirId, cat.Id, dateAt, dateTo);
            }
            return res;
        }

        private void ReportCreate()
        {
            DateTime dateAt = (DateTime)FldDateAt.SelectedDate;
            dateAt = new DateTime(dateAt.Year, dateAt.Month, dateAt.Day, 0, 0, 0);
            DateTime dateTo = (DateTime)FldDateTo.SelectedDate;
            dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
            FldDateTo.SelectedDate = dateTo;
            string reportStr = "";
            reportStr += HtmlReport.PageStart(title);
            reportStr += HtmlReport.ReportHeader(title, dateAt, dateTo);
            string thead = "<tr><td rowspan=\"2\">Номенклатура</td><td colspan=\"2\">Количество</td><td rowspan=\"2\">Ср. цена</td><td rowspan=\"2\">Сумма</td></tr>";
            thead += "<tr><td>Заказано</td><td>" + (dirId == 1 ? "Получено" : "Отгружено") + "</td></tr>";
            string tbody = CreateTBody(dirId, null, dateAt, dateTo);
            reportStr += HtmlReport.Table(thead, tbody);
            reportStr += HtmlReport.PageEnd();
            fldBrowser.NavigateToString(reportStr);
        }

        private void FldDateTo_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FldDateTo.SelectedDate < FldDateAt.SelectedDate)
            {
                FldDateAt.SelectedDate = FldDateTo.SelectedDate;
            }
        }

        private void FldDateAt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FldDateTo.SelectedDate < FldDateAt.SelectedDate)
            {
                FldDateTo.SelectedDate = FldDateAt.SelectedDate;
            }
        }
    }
}