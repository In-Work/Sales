   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.FormsSales.Forms  5   	       Sales.Forms.PaymentForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sales.Forms     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Оплата��5	   	   $	��450��6   $	��800��6%   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Дата��61   $��2q�6=   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ FldDate��5   2   $��1��6   $��0��6%   $��2q�6s      SelectedDate 6C   ��  �� Path$
 Date� �� Mode$ TwoWay=�6s   �� 5   
   $��0��6   $��1��6$   $��Контрагент��61   $��2q�6C   �� 5   
   $��1��6   $��1��6$   $��2q�6X   ��61   �� $ Bid.Partner.Name�6X   �� 5   
   $��0��6   $��2��6$   $��Направление��61   $��2q�6D   �� 5    
   -   5         ��Name$ FldDirection��5    0   $��1��6   $��2��6#    �� DisplayMemberPath$ PaymentName��6F   $��2q�6�   	 �� SelectedItem	 6f   �� $ 	Direction�$ TwoWay=�6�   �� 5"   
   $��0��6   $��3��6$   $��Сумма оплаты��61   $��2q�6E   %  Xceed.Wpf.Toolkit.DecimalUpDown  5#   
   -   5        
  Name$
 FldSumma��5$      $��1��5#      $��3��6-   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ F2��6:      	Increment$
 0.01X�6v   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$
 0.00X�5$   /      Maximum$ 	100000.00X�6>   $��2q�6R      Value 5#   L   �� $ Summa�$ TwoWay=�5$   R   �� 5&   
   $��0��6   $��4��6$   $��Сотрудник��61   $��2q�6B   �� 5'   
   $��1��6   $��4��6$   $��2q�6Q   ��61   �� $ 	User.Name�6Q   � 5)   
   $��0��6   $��2��6$   $��6��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5*      �� -   5         ��Name$ BtnOk��5*      $��96��68   $��8q�6C   $��2q�6N   .��5+      ��  �� Orientation$ 
Horizontal=�6   .+�5,      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 5-      $��Сохранить��6    $��Center=�61   $��2q�6L   5.      5/      �� 50      -   5        $ 	BtnCancel��50      $��96��6@   $��8q�6K   $��2q�6V   .��51      �� $ 
Horizontal=�6   .+�52      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 53      $��Отмена��6    $��Center=�6.   $��2q�6I   54      55      56      58      59      