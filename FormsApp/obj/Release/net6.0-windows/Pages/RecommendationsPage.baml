   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel "    FormsApp.RecommendationsPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FormsApp     \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     MmaterialDesign2https://materialdesigninxaml.net/winfx/xaml/themes       N� Title$  RecommendationsPage��.���� -    ��Name$ 
mainBorder�� �� Padding$ 10q�
�������._��� $��Hidden=�$
��Auto=�.���� .+��� $��Center=�$��25(�$��0 0 0 20q�$��DemiBold"�Recommendations�� ���� *Recommendations+���� .R��  � ColumnDefinitions �� $
��Auto ��� $��3* ��� $��* ��� $��* ��� $��* ��� $
��Auto �.+��� $��Center=�$��Center=�$��17(�$��Medium"����#ababab$��0 0 5 0q����� *Label+��    	TextInput#��[  $��1��$
��10 5q�
 � Tag$ Enter recommendation��$
��Left=�$	��Top=�$��20(� �� TextAlignment$
 Left=�$
��0 15q����� *Recommendation+�� $��2��$��40��$
��10 5q�$��18(�  MaterialDesignComboBox#���  $��0 0 0 1q� �� 
IsReadOnly$
 True�� �� SelectedValue �� *
QuestionId+����  �� ElementName$ 
mainBorder��	 �� Path$!	 DataContext.QuestionOptions��� #��[  $��3��$ Enter min %��$
��10 5q�$
��Left=�$	��Top=�$��20(�$
 Left=�$
��0 15q����� *
MinValue+�� #��[  $��4��$
��10 5q�$ Enter max %��$
��Left=�$	��Top=�$��20(�$
 Left=�$
��0 15q����� *
MaxValue+�� $��5��  RoundedButtons#��[   
DeleteIcon#��[   FontAwesome_Solid#��[ $��16(�$
��10 5q�$��Center=�$��Center=����� $ 
mainBorder��$-	 'DataContext.RemoveRecommendationCommand����� *Number+��   SubmitButton#��[ $��Add Recommendation��$��Center=�$��Center=�$	��200��$��40������ *AddRecommendationCommand+�� 
 �� Orientation$
 
Horizontal=�$��Center=�$
��0 20q�.+���   ConfirmButton#��[ $
��Save��$
��10 0q�$��Center=�$��Center=�$	��150��$��40������ *SaveCommand+��   CancelButton#��[ $��Discard��$��Center=�$��Center=�$	��150��$
��10 0q�$��40������ *DiscardCommand+