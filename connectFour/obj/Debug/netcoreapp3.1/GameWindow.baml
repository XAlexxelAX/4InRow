   M S B A M L   `   `   `  ����F  BconnectFour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:connectFourconnectFour  5   	       connectFour.Game   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:connectFour     5   	   -   5          �Name$  	viewModel��5
   	    � Title$ 
MainWindow��5   	   $	��600��6   $	��680��6)   
������� � Icon$ Resources\icon.ico��5	      .��5      � -   5         �Name$ 	boardView��5       � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $	��220 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��70 �6   �� 5      $��20 �6    � RowDefinitions 5   
   �� 5       $��30 �6   �� 5"      $��70 �6   �� 5#      $��70 �6   �� 5$      $��70 �6   �� 5%      $��70 �6   �� 5&      $��70 �6   �� 5'      $��70 �6   �� 5(      $��70 �6   �� 5*      $��30 �6   .+�5.   
   �� $��Resources/cell_hole.png��6   $��2��61   $��1��6A   �� 5/   
   $��Resources/cell_hole.png��6   $��3��61   $��1��6A   �� 50   
   $��Resources/cell_hole.png��6   $��4��61   $��1��6A   �� 51   
   $��Resources/cell_hole.png��6   $��5��61   $��1��6A   �� 52   
   $��Resources/cell_hole.png��6   $��6��61   $��1��6A   �� 53   
   $��Resources/cell_hole.png��6   $��7��61   $��1��6A   �� 54   
   $��Resources/cell_hole.png��6   $��2��61   $��2��6A   �� 55   
   $��Resources/cell_hole.png��6   $��3��61   $��2��6A   �� 56   
   $��Resources/cell_hole.png��6   $��4��61   $��2��6A   �� 57   
   $��Resources/cell_hole.png��6   $��5��61   $��2��6A   �� 58   
   $��Resources/cell_hole.png��6   $��6��61   $��2��6A   �� 59   
   $��Resources/cell_hole.png��6   $��7��61   $��2��6A   �� 5:   
   $��Resources/cell_hole.png��6   $��2��61   $��3��6A   �� 5;   
   $��Resources/cell_hole.png��6   $��3��61   $��3��6A   �� 5<   
   $��Resources/cell_hole.png��6   $��4��61   $��3��6A   �� 5=   
   $��Resources/cell_hole.png��6   $��5��61   $��3��6A   �� 5>   
   $��Resources/cell_hole.png��6   $��6��61   $��3��6A   �� 5?   
   $��Resources/cell_hole.png��6   $��7��61   $��3��6A   �� 5@   
   $��Resources/cell_hole.png��6   $��2��61   $��4��6A   �� 5A   
   $��Resources/cell_hole.png��6   $��3��61   $��4��6A   �� 5B   
   $��Resources/cell_hole.png��6   $��4��61   $��4��6A   �� 5C   
   $��Resources/cell_hole.png��6   $��5��61   $��4��6A   �� 5D   
   $��Resources/cell_hole.png��6   $��6��61   $��4��6A   �� 5E   
   $��Resources/cell_hole.png��6   $��7��61   $��4��6A   �� 5F   
   $��Resources/cell_hole.png��6   $��2��61   $��5��6A   �� 5G   
   $��Resources/cell_hole.png��6   $��3��61   $��5��6A   �� 5H   
   $��Resources/cell_hole.png��6   $��4��61   $��5��6A   �� 5I   
   $��Resources/cell_hole.png��6   $��5��61   $��5��6A   �� 5J   
   $��Resources/cell_hole.png��6   $��6��61   $��5��6A   �� 5K   
   $��Resources/cell_hole.png��6   $��7��61   $��5��6A   �� 5L   
   $��Resources/cell_hole.png��6   $��2��61   $��6��6A   �� 5M   
   $��Resources/cell_hole.png��6   $��3��61   $��6��6A   �� 5N   
   $��Resources/cell_hole.png��6   $��4��61   $��6��6A   �� 5O   
   $��Resources/cell_hole.png��6   $��5��61   $��6��6A   �� 5P   
   $��Resources/cell_hole.png��6   $��6��61   $��6��6A   �� 5Q   
   $��Resources/cell_hole.png��6   $��7��61   $��6��6A   �� 5R   
   $��Resources/cell_hole.png��6   $��2��61   $��7��6A   �� 5S   
   $��Resources/cell_hole.png��6   $��3��61   $��7��6A   �� 5T   
   $��Resources/cell_hole.png��6   $��4��61   $��7��6A   �� 5U   
   $��Resources/cell_hole.png��6   $��5��61   $��7��6A   �� 5V   
   $��Resources/cell_hole.png��6   $��6��61   $��7��6A   �� 5W   
   $��Resources/cell_hole.png��6   $��7��61   $��7��6A   �� 5Z   
   -   5         ��Name$ 	turnTitle��5]   1   $��Red Player Turn��5Z      $��1��6+   $��3��6;   $��25(�5[      $��Bell MT)�6"   
���  ��$��Center=�5\   %   $��Center=�5]      61   �� 5_   
   $��
4 In A Row��6   $��1��6&   $��1��66   $��40(�5`      $��Bell MT Bold)�6"   $��	Underline{�5a      
���"�"�$��Center=�5b   -   $��Center=�5c      �� 5e   
   $��Score Player 1:��6   $��1��6+   $��4��6;   $��30(�5f      $��Bell MT Italic Bold)�6"   
���  ��$��Center=�5g   %   $��Center=�5h      $��	Underline{�5i      �� 5j   
   $��Score Player 2:��6   $��1��6+   $��6��6;   $��30(�5k      $��Bell MT Italic Bold)�6"   
��� ���$��Center=�5l   (   $��Center=�5m      $��	Underline{�5n      �� 5p   
   -   5        $ p1Score��5t      $��0��5p      $��1��6   $��5��6-   $��30(�5q      $��Bell MT Bold)�6"   
���   �$��Center=�5r   '   $��Center=�5s      5t      �� 5u   
   -   5        $ p2Score��5y      $��0��5u      $��1��6   $��7��6-   $��30(�5v      $��Bell MT Bold)�6"   
���   �$��Center=�5w   '   $��Center=�5x      5y      5z      5{      