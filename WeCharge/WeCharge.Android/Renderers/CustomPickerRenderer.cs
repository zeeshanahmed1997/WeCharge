using Android.Content;
using WeCharge;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeCharge;
using WeCharge.Droid;
using Android.Graphics.Drawables;
using System.ComponentModel;
using WeCharge.CustomControls;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]

namespace WeCharge.Droid
{
    public class CustomPickerRenderer : PickerRenderer
    {
        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null; // Remove the background drawable
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent); // Set transparent background

                // Set the border color
                Android.Graphics.Drawables.GradientDrawable borderDrawable = new Android.Graphics.Drawables.GradientDrawable();
                borderDrawable.SetStroke(1, Android.Graphics.Color.LightGray); // Border width and color
                borderDrawable.SetCornerRadius(10); // Corner radius

                // Apply the drawable to the control's background
                Control.SetBackground(borderDrawable);

                if (!Control.Enabled)
                {
                    // Set the text color to Black even if disabled
                    Control.SetTextColor(Android.Graphics.Color.Black);
                }
                else
                {
                    // Set to default color when enabled
                    Control.SetTextColor(Android.Graphics.Color.Black);
                }
            }


        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomPicker.BorderColorProperty.PropertyName && Control != null && Element is CustomPicker customEntry)
            {
                CustomPicker customEntry1 = (CustomPicker)sender;
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.ParseColor("#f0f1f3")); // Set background color
                gradientDrawable.SetCornerRadius(10); // Set corner radius
                gradientDrawable.SetStroke(1, customEntry1.BorderColor.ToAndroid());
                Control.SetBackground(gradientDrawable);
                //Control.Background.SetColorFilter(customEntry.BorderColor.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcAtop);
            }
        }
    }
}
