using FormsApp.Animations.FrameworkElementAnimations;
using FormsApp.AttachedProperties;

using System.Collections.Generic;
using System.Windows;

namespace FormsApp.Animations.FrameworkElementAnimations
{
    public class SlideCollapseAndFadeWithLeft : BaseFrameworkElementAnimation<SlideCollapseAndFadeWithLeft>
    {
        private double Height = 0;

        private Thickness elementMargin;

        private Thickness parentMargin;

        //Animates the object
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (FirstLoad)
            {
                Height = element.Height;
                elementMargin = element.Margin;
                parentMargin = (element.Parent as FrameworkElement).Margin;
            }

            if (value)
            {
                element.Margin = elementMargin;
                (element.Parent as FrameworkElement).Margin = parentMargin;

                //await element.Expand(Height, FirstLoad ? 0 : 0.3);
                await element.SlideAndFadeInFromLeft(element.ActualWidth, FirstLoad ? 0 : 0.3);
            }
            else
            {
                await element.SlideAndFadeOutToLeft(element.ActualWidth, FirstLoad ? 0 : 0.3, false);
                //await element.Collapse(Height, FirstLoad ? 0 : 0.3);

                element.Margin = new Thickness(0);
                (element.Parent as FrameworkElement).Margin = new Thickness(0);
            }
        }
    }

    public class CollapseAndExpand : BaseFrameworkElementAnimation<CollapseAndExpand>
    {
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (FirstLoad)
                return;

            double expandedHeight = ExpandedHeight.GetValue(element);
            double collapsedHeight = CollapseHeight.GetValue(element);
            if (!value)
            {
                await element.Expand(collapsedHeight, expandedHeight, FirstLoad ? 0 : 0.2);
            }
            else
            {
                await element.Collapse(expandedHeight, collapsedHeight, FirstLoad ? 0 : 0.2);
            }
        }
    }

    public class FadeInAndOut : BaseFrameworkElementAnimation<FadeInAndOut>
    {
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (value)
                await element.FadeIn(FirstLoad ? 0 : 0.3);
            else
                await element.FadeOut(FirstLoad ? 0 : 0.3);
        }

    }

    /// <summary>
    /// Slides an element in and out from top
    /// </summary>
    public class SlideWithTop : BaseFrameworkElementAnimation<SlideWithTop>
    {
        protected override async void DoAnimationOnUpdate(FrameworkElement element, bool value, bool FirstLoad)
        {
            if (value)
                await element.SlideInFromTop(element.Height, FirstLoad ? 0 : 0.3);
            else
                await element.SlideOutToTop(element.Height, FirstLoad ? 0 : 0.3);

        }
    }
}
