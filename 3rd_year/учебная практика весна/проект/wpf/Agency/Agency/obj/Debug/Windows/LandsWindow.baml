   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agency.WindowsAgency.Windows  5   	        Agency.Windows.LandsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Agency.Windows     5   	     � Title$  
Земли��5   	   $	��550��6   $	��800��6'   $	��650��66   $	��900��6F    � WindowStartupLocation$ CenterScreen=�6U   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   ��  	  Title#��[  6   $��
Земли��6/   6A   �� 5   
   $��45��6   $��10q�6   $��0��6)   $��3��69   $
��Left=�6F   $��/Resources/logo (1).png��6a   6�   �� 5   
   -   5         ��Name$ BackBtn��5        BackBtn#��[ 6"   6[   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AppartamentsDataGrid��5   *      CanUserAddRows .     AutoGenerateColumns .  $��1��6d      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Код земли��6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 68   �� *Id+6Q     5      $ Площадь��6%   	 66   �� *	TotalArea+6V   5      5      5      