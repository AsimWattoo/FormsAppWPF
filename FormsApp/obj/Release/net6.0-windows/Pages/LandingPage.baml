   M S B A M L   `   `   `  ���� L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 9!clr-namespace:FormsApp.ConvertersFormsApp.Converters      FormsApp.LandingPage   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     (localclr-namespace:FormsApp     \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     2conv!clr-namespace:FormsApp.Converters       N� Title$  LandingPage��.��� 
������� � ColumnDefinitions �� $��* ��� $��* �.+��� $��Center=�$��Center=�$	��700��.+�� $��0 0 0 30q�.+��� -    ��Name$ 	imageMask��$	��200��
����������� *Width+ �� RelativeSource ��  �� Mode$
 Self=� �� CornerRadius �� *Height+ �� $
 Self=��� $��/Data/Images/Logo.jpg������ *ActualWidth+ �� ElementName$ 	imageMask������ *Width+ �� $
 Self=� J� OpacityMask !�  !� Visual �� $ 	imageMask���� $��AI Ethics Compass��$
��Left=�$��Center=�$��50(�$
��Bold"��� $>��8AI Ethics Compass: Your Guide to Responsible AI Adoption��$��20(�$��DemiBold"�$
��Wrap=�	 �� TextAlignment$
	 Left=�$
��Left=�$��0 10 0 5q��� $����Welcome to AI Ethics Compass, where responsible AI adoption is made simple. Navigate the complexities of AI implementation with confidence and align your organization with ethical principles.Gain valuable insights, identify risks, and foster transparency and fairness. Start your journey with AI Ethics Compass today. Let's shape a future where AI serves as a force for good.��$
��Wrap=�$
��Left=�$��Center=�$
	 Left=�
 �� 
LineHeight$
 30�� �� LineStackingStrategy$ BlockLineHeight=�$��Light"�$��20(��� $��0 20 0 0q�$��18(�$��Medium"�$2��,To navigate effectively, follow these steps:���� $��18(�$��Light"�$
��Wrap=�$
 30��$ BlockLineHeight=�$����1. Choose your industry from the drop-down menu, this selection will help tailor the assessment to your specific sector ensuring relevant insights���� $��18(�$��Light"�$
��Wrap=�$
 30��$ BlockLineHeight=�$~��x2. Indicate the size of your business to customise the evaluation and recommendations based on your organisation's scale���� $��18(�$��Light"�$
��Wrap=�$
 30��$ BlockLineHeight=�$����3. Select your role from the provided options. this will enable us understand your perspective better and provide targeted guidance����  �� Orientation$ 
Horizontal=�$
��Left=�$��Bottom=�$��10q�.+��� $��1��   	CopyRight#��[    FontAwesome_Solid#��[ $��15(�$��Center=�
��������� $��1��$��Center=�$��5 0 0 0q�$��Omokanyinsola Alajogun��$��15(�
��������� $��1��$��Center=�$��Center=�.+��� ���� *GeneralQuestions+���� .R�   FormsApp.QuestionControl  $	��150��$	��700�� � DataContext �� �� $��Center=�$��0 20 0 5q�$��DemiBold"�
���  ��$��18(����� *Error+ �� FallbackValue$ InvalidValue��y��� *Error+ �� 	Converter ;   5FormsApp.Converters.InvertStringToVisibilityConverter  ��   SubmitButton#��[ $
��Next��$��Right=�$��0 20 0 0q�$��Center=�$	��150��$��40������ *NextCommand+