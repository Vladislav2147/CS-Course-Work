   M S B A M L   `   `   `  ����G  CComputerShop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ComputerShop.viewComputerShop.view  5      $    ComputerShop.view.login.SignIn   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ComputerShop.view     5        � 	Resources  5	       �� 
TargetType   TextBlockStyle �� Property �� Value  TextBoxStyle��%�   &	        &	 �     �� 5
   
   " ��6   .�5      ��  � ��$ Right=�64   6D   �� 5       � ��$ 10,10,25,10q�6'   6=   5      �� 5   
   " ��6   .�5      ��  � ��$ 10,10,10,10q�6'   6=   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��0.5* �6   6,   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��Вход��6!   $
��Bold"�6-   $��36(�6?    �� TextAlignment$ Center=�6M   $��Center=�6d   $��Center=�6�   6�   �� 5   
   $��1��6    �� Orientation$ Vertical=�6"   .+�5      �  � ColumnDefinitions 5      �� 5      6)   �� 5      6)   .+�5      �� $��0��6   $��
Логин��6,   #��[  69   6o   �� 5       $��1��6   #��[ 6B   ��6*   �� *Login+6v   5!      � 5"       5#      �� 5$      6)   �� 5%      6)   .+�5'      �� $��0��6   $��Пароль��6,   #��[  6:   6p   �� 5(      $��1��6   #��[ 6D   ��6*   �� *
Password+6x   5)      � 5*      .+�5+      �� $��1��6   $+��%Восстановить пароль��6D   $��Center=�6b     WhiteButton#��[ 6�   $��5q�6�   ��6)   �� *Backup+6�   5,      5-      �� 5.   
   $ 
Horizontal=�6   $��2��6.   $��Right=�6;   $��Center=�6W   $��RightToLeft=�6r   .+�5/      �� -   5         ��Name$ SignInButton��5/      $��
Войти��6N   #��[ 6^   $��5q�6�   ��6+   �� *LoadMainWindow+6�   �� 50      -   5        $ SignUpButton��50      $��Регистрация��6P   #��[ 6f   $��5q�6�   ��6+   �� *LoadRegistration+6�   51      52      53      