   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 9!clr-namespace:FormsApp.ConvertersFormsApp.Converters      FormsApp.ResultsPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FormsApp     \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     2conv!clr-namespace:FormsApp.Converters       N� Title$  ResultsPage��.���� 
������� �� Padding$ 20q�._��  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��Hidden=�$
��Auto=�$��1��.���� .+�� $��0 50 0 0q�.+��� .+��� $��Overall Result��$��30(�$��Center=�$��Center=�$��Medium"���  �� Orientation$ 
Horizontal=�$��Center=�$	��Top=�.+��� $��Center=�$��Center=�$��75(�$��10 0 0 0q�$
��Bold"����� *OverallRecommendation.Result+ �� FallbackValue$	 100������ *Color+ �� 	Converter 0   *FormsApp.Converters.StringToColorConverter  �� $
��/100��$��Center=�$��Bottom=�$��18(�$��0 0 0 0q�$��Light"��� $��25(�$��Medium"�
���   �$��Center=����� *	Message+y��� *	Message+ 5   /FormsApp.Converters.StringToVisibilityConverter   �� ConverterParameter$ d���� $��Recommendations��$��20(�$
��Left=�$��Center=�$��DemiBold"�$��10q�y��� *HasAnyRecommendations+ 6   0FormsApp.Converters.BooleanToVisibilityConverter  �� ���� *'%OverallRecommendation.Recommendations+���� .R��� $ 
Horizontal=�.+���    DotIcon#��[    FontAwesome_Solid#��[ $��10(�$��Center=�$��Center=�$��Medium"�$��0 0 10 0q�
��������� $��18(� �� 
LineHeight$ 30�� �� LineStackingStrategy$ BlockLineHeight=�$
��Left=�$��Center=�$��Medium"�
����������� ��   SubmitButton#��[ $��Restart��$��Center=�$��Center=�$
��0 20q�$	��150��$��40������ *ResetCommand+�� $ 
Horizontal=�$
��Left=�$��Bottom=�$��1��$��20q�.+��� $��1��  	CopyRight#��[ #��[ $��15(�$��Center=�
��������� $��1��$��Center=�$��5 0 0 0q�$��Omokanyinsola Alajogun��$��15(�
�������