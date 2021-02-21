using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CustomControls.Structure;

namespace CustomControls
{
    public class IconPresenter : TextBlock
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(FontAwesomeEnum), typeof(IconPresenter),
                new FrameworkPropertyMetadata(FontAwesomeEnum.None, IconChanged));

        public static readonly DependencyProperty IconBrushProperty =
            DependencyProperty.Register("IconBrush", typeof(Brush), typeof(IconPresenter),
                new FrameworkPropertyMetadata(default(Brush), BrushChanged));

        public static readonly DependencyProperty IconStyleProperty =
            DependencyProperty.Register("IconStyle", typeof(Style), typeof(IconPresenter),
                new PropertyMetadata(default(Style), StyleChanged));

        static IconPresenter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconPresenter),
                new FrameworkPropertyMetadata(typeof(IconPresenter)));
        }


        public Style IconStyle
        {
            get => (Style)GetValue(IconStyleProperty);
            set => SetValue(IconStyleProperty, value);
        }


        public FontAwesomeEnum Icon
        {
            get => (FontAwesomeEnum)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }


        public Brush IconBrush
        {
            get => (Brush)GetValue(IconBrushProperty);
            set => SetValue(IconBrushProperty, value);
        }

        private static void StyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is IconPresenter self) || !(e.NewValue is Style style)) return;

            foreach (var setter in style.Setters.OfType<Setter>())
                self.SetValue(setter.Property, setter.Value);
        }

        private static void IconChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is IconPresenter self)) return;

            self.Text = $"{(char)(FontAwesomeEnum)e.NewValue}";
        }

        private static void BrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is IconPresenter self)) return;

            self.Foreground = e.NewValue as Brush;
        }
    }
}