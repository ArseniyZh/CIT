   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agency.WindowsAgency.Windows  5   	   "    Agency.Windows.Authorization   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Agency.Windows     5   	     � Title$   Вход в систему��5   	   $	��350��6    $	��700��60   $	��450��6?   $	��800��6O    � WindowStartupLocation$ CenterScreen=�6^   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   ��  	  Title#��[  6   $ ��Вход в систему��6/   $��2��6H   6^   �� 5   
   $��45��6   $��10q�6   $��0��6)   $��3��69   $
��Left=�6F   $��/Resources/logo (1).png��6a   6�   �� 5   
     Subtitle#��[ 6   $5��/Введите код пользователя:��62   $��1��6V   6e   �� 5   
   #��[ 6   $"��Введите пароль:��62   $��2��6L   6[   �� 5   
   -   5         ��Name$ 
Codetxtbox��5   i    �� 	MaxLength$ 10��6     TextboxInput#��[ 6B   $��1��6}   $��1��6�   6�   �� 5   
   -   5        $ Passwordtxtbox��5   H   $ 25��6   #��[ 6!   $��2��6`   $��1��6m   6   �� 5   
   -   5         ��Name$ LoginBtn��5   K     	ActionBtn#��[ 6(   $��
Войти��6]   $��3��6m   $��2��6z   6�   5      5      