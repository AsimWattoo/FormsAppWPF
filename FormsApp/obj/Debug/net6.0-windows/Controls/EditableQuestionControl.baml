   M S B A M L   `   `   `  ����L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  5      9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  5      &     FormsApp.EditableQuestionControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FormsApp     5      2conv!clr-namespace:FormsApp.Converters     5      -   5          >�Name$  editableQuestionControl��5      $	��130��5	      $	��700��5
      $
��0 10q�5      .��5      ��  �� CornerRadius$ 10��6   $	��0.5q�5      
�������$
}�True��5      
������� �� Padding$
 10 5q�5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $��40��6    �� Orientation$ 
Horizontal=�5      $��Right=�5      .+�5      �� -   5         ��Name$ editBtn��5"         EditIcon#��[  5      $��35��5       $��16(�5!        FontAwesome_Solid#��[ 5$        RoundedButtons#��[ 5%      $	��5 0q�5&      �� 5'      -   5        $ 	deleteBtn��5+        
DeleteIcon#��[ 5'      #��[ 5(      #��[ 5)      $��35��5*      $��16(�5-      $	��5 0q�5.      5/      � 52      $��Center=�6   $��1��53       � Cursor$
 Hand��54       � ColumnDefinitions 56      �� 57      $
��Auto �6'   �� 58      $��* �6'   .+�5;      �� $ 3q�5=      $��30��5>      $��Center=�5?      $	��Top=�5@        
Light_Blue#��[ 5A       5;      �� *ActualHeight+ �� RelativeSource �� 	 �� Mode$
	 Self=���5<      �� *ActualHeight+ �� $
	 Self=�._�5B      �� $��17(�6a   
�������$��Center=�5D   $   $��Center=�5E   $   ��5B   $   �� *Number+
 �� ElementName$
 editableQuestionControl��5E   $   5F      �� 5H      $��1��6   $��6 0 0 0q�5I      $
��Wrap=�5K      $��18(�5L      $��Stretch=�5M      $	��Top=�5N      $��DemiBold"�5O      ��5J      �� *Text+$
 editableQuestionControl��5O      5Q      5S      5U      5V      