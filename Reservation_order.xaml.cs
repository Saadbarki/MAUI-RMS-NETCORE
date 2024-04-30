namespace RestaurantManagementSystem;

public partial class Reservation_order : ContentPage
{
	public Reservation_order(int reservationID, Customer customer)
	{
		InitializeComponent();
        reservationMessage.Text = $"Thank you! You have successfully made a reservation for {customer.Name}.";

    }

    private async void OnBacktoMainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnGoToOrderButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new OrderMain());
    }
}