using System;
namespace HardwareChatXamarin
{
	public class User
	{
		private static string uid;

		public static string UserName
		{
			get {
				return uid;
			}
			set
			{
				uid = value;
			}
		}


		private User(){}

	}
}
