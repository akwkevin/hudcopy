   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollBarPageButton  �� 
TargetType �� Property �� Value �� 
TargetType  HorizontalScrollBarThumb �� CornerRadius  VerticalScrollBarThumb  VerticalScrollBar  AccentColorBrush ]� DecreaseRepeatButton ]� Thumb n�Name J� Opacity	 ]� IncreaseRepeatButton
 �� Triggers P� Property P� Value N� EnterActions g� Duration �� 
TargetName �� TargetProperty	 W� To N� ExitActions  HorizontalScrollBar �� Triggers �Name � ColumnDefinitions ��Name � RowDefinitions ��Name �� CanHorizontallyScroll �� CanVerticallyScroll ��Name4    .System.Windows.Automation.AutomationProperties    AutomationId �� ScrollableHeight � Maximum � Minimum*  �� #ComputedVerticalScrollBarVisibility! �� ViewportHeight" �� ViewportSize# � Value$ �� Path% �� Mode& �� RelativeSource' �� ScrollableWidth( �� Orientation,) �� %ComputedHorizontalScrollBarVisibility* �� ViewportWidth+ P� 
SourceName, �� 
TargetName�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %�	  &	        &	 �     &	 �    &	     7   7  7   &	     7   7  7   '�� �    7  7  '�� A    �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " ��.R��� 
������ �� "  n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R�� 
������ .+��� $��8�����#FFF$��0.5,1q�$ 3���� "  n�.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� " n�.R�� 
������ .+��� $��8�����#FFF$��1,0.5q�$ 3���� " ��.R�� $��12��.+��� $��12��#���  $ 3��]� $��
PART_Track����.  �� $��ScrollBar.PageUpCommand��8��   n� $ Thumb��$
 0.25Q�8�� 	 �� $��ScrollBar.PageDownCommand��8�� 
 P�  �@J�IsMouseOver .  �� .���� .��W� $ 0:0:0.25D�$ Thumb��$ Opacity�$ 1X� �� .���� .��W� $ 0:0:0.25D�$ Thumb��$ Opacity��� " ��.R�� $��12��.+��� $��12��#���  $ 3��]� $��
PART_Track����.   �� $��ScrollBar.PageUpCommand��8��   n� $ Thumb��$
 0.25Q�8�� 	 �� $��ScrollBar.PageDownCommand��8�� 
 P�  �@J�IsMouseOver .  �� .���� .��W� $ 0:0:0.25D�$ Thumb��$ Opacity�$ 1X� �� .���� .��W� $ 0:0:0.25D�$ Thumb��$ Opacity��� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��8    P�  �@��Orientation$ 
Horizontal=�. ���  � ��8  �� "  ��.���  �@�FocusVisualStyle Z� ��  � �� �� " ��.R�� $
 Grid��
������  �� $ 
leftColumn��$��* ��� $ rightColumn��$
��Auto � �� $��* ��� $
��Auto �.+��� $! PART_ScrollContentPresenter��$��0,0,0,0q� .   .  �� $ PART_VerticalScrollBar��$��1��$��0��$ VerticalScrollBar��# z $ 0Q�#y�z  #" z! # �� $$ VerticalOffset�$% OneWay=�& �� *TemplatedParent+�� $ PART_HorizontalScrollBar��$��0��$��1��$ HorizontalScrollBar��# z' $ 0Q�$( 
Horizontal=�#y�z) #" z* # �� *HorizontalOffset+$% OneWay=�& �� *TemplatedParent+
 P� $+ PART_VerticalScrollBar�� � y�$ Visible=�. ��� $!, PART_ScrollContentPresenter�� � ��$ 0,0,4,0q�