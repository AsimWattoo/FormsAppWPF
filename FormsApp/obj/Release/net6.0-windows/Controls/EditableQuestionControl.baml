   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  &     FormsApp.EditableQuestionControl   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FormsApp     2conv!clr-namespace:FormsApp.Converters     -     >�Name$  editableQuestionControl��$	��130��$	��700��$
��0 10q�.����  �� CornerRadius$ 10��$	��0.5q�
�������$
}�True��
������� �� Padding$
 10 5q�._��  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��40�� �� Orientation$ 
Horizontal=�$��Right=�.+��� -    ��Name$ editBtn��   EditIcon#��[  $��35��$��16(�  FontAwesome_Solid#��[   RoundedButtons#��[ $	��5 0q��� -   $ 	deleteBtn��  
DeleteIcon#��[ #��[ #��[ $��35��$��16(�$	��5 0q�� $��Center=�$��1�� � Cursor$
 Hand�� � ColumnDefinitions �� $
��Auto ��� $��* �.+��� $ 3q�$��30��$��Center=�$	��Top=�  
Light_Blue#��[  �� *ActualHeight+ �� RelativeSource �� 	 �� Mode$
	 Self=����� *ActualHeight+ �� $
	 Self=�._��� $��17(�
�������$��Center=�$��Center=����� *Number+
 �� ElementName$
 editableQuestionControl���� $��1��$��6 0 0 0q�$
��Wrap=�$��18(�$��Stretch=�$	��Top=�$��DemiBold"����� *Text+$
 editableQuestionControl��