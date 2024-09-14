namespace MyLoginApp.UserControl;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if (App.userInfo is not null)
		{
            labelUserName.Text = "Logged in as: " + App.userInfo.username;
			labelUserEmail.Text = App.userInfo.email;
		}
	}
}