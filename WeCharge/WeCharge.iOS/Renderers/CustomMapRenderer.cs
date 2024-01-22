using CoreGraphics;
using Foundation;
using MapKit;
using ObjCRuntime;
using System;
using System.Collections.Generic;
using UIKit;
using WeCharge.CustomControls;
using WeCharge.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace WeCharge.iOS
{
    public class CustomMapRenderer : MapRenderer
    {
        List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {

                var nativeMap = Control as MKMapView;
                if (nativeMap != null)
                {
                    nativeMap.RemoveAnnotations(nativeMap.Annotations);
                    nativeMap.GetViewForAnnotation = null;
                }
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                var nativeMap = Control as MKMapView;
                customPins = formsMap.CustomPins;

                nativeMap.GetViewForAnnotation = GetViewForAnnotation;
            }
        }

        [Export("mapView:viewForAnnotation:")]
        public MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            //pass pointer to GetNSObject and cast it to MKUserLocation then you
            //can know if it is user location or not
            var userAnnotation = Runtime.GetNSObject(annotation.Handle) as MKUserLocation;
            if (userAnnotation != null)
            {
                return null;//when returning null there will be default pin for user
            }
            if (App.CurrentPosition != null && annotation.Coordinate.Latitude == App.CurrentPosition.Latitude && annotation.Coordinate.Longitude == App.CurrentPosition.Longitude)
                return null;
            var annView = new MKAnnotationView//custom annotation logic
            {
                Image = UIImage.FromFile("pin.png"),
                CanShowCallout = false,
                Annotation = annotation,
                CalloutOffset = new CGPoint(0, 0)
            };
            return annView;
        }

        /*protected override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
        {
            MKAnnotationView annotationView = null;
            if (annotation is MKUserLocation)
                return null;
            if (App.CurrentPosition!=null && annotation.Coordinate.Latitude == App.CurrentPosition.Latitude && annotation.Coordinate.Longitude == App.CurrentPosition.Longitude)
                return null;
            //if (annotation is MapKit.MKAnnoyay)
            //    return null;

            var annotationId = "CustomPinAnnotation";
            annotationView = mapView.DequeueReusableAnnotation(annotationId);
            if (annotationView == null)
            {
                annotationView = new MKAnnotationView(annotation, annotationId);
                annotationView.Image = UIImage.FromFile("pin.png");
                annotationView.CalloutOffset = new CGPoint(0, 0);
            }
            annotationView.Annotation = annotation;
            annotationView.CanShowCallout = false;

            return annotationView;
        }*/
    }
}
