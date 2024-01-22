using System;
using System.ComponentModel;
using CoreGraphics;
using UIKit;
using WeCharge;
using WeCharge.CustomControls;
using WeCharge.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]

namespace WeCharge.iOS
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderStyle = UITextBorderStyle.None; // Remove default border
                Control.Layer.BorderColor = UIColor.LightGray.CGColor; // Set border color
                Control.Layer.BorderWidth = (float)0.5; // Set border width
                Control.Layer.CornerRadius = 5; // Set corner radius

                // Add padding to the left of the text
                Control.LeftView = new UIView(new CGRect(0, 0, 10, Control.Bounds.Height)); // 10 is the padding width
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

            if (e.PropertyName == CustomPicker.BorderColorProperty.PropertyName && Control != null && Element is CustomPicker customEntry)
            {
                Control.Layer.BorderColor = customEntry.BorderColor.ToCGColor();
                Control.Layer.CornerRadius = 10;
                Control.Layer.BorderWidth = (float)0.5;
            }
        }
    }
}
