   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.PagesSales.Pages  5          Sales.Pages.BidsListPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Sales.Pages     5      -   5          N� Title$!  Список заказов��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   o� $��0��6   .@�5      m� -   5         m�Name$ MenuAdd��5   6   $��2q�6    � ToolTip$ Добавить��6#   ��5      �� 5      $��20��6   $0��*pack://siteoforigin:,,,/Resources/plus.png��6+   5      m� 5      -   5        $ MenuEdit��5   6   $��2q�6   $ Изменить��6#   ��5      �� 5      $��20��6   $0��*pack://siteoforigin:,,,/Resources/edit.png��6+   5      m� 5      -   5        $ 
MenuDelete��5   5   $��2q�6   $ Удалить��6#   ��5      �� 5      $��20��6   $1��+pack://siteoforigin:,,,/Resources/minus.png��6+   5      m� 5       -   5        $ 
MenuFilter��5    4   $��2q�6   $ Фильтр��6#   ��5!      �� 5"      $��20��6   $2��,pack://siteoforigin:,,,/Resources/filter.png��6+   5$      5%      ]� 5&   
   $��1��6   ��. .+�5'      � -   5         �Name$ FltrGrid��5'   (   $	��Top=�6    � ColumnDefinitions 5(      �� 5)      $
��Auto �6'   �� 5*       5,      �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   .+�52      �� $��0��6   $��0��6,   $��Контрагент��69   $��Center=�6K   $��2q�6f   �� 53      $��1��6   $��0��6-    �� Orientation$ 
Horizontal=�6:   $��2q�6S   .+�54      �� -   5         ��Name$ FltrPartnerCheck��54      $��Center=�69   $��0,0,4,0q�6T   �� 55      -   5         ��Name$ FltrPartner��55      	 �� DisplayMemberPath$
	 Name��64   56      �� 57      $��0��6   $��1��6,   $��
Склад��69   $��Center=�6F   $��2q�6a   �� 58      $��1��6   $��1��6-   $ 
Horizontal=�6:   $��2q�6S   .+�59      �� -	   5        $ FltrStoreCheck��59      $��Center=�67   $��0,0,4,0q�6R   �� 5:      -
   5        $ 	FltrStore��5:      $
	 Name��62   5;      �� 5<      $��0��6   $��2��6,   $��Дата��69   $��Center=�6E   $��2q�6`   �� 5=      $��1��6   $��2��6-   $ 
Horizontal=�6:   $��2q�6S   .+�5>      �� -   5        $ FltrDateCheck��5>      $��Center=�66   $��0,0,4,0q�6Q   (  "System.Windows.Controls.DatePicker  5?      -   5        
  Name$
 
FltrDateAt��5?   !   �� 5@      $�� ... ��6    $��Center=�6-     5A      -   5        $
 
FltrDateTo��5A   !   5B      � 5C      $��0��6   $��2��6,   $��3��6@    � Orientation$ 
Horizontal=�6M   $��Center=�6f   .+�5D      �� -   5         ��Name$ FltrBtn��5D      $��Применить��6.   $��2q�6B   6M   �� 5E      -   5        $ 
FltrCancel��5E      $��Сбросить��61   $��2q�6D   6O   5F      5G      &   System.Windows.Controls.DataGrid  5H      -   5          Name$ GrdItems��5H   K   $��Bottom=�6      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6o      Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id+6@     5K      $ Дата��6a    6)   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��6a     5L      $ Контрагент��6J      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6^    6)   �� *Partner.Name+6^     5M      $ 
Склад��6H    6)   �� *
Store.Name+6H     5N      $ Срок поставки��6J    6)   �� *DeliveryTime+6J     5O      $ Срок оплаты��6I    6)   �� *PaymentTime+6I   5Q      5R      5T      5U      