   M S B A M L   `   `   `  ���� R  NMultipleRobloxInstances, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MultipleRobloxInstancesMultipleRobloxInstances  (    "MultipleRobloxInstances.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:MultipleRobloxInstances     -     �Name$  MW�� � Title$ 
MainWindow��$	��322��$	��524�� � WindowStyle$
 None=� � 
ResizeMode$ NoResize=���Z� ��Z�  � 	Resources    
GlyphBrush �� Color  NormalBrush  NormalBorderBrush  HorizontalNormalBrush  HorizontalNormalBorderBrush  DisabledForegroundBrush  NoHighlightBut �� 
TargetType ��Name J� SnapsToDevicePixels	 ��Name
 �� ContentStringFormat �� ContentStringFormat �� Triggers P� Property P� Value �� 
TargetName!  System.Windows.SystemColors   HighlightBrushKey �� Value �� Property  PressedBrush �� 
StartPoint �� EndPoint � Color � Offset  ScrollBarLineButton �� 
TargetType �� RelativeSource 	 ScrollBarPageButton 
 ScrollBarThumb �� CornerRadius  VerticalScrollBar � RowDefinitions ]�Name ]� DecreaseRepeatButton ]� Thumb ]� IncreaseRepeatButton  HorizontalScrollBar � ColumnDefinitions  �� Triggers  FavsScrollViewer! ��Name" �� VerticalOffset# � Value$ �� ScrollableHeight% � Maximum& �� ViewportHeight' �� ViewportSize*( �� #ComputedVerticalScrollBarVisibility) �� Orientation* �� HorizontalOffset+ �� ScrollableWidth, �� ViewportWidth,- �� %ComputedHorizontalScrollBarVisibility��%Y  &	        &	      &	       &	 0     &	 E     &	 U     &	 e     &	 b    &	 �    7  7  7   7  7  &		 �    &	
 v    &	 g    7  7 	 7 
 7 	 7  &	 <    7  7 	 7 
 7  7  7 	 7  '�� �	    7  7  &	 8    �� $
 #444���� $
 #888���� $
 #888���� $ 	#FF686868���� $
 #888���� $
 #888���� " ��.R��� $ border��#��z��#��z��#��z��$
 True��._��� $	 contentPresenter��#��z��#��z��# z
 $|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 True��. ��� $ border��# �   � ��P�  �@d�	IsChecked$
 TrueY�. ��� $ border�� � �� �	#4C464646�� $ border�� � �� �	#4C464646P�  � {�$ False��. ��� $ border�� � �� �	#4C464646�� $ border�� � �� �	#4C464646��  � �� �	#4C464646�� $	 0,0&�$	 0,1&���� � $
 #BBB��$	 0.0Q�� $
 #EEE��$	 0.1Q�� $
 #EEE��$	 0.9Q�� $
 #FFF��$	 1.0Q��� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � |�$ false����  � �� �� " ��.R��� $ Border��$��0q�8��  8�� $��0q�._�F� $��Center=�$��Center=�8�� ���� *	Content+ �� *TemplatedParent+ P�  � ��$
 true��. ��� $ Border��8   � ��P�  � {�$ false��. ��� 8   � ���� " ��.���  � y�$ Hidden=���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " ��.R��� 
���   ��� " n�.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true����  � ��$ false����  � |�$ false����  � �� �� " n�.R��� $ 3��#��z��#��z��$��0q�$��8��$��8,0,-2,0q��� " ��.R��  �� $��0���� $��0.00001* ��� $��0��.+��� $��3��
������ �� $��0��8��  $��18��$��ScrollBar.LineUpCommand��$��M 0 4 L 8 4 L 4 0 Z����Z� ]� $ 
PART_Track��$��1��$
��true�� �� 8�� $��ScrollBar.PageUpCommand�� n� 8�� $��0.5,0,0.5,0q����	#33525252���	#7F7C7C7C �� 8�� $��ScrollBar.PageDownCommand���� $��3��8�� $��18��$��ScrollBar.LineDownCommand��$��M 0 0 L 4 4 L 8 0 Z���� " ��.R��  �� $��18���� $��0.00001* ��� $��18��.+��� $��3��
������ �� $��0��8��  $��18��$��ScrollBar.LineLeftCommand��$��M 4 0 L 4 8 L 0 4 Z��]� $ 
PART_Track��$��1��$��False�� �� 8�� $��ScrollBar.PageLeftCommand�� n� 8�� $��0,1,0,1q�8�� 8��  �� 8�� $ ��ScrollBar.PageRightCommand���� $��3��8�� $��18��$ ��ScrollBar.LineRightCommand��$��M 0 0 L 4 4 L 0 8 Z���� " ��.���  �@J�SnapsToDevicePixels$
 True����  �@�OverridesDefaultStyle$
 true��  P�  �@��Orientation$ 
Horizontal=�. ���  � ��$
 Auto����  � ��$ 18����  � ��8   P�  �@��Orientation$ Vertical=�. ���  � ��$ 18����  � ��$
 Auto����  � ��8  �� " ��.���  �@�OverridesDefaultStyle$
 True����  � �� �� " ��.R��  �� $
��Auto ���  �� �� $
��Auto �.+��� $��1���� $! PART_VerticalScrollBar��## z" #% z$ #' z& #y�z( �� $! PART_HorizontalScrollBar��$) 
Horizontal=�$��1��$��1��## z* #% z+ #' z, #y�z- .��� -   . �Name$. Border��
������� �� $
��446* ��� $	��79* �.+�� -   $. MainWin��$��0.5,0.5,0.5,0.5q�$	��522��$	��321��$��2�����	#FF0C0C0C �� $
��177* ��� $	��23* �.+�� -   $. TopBar��$��
0,0,-2,279q�$��2��.+��� -   / ��Name$/ Title��$��Multiple Roblox Instances��$
��Left=�$��Center=�$��40��0 J� RenderTransformOrigin$0 0.5,0.5&�$	��237��$��Calibri Light)�
�������$��4,0,0,0q�$��22(�z�V� .~��� 1 �� ScaleY$1 1Q��� �� T� �� -   2 ��Name$2 Close��$��X��$
��Left=�$��	489,0,0,0q�$��Center=�#���  
�������$��Calibri Light)�$��30��$��21��$��20(���Z� ��Z� �� -   $2 Minimise��$	��—��$
��Left=�$��	454,0,0,0q�$��Center=�#���  
�������$��Calibri Light)�$��30��$��21��$��20(���Z� ��Z� �� -   $ VersionBorder��$��1q�$
��Left=�$��16��$ 5 5 5 5��$��Center=�$��28�����	#FF9B62F9$��	244,0,0,0q��� -	   3 ��Name$3 VersionText��$
��Left=�$��14��$
��Wrap=�$��Center=�$��28�����	#FF9A9898$��Calibri Light)�$��10(�4 �� TextAlignment$4 Center=�$��244,0,0,-1.5q��� 5 � Language$5 en-hk�$	�2.0���� -
   $3 UpdateAvailable��$
��Left=�$��14��$
��Wrap=�$��Center=�$��149.7�����	#FF646464$��Calibri Light)�$��10(�$
4 Left=�$��280,0,0,-1.5q�$y�Hidden=��� $5 en-hk�$�Update available���� -   6 ��Name$6 InstancesScrollView��$
��Left=�$	��261��$	��Top=�$	��522��7 � IsSharedSizeScope$
7 True��$��2��$��0,35,0,0q�.��� -   8 �Name$	8 WP1��$
��Left=�$
��Auto��$	��Top=�$	��522��$
7 True��� -   $. 	StatusBar��$��2��$��	0,296,0,0q�.+��� -   $/ 
StatusText��$
��Left=�$5��/Multiple Roblox Instances is currently running.��$
��Left=�$��3,-2,0,0q�$	��Top=�$��25��$	��364�����	#FF737373$��Calibri)��� -   9 ��Name$9 
GitHubIcon��: �� BitmapScalingMode$: HighQuality=�; �� EdgeMode$; Aliased=�$
��Left=�$��14��$��	499,4,0,0q�$	��Top=�$��13��$��/Resources/GitHubIcon.png��< J� Opacity$	< 0.5Q��� -   $9 DiscordIcon��$: HighQuality=�$; Aliased=�$
��Left=�$��18��$��	476,0,0,3q�$��Center=�$��14��$ ��/Resources/DiscordIcon.png��$	< 0.5Q��� -   $9 TelegramIcon��$: HighQuality=�$; Aliased=�$
��Left=�$��14��$��	454,4,0,0q�$	��Top=�$��13��$!��/Resources/TelegramIcon.png��$	< 0.5Q��� -   $9 WebsiteIcon��$: HighQuality=�$; Aliased=�$
��Left=�$��16��$��	432,3,0,0q�$	��Top=�$��15��$!��/Resources/QuestionIcon.png��$	< 0.5Q�