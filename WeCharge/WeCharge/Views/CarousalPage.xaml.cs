using System;
using System.Collections.Generic;
using WeCharge.ViewModels;
using Xamarin.Forms;

namespace WeCharge.Views
{	
	public partial class CarousalPage : ContentPage
	{
		MakeBookingPageViewModel carouselPageViewModel;
		public CarousalPage ()
		{
			carouselPageViewModel = new MakeBookingPageViewModel();
			InitializeComponent ();
			BindingContext = carouselPageViewModel;
		}
	}
}

