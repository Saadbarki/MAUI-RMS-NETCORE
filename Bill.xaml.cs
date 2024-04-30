namespace RestaurantManagementSystem;

public partial class Bill : ContentPage
{
	public Bill()
	{
		InitializeComponent();
	}

    private async void OnBackToMainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}