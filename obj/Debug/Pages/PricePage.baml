   M S B A M L   `   `   `  ����@  <Sales, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Sales.PagesSales.Pages  5          Sales.Pages.PricePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Sales.Pages     5      -   5          N� Title$  Список цен��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   o� $��0��6   .@�5      m� -   5         m�Name$ MenuAdd��5   6   $��2q�6    � ToolTip$ Добавить��6#   ��5      �� 5      $��20��6   $0��*pack://siteoforigin:,,,/Resources/plus.png��6+   5      m� 5      -   5        $ MenuEdit��5   6   $��2q�6   $ Изменить��6#   ��5      �� 5      $��20��6   $0��*pack://siteoforigin:,,,/Resources/edit.png��6+   5      m� 5      -   5        $ 
MenuDelete��5   5   $��2q�6   $ Удалить��6#   ��5      �� 5      $��20��6   $1��+pack://siteoforigin:,,,/Resources/minus.png��6+   5      m� 5       -   5        $ 
MenuFilter��5    4   $��2q�6   $ Фильтр��6#   ��5!      �� 5"      $��20��6   $2��,pack://siteoforigin:,,,/Resources/filter.png��6+   5$      5%      ]� 5&   
   $��1��6   ��. .+�5'      � -   5         �Name$ FltrGrid��5'   (   $	��Top=�6    � ColumnDefinitions 5(      �� 5)      $
��Auto �6'   �� 5*       5,      �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   .+�51      �� $��0��6   $��0��6,   $��
Товар��69   $��Center=�6F   $��2q�6a   �� 52      $��1��6   $��0��6-    �� Orientation$ 
Horizontal=�6:   $��2q�6S   .+�53      �� -   5         ��Name$ FltrProductCheck��53      $��Center=�69   $��0,0,4,0q�6T   �� 54      -   5         ��Name$ FltrProduct��54      	 �� DisplayMemberPath$
	 Name��64   55      �� 56      $��0��6   $��1��6,   $��Дата��69   $��Center=�6E   $��2q�6`   �� 57      $��1��6   $��1��6-   $ 
Horizontal=�6:   $��2q�6S   .+�58      �� -	   5        $ FltrDateCheck��58      $��Center=�66   $��0,0,4,0q�6Q   (  "System.Windows.Controls.DatePicker  59      -
   5        
  Name$
 
FltrDateAt��59   !   �� 5:      $�� ... ��6    $��Center=�6-     5;      -   5        $
 
FltrDateTo��5;   !   5<      � 5=      $��0��6   $��2��6,   $��2��6@    � Orientation$ 
Horizontal=�6M   $��Center=�6f   .+�5>      �� -   5         ��Name$ FltrBtn��5>      $��Применить��6.   $��2q�6B   6M   �� 5?      -   5        $ 
FltrCancel��5?      $��Сбросить��61   $��2q�6D   6O   5@      5A      &   System.Windows.Controls.DataGrid  5B      -   5          Name$ GrdItems��5B   K   $��Bottom=�6      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6o      Columns 5C      0  *System.Windows.Controls.DataGridTextColumn  5D      ,  &System.Windows.Controls.DataGridColumn   Header$ Код��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *Id+6@     5E      $ Дата��6a    6)   �� *Date+ �� StringFormat$ {0:dd.MM.yyyy}��6a     5F      $ 
Товар��6J      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y    6)   �� *Product.Name+6Y     5G      $ Цена��6Z    6)   �� *Value+$ {0:f2}��6Z   5I      5J      5L      5M      