   M S B A M L   `   `   `  ����@  <Shell, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Shell.ViewsShell.Views  5          Shell.Views.DataGrid   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Shell.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��20 �6   �� 5      $��20 �6   �� 5      $��10 �6   �� 5      $��20 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��2��6!   (&Welche Tabelle möchten Sie einsehen?.6\   �� 5   
   -   5         ��Name$ 	Speichern��5      $��Änderungen Speichern��6$   $��1��6C   $��1��6P    �� 	ClickMode$ Release=�6`   6t   �� 5   
   -   5         ��Name$ Auswahl_Tabelle��5   !   $
��10,0q�6   $��1��6:   $��0��6G   .@�5      �� $��1 Einkauf Gesamt��6   68   �� 5      $��2 Einkauf Food��6   66   �� 5      $��3 Einkauf NonFood��6   69   �� 5      $��4 Verkauf Gesamt��6   68   �� 5      $��5 Verkauf InHouse��6   69   �� 5      $��6 Verkauf ToGo��6   66   �� 5      $��
7 Personal��6   62   �� 5      $��8 Arbeitszeiten��6   67   �� 5       $��9 Fixkosten��6   63   �� 5!      $��10 Steuersätze��6   66   5#      &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ Anzeige_tabellen��5$      $��3��6-   $��3��6:   $��2��6K      CanUserAddRows$
 True��6_      AutoGenerateColumns$
 True��6�   ��6u   ��  �� Path$ .�	 �� Mode$	 TwoWay=�
   Columns
 5%      5(      5)      5*      