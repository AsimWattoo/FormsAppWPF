   M S B A M L   `   `   `  ����L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  5      H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 5      "    FormsApp.RecommendationsPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FormsApp     5      \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     5      MmaterialDesign2https://materialdesigninxaml.net/winfx/xaml/themes     5        N� Title$  RecommendationsPage��5      .��5      �� -   5         ��Name$ 
mainBorder��5       �� Padding$ 10q�5      
�������._�5   
   �� $��Hidden=�6   $
��Auto=�5      .��5      �� .+�5      �� $��Center=�6   $��25(�5      $��0 0 0 20q�5      $��DemiBold"�5      Recommendations5      �� 5      ��6   �� *Recommendations+��5      �� 5       .R�5!      �  � ColumnDefinitions 5"   "   �� 5#   &   $
��Auto �67   �� 5$   &   $��3* �67   �� 5%   &   $��* �67   �� 5&   &   $��* �67   �� 5'   &   $��* �67   �� 5(   &   $
��Auto �67   .+�5+   "   �� $��Center=�6(   $��Center=�5,   (   $��17(�5-   (   $��Medium"�5.   (   ���#ababab$��0 0 5 0q�51   (   ��50   (   �� *Label+51   (   �� 53   "      	TextInput#��[  6*   $��1��54   *   $
��10 5q�55   *   
 � Tag$ Enter recommendation��57   *   $
��Left=�58   *   $	��Top=�59   *   $��20(�5:   *    �� TextAlignment$
 Left=�5;   *   $
��0 15q�5<   *   ��56   *   �� *Recommendation+5<   *   �� 5>   "   $��2��6+   $��40��5?   +   $
��10 5q�5@   +   $��18(�5A   +     MaterialDesignComboBox#���  5B   +   $��0 0 0 1q�5C   +    �� 
IsReadOnly$
 True��5D   +    �� SelectedValue 5E   +   �� *
QuestionId+��5F   +   ��  �� ElementName$ 
mainBorder��	 �� Path$!	 DataContext.QuestionOptions�5G   #   �� 5I   "   #��[  6*   $��3��5J   *   $ Enter min %��5L   *   $
��10 5q�5M   *   $
��Left=�5N   *   $	��Top=�5O   *   $��20(�5P   *   $
 Left=�5Q   *   $
��0 15q�5R   *   ��5K   *   �� *
MinValue+5R   *   �� 5T   "   #��[  6*   $��4��5U   *   $
��10 5q�5W   *   $ Enter max %��5X   *   $
��Left=�5Y   *   $	��Top=�5Z   *   $��20(�5[   *   $
 Left=�5\   *   $
��0 15q�5]   *   ��5V   *   �� *
MaxValue+5]   *   �� 5_   "   $��5��6)     RoundedButtons#��[ 5`   )     
DeleteIcon#��[ 5a   )     FontAwesome_Solid#��[ 5b   )   $��16(�5e   )   $
��10 5q�5f   )   $��Center=�5g   )   $��Center=�5h   )   ��5c   )   �� $ 
mainBorder��$-	 'DataContext.RemoveRecommendationCommand���5d   )   �� *Number+5h   )   5j      5k      5m      �� 5o        SubmitButton#��[ 6   $��Add Recommendation��5q      $��Center=�5r      $��Center=�5s      $	��200��5t      $��40��5u      ��5p      �� *AddRecommendationCommand+5u      �� 5w      
 �� Orientation$
 
Horizontal=�6   $��Center=�5x   !   $
��0 20q�5y   !   .+�5z      ��   ConfirmButton#��[ 6   $
��Save��5{      $
��10 0q�5|      $��Center=�5~      $��Center=�5      $	��150��5�      $��40��5�      ��5}      �� *SaveCommand+5�      �� 5�        CancelButton#��[ 6   $��Discard��5�      $��Center=�5�      $��Center=�5�      $	��150��5�      $
��10 0q�5�      $��40��5�      ��5�      �� *DiscardCommand+5�      5�      5�      5�      5�      5�      