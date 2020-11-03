using Sales.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Sales.Reports
{
    public partial class ReportPricePage : Page
    {
        string title;
        public ReportPricePage()
        {
            InitializeComponent();
            title = "Прайс-лист";
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

        private string CreateTBody(int? id, DateTime dateTo)
        {
            string res = "";
            var parent = App.db.Categories.Find(id);
            if (parent != null)
            {
                res += HtmlReport.TrSub(new string[] { parent.Name, "" });
            }
            foreach (var product in App.db.Products.Where(p => p.ParentId == id))
            {
                res += HtmlReport.Tr(new string[] { product.Name + ", " + product.Measure.Name, string.Format("{0:f2}", product.ActualPrice) });
            }
            foreach (var cat in App.db.Categories.Where(p => p.ParentId == id))
            {
                res += CreateTBody(cat.Id, dateTo);
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
            string thead = HtmlReport.Tr(new string[] { "Номенклатура", "Цена" });
            string tbody = CreateTBody(null, dateTo);
            reportStr += HtmlReport.Table(thead, tbody);
            reportStr += HtmlReport.PageEnd();
            fldBrowser.NavigateToString(reportStr);
        }
    }
}