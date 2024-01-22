using System;
using System.ComponentModel;
using CoreGraphics;
using UIKit;
using WeCharge;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using WeCharge;
using WeCharge.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]

namespace WeCharge.iOS
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null && e.NewElement is CustomDatePicker customDatePicker)
            {
                // Remove the default border and background
                Control.BorderStyle = UITextBorderStyle.None;
                Control.Background = null;

                // Set border color and width
                //Control.Layer.BorderWidth = (float)0.5;
                //Control.Layer.BorderColor = UIColor.Black.CGColor;

                // Set corner radius
                Control.Layer.CornerRadius = 5;

                // Clear button
                Control.ClearButtonMode = UITextFieldViewMode.WhileEditing;

                // Add padding to the left of the text
                Control.LeftView = new UIView(new CGRect(0, 0, 10, Control.Bounds.Height)); // 10 is the padding width
                Control.LeftViewMode = UITextFieldViewMode.Always;

                // Handle changes to DatePicker properties here if needed
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
                UIDatePicker datePicker = (UIDatePicker)Control.InputView;
                datePicker.Mode = UIDatePickerMode.Date;

                // Event handler to format the date
                datePicker.ValueChanged += (sender, ev) =>
                {
                    DateTime newDate = DateTime.SpecifyKind(((UIDatePicker)sender).Date.ToDateTime(), DateTimeKind.Unspecified);
                    Control.Text = newDate.ToString("dd/MM/yyyy");
                };

                // Initial format setting
                DateTime initialDate = DateTime.SpecifyKind(datePicker.Date.ToDateTime(), DateTimeKind.Unspecified);
                Control.Text = initialDate.ToString("dd/MM/yyyy");
            }
        }
    }
}
