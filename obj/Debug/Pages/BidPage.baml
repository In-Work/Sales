   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.PagesSales.Pages  5          Sales.Pages.BidPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      %localclr-namespace:Sales.Pages  5        N� Title$  
Заказ��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��1��6   $��0��6$   $
��Bold"�6Y    �� TextAlignment$ Center=�6k   $��2q�6�   ��61   ��  �� Path$ Direction.BidName�6�   �� 5   
   $��2��6   $��0��6$   $��Дата��61   $��2q�6=   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ FldDate��5   2   $��3��6   $��0��6%   $��2q�6s      SelectedDate 6C   �� $
 Date� �� Mode$ TwoWay=�6s   �� 5!   
   $��0��6   $��1��6$   $��Контрагент��61   $��2q�6C   �� 5"   
   -   5         ��Name$ 
FldPartner��5"   0   $��1��6   $��1��6#   	 �� DisplayMemberPath$
	 Name��6D   $��2q�6�   
 �� SelectedItem
 6]   �� $ Partner�$ TwoWay=�6�   �� 5$   
   $��2��6   $��1��6$   $��
Склад��61   $��2q�6>   �� 5%   
   -   5        $ FldStore��5%   0   $��3��6   $��1��6#   $
	 Name��6B   $��2q�6�   
 6[   �� $ Store�$ TwoWay=�6�   �� 5'   
   $��0��6   $��2��6$   $'��!Срок поставки, дни��61   $��2q�6K   %  Xceed.Wpf.Toolkit.IntegerUpDown  5(   
   -   5          Name$ FldDeliveryTime��5(   y   $��1��6   $��2��6-   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�6:   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0X�6�      Maximum$	 365X�6�   $��2q�6�      Value 6H   �� $ DeliveryTime�$ TwoWay=�6�   �� 5*   
   $��2��6   $��2��6$   $#��Срок оплаты, дни��61   $��2q�6I     5+   
   -   5        $ FldPaymentTime��5+   x   $��3��6   $��2��6-   $ 1X�6:   $ 0X�6�   $	 365X�6�   $��2q�6�    6H   �� $ PaymentTime�$ TwoWay=�6�   �� 5-   
   $��0��6   $��3��6$   $��Сотрудник��61   $��2q�6B   �� 5.   
   $��1��6   $��3��6$   $��3��68   $��2q�6e   ��6E   �� $ 	User.Name�6e   �� 50   
   $��0��6   $��4��6%   $��4��62   .@�51      �� $��Товары��6   .��52      ]� .+�53      o� $	��Top=�6   $��0��60   $��2��6@   $��3��6T   .@�54      m� -   5         m�Name$ MenuProductAdd��54   B   $��2q�6#    � ToolTip$ Добавить��6/   ��55      �� 56   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/plus.png��67   58      m� 59      -   5        $ MenuProductEdit��59   B   $��2q�6#   $ Изменить��6/   ��5:      �� 5;   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/edit.png��67   5=      m� 5>      -   5        $ MenuProductDelete��5>   A   $��2q�6#   $ Удалить��6/   ��5?      �� 5@   "   $��20��6(   $1��+pack://siteoforigin:,,,/Resources/minus.png��67   5B      5C      &   System.Windows.Controls.DataGrid  5D      -	   5          Name$ GrdProducts��5D   7   $��Bottom=�6      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6z      Columns 5E      0  *System.Windows.Controls.DataGridTextColumn  5F      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Товар��6R      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 61   �� *Product.Name+6a     5G      $ Количество��6e    61   �� *
Quantity+ �� StringFormat$ {0:f3}��6e     5H      $ Цена��6b    61   �� *Price+$ {0:f2}��6b     5I      $ 
Сумма��6b    61   �� *Summa+$ {0:f2}��6b   5K      5L      5M      �� 5N      ��6   �� $ Direction.OrderName�.��5O      ]� .+�5P      o� $	��Top=�6   $��0��60   $��2��6@   $��3��6T   .@�5Q      m� -
   5        $ MenuOrderAdd��5Q   B   $��2q�6#   $ Добавить��6/   ��5R      �� 5S   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/plus.png��67   5U      m� 5V      -   5        $ MenuOrderEdit��5V   B   $��2q�6#   $ Изменить��6/   ��5W      �� 5X   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/edit.png��67   5Z      m� 5[      -   5        $ MenuOrderDelete��5[   A   $��2q�6#   $ Удалить��6/   ��5\      �� 5]   "   $��20��6(   $1��+pack://siteoforigin:,,,/Resources/minus.png��67   5_      5`        5a      -   5        $ 	GrdOrders��5a       .   . $ Single=�6`    5b        5c      $ Дата��6i    61   �� *Date+$ {0:dd.MM.yyyy}��6i     5d      $ 
Товар��6R   $ * 6a    61   �� *Product.Name+6a     5e      $ Количество��6N    61   �� *
Quantity+6N     5f      $ Сотрудник��6O    61   �� *	User.Name+6O   5h      5i      5j      �� 5k      ��6   �� $ Direction.PaymentName�.��5l      �  5m      �� 5n      $
��Auto �6(   �� 5o      $
��Auto �6(   �� 5p      .+�5r      o� $��0��6   .@�5s      m� -   5        $ MenuPaymentAdd��5s   B   $��2q�6#   $ Добавить��6/   ��5t      �� 5u   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/plus.png��67   5w      m� 5x      -   5        $ MenuPaymentEdit��5x   B   $��2q�6#   $ Изменить��6/   ��5y      �� 5z   "   $��20��6(   $0��*pack://siteoforigin:,,,/Resources/edit.png��67   5|      m� 5}      -   5        $ MenuPaymentDelete��5}   A   $��2q�6#   $ Удалить��6/   ��5~      �� 5   "   $��20��6(   $1��+pack://siteoforigin:,,,/Resources/minus.png��67   5�      5�      �� 5�       �� Orientation$ 
Horizontal=�6!   $��Right=�6:   $��1��6V   .+�5�      �� $��Сумма заказа��6$    �� Padding$ 
2, 2, 4, 2q�68   �� 5�      -   5         ��Name$ LblSumma��5�   $   $ 2q�66   $
��Bold"�6B   �� 5�      $��К оплате��6$   $ 
8, 2, 4, 2q�64   �� 5�      -   5        $ 
LblBalance��5�   $   $ 2q�68   $
��Bold"�6D   5�        5�      -   5        $ GrdPayments��5�       .   . $ Single=�6b   $��2��6y    5�        5�      $ Дата��6i    61   �� *Date+$ {0:dd.MM.yyyy}��6i     5�      $ Направление��6T    61   �� *Direction.Name+6T     5�      $ 
Сумма��6b    61   �� *Summa+$ {0:f2}��6b     5�      $ Сотрудник��6O    61   �� *	User.Name+6O   5�      5�      5�      5�      � 5�   
   $��0��6   $��4��6$   $��5��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5�      �� -   5         ��Name$ BtnOk��5�      $��96��68   $��8q�6C   $��2q�6N   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 5�      $��Сохранить��6    $��Center=�61   $��2q�6L   5�      5�      �� 5�      -   5        $ 	BtnCancel��5�      $��96��6@   $��8q�6K   $��2q�6V   .��5�      �� $ 
Horizontal=�6   .+�5�      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 5�      $��Отмена��6    $��Center=�6.   $��2q�6I   5�      5�      5�      5�      5�      