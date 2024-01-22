using System;
using System.Collections.Generic;
using WeCharge.ViewModels;
using Xamarin.Forms;

namespace WeCharge.Views.Accounts
{	
	public partial class UpdateProfilePage : ContentPage
	{
		UpdateProfileViewModel updateProfileViewModel;
		public UpdateProfilePage ()
		{
            InitializeComponent();
            updateProfileViewModel = new UpdateProfileViewModel();
			
			BindingContext = updateProfileViewModel;
		}
	}
}

