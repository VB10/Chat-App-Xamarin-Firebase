using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace HardwareChatXamarin
{
	public partial class RoomPage : ContentPage
	{
		DBFire db = new DBFire();
		protected override async void OnAppearing()
		{
			base.OnAppearing();
			var list = await db.getRoomList();
			_lstx.BindingContext = list;
		}

		public RoomPage()
		{
			InitializeComponent();


			Device.BeginInvokeOnMainThread(() =>
		   {
				
				Navigation.PushPopupAsync(new MyPopups());
			});
		}

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			_lstx.BindingContext = await db.getRoomList();
			_lstx.IsRefreshing = false;
		}

		void Info_Clicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Current User", User.UserName, "Okey");
		}

		void Plus_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new AddRoomPage());
			
		}

		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{


			if (_lstx.SelectedItem!=null)
			{
			var selectRoom = (Room)_lstx.SelectedItem;

				Navigation.PushAsync(new ChatPage());
				//NAVİGATON !!! 
				MessagingCenter.Send<RoomPage, Room>(this, "RoomProp", selectRoom);



				
			}

		}
	}
}
