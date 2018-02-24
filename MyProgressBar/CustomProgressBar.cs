using System;
using Xamarin.Forms;

namespace MyProgressBar
{
    public class CustomProgressBar : View
    {

        public CustomProgressBar()
        {
            
        }
        public static readonly BindableProperty ProgressValueProperty =
            BindableProperty.Create<CustomProgressBar, double>
           (p => p.ProgressValue, double.NaN, BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
            {
                 var control = (CustomProgressBar)bindable;
               control.ProgressValue = newValue;

             });

        public double ProgressValue
        {
            get { return (double)GetValue(ProgressValueProperty); }
            set { SetValue(ProgressValueProperty, value); }
        }


        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create<CustomProgressBar, ImageSource>(
                p => p.Source, null);

        public ImageSource Source
        {
            get
            {
                return (ImageSource)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }

        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create("ProgressColor", typeof(Color), typeof(CustomProgressBar), Color.Red, BindingMode.TwoWay, null, null);
        public Color ProgressColor
        {
            get { return (Color)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }

        public static readonly BindableProperty BackColorProperty =
            BindableProperty.Create("BackColor", typeof(Color), typeof(CustomProgressBar), Color.Blue, BindingMode.TwoWay, null, null);
        public Color BackColor
        {
            get { return (Color)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }



        public event EventHandler ValueChanged;
        public void NotifyValueChanged()
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, new EventArgs());
            }
        }

    }
}
