using WeCharge.CustomControls;
using Xamarin.Forms;

namespace WeCharge
{
    public class CustomPicker : Picker
    {
        // You can add any additional properties or methods here
        public static readonly BindableProperty Corner = BindableProperty.Create("Corner", typeof(int), typeof(CustomPicker), 0);

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(CustomPicker), Color.Default);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
    }
}
