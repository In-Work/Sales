﻿#pragma checksum "..\..\..\Pages\UsersPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0B044CF434ECBF91AFE76E689EB7BF07B0ABB7B18770205040142FA41946F69D"
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


namespace Sales.Pages {
    
    
    /// <summary>
    /// UsersPage
    /// </summary>
    public partial class UsersPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Pages\UsersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuAdd;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\UsersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuEdit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\UsersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuDelete;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Pages\UsersPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GrdItems;
        
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
            System.Uri resourceLocater = new System.Uri("/Sales;component/pages/userspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\UsersPage.xaml"
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
            
            #line 9 "..\..\..\Pages\UsersPage.xaml"
            ((Sales.Pages.UsersPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Page_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MenuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\..\Pages\UsersPage.xaml"
            this.MenuAdd.Click += new System.Windows.RoutedEventHandler(this.MenuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MenuEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 22 "..\..\..\Pages\UsersPage.xaml"
            this.MenuEdit.Click += new System.Windows.RoutedEventHandler(this.MenuEdit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuDelete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 27 "..\..\..\Pages\UsersPage.xaml"
            this.MenuDelete.Click += new System.Windows.RoutedEventHandler(this.MenuDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.GrdItems = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

