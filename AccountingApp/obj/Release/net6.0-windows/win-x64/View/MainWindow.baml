   M S B A M L   `   `   `  ���� H  DAccountingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:AccountingApp.ViewModelAccountingApp.ViewModel      AccountingApp.MainWindow   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4vm%clr-namespace:AccountingApp.ViewModel     _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  _	 [Hardcodet.NotifyIcon.Wpf, Version=1.1.0.0, Culture=neutral, PublicKeyToken=682384a853a08aad)tb http://www.hardcodet.net/taskbar 	 -     �Name$  
mainWindow�� � Title$ Application��$	��700��$
��1060��$	��500��$	��880�����#121212 � WindowStartupLocation$ CenterScreen=� � Icon$ Assets/appIcon2.ico�� � WindowState �� *WindowStateProp+ �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources    categoryColor �� Color �� ElementName	 �� Path  categoryColorEdit5   /AccountingApp.ViewModel.InverseBooleanConverter  InverseB��%�   &	        &	 4     &	 l     ��  �� $ categoryColorPicker��$	 Color���  �� $ categoryColorPickerEdit��$	 Color�  
 � DataContext
 +  %AccountingApp.ViewModel.MainViewModel  '  !System.Windows.Shell.WindowChrome   WindowChrome   *  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged��/  )Microsoft.Xaml.Behaviors.EventTriggerBase   SourceObject �� $ mainListbox��*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command �� *FinanceSelectCommand+  $ SelectionChanged�� �� $ currencyBox��.    �� *CurrencyChanged+  $ SelectionChanged�� �� $ categoryBox��.    �� *CategoryChanged+  $ SelectionChanged�� �� $ typeBox��.    �� *TypeChanged+  $ TextChanged�� �� $ 	searchBox��.    �� *SearchItemsCommand+  $ Checked�� �� $ trayChecked��.    �� *TrayStateChanged+  $ StateChanged�� �� $ 
mainWindow��.    �� *WindowStateChanged+   CommandParameter �� $ 
mainWindow��  $ TrayLeftMouseDown�� �� $ trayElement��.    �� *ShowWindowCommand+ �� $ 
mainWindow��  $ Click�� �� $ closeApp��.    �� *CloseByTrayCommand+ �� $ 
mainWindow��.��� -    �Name$ mainGrid�� � RowDefinitions �� $��35 ���  � ColumnDefinitions �� $��35��$	��250��$
��auto ��� �� -    ��Name$ 	SidePanel��$	��230 �.+�3	 	 -Hardcodet.Wpf.TaskbarNotification.TaskbarIcon	  -    	 Name$ trayElement�� 	  
IconSource$ Assets/appIcon2.ico�� � ContextMenu �� .@�m� -    m�Name$ closeApp��$��Закрыть��� $��2��$��2��  Gradient#��[  �� $
��auto ��� $
��auto ��� .+��� $��1�� �� Orientation$ Vertical=�$��0,0,0,20q�.+��� -    ��Name$ 	searchBox��$��2��$��2��  SearchTextBox#���  $��15,50,15,10q�$��Bottom=����� *SearchContent+$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� *SearchCommand+.���� 
�������$��Добавить��$
��Bold"�$��18(� �� Padding$ 	25,18,0,0q�$��Century gothic)�$��0,0,0,20q���   ButtonTemplate#���  $��60������ *SwitchToAddIncome+.���  �� $��50 ��� .+��� $��Assets/income.png��$��40���� $��1��$��	0,15,0,15q�
�������$��Century gothic)�$��15(�$��Доходы��  �� TextAlignment$  Center=�$ 	10,3,80,0q�! � Triggers! :� " :� RoutedEvent$" Button.Click��[��� .���� .��U� # �� 
TargetName$# dynamic_side_panel��$ �� TargetProperty$$ (FrameworkElement.Width)�.\�9
  3System.Windows.Media.Animation.EasingDoubleKeyFrame
  % O� KeyTime$% 0:0:0.1��& O� Value& �� *ActualWidth+$ 	SidePanel��' � ToolTip' _� .��(&Добавить новый доход�� $��60��#���  ���� *SwitchToAddExpenses+.���  �� $��50 ��� .+��� $��Assets/expenses.png��$��40��$��10,0,0,0q��� $��1��$��	0,15,0,15q�
�������$��Century gothic)�$��15(�$��Расходы��$  Center=�$ 	10,3,80,0q�! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��& �� *ActualWidth+$ 	SidePanel��' _� .��*(Добавить новый расход� $��2�� �� $��60 ��� .+��� $��0,1,0,1q�
�������._�� $��60�� �� �� $
��0.5* �.+��� 
�������$��Категории��$
��Bold"�$��18(�$ 	25,18,0,0q�$��Century gothic)���   RoundButtonTemplate#���  $��1��$��30��$��30��$��0,0,0,0q�$
��Left=�
����������� *SwitchToAddCategory+.���� $��Assets/addSomething.png��$��19��! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��& �� *ActualWidth+$ 	SidePanel��' _� .��0.Добавить новую категорию�� -   ( ��Name$( categoryListBox��$��1��
������ $��0q�$��Disabled=�) �� SelectedItem) �� *SelectedCategoryItem+$ PropertyChanged=����� *categoryItems+ * �� 
TargetType+ �� Property, �� Value- ��Name. �� CornerRadius/ ��Name  ButtonTemplateOpac0 �� Target1 W� From	2 W� To3 g� Duration4 �� Triggers5 P� Property6 P� Value7 �� 
TargetName��%�  '��       �� "* ��.��� + � ��$, 50���� + � ��
, ���� �� + �@�ToolTip, _� ���� *Title+�� + � ��, �� .R��� $- bd��._��  �� $
��auto ��� �� $
��auto �.+��� $��35��$��35��$. 8��$��2q����#27292d$��Right=�$��20,0,0,0q����� *
ColorHex+�� $��1��$��	0,15,0,15q�
�������$��Century gothic)�$��14(�$
  Left=�$ 	15,0,30,0q����� *Title+� $��2��$��Right=�$��	10,0,10,0q� �� �� .+��� $/ editCategoryButton��$��0��$��0,0,6,0q�#���  $y�Hidden=����� $ 
mainWindow��$&	  DataContext.SwitchToEditCategory�.���� $��Assets/edit2.png��$��17��! :� $" Button.Click��[��� .���� $$ Width�0 �� $ dynamic_side_panel��.��W� 1 02 230$3 0:0:0.1D��� $/ removeCategoryButton��$��1��$��0,0,5,0q�#���  $y�Hidden=����� $ 
mainWindow��$'	 !DataContext.RemoveCategoryCommand�.���� $��Assets/delete.png��$��17��4 P� 5 �@J�IsMouseOver$
6 True��. ��� $7 bd��+ � ��, �#1f2023P� 5 �@��
IsSelected$
6 True��. ��� $7 bd��+ � ��, �#27292d�� $7 removeCategoryButton��+ � y�$, Visible=��� $7 editCategoryButton��+ � y�$, Visible=��� $��1��
�������$��14(�$��Century gothic)�$  Center=�$	��150��$
��Wrap=�$��Center=�$��0,0,0,50q�$1��+Список категорий пуст :(������ "* ��.��� + � y�$, Visible=�8 �� Triggers8 �� 9 �� Binding9 �� $ categoryListBox��$	 HasItems�: �� Value: True.a��� + � y�$, Hidden=�� $��2��.+��� -   $- dynamic_side_panel��$��Right=�$��0�����#1a1c1d$��0,1,0,0q�
�������._�� .+��� 
������ $��0q�; �� SelectedIndex; �� *SelectedSidePanelMenu+.@��� $��0��.���  �� �� $��50 ��� $��10 �.+��� $��0��.���� $ Vertical=�.+��� $��Наименование��  TextBlock_RSP#���  � .+��� -	   $ enterTitle_tb�� 	 TextBox_RSP#��� 	 ���� *IncomeTitle+$ PropertyChanged=��� 
�������< J� IsHitTestVisible$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterTitle_tb��:  .a��� + � y�$, Visible=��� $��
Сумма��#���  �  �� �� $��70 �.+��� -
   $ enterSum_tb��#��� 	 ���� *	IncomeSum+$ PropertyChanged=�= �� StringFormat$= N2��.��>   	Behaviors> ,  &AccountingApp.ViewModel.LimitBehaviour  .���� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$��Введите сумму������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterSum_tb��:  .a��� + � y�$, Visible=��� $��1��$��60��$��0,10,5,0q�$��30��; �� *SelectedCurrencyIndexIncome+$ PropertyChanged=�.@��� .���� $��Assets/dollar.png��$��20��$
��Left=��� .���� $��Assets/euro.png��$��20��$
��Left=��� .���� $��Assets/hryvnia.png��$��20��$
��Left=��� $��Категория��#���  �� $��
10,10,55,0q�? �� SelectedValuePath$? Content������ *category_combobox_items+) �� *SelectedIncomeCategory+$ PropertyChanged=�; �� *SelectedCategoryIncomeAdd+���� .R��  �� $��30 ��� .+��� $��0��$��15��$
��Left=�$��3,0,0,0q�$��15��$. 3��$��0q����� *
ColorHex+�� $��1�� 
 	TextColor#��[
 $��Century gothic)�$��11(����� *Title+�� $��Описание��#���  � .+��� -   $ enterDescription_tb��  Dynamic_TextBox_RSP#���  ���� *
IncomeDesc+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterDescription_tb��:  .a��� + � y�$, Visible=�� $��1�� �� �� $��50 �.+��� $��1��  AddIncomeButton_RSP#���  ���� *AddNewIncomeCommand+{��� $ enterSum_tb��$	 (Validation.HasError)�@ �� 	Converter#@ [ ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��1��  ClosePanelButton_RSP#���  ���� *CloseIncomeAddCommand+! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��0��.���  �� �� $��50 ��� $��10 �.+��� $��0��.���� $ Vertical=�.+��� $��Наименование��#���  � .+��� -   $ enterTitle_tb3��#��� 	 ���� *ExpensesTitle+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterTitle_tb3��:  .a��� + � y�$, Visible=��� $��
Сумма��#���  �  �� �� $��70 �.+��� -   $ enterSum_tb3��#��� 	 ���� *ExpensesSum+$ PropertyChanged=�$= N2��.��>   .���� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$��Введите сумму������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterSum_tb3��:  .a��� + � y�$, Visible=��� $��1��$��60��$��0,10,5,0q�$��30��; �� *SelectedCurrencyIndexExpenses+$ PropertyChanged=�.@��� .���� $��Assets/dollar.png��$��20��$
��Left=��� .���� $��Assets/euro.png��$��20��$
��Left=��� .���� $��Assets/hryvnia.png��$��20��$
��Left=��� $��Категория��#���  �� $��
10,10,55,0q�$? Content������ *category_combobox_items+) �� *SelectedExpensesCategory+$ PropertyChanged=�; �� *SelectedCategoryExpensesAdd+���� .R��  �� $��30 ��� .+��� $��0��$��15��$
��Left=�$��3,0,0,0q�$��15��$. 3��$��0q����� *
ColorHex+�� $��1��#��[
 $��Century gothic)�$��11(����� *Title+�� $��Описание��#���  � .+��� -   $ enterDescription_tb3��#���  ���� *ExpensesDesc+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterDescription_tb3��:  .a��� + � y�$, Visible=�� $��1�� �� �� $��50 �.+��� $��1��  AddExpensesButton_RSP#���  ���� *AddNewExpensesCommand+{��� $ enterSum_tb3��$	 (Validation.HasError)�#@ [ ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��1��#���  ���� *CloseExpensesAddCommand+! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��0��.��� 
 �� *SelectedFinanceItem+ �� �� $��50 ��� $��10 �.+��� $��0��.���� $ Vertical=�.+��� #���  $��Наименование��� .+��� -   $ enterTitle_tb4��#��� 	 ���� *Title+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterTitle_tb4��:  .a��� + � y�$, Visible=��� #���  $��
Сумма���  �� �� $��70 �.+��� -   $ enterSum_tb4��#��� 	 ���� *Sum+$ PropertyChanged=�$= N2��.��>   .���� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$��Введите сумму������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterSum_tb4��:  .a��� + � y�$, Visible=��� -   A ��Name$A currencyBox��$��1��$��60��$��0,10,5,0q�$��30��; �� $ 
mainWindow��$+	 %DataContext.SelectedCurrencyIndexEdit�$ PropertyChanged=�.@��� .���� $��Assets/dollar.png��$��20��$
��Left=��� .���� $��Assets/euro.png��$��20��$
��Left=��� .���� $��Assets/hryvnia.png��$��20��$
��Left=��� #���  $��Категория���� -   $A categoryBox��$��
10,10,55,0q�$? Content������ $ 
mainWindow��$)	 #DataContext.category_combobox_items�) �� $ 
mainWindow��$-	 'DataContext.SelectedFinanceCategoryEdit�; �� $ 
mainWindow��$2	 ,DataContext.SelectedFinanceIndexCategoryEdit����� .R��  �� $��30 ��� .+��� $��0��$��15��$
��Left=�$��3,0,0,0q�$��15��$. 3��$��0q����� *
ColorHex+�� $��1��#��[
 $��Century gothic)�$��11(����� *Title+�� #���  $��Тип���� -   $A typeBox��$��1��$��2��$��30��$��
10,10,85,5q�$��Bottom=�; �� $ 
mainWindow��$'	 !DataContext.SelectedTypeIndexEdit�.@��� .���  �� $
��auto ��� .+��� $��0��
�������$
��auto��$��Center=�$
��auto��$��2,0,0,0q�$��Доходы���� $��2��$
��Left=�$��10,0,0,0q�$��Assets/income.png��$��22���� .���  �� $
��auto ��� .+��� $��0��
�������$
��auto��$��Center=�$
��auto��$��2,0,0,0q�$��Расходы���� $��2��$
��Left=�$��10,1,0,0q�$��Assets/expenses.png��$��21���� #���  $��Описание��� .+��� -   $ enterDescription_tb4��#���  ���� *Description+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterDescription_tb4��:  .a��� + � y�$, Visible=�� $��1�� �� �� $��50 �.+��� $��1��  EditPanelButton_RSP#���  ���� $ 
mainWindow��$$	 DataContext.EditFinanceCommand�{��� $ enterSum_tb4��$	 (Validation.HasError)�#@ [ .���  �� $��20 ��� ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��1��#���  ���� $ 
mainWindow��$)	 #DataContext.CloseFinanceEditCommand�! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��0��.���  �� �� $��50 ��� $��10 �.+��� $��0��.���� .+��� #���  $��Название��� .+��� -   $ enterTitle_tb5��#��� 	 ���� *CategoryTitle+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterTitle_tb5��:  .a��� + � y�$, Visible=��� #���  $��Цвет��*  $MaterialDesignThemes.Wpf.ColorPicker  -   B  Name$B categoryColorPicker��$	��120��$��
15,20,30,0q�C   ColorC �� *CategoryColorHex+$ PropertyChanged=�� .+��� -   $ enter_color��#��� 	 ���� $ categoryColorPicker��$	 Color�$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$��Введите HEX-код������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enter_color��:  .a��� + � y�$, Visible=�� $��1�� �� �� $��50 �.+��� $��1��#���  ���#27292d���� *AddNewCategoryCommand+.���  �� �� .+��� $��0��
�������$��Добавить��$
��Bold"�$��13(�$��Center=�$ 0,0,0,0q�$��0,0,0,0q�$��Century gothic)��� $��Right=�$��1��$��25��$��25��$��	30,0,20,0q�$. 5��#��[  ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��1��#���  ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��0��.��� 
 �� *SelectedCategoryItem+ �� �� $��50 ��� $��10 �.+��� $��0��.���� .+��� #���  $��Название��� .+��� -   $ enterTitle_tb6��#��� 	 ���� *Title+$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$(��"Введите что-нибудь������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enterTitle_tb6��:  .a��� + � y�$, Visible=��� #���  $��Цвет��  -   $B categoryColorPickerEdit��$	��120��$��
15,20,30,0q�C �� *
ColorHex+$ PropertyChanged=�� .+��� -   $ enter_color_edit��#��� 	 ���� $ categoryColorPickerEdit��$	 Color�$ PropertyChanged=��� 
�������$< False��$��
10,10,20,0q�$ 10,8,0,0q�$��11(�$��Century gothic)�$��Введите HEX-код������ "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ enter_color_edit��:  .a��� + � y�$, Visible=�� $��1�� �� �� $��50 �.+��� $��1��#���  ���#27292d���� $ 
mainWindow��$%	 DataContext.EditCategoryCommand�.���  �� $��20 ��� .+��� $��1��
�������$ ��Редактировать��$
��Bold"�$��13(�$��Center=�$ 0,0,0,0q�$��0,0,50,0q�$��Century gothic)��� $��Right=�$��1��$��25��$��25��$��0,0,10,0q�$. 5��#��[ ! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q��� $��1��#���  ���� $ 
mainWindow��$*	 $DataContext.CloseCategoryEditCommand�! :� $" Button.Click��[��� .���� .��U� $# dynamic_side_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q�� $��1��$��1�� �� .+��� $��1��
�������$��15(�$��Century gothic)�$  Center=�$	��250��$
��Wrap=�$��Center=�$��0,0,0,50q�$)��#Ничего не найдено :(������ "* ��.��� + � y�$, Visible=�8 �� 9 �� $ mainListbox��$	 HasItems�: True.a��� + � y�$, Hidden=��� -   $( mainListbox��$��1��D %� IsVirtualizing$
D True��$��0,0,0,15q�
������ $��0,0,0,0q�$��Disabled=����� *sortedFinanceItems+$ PropertyChanged=�) �� *SelectedFinanceItem+$ PropertyChanged=�; �� *SelectedFinanceItemIndex+$ PropertyChanged=� ��%�  '��       �� "* ��.��� + � ��$, 60���� + � ��, �� .R��� $- bd��$��3q�$. 5��
������ ._��  �� $��2* ��� .+��  �� $��50 ��� .+��� $��35��$��35��$. 8��$��2q����#27292d$��Center=�$��5,0,0,0q����� *Color+�� $��1��$��0,7,50,0q�$	��Top=�
�������$��Century gothic)�$��15(�$
��auto��$
��Left=�$ 	15,0,30,0q����� *Title+�� $��1��$ 
Horizontal=�.+��� $��0,0,0,7q�$��Bottom=�
�������$��Century gothic)�$��12(�$
��auto��$
  Left=�$ 	15,0,10,0q����� *Date+�� $��0,0,0,7q�$��Bottom=�$��12(�
�������$��Century gothic)�$
��auto������ *Time+� $��1�� �� �� $��70 �.+�� $��2��$��Right=�$��0,0,10,0q� �� �� .+��� $/ editItem��$��0��$��0,0,6,0q�#���  $y�Hidden=����� $ 
mainWindow��$%	 DataContext.SwitchToEditFinance�.���� $��Assets/edit2.png��$��17��! :� $" Button.Click��[��� .���� $$ Width�0 �� $ dynamic_side_panel��.��W� 1 02 230$3 0:0:0.1D��� $/ 
removeItem��$��1��$��0,0,5,0q�#���  $y�Hidden=����� $ 
mainWindow��$&	  DataContext.RemoveFinanceCommand�.���� $��Assets/delete.png��$��17���� $ 
Horizontal=�.+��� $��Center=�$��Century gothic)�$��16(�$
��Bold"�$
��auto��$  Right=����� *
SumColor+���� *Sign+�� $��0,0,0,0q�$��Center=�$��Century gothic)�$��16(�$
��Bold"�$
��auto��$  Right=�$ 0,0,5,0q����� *
SumColor+���� *Sum+$ PropertyChanged=��� $��0��$��0,0,0,0q�$��Center=�$��Century gothic)�$��16(�$
��Bold"�$
��auto��$  Right=�$ 0,0,10,0q����� *
SumColor+���� *
Currency+' _� $
��auto������ *Description+4 P� 5 �@J�IsMouseOver$
6 True��. ��� $7 bd��+ � ��, �#1f2023P� 5 �@��
IsSelected$
6 True��. ��� $7 bd��+ � ��, �#27292d�� $7 
removeItem��+ � y�$, Visible=��� $7 editItem��+ � y�$, Visible=�� ���#1a1c1d$��35��$
��Left=�$��0��$��2�� �� $��35 ��� $��35 ��� $��35 �.+��� $��35��$��1��#���  ���� *SwitchToExcelConverterPanel+.���� $��Assets/exel.png��$��22��! :� $" Button.Click��[��� .���� .��U� $# right_dynamic_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$	& 250Q�' _� .��Преобразование� -   $ TitleBar��$��0,1,0,0q�$��0��$��0��$��3��E   IsHitTestVisibleInChrome$
E True�� �� �� $��70 ��� $��35 ��� $��35 ��� $��35 ��� $��35 �.+��� -   $/ closeWindow��  TitleButtonTemplate#���  $��5��$
E True������ *CloseWindowCommand+���� $ 
mainWindow��.���� $��Assets/closeButton.png��  
TitleImage#���  ' _� .��Закрыть�� -   $/ changeStateWindow��#���  $��4��$
E True������ *StateChangeCommand+���� $ 
mainWindow��.���� $��Assets/stateChangeSq.png��#���  �� -   $/ minimizeWindow��#���  $��3��$
E True������ *MinimizeWindowCommand+���� $ 
mainWindow��.���� $��Assets/minimize.png��#���  ' _� .��Свернуть�� -    $/ 	pinWindow��#���  $��2��$
E True������ *PinUnpinCommand+���� $ 
mainWindow��.���� $��18������ "* ��.��� + � ��$, Assets/pin.png��8 �� 9 �� *
IsPinned+: True.a��� + � ��$, Assets\unpin.png��' _� .��$"Поверх других оконd� -!   F d�Name$F trayChecked��$��1��  titleToggleStyle#���  G d� 	IsCheckedG �� *IsTrayActive+$ PropertyChanged=�' _� .��
Трэй�� $
��Left=�$��35��#���  ���� *SwitchToFilterPanel+.���� $��Assets/filter.png��$��20��! :� $" Button.Click��[��� .���� .��U� $# right_dynamic_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$	& 250Q�' _� .��Фильтры�� -"   $- right_dynamic_panel�����#1a1c1d$��2��$��1��$��0��$
��Left=�._��  �� �� $��55 ��� $��15 �.+��� 
������ $��0q�; �� *SelectedRightPanelIndex+$ PropertyChanged=�.@��� $��0��.���  �� $��50 ��� �� $��20 �.+��� 
�������$��Фильтры��$
��Bold"�$��18(�$ 	15,18,0,0q�$��Century gothic)��� $��0��$��30��$��30��$��Bottom=�$��Right=�$��0,0,20,5q�$��0q����#27292d#���  ���� *SwitchToExcelConverterPanel+.���� $��Assets/exel.png��$��20���� $ Vertical=�$��1��.+��� $��По стоимости:��  TextBlock_LSP#���  � .+��� -#   $A allOrSum��$��30��$	��120��$��
20,10,15,0q�$
��Left=�$��Bottom=�; �� *SortingSumIndex+$ PropertyChanged=�.@��� .��Все�� .��� .+��� -$   $ enterCost_tb��$��2,1,0,0q�$��0,0,20,0q�$��11(�  EmptyTextBoxStyle#���  ���� *
SortingSum+$ PropertyChanged=�$= N2��.��>   .���� $��80��$��	140,0,5,0q�$��30��$��Bottom=�; �� *SortingCurrencyIndex+$ PropertyChanged=�.@��� .��Все�� .���� $ 
Horizontal=�.+��� #��[
 $	��USD��$��Center=�$��0,0,5,0q��� $��Assets/dollar.png��$��20��$
��Left=��� .���� $ 
Horizontal=�.+��� #��[
 $	��EUR��$��Center=�$��0,0,5,0q��� $��Assets/euro.png��$��20��$
��Left=��� .���� $ 
Horizontal=�.+��� #��[
 $	��UAH��$��Center=�$��0,0,3,0q��� $��Assets/hryvnia.png��$��20��$
��Left=��� $��По дате:��#���  �� $��1��$��1��$��30��$	��200��$
��Left=�$��
20,10,10,5q�; �� *SortingDateIndex+$ PropertyChanged=�.@��� .��Все�� .��� .+�(  "System.Windows.Controls.DatePicker  -%   $��datePicker1��H   IsDropDownOpen$
H True��$
��auto��I   SelectedDateFormat$
I Long=�$
��Left=�  DatePickerStyle#���    CalendarStyleJ   CalendarStyle#J �  K   SelectedDateK �� *SortingDate+�� #���  $��По типу:���� $��30��$	��150��$��
20,10,10,5q�$
��Left=�; �� *SortingTypeIndex+$ PropertyChanged=�.@��� .��Все�� .���  �� $
��auto ��� .+��� $��0��
�������$
��auto��$��Center=�$
��auto��$��2,0,0,0q�$��Доходы���� $��2��$
��Left=�$��10,0,0,0q�$��Assets/income.png��$��22���� .���  �� $
��auto ��� .+��� $��0��
�������$
��auto��$��Center=�$
��auto��$��2,0,0,0q�$��Расходы���� $��2��$
��Left=�$��10,1,0,0q�$��Assets/expenses.png��$��21���� #���  $��По категории:���� $��30��$��
20,10,10,5q�$	��150��$
��Left=�; �� *SortingCategoryIndex+) �� *SortingCategory+$ PropertyChanged=����� *category_sort_items+���� .R��  �� $��30 ��� .+��� $��0��$��15��$
��Left=�$��3,0,0,0q�$��15��$. 3��$��0q����� *
ColorHex+�� $��1��#��[
 $��Century gothic)�$��11(����� *Title+�� $��Применить��  ApplyButtonStyle_LSP#���  ���� *ApplyFiltersCommand+{��� $ enterCost_tb��$	 (Validation.HasError)�#@ [ � $��2�� �� $
��auto ��� .+��� 
�������$��Century gothic)�$ 10,0,0,0q�$��12(�$*��$Найдено совпадений:���� $��1��$
��Bold"�$ 4,0,0,0q�
�������$��Century gothic)�$��12(����� $ mainListbox��$	 Items.Count�$ PropertyChanged=��� $��0��.���  �� $��50 ��� .+��� 
�������$"��Преобразование��$
��Bold"�$��18(�$��0,0,0,10q�$ 	15,18,0,0q�$��Century gothic)��� $��0��$��30��$��30��$��Bottom=�$��Right=�$��0,0,20,5q�$��0q����#27292d#���  ���� *SwitchToFilterPanel+.���� $��Assets/filter.png��$��20���� $ Vertical=�$��1��.+��� #���  $��Название:��� .+��� -&   $ 	enterName��  DarkTextBoxStyle#���  $��30��
�������$��
15,10,15,0q�$��5,7,5,0q�$��11(�$��Century gothic)�$��1��$��1q����#27292d���� *ConvertedFileName+$ PropertyChanged=�.��> /  )AccountingApp.ViewModel.LimitPathBehavior  .���� $< False��$��1��
�������$��11(�$ 	24,18,0,0q�$&�� Введите имя файла��$��Century gothic)����� "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ 	enterName��:  .a��� + � y�$, Visible=��� #���  $&�� Выбор директории:���  �� �� $
��0.3* �.+��� -'   $ 
selectPath��#���  $��30��
�������$��
15,10,15,0q�$��5,6,5,0q�$��11(�$��Century gothic)�$��1��$��1q����#27292d���� *ExcelFilePath+$ PropertyChanged=�.���� $< False��$��1��
�������$��11(�$ 	25,18,0,0q�$+��%Выберете директорию��$��Century gothic)����� "* ��.��� + � y�$, 	Collapsed=�8 �� 9 �� *Text+$ 
selectPath��:  .a��� + � y�$, Visible=��� $��1��  someStyleColor#��[ $��30��$��30��$
��Left=�$��0,10,0,0q�$��0q�#���  ���� *SelectExcelPathCommand+.���� $��Assets/folder2.png��$��20���� $��0,10,0,0q�$	��top=�#��[
 $��Century gothic)�$��12(�$��Категория:��$
��auto��$
  Left=�$ 	20,5,10,0q��� $��30��$��
20,10,10,5q�$	��150��$
��Left=�; �� *!SelectedConvertingCategoryIndex+) �� *SelectedConvertingCategory+$ PropertyChanged=����� *category_sort_items+���� .R��  �� $��30 ��� .+��� $��0��$��15��$
��Left=�$��3,0,0,0q�$��15��$. 3��$��0q����� *
ColorHex+�� $��1��#��[
 $��Century gothic)�$��11(����� *Title+�� #���  $*��$Из отсортированных:��d� $��5��L � Cursor$
L Hand��  toggleStyle#���  $
��Left=�$��	20,10,0,0q�$	��Top=�G �� *IsUsingSorted+$ PropertyChanged=�� .+��� $"��Конвертировать��#���  ���� *ConvertToExcelCommand+y��� *ConvertButtonVisible+$ PropertyChanged=�� $��0,20,0,0q�$	��200��$��20��
��� � �  ProgressStyle#���  y��� *ConvertProgressVisible+$ PropertyChanged=�M � ValueM �� *ConvertProgressBarValue+$ PropertyChanged=��� $��1��
�������$��0,0.5,0,0.5q�._�� .+��� 
������ 
�������$��80��$��0,0.5,0,0.5q�#���  .���� $��Assets/closeButton.png��$��20��! :� $" Button.Click��[��� .���� .��U� $# right_dynamic_panel��$$ (FrameworkElement.Width)�.\�
  $% 0:0:0.1��$& 0Q�