   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.FormsSales.Forms  5   	       Sales.Forms.UserForm   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Sales.Forms     5   	     � Title$;  5Редактирование пользователя��5   	   $	��300��6-   $	��300��6:   $	��400��6J   $	��400��6V    � ShowInTaskbar .  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6$   $��Имя��61   $��2q�6<   �� 5   
   -   5         ��Name$ FldName��5   /   $��1��6   $��0��6"   $��2q�6h   ��6@   ��  �� Path$
 Name� �� Mode$ TwoWay=�6h   �� 5   
   $��0��6   $��1��6$   $��Пароль��61   $��2q�6?   �� 5   
   $��1��6   $��1��6%    �� Orientation$ Vertical=�62   $��2q�6I   .+�5      �� -   5         ��Name$ ChngPassword��5      $#��Изменить пароль��6-   6G   G� 5      -   5        	 G�Name$	 FldPassword��5      {�.  6/   5      �� 5    
   $��0��6   $��2��6$   $��Роль��61   $��2q�6=   �� 5!   
   -   5        
 ��Name$
 FldRole��5!   0   $��1��6   $��2��6#    �� DisplayMemberPath$
 Name��6A   $��2q�6�    �� SelectedItem 6Z   �� $
 Role�$ TwoWay=�6�   �� 5#   
   $��0��6   $��3��6$   $��Доступ��61   $��2q�6?   �� 5$   
   -   5        $ 
FldEnabled��5$   0   $��1��6   $��3��6#   $��2q�6g    d� 	IsChecked 6D   �� $ Enabled�6g   � 5&   
   $��0��6   $��2��6$   $��5��68    � Orientation$ 
Horizontal=�6E   $��Center=�6^   .+�5'      �� -   5         ��Name$ BtnOk��5'      $��96��68   $��8q�6C   $��2q�6N   .��5(      �� $ 
Horizontal=�6   .+�5)      �� $4��.pack://siteoforigin:,,,/Resources/diskette.png��6   $��16��6T   �� 5*      $��Сохранить��6    $��Center=�61   $��2q�6L   5+      5,      �� 5-      -   5        $ 	BtnCancel��5-      $��96��6@   $��8q�6K   $��2q�6V   .��5.      �� $ 
Horizontal=�6   .+�5/      �� $2��,pack://siteoforigin:,,,/Resources/cancel.png��6   $��16��6R   �� 50      $��Отмена��6    $��Center=�6.   $��2q�6I   51      52      53      54      55      