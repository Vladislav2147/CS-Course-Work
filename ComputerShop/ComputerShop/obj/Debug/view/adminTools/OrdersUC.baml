   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ComputerShop.view.adminToolsComputerShop.view.adminTools  5      F BCalcBinding, Version=2.5.2.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:CalcBinding;assembly=CalcBindingCalcBinding 5      +    %ComputerShop.view.adminTools.OrdersUC   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:ComputerShop.view.adminTools     5      <c.clr-namespace:CalcBinding;assembly=CalcBinding     5      -   5        $��
OrdersView��5	   7     � 	Resources  5       
  Accept �� ElementName �� Path �� RelativeSource �� Mode��%�   &	        �� 5   
   .R�5      �� 
�������$��Принять��6�   ��6   �� $ 
OrdersView��$ DataContext.Accept���6Y   ��  �� $
 Self=�6�   5      5      .��5      � .+�5   
   �� $
��Auto=�6   .��5      �� $��5q�6   .+�5      �� $��0��6   $��Заказы��6)   $��32(�67   6G   �� 5      $%��Запросы на заказ:��6   $��24(�65   6E   &   System.Windows.Controls.DataGrid  5         AutoGenerateColumns .     
IsReadOnly . ��6   �� *NotAcceptedOrders+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Номер��6-   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6<   �� *Id+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Товары��61   
   CellTemplate
 5      �� 5   "   .R�5   &      .   . ��6/   �� *	Ordered+ 5   *     5   .   $ Артикул��6A   	 6R   �� *	ProductId+6r     5    .   $ Название��6A   	 6S   �� *Product.Name+6v     5!   .   $ Количество��6A   	 6U   �� *Amount+6r     5"   .   $ Стоимость��6A   	 6T     CalcBinding.Binding  *Amount*Product.Price+   StringFormat$
 0.00��6�   5$   '   5%   #   5'        5(      $ ID покупателя��6-   	 6D   �� *
CustomerId+6e     5)      $ 
Адрес��6-   	 6<   �� *	Address+6Z     5*      $ Телефон��6-   	 6>   �� *Phone+6Z     5+      #
 [  61   6f   5-      �� 5/      $$��Принятые заказы:��6   $��24(�64   6D     51       .   . ��6   �� *AcceptedOrders+ 52        53      $ 
Номер��6-   	 6<   �� *Id+6U     54      $ Товары��61   
 55      �� 56   "   .R�57   &      .   . ��6/   �� *	Ordered+ 58   *     59   .   $ Артикул��6A   	 6R   �� *	ProductId+6r     5:   .   $ Название��6A   	 6S   �� *Product.Name+6v     5;   .   $ Количество��6A   	 6U   �� *Amount+6r     5<   .   $ Стоимость��6A   	 6T     *Amount*Product.Price+$
 0.00��6�   5>   '   5?   #   5A        5B      $ ID покупателя��6-   	 6D   �� *
CustomerId+6e     5C      $ 
Адрес��6-   	 6<   �� *	Address+6Z     5D      $ Телефон��6-   	 6>   �� *Phone+6Z   5F      5H      5I      5K      5L      