   M S B A M L   `   `   `  ����L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  5      H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 5      9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  5	      "    FormsApp.QuestionAddEditForm   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FormsApp     5      \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     5      2conv!clr-namespace:FormsApp.Converters     5	        N� Title$  QuestionAddEditForm��5      .��5      ��  �� Padding$ 20q�6   
�������._�5   
   �� $��Disabled=�6   $
��Auto=�5      .��5      �� .+�5      �� -   5         ��Name$ backBtn��5         RoundedButtons#��[  5      $
��Left=�5      $��15(�5      $��30��5        ChevronLeft#��[ 5        FontAwesome_Solid#��[ 5      ��5      �� *CancelCommand+5      � 5       � ColumnDefinitions 5       �� 5!      $��4* �6+   �� 5"      $��* �6+   .+�5%      ��   	TextInput#��[ 6   $��0��5'      
 � Tag$ Enter the question��5(      $
��Left=�5)      $	��Top=�5*      $��20(�5+       �� TextAlignment$
 Left=�5,      $
��0 15q�5-      ��5&      �� *QuestionText+5-      �� 5/      #��[ 6   $��1��51      $ Enter the weight %��52      $
��Left=�53      $	��Top=�54      $��20(�55      $
 Left=�56      $
��0 15q�57      ��50      �� *Weight+57      59      �� 5;      .+�5=      �� ��6#   �� *	Options+��5>      �� 5?      .R�5@   "   �  5A   &   �� 5B   *   $
��Auto �6;   �� 5C   *   $��3* �6;   �� 5D   *   $��* �6;   �� 5E   *   $
��Auto �6;   .+�5H   &   �� $��Center=�6,   $��Center=�5I   ,   $��17(�5J   ,   $��Medium"�5K   ,   ���#ababab$��0 0 5 0q�5M   ,   ��5N   ,   �� *Label+�� 5P   &   #��[ 6.   $��1��5Q   .   $
��Left=�5T   .   $	��Top=�5U   .   $��20(�5V   .   $
 Left=�5W   .   $
��0 15q�5X   .   ��5R   .   �� *Text+ �� Mode$ TwoWay=� 5S   .   �� *Tag+5X   .   �� 5Z   &   #��[ 6.   $��2��5[   .   $ Enter weightage��5]   .   $
��Left=�5^   .   $	��Top=�5_   .   $��20(�5`   .   $
 Left=�5a   .   $
��0 15q�5b   .   ��5\   .   �� *Weight+5b   .   �� 5d   &   $ optionRemoveBtn��5h   -   -   5        $��3��5d   -   #��[  5e   -     
DeleteIcon#��[ 5f   -   #��[ 5g   -   $��16(�5k   -   $
��10 5q�5l   -   $��Center=�5m   -   $��Center=�5n   -   ��5j   -   �� *Number+5n   -   5p   #   5q      5s      �� 5u        SubmitButton#��[ 6   $��
Add Option��5v      $��Center=�5x      $��Center=�5y      $	��150��5z      $��40��5{      ��5w      �� *AddOptionCommand+5{      �� 5}      $��Center=�5~       $��0 20 0 5q�5       $��DemiBold"�5�       
���  ��$��18(�5�       ��5}       �� *Error+ �� FallbackValue$ InvalidValue��y�5�       �� *Error+ �� 	Converter ;   5FormsApp.Converters.InvertStringToVisibilityConverter  5�       �� 5�      	 �� Orientation$	 
Horizontal=�6!   $��Center=�5�   !   $
��0 20q�5�   !   .+�5�      ��   ConfirmButton#��[ 6!   $
��Save��5�   !   $
��10 0q�5�   !   $��Center=�5�   !   $��Center=�5�   !   $	��150��5�   !   $��40��5�   !   ��5�   !   �� *SaveCommand+5�   !   �� 5�        CancelButton#��[ 6!   $��Cancel��5�   !   $��Center=�5�   !   $��Center=�5�   !   $	��150��5�   !   $
��10 0q�5�   !   $��40��5�   !   ��5�   !   �� *CancelCommand+5�   !   5�      5�      5�      5�      5�      5�      