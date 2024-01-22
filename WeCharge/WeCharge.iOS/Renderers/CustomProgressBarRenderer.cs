using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using WeCharge; // Ensure this matches with the namespace of your CustomProgressBar
using WeCharge.CustomControls;
using WeCharge.iOS;
using WeCharge.iOS.Renderers;
using System;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]

namespace WeCharge.iOS.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            try
            {
                base.OnElementChanged(e);

                if (Control != null)
                {
                    Control.ProgressTintColor = Color.Black.ToUIColor();
                    Control.TrackTintColor = Color.LightGray.ToUIColor();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var X = 1.0f;
            var Y = 4.0f;
            CGAffineTransform _transform = CGAffineTransform.MakeScale(X, Y);
            this.Transform = _transform;
            this.ClipsToBounds = true;
            this.Layer.MasksToBounds = true;
            this.Layer.CornerRadius = 8.0f;
        }
    }
}
