using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeCharge;
using WeCharge.Droid;
using Android.Content.Res;
using System;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]

namespace WeCharge.Droid
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // Remove the background drawable and bottom line
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.Black.ToAndroid());

                Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.Element.DateSelected += OnDateSelected;
                // Remove the dropdown arrow
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(0, 0, 0, 0);
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
        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            Control.Text = e.NewDate.ToString("dd/MM/yyyy");
        }
    }
}
