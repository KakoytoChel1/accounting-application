   M S B A M L   `   `   `  ���� H  DAccountingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:AccountingApp.ViewAccountingApp.View  #    AccountingApp.View.WindowTest   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:AccountingApp.View       � Title$  
WindowTest��$	��450��$	��800��
���   � � 	Resources    CalendarItemTemplate1 �� 
TargetType5  /System.Windows.Controls.Primitives.CalendarItem � 	Resources �Name  Key �� Color'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState   
Storyboard	 g� Duration
 �� 
TargetName	 W� To �� TargetProperty �� CornerRadius � Cursor	 �� To J� Opacity �� Stretch F�Name ��Name � ColumnDefinitions � RowDefinitions ��Name  PreviousButtonTemplate  HeaderButtonTemplate  NextButtonTemplate ��Name  DisabledColor �� RadiusX �� RadiusY �� Triggers P� Property P� Value �� 
TargetName �� Property �� Value  �� Value! �� Binding" �� RelativeSource# �� AncestorType&   System.Windows.Controls.Calendar  CalendarStyle1$ �� 
TargetType% ��Name&  Name'   CalendarItemStyle��%�  &	        7  7  7  7  7  &	 �    �� "   ���� (��       **(CalendarItem.DayTitleTemplateResourceKey+).R��� ���	#FF333333$��Verdana)�$
��Bold"�$	��9.5(�$��Center=�$��0,6,0,6q�$��Center=����� .R�� $ 	PART_Root�� ���� DisabledColor $ 	#A5FFFFFF��   CommonStates��.   
Normal��  Disabled��. �� .��W� $	 0D�$
 PART_DisabledVisual�� 1$ Opacity�.+��� #��z��#��z��#��z��$ 1��._��� ���	#FFFFFFFF$��2q�$ 1��._��  ���� PreviousButtonTemplate " ��.R�� $
 Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $	 0D�$

 path�� 	#FF73A9D8$* $(Shape.Fill).(SolidColorBrush.Color)�  Disabled��. �� .��W� $	 0D�$

 path�� .5$" (Shape.Fill).(Brush.Opacity)�.+��� ���	#11E5EBF1$ 1Q�$
 Fill=�� .+�F� $
 path��"�����5���Ѱ�5h�W��<�h�	���	#FF333333$
��Left=�$��10��$��	14,-6,0,0q�$
 Fill=�$��Center=�$��6���� NextButtonTemplate " ��.R�� $
 Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $	 0D�$

 path�� 	#FF73A9D8$* $(Shape.Fill).(SolidColorBrush.Color)�  Disabled��. �� .��W� $	 0D�$

 path�� .5$" (Shape.Fill).(Brush.Opacity)�.+��� ���	#11E5EBF1$ 1Q�$
 Fill=�� .+�F� $
 path��"����xT��!��xT���S�h4 	���	#FF333333$��Right=�$��10��$��	0,-6,14,0q�$
 Fill=�$��Center=�$��6���� HeaderButtonTemplate " ��.R�� $
 Hand��   CommonStates��.   
Normal��  	MouseOver��. �� .���� $	 0D�$
 buttonContent�� 	#FF73A9D8$6 0(TextElement.Foreground).(SolidColorBrush.Color)�  Disabled��. �� .��W� $	 0D�$
 buttonContent�� .5$ Opacity�.+��� $ buttonContent��#��z��#��z�����	#FF333333#��z��$��1,4,1,9q�#��z�� �� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $ PART_PreviousButton��$��0��$|�False��$
��Left=�$��20��$��0��8��  $��28���� $ PART_HeaderButton��$��1��$|�False��$
��Bold"�$
��10.5(�$��Center=�$��0��8�� $��Center=��� $ PART_NextButton��$��2��$|�False��$��Right=�$��20��$��0��8�� $��28��� $ PART_MonthView��$��3��$��Center=�$��6,-1,6,6q�$��1��$y�Visible=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �� $ PART_YearView��$��3��$��Center=�$��6,-3,7,6q�$��1��$y�Hidden=� �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $ PART_DisabledVisual��8�� $ 0Q�$ 2��$ 2��8�� $
 Fill=�$��1��$y�	Collapsed=� P�  � {�$ False��. ��� $ PART_DisabledVisual�� � y�$ Visible=��� $
  Year��! �� *DisplayMode+" �� *FindAncestor+"#  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� $  Decade��! �� *DisplayMode+" �� *FindAncestor+"#  .a��� $ PART_MonthView�� � y�$ Hidden=��� $ PART_YearView�� � y�$ Visible=��� "$  .���  � ��
 �������  � �� �#1f2023��  � ��
 �������  � ��$ 0q���  � �� �� "  .R��� $% 	PART_Root��$��Center=�.+�  $& PART_CalendarItem��#���   #��z��#��z��#��z��#��z' .���  �� �� .+�  #���  
���   �