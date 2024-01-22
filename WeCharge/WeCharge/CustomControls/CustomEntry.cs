using Xamarin.Forms;

namespace WeCharge.CustomControls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty Corner = BindableProperty.Create("Corner", typeof(int), typeof(CustomEntry), 0);

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomEntry), Color.Default);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
    }
}
