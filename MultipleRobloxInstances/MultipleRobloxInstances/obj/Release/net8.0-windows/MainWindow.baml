   M S B A M L   `   `   `  ���� R  NMultipleRobloxInstances, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MultipleRobloxInstancesMultipleRobloxInstances  (    "MultipleRobloxInstances.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:MultipleRobloxInstances     -     � Title$  
MainWindow��$	��322��$	��524�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=���Z�  � 	Resources    
GlyphBrush �� Color  NormalBrush  NormalBorderBrush  HorizontalNormalBrush  HorizontalNormalBorderBrush  DisabledForegroundBrush  NoHighlightBut �� 
TargetType ��Name J� SnapsToDevicePixels ��Name	 �� ContentStringFormat
 �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName!  System.Windows.SystemColors   HighlightBrushKey �� Value �� Property  PressedBrush �� 
StartPoint �� EndPoint � Color � Offset  ScrollBarLineButton �� 
TargetType �� RelativeSource 	 ScrollBarPageButton 
 ScrollBarThumb �� CornerRadius  VerticalScrollBar � RowDefinitions ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions �� Triggers  FavsScrollViewer  ��Name! �� VerticalOffset" � Value# �� ScrollableHeight$ � Maximum% �� ViewportHeight& �� ViewportSize*' �� #ComputedVerticalScrollBarVisibility( �� Orientation) �� HorizontalOffset* �� ScrollableWidth+ �� ViewportWidth,, �� %ComputedHorizontalScrollBarVisibility��%Y  &	        &	      &	       &	 0     &	 E     &	 U     &	 e     &	 b    &	 �    7  7  7   7  7  &		 �    &	
 v    &	 g    7  7 	 7 
 7 	 7  &	 <    7  7 	 7 
 7  7  7 	 7  '�� �	    7  7  &	 8    �� $
 #444���� $
 #888���� $
 #888���� $ 	#FF686868���� $
 #888���� $
 #888���� " ��.R��� $ border��#��z��#��z��#��z��$
 True��._��� $ contentPresenter��#��z��#��z��#
 z	 $|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 True��. ��� $ border��# �   � ��P�  �@d�	IsChecked$
 TrueY�. ��� $ border�� � �� �	#4C464646�� $ border�� � �� �	#4C464646P�  � {�$ False��. ��� $ border�� � �� �	#4C464646�� $ border�� � �� �	#4C464646��  � �� �	#4C464646�� $	 0,0&�$	 0,1&���� � $
 #BBB��$	 0.0Q�� $
 #EEE��$	 0.1Q�� $
 #EEE��$	 0.9Q�� $
 #FFF��$	 1.0Q��� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � |�$ false����  � �� �� " ��.R��� $ Border��$��0q�8��  8�� $��0q�._�F� $��Center=�$��Center=�8�� ���� *	Content+ �� *TemplatedParent+ P�  � ��$
 true��. ��� $ Border��8   � ��P�  � {�$ false��. ��� 8   � ���� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " ��.R��� 
���   ��� " n�.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " n�.R��� $ 3��#��z��#��z��$��0q�$��8��$��8,0,-2,0q��� " ��.R��  �� $��0���� $��0.00001* ��� $��0��.+��� $��3��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z����Z� ]� $ 
PART_Track��$��1��$
��true�� �� 8�� $��ScrollBar.PageUpCommand�� n� 8�� $��0.5,0,0.5,0q����	#33525252���	#7F7C7C7C �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��18���� $��0.00001* ��� $��18��.+��� $��3��
������ �� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $ 
PART_Track��$��1��$��False�� �� 8�� $��ScrollBar.PageLeftCommand�� n� 8�� $��0,1,0,1q�8�� 8��  �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true�� P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� " ��.���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R��  �� $
��Auto ���  �� �� $
��Auto �.+��� $��1���� $  PART_VerticalScrollBar��#" z! #$ z# #& z% #y�z' �� $  PART_HorizontalScrollBar��$( 
Horizontal=�$��1��$��1��#" z) #$ z* #& z+ #y�z, .��� -   - �Name$- Border�����	#FFE2E2E2 �� $
��446* ��� $	��79* �.+�� -   $- MainWin��$��0.5,0.5,0.5,0.5q�$	��522��$	��321��$��2�����	#FF0C0C0C �� $
��177* ��� $	��23* �.+�� -   $- TopBar��$��
0,0,-2,279q�$��2��.+��� -   . ��Name$. Title��$��Multiple Roblox Instances��$
��Left=�$��Center=�$��40��/ J� RenderTransformOrigin$/ 0.5,0.5&�$	��237��$��Calibri Light)�
�������$��4,0,0,0q�$��22(�z�V� .~��� 0 �� ScaleY$0 1Q��� �� T� �� -   1 ��Name$1 Close��$��X��$
��Left=�$��	489,0,0,0q�$��Center=�#���  
�������$��Calibri Light)�$��30��$��21��$��20(���Z� ��Z� �� -   $1 Minimise��$	��—��$
��Left=�$��	454,0,0,0q�$��Center=�#���  
�������$��Calibri Light)�$��30��$��21��$��20(���Z� ��Z� �� -   $ VersionBorder��$��1q�$
��Left=�$��16��$ 5 5 5 5��$��Center=�$��28�����	#FF9B62F9$��	244,0,0,0q��� -	   2 ��Name$2 VersionText��$
��Left=�$��14��$
��Wrap=�$��Center=�$��28�����	#FF9A9898$��Calibri Light)�$��10(�3 �� TextAlignment$3 Center=�$��244,0,0,-1.5q��� 4 � Language$4 en-hk�$	�2.0���� -
   $2 UpdateAvailable��$
��Left=�$��14��$
��Wrap=�$��Center=�$��92�����	#FF646464$��Calibri Light)�$��10(�$
3 Left=�$��280,0,0,-1.5q��� $4 en-hk�$�Update available���� -   5 ��Name$5 InstancesScrollView��$
��Left=�$	��261��$	��Top=�$	��522��6 � IsSharedSizeScope$
6 True��$��2��$��0,35,0,0q�.��� -   7 �Name$	7 WP1��$
��Left=�$
��Auto��$	��Top=�$	��522��$
6 True��� -   $- 	StatusBar��$��2��$��	0,296,0,0q�.+��� -   $. 
StatusText��$
��Left=�$5��/Multiple Roblox Instances is currently running.��$
��Left=�$��3,-2,0,0q�$	��Top=�$��25��$	��364�����	#FF737373$��Calibri)��� -   8 ��Name$8 
GitHubIcon��9 �� BitmapScalingMode$9 HighQuality=�: �� EdgeMode$: Aliased=�$
��Left=�$��14��$��	499,4,0,0q�$	��Top=�$��13��$��/Resources/GitHubIcon.png��; J� Opacity$	; 0.5Q��� -   $8 DiscordIcon��$9 HighQuality=�$: Aliased=�$
��Left=�$��18��$��	476,0,0,3q�$��Center=�$��14��$ ��/Resources/DiscordIcon.png��$	; 0.5Q��� -   $8 TelegramIcon��$9 HighQuality=�$: Aliased=�$
��Left=�$��14��$��	454,4,0,0q�$	��Top=�$��13��$!��/Resources/TelegramIcon.png��$	; 0.5Q��� -   $8 WebsiteIcon��$9 HighQuality=�$: Aliased=�$
��Left=�$��16��$��	432,3,0,0q�$	��Top=�$��15��$ ��/Resources/WebsiteIcon.png��$	; 0.5Q�� -   $- MessageGrid�����	#B2000000$��2��$y�Hidden=�.+��� -   $. MessageTitle��$��Title��$��Center=�$��Center=�$��0,77,0,0q�$	��Top=�$	��524�����	#FFE8E8E8$��Calibri)�$��22(�$��33���� -   $2 MessageText��$3 Center=�$
��Left=�$��62��$
��Wrap=�$	��Top=�$	��523�����	#FFB0B0B0$��Calibri Light)�$��	5,112,0,0q�$/ 1.338,2.769&�$��16(�$
��True��z�V� .~��� �� < �� AngleX$< -0.674Q��� T� = T� X$= -4.365Q��� $4 en-hk�$�1���� �� $4 en-hk�$�2���� �� $4 en-hk�$�3���� -   $1 MessageOption1��$��Option 1��$��180,181,264,117q����	#4C000000���	#FFFAFAFA#���  ���	#19A5A5A5$/ 0.5,0.5&�$��11(�$
; 0.75Q����� " �� :� > :� RoutedEvent$> UIElement.MouseEnter��.[��� .���� .��W� ? �� TargetProperty$? Opacity�@ W� From@ 0.75	A W� ToA 1B g� 	BeginTime	B 0:0:0C g� Duration$C 0:0:0.2D�:� $> UIElement.MouseLeave��.[��� .���� .��W� $? Opacity�@ 1A 0.75	B 0:0:0$C 0:0:0.2D�z�V� .~��� $0 -1Q�D �� ScaleX$D -1Q��� �� E �� Angle$E -179.832Q�T� �� -   $1 MessageOption2��$��Option 2��$��267,181,177,117q����	#4C000000���	#FFFAFAFA#���  ���	#19A5A5A5$/ 0.5,0.5&�$��11(�$
; 0.75Q����� " �� :� $> UIElement.MouseEnter��.[��� .���� .��W� $? Opacity�@ 0.75A 1	B 0:0:0$C 0:0:0.2D�:� $> UIElement.MouseLeave��.[��� .���� .��W� $? Opacity�@ 1A 0.75	B 0:0:0$C 0:0:0.2D�z�V� .~��� $0 -1Q�$D -1Q��� �� $E -179.832Q�T� 