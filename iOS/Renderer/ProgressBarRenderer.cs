using System;
using System.Drawing;
using MyProgressBar;
using MyProgressBar.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]
namespace MyProgressBar.iOS.Renderer
{
    public class CustomProgressBarRenderer : ViewRenderer<CustomProgressBar, CustomProgressBarRenderer>
    {
        private UIView _background, _range;
        private UIImageView _tintImage;
        public CustomProgressBarRenderer()
        {
            // Add Background Layer 
            _background = new UIView();
             // Add Range Layer 
            _range = new UIView();
          
            // Range Image Indicator 
        //    _tintImage = new UIImageView();
            _tintImage = new UIImageView();
                _tintImage.Image = UIImage.FromBundle("progress");

         
            AddSubview(_background);
            AddSubview(_range);
            AddSubview(_tintImage);
        }

        private bool _layouted;
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            if (!_layouted)
            {

                _background.Frame = new RectangleF(0, 19, (float)Frame.Width, 2);
                _background.Layer.CornerRadius = 2f;
                _range.Frame = new RectangleF(0, 19, 20, 2);
                _tintImage.Frame = new RectangleF(0, 1, 35, 39);
                _layouted = true;

            }
        }

       

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

           
            if (e.PropertyName == "Renderer")
            {

          
              
                // Range Guidelines  Colors
                _background.BackgroundColor = Element.ProgressColor.ToUIColor();

          
                // Range Guidelines  Colors
                _range.BackgroundColor =Element.BackColor.ToUIColor();   //UIColor.FromRGB(0, 153, 255);

            }
            if (e.PropertyName == "ProgressValue")
            {

                if ((float)Element.ProgressValue <= .97)
                {
                    // Set Current Posstion of Image 
                    var progressBarWidth = (float)Frame.Width;
                    float posstionPrgressIndicator = progressBarWidth * (float)Element.ProgressValue;
                    _range.Frame = new RectangleF(0, 19, posstionPrgressIndicator, 2);
                    _tintImage.Frame = new RectangleF(posstionPrgressIndicator, 1, 35, 39);
                }

            }
        }
    }
}
