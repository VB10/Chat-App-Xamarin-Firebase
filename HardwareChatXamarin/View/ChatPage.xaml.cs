using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HardwareChatXamarin
{
	public partial class ChatPage : ContentPage
	{
		DBFire db = new DBFire();
		Room rm = new Room();
		public ChatPage()
		{
			InitializeComponent();

			MessagingCenter.Subscribe<RoomPage, Room>(this, "RoomProp", (page, data) =>
			{
				rm = data;

				_lstChat.BindingContext = db.subChat(data.Key);

				MessagingCenter.Unsubscribe<RoomPage, Room>(this, "RoomProp");

			});
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			// firsth chat object
			//room name 1---okey

			var chatOBJ = new Chat { UserMessage = _etMessage.Text, UserName = User.UserName };
			await  db.saveMessage(chatOBJ, rm.Key);


		}
	}
}
