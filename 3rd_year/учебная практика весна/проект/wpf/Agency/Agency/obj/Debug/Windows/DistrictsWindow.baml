   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agency.WindowsAgency.Windows  5   	   $    Agency.Windows.DistrictsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Agency.Windows     5   	     � Title$  Районы��5   	   $	��550��6   $	��800��6(   $	��650��67   $	��900��6G    � WindowStartupLocation$ CenterScreen=�6V   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   ��  	  Title#��[  6   $��Районы��6/   $��0��6@   �� 5   
   -   5         ��Name$ BackBtn��5        BackBtn#��[ 68   6[   �� 5   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��0,0,0,10q�6;   .+�5      �� $��Код района:��6   $��Center=�6+   $��0,0,5,0q�6F   �� 5      -   5         ��Name$ DistrictIdTextBox��5      $	��100��61   $��0,0,10,0q�6=   �� 5      $��Название:��6   $��Center=�6)   $��0,0,5,0q�6D   �� 5      -   5        $ DistrictNameTextBox��5      $	��200��63   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ AppartamentsDataGrid��5         AutoGenerateColumns .  $��2��6M   $	��300��6Z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Код района��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 69   �� *Id+  5      $	 Название��6%   
 67   �� *Name+  5      $	 Координаты��6%   
 69   �� *Area+5       �� 5"   
   $ 
Horizontal=�6   $��3��6.   $
��Left=�6;   $��0,10,0,0q�6V   .+�5#      �� $��45��6   $��/Resources/logo (1).png��6    6C   �� 5$      -   5        $ AddDistrictBtn��5$        	ActionBtn#��[ 6-   $��Добавить��6P   $	��100��6�   5%      5&      5'      