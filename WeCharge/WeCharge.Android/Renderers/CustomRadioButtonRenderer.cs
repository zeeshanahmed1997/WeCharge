using System;
using Android.Content;
using Android.Content.Res;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WeCharge.CustomControls.RadioButton), typeof(WeCharge.Droid.Renderers.CustomRadioButtonRenderer))]
namespace WeCharge.Droid.Renderers
{
    public class CustomRadioButtonRenderer : RadioButtonRenderer
    {
        public CustomRadioButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.RadioButton> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ButtonTintList = ColorStateList.ValueOf(Android.Graphics.Color.Black);
            }
        }
    }
}

