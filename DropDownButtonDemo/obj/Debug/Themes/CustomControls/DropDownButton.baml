   M S B A M L   `   `   `  ����M  IDropDownButtonDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DropDownButtonDemo.ControlsDropDownButtonDemo.Controls  5      ]3clr-namespace:DropDownButtonDemo.Controls.Utilities%DropDownButtonDemo.Controls.Utilities  5      M+clr-namespace:DropDownButtonDemo.ConvertersDropDownButtonDemo.Converters  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      c6clr-namespace:DropDownButtonDemo.Themes.CustomControls(DropDownButtonDemo.Themes.CustomControls  5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0890    *DropDownButtonDemo.Controls.DropDownButton  �� 
TargetType �� 	Resources �� MergedDictionaries �� Source   Key �� Color �� Property �� Value �� 
TargetType d�Name	    ButtonStyle
 d� 	IsChecked �� RelativeSource �� Mode ]�Name F�Name  DownwardChevron  DropDownArrowBrush   DropDownArrowStrokeThickness ��Name    Content    ContentTemplate    ContentTemplateSelector    ContentStringFormat �� ContentStringFormat � ContextMenu ��Name    	MenuStyle � ActualWidth �� 	StaysOpen    MenuPlacementTarget �� PlacementTarget �� 	Placement:   4DropDownButtonDemo.Controls.Utilities.DropDownHelper!   MenuPopupPlacementCallback# �� CustomPopupPlacementCallback �� ItemStringFormat  �� IsOpen! �� HorizontalOffset" �� Path# �� Mode$ �� 	Converter3   -DropDownButtonDemo.Converters.NumericInverter% �� VerticalOffset& �� Triggers' P� Property( P� Value) �� 
TargetName* :� 
SourceName+ :� RoutedEvent, �� 
TargetName- �� TargetProperty. �� KeyTime/ �� Value0 �� CenterX1 �� CenterY2 �� ScaleY3 �� BasedOn�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      6Controls)clr-namespace:DropDownButtonDemo.Controls  5      A	Utilities3clr-namespace:DropDownButtonDemo.Controls.Utilities  5      :
Converters+clr-namespace:DropDownButtonDemo.Converters  5      1system&clr-namespace:System;assembly=mscorlib  5      @local6clr-namespace:DropDownButtonDemo.Themes.CustomControls  5      %�  '         7  7  7  7d��� 5	      "    6    5   
   �� 5       5      �� 5      $E ?/DropDownButtonDemo;component/Styles/Controls/ToggleButton.xaml?�6)   �� 5      $A ;/DropDownButtonDemo;component/Resources/Shapes/Chevron.xaml?�6)   �� 5      DropDownArrowBrush  $ #303030��6=   X�5       DropDownArrowStrokeThickness  1Q�6H   5      .�5   
   ��  � �� 5      �� 5      "   6"   .R�5!      d� $ PART_Button��6#   #��z	 5"   #   
 5#   #   �� *
IsExpanded+ �� *TemplatedParent+$ TwoWay=�.��5%      ]� $ PART_DockPanel��6$   ��. |�.  .+�5(      F� $ 
PART_Arrow��6#   8��  8�� 8�� 5+   #   �� 5-      $ PART_ButtonContent��6/   #��z 5.   /   #��z 5/   /   #��z 50   /   # z 51   /   #��z��52   /   #��z��53   /   55       57      �� 59      $ 	PART_Menu��6*   #��z 6=   #��z 5:   *    .  # z 5<   *   $ Custom=�5=   *   # Z 6=   #��z��5@   *   #��z��5A   *   # z 5B   *   #��z��5C   *   #��z��5D   *   #��z��5E   *   #��z��5F   *     5;   *   �� *
IsExpanded+$ TwoWay=� �� *TemplatedParent+! 5>   *   �� $" Margin.Left� �� $
# Self=�$   % 5?   *   �� $" 
Margin.Top� �� $
# Self=�$   5F   *   5J      & 5L      P� 5N      ' �@  Orientation$( 
Horizontal=�69   . �5O      �� $) 
PART_Arrow��6%    � ��$ Right=�6W   �� 5P      $) 
PART_Arrow��6%    � ��$ Center=�6Z   �� 5Q      $) 
PART_Arrow��6%    � ��$ 6 0 0 0q�6O   5R      P� 5T      ' �@  Orientation$( Vertical=�69   . �5U      �� $) 
PART_Arrow��6%    � ��$ Bottom=�6W   �� 5V      $) 
PART_Arrow��6%    � ��$ Center=�6\   �� 5W      $) 
PART_Arrow��6%    � ��$ 0 6 0 0q�6O   5X      P� 5[      ( 65   Z� ' �@  Content. �5\      �� $) 
PART_Arrow��6%    � ��$ 0q�6O   5]      :� 5a      $* 	PART_Menu��6'   $+ ContextMenu.Opened��6>   .[�5b      �� .��5c   "   �� .��5d   &   �� $, PART_Button��6E   $- IsHitTestVisible�6i   .p�5e   *   s� $. 0��6B   	/ False6N   5f   '   5g   #   5h      5i      :� 5l      $* 	PART_Menu��6'   $+ ContextMenu.Closed��6>   .[�5m      �� .��5n   "   �� .��5o   &   �� $, PART_Button��6E   $- IsHitTestVisible�6i   .p�5p   *   s� $. 0��6B   / True6N   5q   '   5r   #   5s      5t      P� 5v      ' �@  
IsExpanded( . . �5w      �� $) 
PART_Arrow��6%    �@�LayoutTransform 5x   "   �� 5y   &   $	0 0.5Q�65   $	1 0.5Q�6C   $2 -1Q�6Q   5{      5|      5�      5�      �� 5�   
    �@  ButtonStyle 5�      �� 5�      "  d�6   83  .�5�      ��  �@��	ClickMode$ Press=�62   5�      5�      �� 5�   
    �@  	MenuStyle# �@��6&   �� 5�   
    � |� .  6&   �� 5�   
    �@  MenuPlacementTarget 60   ��  �� $
# Self=�5�      5�      