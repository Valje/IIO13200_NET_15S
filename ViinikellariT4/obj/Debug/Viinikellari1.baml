   M S B A M L   `   `   `  ����I  EViinikellariT4, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ViinikellariT4ViinikellariT4  5   	   "    ViinikellariT4.Viinikellari1   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ViinikellariT4     5   	     � Title$  Viinikellari1��5   	   $	��400��6   $	��600��6,   .��5	      � $��0,0,0,15q�6    � 	Resources 5
   
      
viinidataa � Source � XPath��%f   &	        � 5      $ D:\H3340\Viinit1.xml?�5      $ viinikellari/wine��5      5      5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgWines��5       � DataContext# [  5         AutoGenerateColumns .  $��0,64,0,0q�5   /   ��5      ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Viini��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$		 250 6S   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   ��  �� XPath$
 nimi��6a     5      $	 Maa��6%   $		 170 6P   
 62   �� $	 maa��6^     5      $ Arvio��6%   $	 50 6T   
 64   �� $ arvio��6a   5      �� 5   
   -   5         ��Name$ btnHaeViinit��5      $��
Hae viinit��6'   $
��Left=�6<   $��	25,20,0,0q�6W   $	��Top=�6j   $	��150��6�   �� 5   
   -   5         ��Name$ cmbMaat��5      $
��Left=�6$   $��
218,20,0,0q�6?   $	��Top=�6S   $	��150��6k   # [  5       �� DisplayMemberPath$
 @maa��5      ��5      �� 5      5       5!      