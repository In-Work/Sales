   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.FormsSales.Forms  5   	       Sales.Forms.TransferForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sales.Forms     5   	   X TXceed.Wpf.Toolkit, Version=4.0.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$)  #Перемещение товара��5	   	   $	��450��6$   $	��800��61   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Дата��61   $��2q�6=   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ FldDate��5   2   $��1��6   $��0��6%   $��2q�6s      SelectedDate 6C   ��  �� Path$
 Date� �� Mode$ TwoWay=�6s   �� 5   
   $��0��6   $��1��6$   $'��!Склад отправитель��61   $��2q�6J   �� 5   
   -   5         ��Name$ 
FldStoreAt��5   0   $��1��6   $��1��6#    �� DisplayMemberPath$
 Name��6D   $��2q�6�   	 �� SelectedItem	 6]   �� $ StoreAt�$ TwoWay=�6�   �� 5    
   $��0��6   $��2��6$   $%��Склад получатель��61   $��2q�6I   �� 5!   
   -   5        $ 
FldStoreTo��5!   0   $��1��6   $��2��6#   $
 Name��6D   $��2q�6�   	 6]   �� $ StoreTo�$ TwoWay=�6�   �� 5#   
   $��0��6   $��3��6$   $��
Товар��61   $��2q�6>   �� 5$   
   -   5        $ 
FldProduct��5$   0   $��1��6   $��3��6#   $
 Name��6D   $��2q�6�   	 6]   �� $ Product�$ TwoWay=�6�   �� 5&   
   $��0��6   $��4��6$   $��Количество��61   $��2q�6C   %  Xceed.Wpf.Toolkit.DecimalUpDown  5'   
   -   5        
  Name$
 FldQuantity��5(      $��1��5'      $��4��6-   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   FormatString$ F3��6:      	Increment$ 1.000X�6y   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Decimal, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Minimum$ 0.001X�5(   2      Maximum$ 	100000.00X�6B   $��2q�6V      Value 5'   L   �� $ Quantity�$ TwoWay=�5(   V   �� 5*   
   $��0��6   $��5��6$   $��Сотрудник��61   $��2q�6B   �� 5+   
   $��1��6   $��5��6$   $��2q�6Q   ��61   �� $ 	User.Name�6Q   � 5-   
   $��0��6   $��2��6$   $��7��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5.      �� -   5         ��Name$ BtnOk��5.      $��96��68   $��8q�6C   $��2q�6N   .��5/      ��  �� Orientation$ 
Horizontal=�6   .+�50      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 51      $��Сохранить��6    $��Center=�61   $��2q�6L   52      53      �� 54      -   5        $ 	BtnCancel��54      $��96��6@   $��8q�6K   $��2q�6V   .��55      �� $ 
Horizontal=�6   .+�56      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 57      $��Отмена��6    $��Center=�6.   $��2q�6I   58      59      5:      5<      5=      