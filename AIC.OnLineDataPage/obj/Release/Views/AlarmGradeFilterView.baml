   M S B A M L   `   `   `  ���� M  IAIC.OnLineDataPage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:AIC.OnLineDataPage.ConvertersAIC.OnLineDataPage.Converters  C ?AIC.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5(clr-namespace:AIC.Core;assembly=AIC.CoreAIC.Core 3    -AIC.OnLineDataPage.Views.AlarmGradeFilterView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     F BItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=nullGbsFilter8http://schemas.bolapansoft.com/xaml/Controls/ItemsFilter  Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  :d2http://schemas.microsoft.com/expression/blend/2008  <
converters+clr-namespace:AIC.OnLineDataPage.Converters  3core(clr-namespace:AIC.Core;assembly=AIC.Core  -     � 	Resources     CategoryItemsPanelTemplate K� IsItemsHost �� Orientation'  !AIC.Core.EnumDescriptionConverter  enumDescriptionConverter>   8AIC.OnLineDataPage.Converters.AlarmGradeToImageConverter  alarmGradeToImageConverter  CheckBoxStyle �� 
TargetType �� Property �� Value �� 
TargetType �� 
Background J� SnapsToDevicePixels	 �� Bullet
 ��Name  AccentColorBrush �� RadiusX �� RadiusY F�Name �� Stretch �� Triggers P� Property P� Value �� 
TargetName��%l  &	        &	 %     &	 *     &	 /     �� .R���  . $ 
Horizontal=�    �� " ��.���  � ��$ 1q���  � ��$ Center=���  � �� �� " ��.R��� 
 ����  . 	 � $��24��$��24��.+��� $
 	PART_Rect��#���  $��3��$ 5��$ 5��F� $
 path��$��18��$��18��$
 Fill=�#��z��F�����ej�Z�����x��,E=R�ܿe������Tn5�$�!��C��ej�Z�._��� #��z��#��z����. # z #��z�� P�  � �� . . ���  � ��$ 4,0,0,0q�P�  � {� .  . ��� # � �� � ��P�  �@d�	IsChecked$ FalseY�. ��� $
 path�� � y�$ Hidden=����� :  4BolapanControl.ItemsFilter.View.MultiValueFilterView"  .���  � �� �� "  .R�� .+�� �  �BolapanControl.ItemsFilter.View.FilterViewBase`1[[BolapanControl.ItemsFilter.Model.IMultiValueFilter, ItemsFilter, Version=1.1.0.1, Culture=neutral, PublicKeyToken=null]]   Model � DataContext# z $
��Auto=� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $��0��$��报警级别：��$��Center=�$��2,0,2,0q���  ��Name$ 
PART_Items��$��1��#��[   �� SelectionMode$ Multiple=����� *AvailableValues+��Z� ��Z� ���� " ��.���  � �� �� *
Background+ �� RelativeSource �� *FindAncestor+ �� AncestorLevel$ 1�� �� AncestorType" ����  � �� �� " ��.R��� $��5,2,5,2q�$ 
Horizontal=�.+�A�  A�Name$ ellipse�����	#FF85CBEB$��Center=�$��24��$��24���� #���  $��Center=�����  �� 	Converter# [ �� $��Center=�#��[  d� 	IsChecked �� *
IsSelected+ �� Mode$ TwoWay=� �� *TemplatedParent+ ��  �� Value$ Invalid��  �� Binding  �� ! �� Path$! .�.a��� $ ellipse�� � ��
 ������� $ 	HighAlarm��  �� $! .�.a��� $ ellipse�� � ��
 � ����� $ LowAlarm��  �� $! .�.a��� $ ellipse�� � ��
 � ����� $ 
HighDanger��  �� $! .�.a��� $ ellipse�� � ��
 �  ���� $ 	LowDanger��  �� $! .�.a��� $ ellipse�� � ��
 �  ��