   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  "    FormsApp.QuestionAddEditForm   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FormsApp     \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     2conv!clr-namespace:FormsApp.Converters       N� Title$  QuestionAddEditForm��.����  �� Padding$ 20q�
�������._��� $��Disabled=�$
��Auto=�.���� .+��� -    ��Name$ backBtn��   RoundedButtons#��[  $
��Left=�$��15(�$��30��  ChevronLeft#��[   FontAwesome_Solid#��[ ���� *CancelCommand+�  � ColumnDefinitions �� $��4* ��� $��* �.+���   	TextInput#��[ $��0��
 � Tag$ Enter the question��$
��Left=�$	��Top=�$��20(� �� TextAlignment$
 Left=�$
��0 15q����� *QuestionText+�� #��[ $��1��$ Enter the weight %��$
��Left=�$	��Top=�$��20(�$
 Left=�$
��0 15q����� *Weight+�� .+��� ���� *	Options+���� .R��  �� $
��Auto ��� $��3* ��� $��* ��� $
��Auto �.+��� $��Center=�$��Center=�$��17(�$��Medium"����#ababab$��0 0 5 0q����� *Label+�� #��[ $��1��$
��Left=�$	��Top=�$��20(�$
 Left=�$
��0 15q����� *Text+ �� Mode$ TwoWay=� �� *Tag+�� #��[ $��2��$ Enter weightage��$
��Left=�$	��Top=�$��20(�$
 Left=�$
��0 15q����� *Weight+�� $ optionRemoveBtn��-   $��3��#��[    
DeleteIcon#��[ #��[ $��16(�$
��10 5q�$��Center=�$��Center=����� *Number+��   SubmitButton#��[ $��
Add Option��$��Center=�$��Center=�$	��150��$��40������ *AddOptionCommand+�� $��Center=�$��0 20 0 5q�$��DemiBold"�
���  ��$��18(����� *Error+ �� FallbackValue$ InvalidValue��y��� *Error+ �� 	Converter ;   5FormsApp.Converters.InvertStringToVisibilityConverter  �� 	 �� Orientation$	 
Horizontal=�$��Center=�$
��0 20q�.+���   ConfirmButton#��[ $
��Save��$
��10 0q�$��Center=�$��Center=�$	��150��$��40������ *SaveCommand+��   CancelButton#��[ $��Cancel��$��Center=�$��Center=�$	��150��$
��10 0q�$��40������ *CancelCommand+