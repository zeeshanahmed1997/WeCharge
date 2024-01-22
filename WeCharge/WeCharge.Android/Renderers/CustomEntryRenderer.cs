using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using WeCharge.CustomControls;
using WeCharge.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace WeCharge.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {

                // Create a new gradient drawable for the background
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.ParseColor("#f0f1f3")); // Set background color
                gradientDrawable.SetStroke(1, Android.Graphics.Color.LightGray); // Set border color and width
                gradientDrawable.SetCornerRadius(10); // Set corner radius

                // Apply the gradient drawable as the background
                Control.SetBackground(gradientDrawable);

                // Apply padding to the control
                Control.SetPadding(10, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

                // Add left padding to the text within the entry
                Control.SetPaddingRelative(20, Control.PaddingTop, Control.PaddingEnd, Control.PaddingBottom);
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

            if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName && Control != null && Element is CustomEntry customEntry)
            {
                CustomEntry customEntry1 = (CustomEntry)sender;
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
