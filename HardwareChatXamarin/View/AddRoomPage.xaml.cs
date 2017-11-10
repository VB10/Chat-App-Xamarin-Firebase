using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HardwareChatXamarin
{
	public partial class AddRoomPage : ContentPage
	{
		public AddRoomPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var db = new DBFire();
			await db.saveRoom(new Room() { Name = _rootName.Text });
			await Navigation.PopAsync();

		}
	}
}
