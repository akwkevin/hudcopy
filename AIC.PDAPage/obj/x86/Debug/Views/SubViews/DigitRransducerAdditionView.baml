   M S B A M L   `   `   `  ����F  BAIC.PDAPage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:AIC.PDAPage.Views.SubViewsAIC.PDAPage.Views.SubViews  5      ?$clr-namespace:AIC.PDAPage.ConvertersAIC.PDAPage.Converters  5      <    6AIC.PDAPage.Views.SubViews.DigitRransducerAdditionView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <subview(clr-namespace:AIC.PDAPage.Views.SubViews     5      8convert$clr-namespace:AIC.PDAPage.Converters     5        � 	Resources  5
      6   0AIC.PDAPage.Converters.CodeSelectedItemConverter   codeSelectedItemConverter��%   &	          5   
   6,   5      .��5      �  � RowDefinitions 5   
   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   4   .AIC.PDAPage.Views.SubViews.TransformMethodView  $��0��6&   $��0��63   $��4��6C   �� 5   
   $��1��6   $��0��6!   $��开关量总类:��61   $��Center=�6?   �� 5   
   -   5         ��Name$ myComBox��5   0   $��1��6   $��1��6     �� DisplayMemberPath$
 Name��6i     VirtualisedMetroComboBox#���  6�   ��6B   �� *SwitchCategory+ �� SelectedItem 5      `� 5       `� 	Converter# [  6   .1�5      ��  �� Path$ 
SwitchCode�6   �� 5       $ SwitchCategory�6    �� Mode$ OneWay=�64   5!      5#      �� 5$   
   $��2��6   $��4��6   $��1q�62     AccentColorBrush#���  6F   $��	-1,0,-1,0q�6x   ._�5%      �  5&      �� 5'      $	��120 �6'   �� 5(      $��* �6'   �� 5)      $	��120 �6'   �� 5*      $��* �6'   .+�5,      �� $��0��6   $��0��6)   $��选择第一项:��69   $��Center=�6G   �� 5-      $��0��6   $��1��6'   	 �� 
IsReadOnly	 .   MetroTextBox#���  6�   ��67   �� *IsFisrtItemofTRUE+
 � DataContext
 6Z   �� *SelectedItem+ �� ElementName$ myComBox��6�   5.      5/      �� 50   
   $��3��6   $��0��6!   $��ModBus功能码种类:��61   $��Center=�6E   �� 51   
   $��3��6   $��1��6    $
 Name��6Z   #���  6s   ��60   �� *ModBusFunCategory+ 52      `� 53      # [  6   .1�54      �� $ ModBusFunCode�6   �� 55      $ ModBusFunCategory�6   $ OneWay=�67   56      58      59      5:      