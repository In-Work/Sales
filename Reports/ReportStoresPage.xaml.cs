using Sales.Entities;
using Sales.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Reports
{
    public partial class ReportStoresPage : Page
    {
        string title;
        public ReportStoresPage()
        {
            InitializeComponent();
            title = "Товары на складах";
            FldDateTo.SelectedDate = DateTime.Now;
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

        private string CreateTBody(int storeId, int? id, DateTime dateTo)
        {
            string res = "";
            foreach (var product in App.db.Products.Where(p => p.ParentId == id))
            {

                decimal purschases = App.db.BidProducts.Where(p => p.Bid.StoreId == storeId && p.ProductId == product.Id && p.Bid.Date <= dateTo && p.Bid.DirectionId == 1).ToList().Sum(p => p.Quantity);
                decimal sales = App.db.BidProducts.Where(p => p.Bid.StoreId == storeId && p.ProductId == product.Id && p.Bid.Date <= dateTo && p.Bid.DirectionId == 2).ToList().Sum(p => p.Quantity);
                decimal transferAt = App.db.Transfers.Where(p => p.StoreAtId == storeId && p.ProductId == product.Id && p.Date <= dateTo).ToList().Sum(p => p.Quantity);
                decimal transferTo = App.db.Transfers.Where(p => p.StoreToId == storeId && p.ProductId == product.Id && p.Date <= dateTo).ToList().Sum(p => p.Quantity);
                decimal ost = purschases - sales - transferAt + transferTo;
                if (ost != 0)
                {
                    res += HtmlReport.Tr(new string[] { product.Name + ", " + product.Measure.Name, string.Format("{0:f3}", ost) });
                }
            }
            foreach (var cat in App.db.Categories.Where(p => p.ParentId == id))
            {
                res += CreateTBody(storeId, cat.Id, dateTo);
            }
            return res;
        }

        private void ReportCreate()
        {
            DateTime dateTo = (DateTime)FldDateTo.SelectedDate;
            dateTo = new DateTime(dateTo.Year, dateTo.Month, dateTo.Day, 23, 59, 59);
            FldDateTo.SelectedDate = dateTo;
            string reportStr = "";
            reportStr += HtmlReport.PageStart(title);
            reportStr += string.Format("<h1>{0}</h1>", title);
            reportStr += string.Format("<p class=\"dates\">На дату {0:dd.MM.yyyy}</p>", dateTo);
            string thead = HtmlReport.Tr(new string[] { "Номенклатура", "Количество" });
            string tbody = "";
            foreach (var store in App.db.Stores)
            {
                tbody += HtmlReport.TrColspan(store.Name, 2);
                tbody += CreateTBody(store.Id, null, dateTo);
            }
            reportStr += HtmlReport.Table(thead, tbody);
            reportStr += HtmlReport.PageEnd();
            fldBrowser.NavigateToString(reportStr);
        }
    }
}