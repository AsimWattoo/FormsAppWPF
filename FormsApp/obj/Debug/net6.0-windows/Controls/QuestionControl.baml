   M S B A M L   `   `   `  ����L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  5      9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  5          FormsApp.QuestionControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      (localclr-namespace:FormsApp     5      2conv!clr-namespace:FormsApp.Converters     5      -   5          >�Name$  question_ctrl��5	      $
��0 10q�5      ��5
      �� *Height+ �� FallbackValue$	 370��.��5      ��  �� CornerRadius$ 10��6   $	��0.5q�5      
�������$
}�True��5      
������� �� Padding$
 10 0q�5      ._�5   
   �  � RowDefinitions 5      �� 5      $	��100 �6    �� 5      $
��Auto �6    .+�5      � $��Center=�6   $��0��5       � Cursor$
 Hand��5       � ColumnDefinitions 5       �� 5!      $
��Auto �6'   �� 5"      $��* �6'   .+�5%      �� $ 3q�5'      $��30��5(      $��Center=�5)      $	��Top=�5*         
Light_Blue#��[  5+       5%      �� *ActualHeight+ �� RelativeSource ��  �� Mode$
 Self=���5&      �� *ActualHeight+ �� $
 Self=�._�5,      �� $��17(�6H   
�������$��Center=�5.       $��Center=�5/       ��5,       �� *Number+$ 1��5/       50      �� 52      $��1��6   $��6 0 0 0q�53      $
��Wrap=�55      $��18(�56      $��Stretch=�57      $��Center=�58      $��DemiBold"�59      ��54      �� *Text+59      5;      �� 5>      $��1��6   y�5?      �� *Type+	 �� 	Converter	 ;   5FormsApp.Converters.QuestionTypeToVisibilityConverter  
 �� ConverterParameter$	
 MCQ��.+�5@      �� ��6   �� *	Options+��5A      �� 5B      .R�5C         FormsApp.CheckBox  $��40��5F   -   $	��200��5G   -   $
��Left=�5H   -   $��5q�5I   -      Checked 5C   -   �� *	Checked+   Command 5D   -   ��  �� ElementName$ question_ctrl�� �� Path$ DataContext.OptionChecked�   CommandParameter 5E   -   �� *Number+   Text 5J   -   �� *
OptionText+5K      5M      5N      �� 5P      $��1��6   y�5Q      �� *Type+	   $

 Text��.+�5R      ��   	TextInput#��[ 6   
 � Tag$ Enter Value��5S      $
��Left=�5U      $��18(�5V      $
��10 5q�5W      $
��20 0q�5X      ��5T      �� *Value+5X      5Y      �� 5[      $��1��6   y�5\      �� *Type+	   $
 Dropdown��.+�5]      �� $��2��6   $��40��5^      $
��10 5q�5_      $��18(�5`        MaterialDesignComboBox#���  5a      $��0 0 0 1q�5b       �� 
IsReadOnly$
 True��5c       �� SelectedValue 5d      �� *Value+��5e      �� *DropDownValues+5f      5g      5i      5j      5k      