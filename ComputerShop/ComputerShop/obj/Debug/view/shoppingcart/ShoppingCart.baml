   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ComputerShop.view.shoppingcartComputerShop.view.shoppingcart  5      I)clr-namespace:ComputerShop.model.databaseComputerShop.model.database  5      F BCalcBinding, Version=2.5.2.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CalcBinding;assembly=CalcBindingCalcBinding 5      M+clr-namespace:ComputerShop.model.convertersComputerShop.model.converters  5
      1    +ComputerShop.view.shoppingcart.ShoppingCart   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ComputerShop.view.shoppingcart     5      ;model)clr-namespace:ComputerShop.model.database     5      <c.clr-namespace:CalcBinding;assembly=CalcBinding     5      X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44wpfx)http://schemas.xceed.com/wpf/xaml/toolkit  5	      ;	converter+clr-namespace:ComputerShop.model.converters  5
      -   5          >�Name$  CartView��5   7    � 	Resources 5      7  1ComputerShop.model.converters.OrderPriceConverter   TotalConverter  AmountTemplate ��Name �� ElementName �� Path �� RelativeSource �� Mode ��Name �� TextAlignment 
 Delete��%  &	        &	      &	 1      5   
   6A   �� 5   
   .R�5      ]� ��. .+�5      �� $ MinusButton��6   {�.  $��15��6�   
�������$��-��6�   $
��Left=�6�   ��6@   �� $ CartView��$ DataContext.ReduceAmount���6�   ��  �� $
 Self=�6  �� 5      $ 
PlusButton��6   $��15��6�   
�������$��+��6�   $��Right=�6�   ��6-   �� $ CartView��$ DataContext.AddAmount���6r   ��  �� $
 Self=�6�   �� 5      $ Amount��6   $ Center=�6I   $��Right=�6`   ��6,   �� $ Amount�6y   5      5      �� 5   
   .R�5      �� $ DeleteButton��6   
�������$��Удалить��6�   ��6+   �� $ CartView��$ DataContext.DeleteProduct���6t   ��  �� $
 Self=�6�   5      5      .��5      �� $
��Auto=�6   .��5   
   �� $��5,5,5,5q�6   .+�5      �� $��Корзина��6   $��36(�6'   $��5,0,0,0q�65   6I   &   System.Windows.Controls.DataGrid  5      -   5        	  Name$	 Order��5      
   AutoGenerateColumns
 .     
IsReadOnly .    GridLinesVisibility$
 None=�6T   $	��0pxq�6o   ��6�   Z�    	CellStyle 5      �� 5        �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6    �� Triggers 5!      P� 5"       P� Property �@ 
IsSelected P� Value . . �5#   "   ��  �� Property � �� �� Value 6@   Z� �� 5$   "    � ��# � ��6?   �� 5%   "    � �� 5&   &   �� 5'   *    �� Color$ Transparent��6:   5)   #   5*      5,         Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$ Артикул��6)   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� $ 
Product.Id�6`     50      $ Название��6)    6;   �� $ Product.Name�6c     51      $ Цена��6)    67   �� $ Product.Price� �� StringFormat$
 0.00��6s   4  .System.Windows.Controls.DataGridTemplateColumn  52      $ Количество��6-      CellTemplate# [ 6A   6~     53      $ Стоимость��6)    6<     CalcBinding.Binding  *Amount*Product.Price+   StringFormat$
 0.00��6|     54      # [ 6-   6b   56      �� 57      -   5        $ 	TotalCost��57      $��Right=�6+   $
��Bold"�6G   $
��16px(�6Y   ��6i   ��  �� 	Converter# [  $ К оплате: {0}��6�   �� 58      $0��*Введите номер телефона��6   68   %	  Xceed.Wpf.Toolkit.MaskedTextBox	  59      -   5         	 Name$ Phone��59   !   $
��Left=�60    	  Mask$ 9-999-999-99-99��6K   6d   �� 5:      $>��8Введите адрес и время доставки��6   6@   �� 5;      -   5         ��Name$ Address��5;      $��100px��6'   $
��Left=�68   $
��Left=�6S   6w   �� 5<       �� Orientation$ 
Horizontal=�6   $��RightToLeft=�62   .+�5=      �� -   5        $ ConfirmButton��5=      $��Подтвердить��60     WhiteButton#��[ 6F   ��6k   �� $ CartView��$ DataContext.Confirm�6�   �� 5>      -   5        $ CancelButton��5>      $��
Назад��6/   #��[ 6?   ��6d   �� $ CartView��$ DataContext.Cancel�6�   5?      5A      5B      5D      