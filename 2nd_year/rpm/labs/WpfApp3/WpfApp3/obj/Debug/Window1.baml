   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.Window1   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5	   	   'localclr-namespace:WpfApp3     5   	     � Title$  Window1��5   	   $	��450��6   $	��800��6&    � 	Resources 5      �� 5   
      KeyMyEditingModes   �� Type2  ,System.Windows.Controls.InkCanvasEditingMode"  6)   .s�5      ��  �� Member$ InkCanvasEditingMode.Ink��6   �� 5      $! InkCanvasEditingMode.Select��6   �� 5      $' !InkCanvasEditingMode.EraseByPoint��6   �� 5      $( "InkCanvasEditingMode.EraseByStroke��6   5      �� 5   
   MyDrawingAttributes  *  $System.Windows.Ink.DrawingAttributes"  6.   .s�5!        -   5        Зеленый��   Color$ Green��5!   1      Width$ 3Q�6?      Height$ 3Q�6I     5#      -   5        Красный��$	 Red��5#   1   $ 4Q�6=   $ 4Q�6G     5%      -   5        
Синий��$
 Blue��5%   /   $ 7Q�6<   $ 7Q�6F   5'      �� 5)   
    �� 
TargetType" ��6    �� Triggers 5+      �� 5-      	 �� Binding	 6   �� 
 �� ElementName$
 lbEditingModes�� �� Path$ SelectedValue� �� Value 6a   Z� .a�5/      ��  �� Property � {� �� Value .  62   51      55      .��59      � 
���� ��.+�5;   
   �� .+�5=      �� $	��120��6   $	��Top=�6%   $
��Left=�6=   $��5,0,0,0q�6X   .+�5A      �� -   5         ��Name$ Colors��5A        MyDrawingAttributes#��[ 6*   ��5C      �� 5G      .R�5I      �� ��6(   �� $ Color�5K      5O      5S      �� 5W      $	��Top=�6   $
��Left=�61   $��5 10 q�6L   .+�5Y      �� -   5        $ lbEditingModes��5Y        MyEditingModes#��[ 62   5[      �� 5]      -   5        $'��!Перейтик 1 заданию��5]      $
��Left=�62   6M   5_      �� 5a   
   .+�5c      �� -   5         ��Name$	 ink��5c      $��140 10 20 0q�6%   $	��Top=�6:   $	��384��6�    �� DefaultDrawingAttributes 6O   �� $
 Colors��$ SelectedValue� �� EditingMode 6�   �� $
 lbEditingModes��$ SelectedValue�5e      5g      5m      5q      