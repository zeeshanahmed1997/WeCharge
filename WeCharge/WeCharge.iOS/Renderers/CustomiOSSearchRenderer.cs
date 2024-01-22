using System;
using CoreGraphics;
using Foundation;
using UIKit;
using WeCharge.CustomControls;
using WeCharge.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomiOSSearchRenderer))]
namespace WeCharge.iOS.Renderers
{
    public class CustomiOSSearchRenderer : SearchBarRenderer
    {
        public CustomiOSSearchRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                //Control.BarTintColor = UIColor.FromRGB(240, 240, 240); // Example background color
                //Control.Layer.BorderColor = UIColor.Gray.CGColor; // Example border color
                //Control.Layer.BorderWidth = 1;
                //Remove the background and border
                //var searchbar = (UISearchBar)Control;
                //searchbar.TintColor = UIColor.Orange;
                Control.BackgroundImage = new UIImage();
                Control.BarTintColor = UIColor.Clear;
                Control.BackgroundColor = UIColor.Clear;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;

                Control.ShowsCancelButton = false;
                var placeholderText = Element?.Placeholder ?? "";
                var textField = Control.ValueForKey(new NSString("searchField")) as UITextField;
                if (textField != null)
                {
                    textField.BorderStyle = UITextBorderStyle.None;
                    textField.Layer.BorderWidth = 0;
                    textField.Layer.CornerRadius = 0;
                    textField.LeftView = new UIView(new CGRect(0, 0, 0, 0)); // Adjust the left padding as needed
                    textField.LeftViewMode = UITextFieldViewMode.Always;
                }
            }
        }
    }
}

