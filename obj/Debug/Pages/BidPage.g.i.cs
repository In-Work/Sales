﻿#pragma checksum "..\..\..\Pages\BidPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9E96CD3656B1610D6C0891087FF1875D0D5FD8F96DB9E75B9721C3CC7460BCF1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Sales.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Sales.Pages {
    
    
    /// <summary>
    /// BidPage
    /// </summary>
    public partial class BidPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker FldDate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FldPartner;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox FldStore;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown FldDeliveryTime;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.Toolkit.IntegerUpDown FldPaymentTime;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuProductAdd;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuProductEdit;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuProductDelete;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GrdProducts;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuOrderAdd;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuOrderEdit;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuOrderDelete;
        
        #line default
        #line hidden
        
        
        #line 97 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GrdOrders;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuPaymentAdd;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuPaymentEdit;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuPaymentDelete;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblSumma;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LblBalance;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GrdPayments;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnOk;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\..\Pages\BidPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sales;component/pages/bidpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\BidPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FldDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.FldPartner = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.FldStore = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.FldDeliveryTime = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            return;
            case 5:
            this.FldPaymentTime = ((Xceed.Wpf.Toolkit.IntegerUpDown)(target));
            return;
            case 6:
            this.MenuProductAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 52 "..\..\..\Pages\BidPage.xaml"
            this.MenuProductAdd.Click += new System.Windows.RoutedEventHandler(this.MenuProductAdd_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.MenuProductEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 57 "..\..\..\Pages\BidPage.xaml"
            this.MenuProductEdit.Click += new System.Windows.RoutedEventHandler(this.MenuProductEdit_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MenuProductDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 62 "..\..\..\Pages\BidPage.xaml"
            this.MenuProductDelete.Click += new System.Windows.RoutedEventHandler(this.MenuProductDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.GrdProducts = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.MenuOrderAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 81 "..\..\..\Pages\BidPage.xaml"
            this.MenuOrderAdd.Click += new System.Windows.RoutedEventHandler(this.MenuOrderAdd_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.MenuOrderEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 86 "..\..\..\Pages\BidPage.xaml"
            this.MenuOrderEdit.Click += new System.Windows.RoutedEventHandler(this.MenuOrderEdit_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.MenuOrderDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 91 "..\..\..\Pages\BidPage.xaml"
            this.MenuOrderDelete.Click += new System.Windows.RoutedEventHandler(this.MenuOrderDelete_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.GrdOrders = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 14:
            this.MenuPaymentAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 115 "..\..\..\Pages\BidPage.xaml"
            this.MenuPaymentAdd.Click += new System.Windows.RoutedEventHandler(this.MenuPaymentAdd_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.MenuPaymentEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 120 "..\..\..\Pages\BidPage.xaml"
            this.MenuPaymentEdit.Click += new System.Windows.RoutedEventHandler(this.MenuPaymentEdit_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.MenuPaymentDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 125 "..\..\..\Pages\BidPage.xaml"
            this.MenuPaymentDelete.Click += new System.Windows.RoutedEventHandler(this.MenuPaymentDelete_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.LblSumma = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 18:
            this.LblBalance = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 19:
            this.GrdPayments = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 20:
            this.BtnOk = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\..\Pages\BidPage.xaml"
            this.BtnOk.Click += new System.Windows.RoutedEventHandler(this.BtnOk_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.BtnCancel = ((System.Windows.Controls.Button)(target));
            
            #line 156 "..\..\..\Pages\BidPage.xaml"
            this.BtnCancel.Click += new System.Windows.RoutedEventHandler(this.BtnCancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

