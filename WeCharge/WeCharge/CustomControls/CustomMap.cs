using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WeCharge.CustomControls
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
        public CustomPin SelectedPin { get; set; }
    }
}
