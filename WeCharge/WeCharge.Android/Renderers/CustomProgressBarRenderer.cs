using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using WeCharge; // Make sure this matches with the namespace of your CustomProgressBar
using WeCharge.CustomControls;
using Android.Graphics.Drawables;
using Android.Service.Controls;
using Android;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]
[System.Obsolete]
public class CustomProgressBarRenderer : ProgressBarRenderer
{
    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
    {
        base.OnElementChanged(e);

        if (Control != null)
        {
            var progressBar = Control as Android.Widget.ProgressBar;
            //below is now deprecated
            //var draw = Resources.GetDrawable(Resource.Drawable.bar_color);
            var draw = Context.GetDrawable(WeCharge.Droid.Resource.Drawable.bar_color);


            progressBar.ProgressDrawable = draw;
        }
    }
}
//public class CustomProgressBarRenderer : ProgressBarRenderer
//{
//    public CustomProgressBarRenderer(Context context) : base(context)
//    {
//    }

//    protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
//    {
//        base.OnElementChanged(e);

//        if (Control != null)
//        {
//            Control.ProgressDrawable.SetColorFilter(Xamarin.Forms.Color.Black.ToAndroid(), Android.Graphics.PorterDuff.Mode.SrcIn);
//            Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Xamarin.Forms.Color.Black.ToAndroid());
//            Control.ProgressTintMode = Android.Graphics.PorterDuff.Mode.SrcIn;
//            Control.ProgressBackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Xamarin.Forms.Color.Transparent.ToAndroid());
//            Control.ProgressBackgroundTintMode = Android.Graphics.PorterDuff.Mode.SrcIn;


//            GradientDrawable shape = new GradientDrawable();
//            shape.SetShape(ShapeType.Rectangle);

//            shape.SetColor(Xamarin.Forms.Color.Transparent.ToAndroid());
//            shape.SetGradientRadius(10.0f);
//            Control.Background = shape;


//            Control.ScaleY = 5; // Adjust this value to make it thicker
//        }
//    }
//}


