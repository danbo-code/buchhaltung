using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CustomControls.Structure;

namespace Styling.Structure
{
    public static class Ap
    {
        public static readonly DependencyProperty FontProperty = DependencyProperty.RegisterAttached(
            "Font", typeof(Style), typeof(Ap), new PropertyMetadata(default(Style), FontChanged));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.RegisterAttached(
            "IconMargin", typeof(Thickness), typeof(Ap), new PropertyMetadata(default(Thickness)));

        private static void FontChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Control self) || !(e.NewValue is Style style)) return;

            foreach (var setter in style.Setters.OfType<Setter>())
                self.SetValue(setter.Property, setter.Value);
            // <Setter Property="Background" Value="Red"/>
        }

        public static void SetFont(DependencyObject element, Style value)
        {
            element.SetValue(FontProperty, value);
        }

        public static Style GetFont(DependencyObject element)
        {
            return (Style)element.GetValue(FontProperty);
        }

        public static void SetIconMargin(DependencyObject element, Thickness value)
        {
            element.SetValue(IconMarginProperty, value);
        }

        public static Thickness GetIconMargin(DependencyObject element)
        {
            return (Thickness)element.GetValue(IconMarginProperty);
        }


        // propdp =>Shortcut DependencyProperty, atta => attached property



        #region AP Icon 

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.RegisterAttached("Icon", typeof(FontAwesomeEnum), typeof(Ap),
                new FrameworkPropertyMetadata(FontAwesomeEnum.None));


        public static FontAwesomeEnum GetIcon(UIElement element)
        {
            return (FontAwesomeEnum)element.GetValue(IconProperty);
        }

        public static void SetIcon(UIElement element, FontAwesomeEnum value)
        {
            element.SetValue(IconProperty, value);
        }

        #endregion

        #region AP IconBrush

        public static readonly DependencyProperty IconBrushProperty = DependencyProperty.RegisterAttached(
            "IconBrush", typeof(Brush), typeof(Ap),
            new PropertyMetadata(null));

        public static void SetIconBrush(DependencyObject element, Brush value)
        {
            element.SetValue(IconBrushProperty, value);
        }

        public static Brush GetIconBrush(DependencyObject element)
        {
            return (Brush)element.GetValue(IconBrushProperty);
        }

        #endregion

        #region AP IconStyle

        public static readonly DependencyProperty IconStyleProperty = DependencyProperty.RegisterAttached(
            "IconStyle", typeof(Style), typeof(Ap),
            new FrameworkPropertyMetadata(default(Style), (s, e) => { }));

        public static void SetIconStyle(DependencyObject element, Style value)
        {
            element.SetValue(IconStyleProperty, value);
        }

        public static Style GetIconStyle(DependencyObject element)
        {
            return (Style)element.GetValue(IconStyleProperty);
        }

        #endregion

        public static readonly DependencyProperty WatermarkProperty = DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(Ap), new PropertyMetadata(default(string)));

        public static void SetWatermark(DependencyObject element, string value)
        {
            element.SetValue(WatermarkProperty, value);
        }

        public static string GetWatermark(DependencyObject element)
        {
            return (string)element.GetValue(WatermarkProperty);
        }
    }
}