using System.ComponentModel;
using UIKit;
using WeCharge.CustomControls;
using WeCharge.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace WeCharge.iOS.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = (float)0.5;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.BackgroundColor = UIColor.FromRGBA(240, 241, 243, 255);

                // Add left padding to the text within the entry
                Control.LeftView = new UIView(new CoreGraphics.CGRect(0, 0, 10, Control.Frame.Height));
                Control.LeftViewMode = UITextFieldViewMode.Always;
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
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomEntry.BorderColorProperty.PropertyName && Control != null && Element is CustomEntry customEntry)
            {
                Control.Layer.BorderColor = customEntry.BorderColor.ToCGColor();
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = (float)0.5;
            }
        }
    }
}
