   M S B A M L   `   `   `  ���� W  SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
TitleImage  �� 
TargetType �� Property �� Value  SidePanel_color �� Color  someStyleColor  Hover_Color  	TextColor  categoryColor �� ElementName �� Path  categoryColorEdit  Gradient �� 
StartPoint �� EndPoint � Color	 � Offset
 �� 
TargetType �� Padding �� CornerRadius K� IsItemsHost � 	Resources �� Triggers P� Property P� Value3    -System.Windows.Media.Effects.DropShadowEffect    Color    ShadowDepth    Opacity    
BlurRadius  DatePickerTextBoxStyle:  4System.Windows.Controls.Primitives.DatePickerTextBox 	 Key'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   States   System.Windows.VisualState   
Storyboard g� Duration �� 
TargetName	 �� To �� TargetProperty	  W� To! ��Name" J� Opacity# �Name$ ��Name% J� IsHitTestVisible& ��Name 
 DatePickerStyle(  "System.Windows.Controls.DatePicker' g� 	BeginTime( �� KeyTime) �� Value* O� KeyTime+ O� Value, � ColumnDefinitions- � RowDefinitions. J� RenderTransformOrigin/ �� Stretch0 ��Name  ButtonTemplateOpac1  Name2 �Name3 � AllowsTransparency4 � 	StaysOpen5 � PlacementTarget6 �� Triggers7 �� Value8 �� Binding9 �� Source: �� 
TargetName; �� RelativeSource  ButtonTemplate< J� SnapsToDevicePixels= ��Name  RoundButtonTemplate  TitleButtonTemplate  AddIncomeButton_RSP> �� Padding  AddExpensesButton_RSP  ClosePanelButton_RSP  EditPanelButton_RSP  AddCategoryButton_RSP  ApplyButtonStyle_LSP  ComboBoxToggleButton? F�Name@ �� 	ClickModeA d� 	IsCheckedB �� ModeC �� SelectionBoxItemD �� SelectionBoxItemTemplateE ��NameF �� 
IsReadOnlyG �� 
IsReadOnlyH �� IsDropDownOpenI � ActualWidthJ �� MaxDropDownHeight-  'System.Windows.Input.KeyboardNavigationK   DirectionalNavigationL P� 
SourceName  TransparentTextBoxStyle  SearchTextBoxM �� UpdateSourceTriggerN �� AncestorType  DarkTextBoxStyle  EmptyTextBoxStyle  TextBox_RSP  Dynamic_TextBox_RSP  TextBlock_RSP  TextBlock_LSP&   System.Windows.Controls.CalendarO ��Name5	  /System.Windows.Controls.Primitives.CalendarItemP 	 NameQ   CalendarItemStyle  CalendarItemTemplateR � 	ResourcesS � Cursor  PreviousButtonTemplate   HeaderButtonTemplate ! NextButtonTemplateT ��Name " DisabledColorU �� RadiusXV �� RadiusY # CalendarStyle $ ScrollThumbsW ]�NameX ]� ThumbY n�NameZ ]� IncreaseRepeatButton[ ��Name\ ]� DecreaseRepeatButton] �� Angle % toggleStyle & titleToggleStyle ' ProgressStyle^ �Name_ � Value` J� Effecta J� OpacityMaskb !� Visualc ��Named �� TextAlignmente �� StringFormat�� H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation       :x,http://schemas.microsoft.com/winfx/2006/xaml      %j`  &	        &	 #     &	 6     &	 G     &	 Z     &	 k     &	 �     &	 �     '_� +    '�� �    &	 �    &	
 �	    &	     7  &	 l    &	 ,    &	 �     7  &	 ^"    &	 �$    &	 �&    &	 x(    &	 �*    7  &	 �,    7  &	 K/    '�� �0    7  '�� 6    &	 ^7    7  &	 �8    7  &	 �;    7  &	 p=    7  &	 �>    &	 �@    &	 �B    &	 JC    '  <D    &	 &E    7  7   7 ! 7 " 7 " &	# R    7  &	$ �R    '�� $T    &	% �W    7  &	& gY    7  &	' [    7  'm� ,]    �� "  ��.���  � ��$ 15���� $ #1a1c1d���� $ Green���� $ #27292d���� $ White����  �� $ categoryColorPicker��$ Color���  �� $ categoryColorPickerEdit��$ Color��� $	 0,0&�$	 1,1&�.��� $ #1a1c1d��$		 0.6Q�� $ #1f2023��$	 0Q��� "  _�.���  � �� �#1f2023��  � ��$ 0q���  � ��
 ���� ��  � ��$ 10q���  � ��$ Century gothic)���  � ��$ 12(���  � ��
 �������  �@_�VerticalOffset$ 20����  �@_�HorizontalOffset$ 20����  � ��$	 500����  � �� �� "
 _�.R��� #��z��#��z��#��z��# z��$ 10��._��� #��z��$
��Wrap=��� "  ��.���  � �� �#27292d��  � ��
 �������  � �� �#1f2023��  � ��$ 1q���  � ��$ 4q���  � �� �� "
 ��.R��� #��z��#��z��#��z��._��� $
 True�� ���� 'm�       "  m�.���  � ��
 ���� ��  � ��
 ����� P�  �@m�IsHighlighted$
 True��. ���  � �� �#1f2023 P�  �@��HasDropShadow$
 True��. ���  � ��$ 0,0,0,5q���  �@J�Effect    $ #1a1c1d��$ 0Q�$	 0.8Q�$ 10Q��� "   .���  � ��
 �������  � ��
 ���� ��  � ��$ 0q���  �@��PanningMode$ VerticalFirst=���  �@��IsFlicksEnabled$ False����  � �� �� "
  .R��  ���� WatermarkBrush	 $ 	#FFAAAAAA��   CommonStates��   $ 0D�  $ 0:0:0.1D�$ 	MouseOver��.   
Normal��  	MouseOver��. �� .���� $ 0D�$ ContentElement�� 	#FF99C1E2$2 ,(Border.BorderBrush).(SolidColorBrush.Color)��� $ 0D�$ watermark_decorator�� 	#FF99C1E2$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�  WatermarkStates��   $ 0D�.   Unwatermarked��  Watermarked��. �� .��W� $ 0D�$ ContentElement��  0$ Opacity�W� $ 0D�$ PART_Watermark��  1$ Opacity�  FocusStates��   $ 0D�.   	Unfocused��  Focused��. �� .��W� $ 0D�$ FocusVisual��  1$ Opacity�.+��� $! Border��#��z��#��z��#��z��$ 1��$" 1Q�# z��._�� $# WatermarkContent��#��z��#��z��.+��� $! ContentElement�����	#FFFFFFFF$��0q��� $! watermark_decorator�����	#FFFFFFFF$��0q�._��� $$ PART_Watermark��$|�False��$% False��$" 0Q�$��2q��� $& PART_ContentHost��#��z��$��0q�#��z���� $! FocusVisual�����	#FF45D6FA$ 1��$% False��$" 0Q��� "   .���  � ��
 �������  � ��$ 0q���  �@ IsTodayHighlighted$
 True����  �@ SelectedDateFormat$ Short=���  � ��
 ���� ��  � ��$
 auto����  � ��$ 2q���  � ��$ Stretch=���  � �� �� "
  .R��� #��z��#��z��#��z��# z��   CommonStates��.   
Normal��  Disabled��. �� .��W� $ 0D�$ PART_DisabledVisual��  1$ Opacity�._�� $# 	PART_Root��#��z��#��z�� ���� DisabledBrush	 $
 Gray���� DropDownButtonTemplate	 "
 ��.R��    CommonStates��   $ 0D�  $ 0:0:0.1D�$ 	MouseOver��  $ 0:0:0.1D�$ Pressed��.   
Normal��  	MouseOver��. �� .���� $ 0D�$ 
Background�� 	#FF448DCA$1 +(Border.Background).(SolidColorBrush.Color)��� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)�.g��� $( 0��$) 	#7FFFFFFF���� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)�.g��� $( 0��$) 	#CCFFFFFF���� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $( 0��$) 	#F2FFFFFF��  Pressed��. �� .���� ' 0$ 00:00:00.001D�$ 
Background��$1 +(Border.Background).(SolidColorBrush.Color)�.g��� $( 0��$) 	#FF448DCA��U� ' 0$ 00:00:00.001D�$ 	Highlight��$ (UIElement.Opacity)�.\��� $* 0��$+ 1Q��� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g��� $( 0��$) 	#EAFFFFFF���� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[2].(GradientStop.Color)�.g��� $( 0��$) 	#C6FFFFFF���� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[3].(GradientStop.Color)�.g��� $( 0��$) 	#6BFFFFFF���� ' 0$ 00:00:00.001D�$ BackgroundGradient��$O I(Border.Background).(GradientBrush.GradientStops)[0].(GradientStop.Color)�.g��� $( 0��$) 	#F4FFFFFF��  Disabled��.+�� ���	#11FFFFFF$��LeftToRight=�$��Center=�$��18��$��0q�$��Center=�$��19��, �� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* �- �� $	��23* ��� $	��19* ��� $	��19* ��� $	��19* �.+��� $! 	Highlight�����	#FF45D6FA$��1q�$ 0,0,1,1��$��4��$��-1q�$" 0Q�$��4��$��0���� $! 
Background�����	#FF1F3B53���	#FFFFFFFF$��1q�$ .5��$��4��$��0,-1,0,0q�$" 1Q�$��3��$��1���� $! BackgroundGradient�����	#BF000000$��1q�$ .5��$��4��$��0,-1,0,0q�$" 1Q�$��3��$��1������ $
 .7,1&�$
 .7,0&�.��� $ 	#FFFFFFFF��$	 0Q�� $ 	#F9FFFFFF��$	 0.375Q�� $ 	#E5FFFFFF��$	 0.625Q�� $ 	#C6FFFFFF��$	 1Q��� $��4��$��1��$��1������ $ 0.3,-1.1&�$ 0.46,1.6&�.��� $ 	#FF4084BD��� $ 	#FFAFCFEA��$	 1Q����� $ 0.48,-1&�$ 	0.48,1.25&�.��� $ 	#FF494949��� $ 	#FF9F9F9F��$	 1Q�F� $��0��$��4������p�[� 4ZX�k� @Q�F� 4ZX�k� @џF� {2� �u� {2� �u�  )� �*� &"@pg� �*� &"@� � ��*�"@��� yh���#@h/��@�#@,� j����"@Sn#� l�H@�/"@��� ����k�!@�[� 4ZX�k� @p�� 4ZX�k� @Q�L4ZX�k� @Q�L�:��"@QH � �:��"@�H � ��� �U+� L�� ����E0@�=� ��� �=� ��	�=� �0ݒ� 5N=� ����� �� �b� �� ��� Ӧ� ��� �u"9��Up0@�� "9��Up0@S�n� "9��Up0@�$� Ӹ� ��� H~� �� {�� �\�� �� ��� [�� �� [�� �y�[�� ���I� ��� Ӭ�J"� sc,� ~T�~O0@c,� Ӷ�� c,� @�� �P� � � /�� ��� �� 	���	#FF2F2F2F$��Center=�$��4,3,4,3q�$. 0.5,0.5&�$��3��$��1��$
/ Fill=�$��Center=�A� $��4�����	#FFFFFFFF$��Center=�$��3��$��0��$��Center=�$��3���� $! DisabledVisual�����	#B2FFFFFF$��1q�$ 	0,0,.5,.5��$��4��$" 0Q�$��4��$��0��, �� $��* ��� $
��Auto �.+��� $0 PART_Button��$��1��#��z��$|�False��$
��Left=�$��2,0,3,0q�$��0��#���  $��Center=�$��20��.���� $��Assets/calendar2.png��  $1 PART_TextBox��$��0,2,0,0q�#���  $��0��
�������$��0q�#|�z|�$��Stretch=�$��0��$��Stretch=�� $# PART_DisabledVisual��$��0��$��2��$% False��$" 0Q�$��0��, �� $��* ��� $
��Auto �.+�� $2 
PART_Popup��$
3 True��$��Bottom=�$4 False��5 �� $ PART_TextBox��6 �� $7 false��8 �� #9 Zr�.a��� $: PART_TextBox�� �� *
Foreground+; �� *TemplatedParent+ � ���� "  ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._��� $= contentPresenter��$|�False��#��z��#��z��$
��True��#< z< #��z��6 P�  �@J�IsMouseOver$
 true��. ��� $: border��8    � ��P�  � ��$
 true��. ��� $: border�� � ��
 ���� �� "  ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._��� $= contentPresenter��$|�False��#��z��#��z��$
��True��#< z< #��z��6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � ��
 ���� ��  � ��$ 2q���  � �� �� "
 ��.R��� $! border��$ 6��#��z��#��z��#��z��$
< true��._��� $= contentPresenter��$|�False��#��z��#��z��$
��True��#< z< #��z��6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � ��
 ���� ��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._��� $= contentPresenter��$|�False��#��z��#��z��$
��True��#< z< #��z��6 P�  �@J�IsMouseOver$
 true��. ��� $: border��8    � ��P�  � ��$
 true��. ��� $: border�� � �� �#27292d�� "  ��.���  � �� �#27292d��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._�� , �� $��50 ��� .+��� $��0��$��Assets/income.png��$��25���� $��1��
�������$��Добавить��$
��Bold"�$��13(�$��Center=�$> 0,0,0,0q�$��Century gothic)�6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � �� �#27292d��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._�� , �� $��50 ��� .+��� $��0��$��Assets/expenses.png��$��25���� $��1��
�������$��Добавить��$
��Bold"�$��13(�$��Center=�$> 0,0,0,0q�$��Century gothic)�6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � �� �#27292d��  � ��$ 1,0,0,0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._�� .+��� $��Assets/closeButton.png��$��18��6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � �� �#27292d��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._�� , �� $��20 ��� .+��� $��1��
�������$��Сохранить��$
��Bold"�$��13(�$��Center=�$> 0,0,0,0q�$��Century gothic)�6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � �� �#27292d��  � ��$ 0q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< true��._�� , �� $��20 ��� .+��� $��1��
�������$��Добавить��$
��Bold"�$��13(�$��Center=�$> 0,0,0,0q�$��Century gothic)��� $��Right=�$��1��$��25��$��25��$��0,0,20,0q�$ 5��8��  6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "  ��.���  � ��8   ��  � ��$ Century gothic)���  � ��$ 	20,25,0,0q���  � ��$
 Left=���  � ��$ 0q���  � ��$ 	15,0,15,0q���  � ��$
 auto����  � ��$ 35����  � ��
 �������  � �� �� "
 ��.R��� $! border��$ 6��#��z��#��z��#��z��$
< true��._��� $= contentPresenter��$|�False��#��z��#��z��$
��True��#< z< #��z��6 P�  �@J�IsMouseOver$
 true��. ��� $: border�� �@J�Opacity$	 0.6Q�P�  � ��$
 true��. ��� $: border�� �@J�Opacity$ 1Q�P�  � {�$ False��. ��� $: border�� �@J�Opacity$	 0.7Q��� "
 d�.R�� , �� �� $��20 �.+��� $! Border��$��2��$ 5�����#1f2023���#27292d$��1q��� $��0��$ 10��$��1q����#1f2023���#27292d$��0,0,1,0q�F� $? Arrow��$��1��
�������$��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	�� "  ��.���  �@J�SnapsToDevicePixels$
 true����  �@�OverridesDefaultStyle$
 true����  � ��$
 Auto=���  � ��$
 Auto=���  � ��$
 true����  � ��$ 30����  � ��
 �������  � �� �� "
 ��.R�� .+�d� $��ToggleButton��8��  $��2��$|�false��$@ Press=�A �� $ IsDropDownOpen�$B TwoWay=�; �� *TemplatedParent+�� $��ContentSite��$% False��#��zC #��zD #��z��$��	10,3,23,3q�$��Center=�$
��Left=��� $E PART_EditableTextBox��$
��Left=�$��Center=�$��	10,3,23,3q�$
|�True�����#1f2023
�������$y�Hidden=�#G zF ��Z� � $��Popup��$��Bottom=�#��zH $
3 True��$|�False��$��Slide=�.��� $��DropDown��$
< True��#��zI #��zJ .+��� $! DropDownBorder�����#1f2023$��1q����#27292d�� $��4,12,4,6q�$
< True��.���� $
 True��$K 	Contained=�6 P�  �@��HasItems$ false��. ��� $: DropDownBorder�� � ��$ 95��P�  � {�$ false��. ���  � �� �#2063e8P�  �@��
IsGrouping$
 true��. ���  � ��$ false��P� $L Popup�� �@�AllowsTransparency$
 true��. ��� $: DropDownBorder�� �@��CornerRadius$ 0���� $: DropDownBorder�� � ��$ 0,10,0,0q�P�  �@��
IsEditable$
 true��. ���  � ��$ false���� $: PART_EditableTextBox�� � y�$ Visible=��� $: ContentSite�� � y�$ Hidden=� �� "  ��.���  �@J�SnapsToDevicePixels$
 true����  � ��
 �������  �@�OverridesDefaultStyle$
 true����  � �� �� "
 ��.R��� $��Border��$ 2q�$
< true��._��� 6 P�  �@��IsHighlighted$
 true��. ��� $: Border�� � �� �#27292dP�  � {�$ false��. ���  � �� �#888888�� "  ��.���  � �� �#1f2023��  � ��8   ��  � �� �#1f2023��  � ��$ 2q���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< True��._��� $& PART_ContentHost��$|�false��$��Hidden=�$��Hidden=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � �� �#1f2023��  � ��8   ��  � �� �#27292d��  � ��$ Century gothic)���  � ��$ 2q���  � ��$ 30����  � �� �� "
 ��.R��� $! border��$ 7��#��z��#��z��#��z��$
< True��._�� , �� $
��auto ��� $��* �.+��� $��0��$��Assets/search1.png��$��20��$��7,0,0,0q��� $E tb��$��1��#��z��#��z��#��z��$��0q�$��	10,5,10,0q����� $
 Text�$M PropertyChanged=�; �� *FindAncestor+"N ��.������ "  �� P�  � {�$ false��. ���  �@J�Opacity$
 0.56Q�.���� $��1��
�������$% False��$> 	12,5,10,0q�$��
Поиск������ "  ��.���  � y�$ 	Collapsed=� �� 8 �� *Text+$ tb��7  .a���  � y�$ Visible=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � �� �#1f2023��  � ��8   ��  � �� �#1f2023��  � ��$ 2q���  � ��$ Century gothic)���  � �� �� "
 ��.R��� $! border��$ 5��#��z��#��z��#��z��$
< True��._��� $& PART_ContentHost��$|�false��$��Hidden=�$��Hidden=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � ��
 ���� ��  � ��8   ��  � ��$ 0q���  �@��
CaretBrush
 �������  � ��$ Century gothic)���  � �� �� "
 ��.R��� $! border��#��z��#��z��#��z��$
< True��._��� $& PART_ContentHost��$|�false��$��Hidden=�$��Hidden=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � �� �#1f2023��  � ��$ 30����  � ��$ 
10,10,20,0q���  � ��$ 5,6,10,0q���  � ��
 �������  � �� �#1f2023��  � ��$ 11(���  � ��$ 2q���  � ��$ Century gothic)���  � �� �� "
 ��.R��� $! border��$ 5��#��z��#��z��#��z��$
< True��._��� $& PART_ContentHost��$|�false��$��Hidden=�$��Hidden=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � �� �#1f2023��  � ��$ 30����  � ��$ 
10,10,20,0q���  � ��$ 5,6,10,6q���  � ��
 �������  � �� �#1f2023��  �@��TextWrapping$
 Wrap=���  � ��$ 11(���  � ��$ 2q���  � ��$ Century gothic)���  � �� �� "
 ��.R��� $! border��$ 5��#��z��#��z��#��z��$
< True��._��� $& PART_ContentHost��$|�false��$��Hidden=�$��Hidden=�6 P�  � {�$ false��. ��� $: border�� �@J�Opacity$
 0.56Q��� "  ��.���  � ��
 �������  � ��$ 13(���  � ��$ 	15,20,0,0q���  � ��$ Century gothic)��� "  ��.���  � ��
 �������  � ��$ 12(���  � ��$ 0,5,0,0q���  � ��$
 auto����  � ��$ Century gothic)���  �@��TextAlignment$
 Left=���  �@��Padding$ 	20,5,10,0q���  � ��$	 Top=��� "   .���  � ��
 �������  � �� �#1f2023��  � ��
 �������  � ��$ 1q���  � �� �� "
  .R��� $O 	PART_Root��$��Center=�.+�	  $P PART_CalendarItem��#��z��#��z��#��z��#��zQ �� "
 	 R ���� (��       **(CalendarItem.DayTitleTemplateResourceKey+).R��� ���#c1becf$��Century gothic)�$
��Bold"�$	��9.5(�$��Center=�$��0,6,0,6q�$��Center=����� .R�� $# 	PART_Root�� ���� DisabledColor	 $ 	#A5FFFFFF��   CommonStates��.   
Normal��  Disabled��. �� .��W� $ 0D�$ PART_DisabledVisual��  1$ Opacity�.+��� #��z��#��z��#��z��$ 10��._��� ���	#FFFFFFFF$��0q�$ 1��._��  ���� PreviousButtonTemplate	 "
 ��.R�� $
S Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$
 path�� 	#FF73A9D8$* $(Shape.Fill).(SolidColorBrush.Color)�  Disabled��. �� .��W� $ 0D�$
 path��  .5$" (Shape.Fill).(Brush.Opacity)�.+��� 
������ $" 1Q�$
/ Fill=�� .+�F� $
? path��"�����5���Ѱ�5h�W��<�h�	
�������$
��Left=�$��10��$��14,0,0,0q�$
/ Fill=�$��Center=�$��6���� NextButtonTemplate	 "
 ��.R�� $
S Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$
 path�� 	#FF73A9D8$* $(Shape.Fill).(SolidColorBrush.Color)�  Disabled��. �� .��W� $ 0D�$
 path��  .5$" (Shape.Fill).(Brush.Opacity)�.+��� 
������ $" 1Q�$
/ Fill=�� .+�F� $
? path��"����xT��!��xT���S�h4 	
�������$��Right=�$��10��$��0,0,14,0q�$
/ Fill=�$��Center=�$��6���� HeaderButtonTemplate	 "
 ��.R�� $
S Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $ 0D�$ buttonContent�� 	#FF73A9D8$6 0(TextElement.Foreground).(SolidColorBrush.Color)�  Disabled��. �� .��W� $ 0D�$ buttonContent��  .5$ Opacity�.+��� $= buttonContent��#��z��#��z��
�������#��z��$��1,8,1,9q�#��z��, �� $
��Auto ��� $
��Auto ��� $
��Auto �- �� $
��Auto ��� $��* �.+��� $0 PART_PreviousButton��$��0��$|�False��$
��Left=�$��20��$��0��8��  $��28���� $0 PART_HeaderButton��$��1��$|�False��$��Century gothic)�$
��Bold"�$
��10.5(�$��Center=�$��0��8�� $��Center=��� $0 PART_NextButton��$��2��$|�False��$��Right=�$��20��$��0��8�� $��28��� $# PART_MonthView��$��3��$��Center=�$��6,-1,6,6q�$��1��$y�Visible=�, �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �- �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �� $# PART_YearView��$��3��$��Center=�$��6,-3,7,6q�$��1��$y�Hidden=�, �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �- �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $T PART_DisabledVisual��8�� $" 0Q�$U 2��$V 2��8�� $
/ Fill=�$��1��$y�	Collapsed=�6 P�  � {�$ False��. ��� $: PART_DisabledVisual�� � y�$ Visible=��� $
7 Year��8 �� *DisplayMode+; �� *FindAncestor+"N  .a��� $: PART_MonthView�� � y�$ Hidden=��� $: PART_YearView�� � y�$ Visible=��� $7 Decade��8 �� *DisplayMode+; �� *FindAncestor+"N  .a��� $: PART_MonthView�� � y�$ Hidden=��� $: PART_YearView�� � y�$ Visible=��� "   .���  � ��
 �������  � ��8   ��  � ��$ 0q���  � �� �� "
  .R��� $O 	PART_Root��$��Center=�.+�	  $P PART_CalendarItem��#���  #��z��#��z��#��z��#��zQ �� "  n�.���  � �� �� "
 n�.R�� $
# Grid��.+��� $��Stretch=�$��Stretch=�$
��Auto��$
��Auto��
������ �� $! 
Rectangle1��$ 5��$��Stretch=�$��Stretch=�$
��Auto��$
��Auto��#��z��6 P�  �@�Tag$ 
Horizontal��. ��� $: 
Rectangle1�� � ��$
 Auto���� $: 
Rectangle1�� � ��$ 7���� "  ��.���  �@��IsFlicksEnabled$ false����  � �� �#27292d��  � ��
 ���� ��  � ��$ 8����  � �� �� "
 ��.R�� $# GridRoot��$��8��#��z��- �� $��0.00001* �.+�]� $W 
PART_Track��$��0��$
��true��$|�false��X n� $Y Thumb��#��z��#��� $ Z �� $[ PageUp��$��ScrollBar.PageDownCommand��$" 0Q�$|�false��\ �� $[ PageDown��$��ScrollBar.PageUpCommand��$" 0Q�$|�false��6 P�  � {�$ false��. ��� $: Thumb�� � y�$ 	Collapsed=�P�  �@��Orientation$ 
Horizontal=�. ��� $: GridRoot�� �@�LayoutTransform �� $	] -90Q��� $: 
PART_Track�� �@�LayoutTransform �� $	] -90Q���  � ��$
 Auto����  � ��$ 8���� $: Thumb�� �@�Tag$ 
Horizontal���� $: PageDown�� � ��$ ScrollBar.PageLeftCommand���� $: PageUp�� � ��$  ScrollBar.PageRightCommand���� "  d�.���  � ��$ 30����  � ��$ 50����  � �� �� "
 d�.R��� $	��btn��
�������$ 16��._�� .+��� $��circle��
�������$��20��$��20��$ 20��$
��Left=�$��5,0,0,0q�6 P�  �@d�	IsChecked$
 TrueY�. ��� $: circle�� � ��$ 25,0,0,0q��� $	: btn��8    � ��P�  �@d�	IsChecked$ FalseY�. ��� $: circle�� � ��$ 5,0,0,0q��� $	: btn�� � ��
 ������� "  d�.���  � ��$ 22����  � ��$ 40����  � �� �� "
 d�.R��� $	��btn��
�������$ 11��._�� .+��� $��circle��
�������$��15��$��15��$ 15��$
��Left=�$��5,0,0,0q�6 P�  �@d�	IsChecked$
 TrueY�. ��� $: circle�� � ��$ 20,0,0,0q��� $	: btn��8    � ��P�  �@d�	IsChecked$ FalseY�. ��� $: circle�� � ��$ 5,0,0,0q��� $	: btn�� � ��
 ������� "  �.���  � ��8   ��  � �� �� "
 �.R�� .+��� $! 
MaskBorder��$ 5�����#1f2023$��20��� $^ progress��
���   �$��0.001q�#��z��_ �� $ Value�$M PropertyChanged=�; �� *FindAncestor+"N ���Z� `    progrEf��$ 0Q�$ #1f2023��$ 1Q�$ 25Q�a !� b �� $ 
MaskBorder���� $c progressText��
�������$��11(�$
��auto��$��SemiBold"�$��Century gothic)�$��Center=�$d Center=�$> 0,0,0,0q����� $ progress��$ Value�$
e {0}%���� "  m�.���  � ��$ 11(���  � ��$	 100����  � ��$ Century gothic)���  � �� �� "
 m�.R��� $! Border��
������ ._��� $��6q�$��Header��6 P�  �@J�IsMouseOver$
 True��. ��� $: Border�� � �� �#1f2023P�  �@m�	IsPressed$
 True��. ��� $: Border�� � ��
 ���� 