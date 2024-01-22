using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using WeCharge.CustomControls;
using WeCharge.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntrySecondary), typeof(CustomEntrySecondaryRenderer))]
namespace WeCharge.Droid.Renderers
{
    public class CustomEntrySecondaryRenderer : EntryRenderer
    {
        public CustomEntrySecondaryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.ParseColor("#ffffff"));
                gradientDrawable.SetStroke(1, Android.Graphics.Color.LightGray);
                gradientDrawable.SetCornerRadius(10);
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(10, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
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
    }
}
