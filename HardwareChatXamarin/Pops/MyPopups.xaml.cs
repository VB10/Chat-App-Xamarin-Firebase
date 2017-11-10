using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace HardwareChatXamarin
{
	public partial class MyPopups : PopupPage
	{
		public MyPopups()
		{
			InitializeComponent();
		}


		void Handle_Clicked(object sender, System.EventArgs e)
		{
			User.UserName = _username.Text;
			Navigation.PopPopupAsync();
		}
	}
}
