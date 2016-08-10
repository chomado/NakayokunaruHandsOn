using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

// Xamarin.FormsコントロールとRendererの対応を宣言
[assembly: ExportRenderer(typeof(NakayokunaruHandsOn.RoundedBoxView), typeof(NakayokunaruHandsOn.iOS.RoundedBoxViewRenderer))]

namespace NakayokunaruHandsOn.iOS
{
    public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView, UIView>
    {
        // private UITapGestureRecognizer tapGesuture;

        protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
        {
            if (Control == null)
            {
                var nativeControl = new UIView();
                // tapGesuture = new UITapGestureRecognizer(() => Element?.SendClick());
                // nativeControl.AddGestureRecognizer(tapGesuture);
                SetNativeControl(nativeControl);
            }

            if (e.NewElement != null)
            {
                UpdateRadius();
                UpdateColor();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName)
            {
                UpdateRadius();
            }
            if (e.PropertyName == RoundedBoxView.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
        }

        private void UpdateRadius()
        {
            Control.Layer.CornerRadius = (float)Element.CornerRadius;
        }

        private void UpdateColor()
        {
            Control.BackgroundColor = Element.Color.ToUIColor();
        }

        // protected override void Dispose(bool disposing)
        // {
        //  if (Control != null)
        //      Control.RemoveGestureRecognizer(tapGesuture);

        //  base.Dispose(disposing);
        // }
    }
}