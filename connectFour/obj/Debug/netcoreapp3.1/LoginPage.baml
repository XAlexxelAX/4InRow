   M S B A M L   `   `   `  ����F  BconnectFour, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:connectFourconnectFour  5   	       connectFour.LoginPage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:connectFour     5   	     � Title$  Login��5   	   $	��450��6   $	��400��6$   
������� � Icon$ Resources\loginIcon.ico��5	      .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $	��100 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5      $��20 �6   �� 5      $��25 �6   �� 5      $��40 �6   �� 5      $��10 �6   �� 5       $��25 �6   �� 5"      $��40 �6   �� 5$      $��50 �6   �� 5&      $��20 �6   �� 5'      $��20 �6   �� 5(      $��50 �6   .+�5,   
   �� $��0��6   $��1��6!   $��Login:��61   $��Bell MT Bold)�6?   
����� �$��Center=�5-   -   $��30(�6H   $��Center=�6V   $��	Underline{�5.      �� 5/   
   $��Resources\loginUser.png��6   $��1��61   $��1��6>   �� 50   
   $��3��6   $��1��6!   $��	Username:��61   $��Bell MT Bold)�6B   
���   �$��Center=�51   '   $��22(�6B   $��Center=�6P   $��	Underline{�52      �� 53   
   -   5         ��Name$ username��53   /   $��4��6   $��1��6   
�������$��20(�54       �� TextAlignment$ Center=�6!   �� 55   
   $��6��6   $��1��6!   $��	Password:��61   $��Bell MT Bold)�6B   
���   �$��Center=�56   '   $��22(�6B   $��Center=�6P   $��	Underline{�57      G� 58   
   -   5         G�Name$ password��58   F   $��7��6   $��1��6#   
�������$��20(�59      $��Center=�6$   �� 5:   
   -   5         ��Name$ loginBtn��5:   .   $��8��6   $��1��6   $��Login��6@   $��25(�6P   $��Bell MT Bold)�5;      
����iA�6C   �� 5<   
   -   5        $��10��5<      $��1��6   $��Click Here To Register��6/   
���� ��
�������$��Center=�5>      $��Center=�6,   5?      5@      5B      