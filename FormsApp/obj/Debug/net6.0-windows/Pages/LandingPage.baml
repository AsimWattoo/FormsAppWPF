   M S B A M L   `   `   `  ����L  HAI Ethics Compass, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FormsAppFormsApp  5      H DFormsApp.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullvKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core&FormsApp.Core.View_Model.PageViewModel 5      9!clr-namespace:FormsApp.ConvertersFormsApp.Converters  5	          FormsApp.LandingPage   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FormsApp     5      \coreKclr-namespace:FormsApp.Core.View_Model.PageViewModel;assembly=FormsApp.Core     5      2conv!clr-namespace:FormsApp.Converters     5	        N� Title$  LandingPage��5      .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Center=�6   $��Center=�5      $	��700��5      .+�5      � $��0 0 0 30q�6   .+�5      �� -   5         ��Name$ 	imageMask��5      $	��200��5      
���������5      �� *Width+ �� RelativeSource ��  �� Mode$
 Self=� �� CornerRadius 5      �� *Height+ �� $
 Self=��� 5      $��/Data/Images/Logo.jpg��6   ��5       �� *ActualWidth+ �� ElementName$ 	imageMask����5!      �� *Width+ �� $
 Self=� J� OpacityMask 5#      !� 5$       !� Visual 6&   �� $ 	imageMask��5&      5(      �� 5*      $��AI Ethics Compass��6   $
��Left=�5+      $��Center=�5,      $��50(�5-      $
��Bold"�5.      �� 5/      $>��8AI Ethics Compass: Your Guide to Responsible AI Adoption��6   $��20(�50      $��DemiBold"�51      $
��Wrap=�52      	 �� TextAlignment$
	 Left=�53      $
��Left=�54      $��0 10 0 5q�55      �� 57      $����Welcome to AI Ethics Compass, where responsible AI adoption is made simple. Navigate the complexities of AI implementation with confidence and align your organization with ethical principles.Gain valuable insights, identify risks, and foster transparency and fairness. Start your journey with AI Ethics Compass today. Let's shape a future where AI serves as a force for good.��6   $
��Wrap=�58      $
��Left=�59      $��Center=�5:      $
	 Left=�5;      
 �� 
LineHeight$
 30��5<       �� LineStackingStrategy$ BlockLineHeight=�5=      $��Light"�5>      $��20(�5?      �� 5A      $��0 20 0 0q�6   $��18(�5B      $��Medium"�5C      $2��,To navigate effectively, follow these steps:��5D      �� 5F      $��18(�6   $��Light"�5G      $
��Wrap=�5H      $
 30��5I      $ BlockLineHeight=�5J      $����1. Choose your industry from the drop-down menu, this selection will help tailor the assessment to your specific sector ensuring relevant insights��5K      �� 5M      $��18(�6   $��Light"�5N      $
��Wrap=�5O      $
 30��5P      $ BlockLineHeight=�5Q      $~��x2. Indicate the size of your business to customise the evaluation and recommendations based on your organisation's scale��5R      �� 5T      $��18(�6   $��Light"�5U      $
��Wrap=�5V      $
 30��5W      $ BlockLineHeight=�5X      $����3. Select your role from the provided options. this will enable us understand your perspective better and provide targeted guidance��5Y      5[      �� 5]   
    �� Orientation$ 
Horizontal=�6   $
��Left=�5^      $��Bottom=�5_      $��10q�5`      .+�5a      �� $��1��6      	CopyRight#��[  5b        FontAwesome_Solid#��[ 5c      $��15(�5d      $��Center=�5e      
�������5f      �� 5h      $��1��6   $��Center=�5i      $��5 0 0 0q�5j      $��Omokanyinsola Alajogun��5k      $��15(�5l      
�������5m      5n      �� 5p   
   $��1��6   $��Center=�5q      $��Center=�5r      .+�5s      �� ��6   �� *GeneralQuestions+��5t      �� 5u      .R�5v         FormsApp.QuestionControl  $	��150��5w   0   $	��700��5x   0    � DataContext 5v   0   �� 5x   0   5y      5{      �� 5}      $��Center=�5~      $��0 20 0 5q�5      $��DemiBold"�5�      
���  ��$��18(�5�      ��5}      �� *Error+ �� FallbackValue$ InvalidValue��y�5�      �� *Error+ �� 	Converter ;   5FormsApp.Converters.InvertStringToVisibilityConverter  5�      �� 5�        SubmitButton#��[ 6   $
��Next��5�      $��Right=�5�      $��0 20 0 0q�5�      $��Center=�5�      $	��150��5�      $��40��5�      ��5�      �� *NextCommand+5�      5�      5�      5�      