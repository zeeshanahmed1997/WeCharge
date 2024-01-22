using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeCharge.Controls
{
    public partial class FlyoutHeader : ContentView
    {
        public FlyoutHeader()
        {
            InitializeComponent();
            if (Preferences.ContainsKey("userName"))
            {
                string name = Preferences.Get("userName", null);
                UserName.Text = name;
            }
        }
    }
}
