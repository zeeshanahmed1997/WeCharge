using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using WeCharge.CustomControls;
using WeCharge.iOS.Renderers;
using Foundation;

[assembly: ExportRenderer(typeof(CustomEntrySecondary), typeof(CustomEntrySecondaryRenderer))]
namespace WeCharge.iOS.Renderers
{
    public class CustomEntrySecondaryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Set the background color to white
                Control.BackgroundColor = UIColor.White;

                // Set the border width
                Control.Layer.BorderWidth = (float)0.5;
                Control.Layer.BorderColor = UIColor.Clear.CGColor;  // Change UIColor.Clear to the desired border color if needed.

                // Set the corner radius
                Control.Layer.CornerRadius = 10;  // Change this value to your desired corner radius
                Control.Layer.MasksToBounds = true;

                // Set the placeholder text color to white
                var placeholderAttributes = new NSAttributedString(
                    Control.Placeholder ?? "",
                    new UIStringAttributes { ForegroundColor = UIColor.White }
                );
                Control.AttributedPlaceholder = placeholderAttributes;
                if (!Control.Enabled)
                {
                    // Set the text color to black even if disabled
                    Control.TextColor = UIColor.Black;
                }
                else
                {
                    // Set to default color when enabled
                    Control.TextColor = UIColor.LabelColor;
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomEntrySecondary.BackgroundColorProperty.PropertyName)
            {
                SetBackgroundColor();
            }
        }

        private void SetBackgroundColor()
        {
            if (Element is CustomEntrySecondary customEntry && Control != null)
            {
                Control.BackgroundColor = customEntry.BackgroundColor.ToUIColor();
            }
        }
    }
}
