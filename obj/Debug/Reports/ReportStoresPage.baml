   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Sales.ReportsSales.Reports  5      $    Sales.Reports.ReportStoresPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:Sales.Reports     5        N� Title$&   Товары на складах��5	      .��5      � $��5q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��
0, 0, 0, 5q�6;   .+�5      �� .��6   На дату6   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 	FldDateTo��5      �� 5      -   5         ��Name$ BtnShow��5      $��
8, 0, 0, 0q�6<   $
��8, 2q�6P   .��6_   Сформировать6m   5      (  "System.Windows.Controls.WebBrowser  5   
   -   5          Name$ 
fldBrowser��5   "   $��1��6   6"   � 5   
   $��2��6    � Orientation$ 
Horizontal=�6!   $��Center=�6:   .+�5      �� -   5        $ BtnPrint��5      $��5q�6>   $
��8, 2q�6I   .��5      �� $ 
Horizontal=�6   .+�5      �� $3��-pack://siteoforigin:,,,/Resources/printer.png��6   $��16��6S   �� 5      $��Печать��6    $��Center=�6.   $��
8, 2, 2, 2q�6I   5      5      5      5      5       