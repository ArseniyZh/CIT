   M S B A M L   `   `   `  ����A  =Agency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Agency.WindowsAgency.Windows  5   	   !    Agency.Windows.AgentsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:Agency.Windows     5   	     � Title$  Агенты��5   	   $	��550��6   $	��800��6(   $	��650��67   $	��900��6G    � WindowStartupLocation$ CenterScreen=�6V   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ BackBtn��5         BackBtn#��[  68   6[   �� 5   
   $��45��6   $��10q�6   $��0��6)   $��3��69   $
��Left=�6F   $��/Resources/logo (1).png��6a   6�   �� 5   
    	 Title#��[ 6   $$��Агенты(риэлторы)��6/   6L   �� 5   
     Subtitle#��[ 6   $��Поиск ->��62   $��Right=�6E   $��
0,10,170,0q�6a   6w   �� 5   
   -   5         ��Name$ SearchTxtbox��5   9     TextboxInput#��[ 6O   $��Right=�6u   $��10q�6�   6�   �� 5   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   .+�5      �� -   5        $ AddNewClientBtn��5        	ActionBtn#��[ 6L   $��Добавить��6o   6�   �� 5      -   5        $ EditBtn��5      #��[ 6<   $��Изменить��6_   6t   �� 5      -   5        $ 	DeleteBtn��5      #��[ 6@   $��Удалить��6c    � Cursor$
 Hand��6u   6�   5      �� 5   
   -   5         ��Name$ ClientsListView��5   T   $��1��6G   $��Disabled=�6m   ��5      �� 5      .R�5      � 5      5      ��5!      �� 5"      .R�5#      �� 
���   �$��1q�61   ._�5$      � $��85��6   $	��750��6+    5%      �� 5&   "   .+�5(      �� .+�5)   "   �� ��6,   �� *Persons.LastName+ �� StringFormat$ Отчество: {0}���� 5*   "   ��6,   �� *Persons.FirstName+$ Фамилия: {0}���� 5+   "   ��6,   �� *Persons.MiddleName+$ Имя: {0}��5,      5-      5.      5/      51      52      53      