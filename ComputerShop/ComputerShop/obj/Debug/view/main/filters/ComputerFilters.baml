   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ComputerShop.view.main.filtersComputerShop.view.main.filters  5      C&clr-namespace:ComputerShop.model.enumsComputerShop.model.enums  5      M+clr-namespace:ComputerShop.model.convertersComputerShop.model.converters  5      4    .ComputerShop.view.main.filters.ComputerFilters   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      >local,clr-namespace:ComputerShop.view.main.filters     5      8enums&clr-namespace:ComputerShop.model.enums     5      B
converters+clr-namespace:ComputerShop.model.converters     5      .��5      �   � RowDefinitions  5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      $
��0.1* �6   6.   �� 5      6!   �� 5      $
��0.2* �6   6.   �� 5      6!   �� 5      $
��0.1* �6   6.   .+�5    
   �� $��0��6   $��1��6!   $��3��61   $$��Количество ядер:��6E   $��0,5,5,5q�6]   6p   �� 5!   
   -   5         ��Name$ MinCores��5!      $��1��6%   $��1��62   6D   �� 5"   
   $��1��6   $��2��6!   $��-��61    �� TextAlignment$ Center=�6:   6S   �� 5#   
   -   5        $ MaxCores��5#      $��1��6%   $��3��62   6D   �� 5%   
   $��2��6   $��1��6!   $��3��61   $.��(Тактовая частота, МГц:��6E   $��0,5,5,5q�6c   6v   �� 5&   
   -   5        $ MinFrequency��5&      $��3��6)   $��1��66   6H   �� 5'   
   $��3��6   $��2��6!   $��-��61   $ Center=�6:   6S   �� 5(   
   -   5        $ MaxFrequency��5(      $��3��6)   $��3��66   6H   �� 5*   
   $��4��6   $��1��6!   $��3��61   $0��*Оперативная память, Гб:��6E   $��0,5,5,5q�6d   6w   �� 5+   
   -   5        $ MinRAM��5+      $��5��6#   $��1��60   6B   �� 5,   
   $��5��6   $��2��6!   $��-��61   $ Center=�6:   6S   �� 5-   
   -   5        $ MaxRAM��5-      $��5��6"   $��3��6/   6A   �� 5/   
   $��6��6   $��1��6!   $��3��61   $!��Тип компьютера��6E   $��0,5,5,5q�6[   6n   �� 50   
   -   5         ��Name$ ComputerType��50       �� SelectedIndex$ 0��6)   $��7��6;   $��1��6H   $��3��6X   ��6l   ��  �� Source >   8ComputerShop.model.converters.EnumBindingSourceExtension  *M� *enums:ComputerType++6�   �� 52   
   $��8��6   $��1��6!   $��3��61   $-��'Операционная система��6E   $��0,5,5,5q�6a   6t   �� 53   
   -   5        $ OS��53      $ 0��6    $��9��62   $��1��6?   $��3��6O   ��6c   ��    *M� *enums:OperatingSystem++6�   55      56      