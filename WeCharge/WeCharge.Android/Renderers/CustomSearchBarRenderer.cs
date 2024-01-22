using WeCharge.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeCharge.Controls;
using WeCharge.Droid.Renderers;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Widget;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]

namespace WeCharge.Droid.Renderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var plateId = Resources.GetIdentifier("android:id/search_plate", null, null);
                var plate = Control.FindViewById(plateId);
                plate.SetBackgroundColor(Android.Graphics.Color.Transparent);
                var icon = Control?.FindViewById(Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null));
                (icon as ImageView)?.SetColorFilter(Color.Black.ToAndroid());
                // Set the corner radius
                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent); // or any color you want
                gradientDrawable.SetCornerRadius(10); // set corner radius

                plate.Background = gradientDrawable;
            }
        }
    }
}
