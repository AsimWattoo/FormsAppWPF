   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  9!clr-namespace:FormsApp.ConvertersFormsApp.Converters      FormsApp.QuestionControl   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     @d2http://schemas.microsoft.com/expression/blend/2008     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     (localclr-namespace:FormsApp     2conv!clr-namespace:FormsApp.Converters     -     >�Name$  question_ctrl��$
��0 10q����� *Height+ �� FallbackValue$	 370��.����  �� CornerRadius$ 10��$	��0.5q�
�������$
}�True��
������� �� Padding$
 10 0q�._��  � RowDefinitions �� $	��100 ��� $
��Auto �.+�� $��Center=�$��0�� � Cursor$
 Hand�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $ 3q�$��30��$��Center=�$	��Top=�   
Light_Blue#��[   �� *ActualHeight+ �� RelativeSource ��  �� Mode$
 Self=����� *ActualHeight+ �� $
 Self=�._��� $��17(�
�������$��Center=�$��Center=����� *Number+$ 1���� $��1��$��6 0 0 0q�$
��Wrap=�$��18(�$��Stretch=�$��Center=�$��DemiBold"����� *Text+�� $��1��y��� *Type+	 �� 	Converter	 ;   5FormsApp.Converters.QuestionTypeToVisibilityConverter  
 �� ConverterParameter$	
 MCQ��.+��� ���� *	Options+���� .R�   FormsApp.CheckBox  $��40��$	��200��$
��Left=�$��5q�   Checked �� *	Checked+   Command ��  �� ElementName$ question_ctrl�� �� Path$ DataContext.OptionChecked�   CommandParameter �� *Number+   Text �� *
OptionText+�� $��1��y��� *Type+	   $

 Text��.+���   	TextInput#��[ 
 � Tag$ Enter Value��$
��Left=�$��18(�$
��10 5q�$
��20 0q����� *Value+�� $��1��y��� *Type+	   $
 Dropdown��.+��� $��2��$��40��$
��10 5q�$��18(�  MaterialDesignComboBox#���  $��0 0 0 1q� �� 
IsReadOnly$
 True�� �� SelectedValue �� *Value+���� *DropDownValues+