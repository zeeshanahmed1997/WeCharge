using Xamarin.Forms;

namespace WeCharge.CustomControls
{
    public class CustomIconButtons : ContentView
    {
        private readonly Label labelString;
        private readonly Label labelIcon;
        private Frame frame;

        #region Bindable Properties

        //Bindable property for Text label
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        //Bindable property for Frame background color
        public Color FrameBackgroundColor
        {
            get { return (Color)GetValue(FrameBackgroundColorProperty); }
            set { SetValue(FrameBackgroundColorProperty, value); }
        }

        //Bindable property for Icon label
        public string LabelIcon
        {
            get { return (string)GetValue(LabelIconProperty); }
            set { SetValue(LabelIconProperty, value); }
        }

        //Bindable property for Text label color
        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        //Bindable property for frame
        public View FrameContent
        {
            get { return (View)GetValue(FrameContentProperty); }
            set { SetValue(FrameContentProperty, value); }
        }

        #endregion

        // Creating Bindable property for Text label
        #region Creating Bindable Properties
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(
            nameof(LabelText),
            typeof(string),
            typeof(CustomIconButtons),
            null,
            propertyChanged: OnChange);

        // Creating Bindable property for icon label
        public static readonly BindableProperty LabelIconProperty = BindableProperty.Create(
            nameof(LabelIcon),
            typeof(string),
            typeof(CustomIconButtons),
            null,
            propertyChanged: OnIconChange);

        // Creating Bindable property for Text label color
        public static readonly BindableProperty LabelTextColorProperty = BindableProperty.Create(
            nameof(LabelTextColor),
            typeof(Color),
            typeof(CustomIconButtons),
            Color.White,
            propertyChanged: OnLabelTextColorChanged);

        // Creating Bindable property for frame
        public static readonly BindableProperty FrameContentProperty = BindableProperty.Create(
            nameof(FrameContent),
            typeof(View),
            typeof(CustomIconButtons),
            null,
            propertyChanged: OnFrameContentChanged);

        // Creating Bindable property for rame background color
        public static readonly BindableProperty FrameBackgroundColorProperty = BindableProperty.Create(
            nameof(FrameBackgroundColor),
            typeof(Color),
            typeof(CustomIconButtons),
            Color.Black,
            propertyChanged: OnFrameBackgroundColorChanged);

        #endregion

        #region OnChnage methods
        //on change method for icon label
        private static void OnIconChange(BindableObject bindable, object oldValue, object newValue)
        {
            var customIconButtons = (CustomIconButtons)bindable;
            customIconButtons.labelIcon.Text = (string)newValue;
        }

        //on change method for text label
        private static void OnChange(BindableObject bindable, object oldValue, object newValue)
        {
            var customIconButtons = (CustomIconButtons)bindable;
            customIconButtons.labelString.Text = (string)newValue;
        }

        //on change method for text label color
        private static void OnLabelTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var customIconButtons = (CustomIconButtons)bindable;
            customIconButtons.labelString.TextColor = (Color)newValue;
            customIconButtons.labelIcon.TextColor = (Color)newValue;
        }

        //on change method for frame
        private static void OnFrameContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var iconButtons = (CustomIconButtons)bindable;
            var newContent = newValue as View;

            if (iconButtons != null && newContent != null)
            {
                iconButtons.frame = new Frame
                {
                    Content = newContent,
                    CornerRadius = 10,
                    Padding = new Thickness(5),
                    HasShadow = false,
                    WidthRequest = 100,
                };

                // Set the initial background color
                iconButtons.SetFrameBackgroundColor();

                iconButtons.Content = new Grid
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = GridLength.Auto },
                        new ColumnDefinition { Width = GridLength.Auto }
                    },
                    RowDefinitions =
                    {
                        new RowDefinition { Height = GridLength.Auto }
                    },
                    Children =
                    {
                        { iconButtons.frame, 0, 0 },
                        { iconButtons.labelIcon, 1, 0 },
                        { iconButtons.labelString, 1, 0 }
                    }
                };
            }
        }

        //on change method for frame background color
        private static void OnFrameBackgroundColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var iconButtons = (CustomIconButtons)bindable;
            iconButtons.SetFrameBackgroundColor();
        }
        #endregion




        private void SetFrameBackgroundColor()
        {
            if (frame != null)
            {
                frame.BackgroundColor = FrameBackgroundColor;
            }
        }

        public CustomIconButtons()
        {
            labelIcon = new Label();
            labelString = new Label();

            // Creating grid 
            Content = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                Children =
                {
                    { labelIcon, 0, 0 },
                    { labelString, 1, 0 }
                }
            };

            // default text colours of the labels
            labelString.TextColor = Color.White;
            labelIcon.TextColor = Color.White;
        }
    }
}
