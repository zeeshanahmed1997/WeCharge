using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace WeCharge.CustomControls
{
    public partial class IconButton : ContentView
    {
        #region Label Text Color
        public static readonly BindableProperty LabelTextColorProperty = BindableProperty.Create(
            nameof(LabelTextColor),
            typeof(Color),
            typeof(IconButton),
            Color.Transparent,
            propertyChanged: OnLabelColorChange);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        private static void OnLabelColorChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).TextLabel.TextColor = (Color)newValue;
        }

        public static readonly BindableProperty IconTextColorProperty = BindableProperty.Create(
    nameof(IconTextColor),
    typeof(Color),
    typeof(IconButton),
    Color.Transparent,
    propertyChanged: OnIconColorChange);

        public Color IconTextColor
        {
            get { return (Color)GetValue(IconTextColorProperty); }
            set { SetValue(IconTextColorProperty, value); }
        }

        private static void OnIconColorChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).IconLabel.TextColor = (Color)newValue;
        }
        public static readonly BindableProperty FrameBorderColorProperty = BindableProperty.Create(
    nameof(FrameBorderColor),
    typeof(Color),
    typeof(IconButton),
    Color.Transparent,
    propertyChanged: OnFrameBorderColorChange);

        public Color FrameBorderColor
        {
            get { return (Color)GetValue(FrameBorderColorProperty); }
            set { SetValue(FrameBorderColorProperty, value); }
        }

        private static void OnFrameBorderColorChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).frame.BorderColor = (Color)newValue;
        }

        public static readonly BindableProperty LabelIconColorProperty = BindableProperty.Create(
            nameof(LabelIconColor),
            typeof(Color),
            typeof(IconButton),
            Color.Transparent,
            propertyChanged: OnLabelIconColorChange);

        public Color LabelIconColor
        {
            get { return (Color)GetValue(LabelIconColorProperty); }
            set { SetValue(LabelIconColorProperty, value); }
        }

        private static void OnLabelIconColorChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).IconLabel.TextColor = (Color)newValue;
        }

        public static readonly BindableProperty FrameBackgroundColorProperty = BindableProperty.Create(
            nameof(FrameBackgroundColor),
            typeof(Color),
            typeof(IconButton),
            Color.Transparent,
            propertyChanged: OnFrameBackgroundColorChange);

        public Color FrameBackgroundColor
        {
            get { return (Color)GetValue(FrameBackgroundColorProperty); }
            set { SetValue(FrameBackgroundColorProperty, value); }
        }

        private static void OnFrameBackgroundColorChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).frame.BackgroundColor = (Color)newValue;
        }
        #endregion

        #region LabelIcon Style
        public static readonly BindableProperty LabelIconStyleProperty = BindableProperty.Create(
            nameof(LabelIconStyle),
            typeof(Style),
            typeof(IconButton),
            default(Style),
            propertyChanged: OnLabelIconStyleChange);

        public Style LabelIconStyle
        {
            get { return (Style)GetValue(LabelIconStyleProperty); }
            set { SetValue(LabelIconStyleProperty, value); }
        }

        private static void OnLabelIconStyleChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).IconLabel.Style = (Style)newValue;
        }
        #endregion


        #region Frame Width
        public static readonly BindableProperty FrameWidthProperty = BindableProperty.Create(
            nameof(FrameWidth),
            typeof(double),
            typeof(IconButton),
            40.0,
            propertyChanged: OnFrameWidthChange);

        public double FrameWidth
        {
            get { return (double)GetValue(FrameWidthProperty); }
            set { SetValue(FrameWidthProperty, value); }
        }

        private static void OnFrameWidthChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).frame.WidthRequest = (double)newValue;
        }
        #endregion

        #region Underline Label Text
        public static readonly BindableProperty UnderlineLabelTextProperty = BindableProperty.Create(
            nameof(UnderlineLabelText),
            typeof(bool),
            typeof(IconButton),
            false,
            propertyChanged: OnUnderlineLabelTextChange);

        public bool UnderlineLabelText
        {
            get { return (bool)GetValue(UnderlineLabelTextProperty); }
            set { SetValue(UnderlineLabelTextProperty, value); }
        }

        private static void OnUnderlineLabelTextChange(BindableObject bindable, object oldValue, object newValue)
        {
            var iconButton = (IconButton)bindable;
            bool underline = (bool)newValue;

            if (underline)
            {
                iconButton.TextLabel.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                iconButton.TextLabel.TextDecorations = TextDecorations.None;
            }
        }
        #endregion
        #region Frame Height
        public static readonly BindableProperty FrameHeightProperty = BindableProperty.Create(
            nameof(FrameHeight),
            typeof(double),
            typeof(IconButton),
            0.0,
            propertyChanged: OnFrameHeightChange);

        public double FrameHeight
        {
            get { return (double)GetValue(FrameHeightProperty); }
            set { SetValue(FrameHeightProperty, value); }
        }

        private static void OnFrameHeightChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).frame.HeightRequest = (double)newValue;
        }
        #endregion


        #region Title Text
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
            nameof(TitleText),
            typeof(string),
            typeof(IconButton),
            null,
            propertyChanged: OnTitleTextChange);

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        private static void OnTitleTextChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).TextLabel.Text = (string)newValue;
        }


        public static readonly BindableProperty IconTextProperty = BindableProperty.Create(
            nameof(IconText),
            typeof(string),
            typeof(IconButton),
            null,
            propertyChanged: OnIconTextChange);

        public string IconText
        {
            get { return (string)GetValue(IconTextProperty); }
            set { SetValue(IconTextProperty, value); }
        }

        private static void OnIconTextChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).IconLabel.Text = (string)newValue;
        }


        #endregion

        #region Corner Radius
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
            nameof(CornerRadius),
            typeof(double),
            typeof(IconButton),
            5.0,
            propertyChanged: OnCornerRadiusChange);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        private static void OnCornerRadiusChange(BindableObject bindable, object oldValue, object newValue)
        {
            ((IconButton)bindable).frame.CornerRadius = (float)(double)newValue;
        }
        #endregion

        public static readonly BindableProperty CommandProperty =
        BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), null,
            BindingMode.TwoWay, propertyChanged: OnCommandChanged);
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (IconButton)bindable;

            // this gesture recognizer will inovke the command event whereever it is used
            control.frame.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = (Command)newValue
            });
        }
        #region Font Size
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(IconButton),
            Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            propertyChanged: OnFontSizeChange);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        private static void OnFontSizeChange(BindableObject bindable, object oldValue, object newValue)
        {
            var iconButton = (IconButton)bindable;
            iconButton.IconLabel.FontSize = (double)newValue;
            iconButton.TextLabel.FontSize = (double)newValue;
        }
        #endregion

        public delegate void IconButtonClickedHandler(object sender, EventArgs e);
        public event IconButtonClickedHandler OnIconButtonClicked;
        public IconButton()
        {
            InitializeComponent();
        }

        void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {
            if (OnIconButtonClicked != null)
                OnIconButtonClicked(this, new EventArgs());
        }
    }
}
