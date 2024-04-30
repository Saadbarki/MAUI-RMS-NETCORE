using MySqlConnector;

namespace RestaurantManagementSystem;

public partial class Reservation_confirm : ContentPage
{
    private Customer _customer;
    private DateTime _schedule;
    private int _boothID;

	public Reservation_confirm(Customer customer, DateTime schedule, int boothID, string boothName)
	{
        InitializeComponent();

        customerName.Text = $"Customer: {customer.Name}";
        tentativeDate.Text = $"Date: {schedule.ToString("M/d/yyyy")}";
        tentativeBooth.Text = $"Booth: {boothName}";
        tentativeTime.Text = $"Time: {schedule.Hour}:00 - {schedule.Hour+1}:00";
        
        this._customer = customer;
        this._schedule = schedule;
        this._boothID = boothID;
    }

    private async void OnConfirmReservationButtonClicked(object sender, EventArgs e)
    {
        

        DatabaseAccess dbAccess = new DatabaseAccess();

        int reservationID = dbAccess.confirmReservation(_customer, _schedule, _boothID);
        await Navigation.PushAsync(new Reservation_order(reservationID, _customer));
    }

    private async void OnBacktoReservationInputButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Reservation_input());
    }
    
}