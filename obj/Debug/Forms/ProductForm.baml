   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.FormsSales.Forms  5   	       Sales.Forms.ProductForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sales.Forms     5   	     � Title$/  )Редактирование товара��5   	   $	��300��6'   $	��300��64   $	��400��6D   $	��400��6P    � ShowInTaskbar .  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Наименование��61   $��2q�6E   �� 5   
   -   5         ��Name$ FldName��5   /   $��1��6   $��0��6"   $��2q�6h   ��6@   ��  �� Path$
 Name� �� Mode$ TwoWay=�6h   �� 5   
   $��0��6   $��1��6$   $��Описание��61   $��2q�6A   �� 5   
   -   5        $ FldDescription��5   /   $��1��6   $��1��6"   $��2q�6v   ��6G   �� $ Description�$ TwoWay=�6v   �� 5   
   $��0��6   $��2��6$   $��Родитель��61   $��2q�6A   � 5   
   $��1��6   $��2��6    5      �� 5       �� 5!      $
��Auto �6#   .+�5#      �� -   5         ��Name$ FldCategory��5#   '   $��0��6    �� DisplayMemberPath$ HName��6<   $��2q�6�   	 �� SelectedItem	 6V   �� $ Parent�$ TwoWay=�6�   �� 5$      -   5        
 ��Name$
 BtnParentClear��5$   %   $��1��6   $��2q�6Z   .��5%      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6N   5&      5'      �� 5)   
   $��0��6   $��3��6$   $��Ед.изм.��61   $��2q�6@   �� 5*   
   -   5        $ 
FldMeasure��5*   0   $��1��6   $��3��6#   $
 Name��6D   $��2q�6�   	 6]   �� $ Measure�$ TwoWay=�6�   � 5,   
   $��0��6   $��2��6$   $��5��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5-      �� -   5        $
 BtnOk��5-      $��96��68   $��8q�6C   $��2q�6N   .��5.      ��  �� Orientation$ 
Horizontal=�6   .+�5/      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 50      $��Сохранить��6    $��Center=�61   $��2q�6L   51      52      �� 53      -   5        $
 	BtnCancel��53      $��96��6@   $��8q�6K   $��2q�6V   .��54      �� $ 
Horizontal=�6   .+�55      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 56      $��Отмена��6    $��Center=�6.   $��2q�6I   57      58      59      5:      5;      