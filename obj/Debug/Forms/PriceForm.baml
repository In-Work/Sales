   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.FormsSales.Forms  5   	       Sales.Forms.PriceForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sales.Forms     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � Title$  Цена товара��5	   	   $	��450��6   $	��800��6*   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Дата��61   $��2q�6=   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ FldDate��5   2   $��1��6   $��0��6%   $��2q�6s      SelectedDate 6C   ��  �� Path$
 Date� �� Mode$ TwoWay=�6s   �� 5   
   $��0��6   $��1��6$   $��
Товар��61   $��2q�6>   �� 5   
   -   5         ��Name$ 
FldProduct��5   0   $��1��6   $��1��6#    �� DisplayMemberPath$
 Name��6D   $��2q�6�   	 �� SelectedItem	 6]   �� $ Product�6�   �� 5   
   $��0��6   $��2��6$   $��Цена��61   $��2q�6=   %  Xceed.Wpf.Toolkit.DecimalUpDown  5   
   -   5        
  Name$
 FldValue��5       $��1��5      $��2��6-   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ F2��6:      	Increment$
 0.01X�6v   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$
 0.01X�5    /      Maximum$ 	100000.00X�6>   $��2q�6R      Value 5   L   �� $ Value�$ TwoWay=�5    R   �� 5"   
   $��0��6   $��4��6$   $��Сотрудник��61   $��2q�6B   �� 5#   
   $��1��6   $��4��6$   $��2q�6Q   ��61   �� $ 	User.Name�6Q   � 5%   
   $��0��6   $��2��6$   $��7��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5&      �� -   5         ��Name$ BtnOk��5&      $��96��68   $��8q�6C   $��2q�6N   .��5'      ��  �� Orientation$ 
Horizontal=�6   .+�5(      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 5)      $��Сохранить��6    $��Center=�61   $��2q�6L   5*      5+      �� 5,      -   5        $ 	BtnCancel��5,      $��96��6@   $��8q�6K   $��2q�6V   .��5-      �� $ 
Horizontal=�6   .+�5.      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 5/      $��Отмена��6    $��Center=�6.   $��2q�6I   50      51      52      54      55      