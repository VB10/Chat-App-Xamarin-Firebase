using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;

namespace HardwareChatXamarin
{
	public class DBFire
	{

		FirebaseClient fbClient;

		public DBFire()
		{
			fbClient = new FirebaseClient("https://hardwareandro-6293a.firebaseio.com/");
		}

		public async Task<List<Room>> getRoomList()
		{
			return (await fbClient
				.Child("ChatApp")
				.OnceAsync<Room>())
				.Select((item) =>
				new Room
				{
					Key = item.Key,
					Name = item.Object.Name
				}

					   ).ToList();

		}

		public async Task saveRoom(Room rm)
		{
			await fbClient.Child("ChatApp")
					.PostAsync(rm);

		}


		public async Task saveMessage(Chat _ch, string _room)
		{
			await fbClient.Child("ChatApp/" + _room + "/Message")
					.PostAsync(_ch);
		}

		public ObservableCollection<Chat> subChat(string _roomKEY)
		{
			
			return fbClient.Child("ChatApp/"+_roomKEY+"/Message")
				           .AsObservable<Chat>()
				           .AsObservableCollection<Chat>();
		}


	}
}
