using MySqlConnector;

namespace RestaurantManagementSystem;
//Working on
public partial class OrderNow : ContentPage
{

    public OrderNow()
    {
       
        InitializeComponent();
        DatabaseAccess access = new DatabaseAccess();
        List<Item> mains = access.FetchMainsItems();
        MenuMainsPicker.ItemsSource = mains;
        MenuMainsPicker.ItemDisplayBinding = new Binding("FullDetails");

        List<Item> drinks = access.FetchPopsItems();
        MenuPopsPicker.ItemsSource = drinks;
        MenuPopsPicker.ItemDisplayBinding = new Binding("FullDetails");


        //reservation information picker
        List<Reservation> reservations = access.FetchReservationItems();
        ReservationSearchPicker.ItemsSource = reservations;
        ReservationSearchPicker.ItemDisplayBinding = new Binding("FullDetails");


    }

    //back to the main page
    private async void OnBackToMainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    //click button event, collect data from ordernow to orderdisplay
    private async void OnConfirmOrderButtonClicked(object sender, EventArgs e)
    {
        Item selectedItem1 = (Item)MenuMainsPicker.SelectedItem;
        Item selectedItem2 = (Item)MenuPopsPicker.SelectedItem;
        double totalcost = Convert.ToDouble(totalPrice.Text);
        int mainsquantity = Convert.ToInt32(MainsItemsNumber.Text);
        int popsquantity = Convert.ToInt32(PopsItemsNumber.Text);

        Reservation reservation = (Reservation)ReservationSearchPicker.SelectedItem;

        await Navigation.PushAsync(new OrderDisplay(selectedItem1, mainsquantity, selectedItem2, popsquantity, totalcost, reservation));
    }

    double total_Price = 0;
    double MainsperItemPrice = 0;
    double PopsperItemPrice = 0;
    int MainsItems = 0;
    int PopsItems = 0;
    //items add function
    private void OnAddMainsItemsClicked(object sender, EventArgs e)
    {

        MainsItems++;


        if (MainsItems < 0)
        {
            MainsItems = 1;
            MainsItemsNumber.Text = $"{MainsItems}";
        }
        else
        {

            MainsItemsNumber.Text = $"{MainsItems}";
        }
        UpdateTotalPrice();

    }

    //items minus button
    private void OnMinusMainsItemsClicked(object sender, EventArgs e)
    {

        MainsItems--;

        if (MainsItems < 0)
        {
            MainsItems = 0;
        }
        else
        {

            MainsItemsNumber.Text = $"{MainsItems}";
        }

        UpdateTotalPrice();
    }


    //add pops function
    private void OnAddPopsItemsClicked(object sender, EventArgs e)
    {

        PopsItems++;

        if (PopsItems < 0)
        {
            PopsItems = 1;
            PopsItemsNumber.Text = $"{PopsItems}";
        }
        else
        {

            PopsItemsNumber.Text = $"{PopsItems}";
        }
        UpdateTotalPrice();

    }



    // minus pops button
    private void OnMinusPopsItemsClicked(object sender, EventArgs e)
    {

        PopsItems--;
        if (PopsItems < 0)
        {
            PopsItems = 0;
        }
        else
        {

            PopsItemsNumber.Text = $"{PopsItems}";
        }

        UpdateTotalPrice();
    }

    //make selected item display on the picker
    public void MenuMainsPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedItem = (Item)picker.SelectedItem;
        if (selectedItem != null)
        {
            MainsperItemPrice = selectedItem.Price;

        }
        UpdateTotalPrice();
    }

    public void MenuPopsPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedItem = (Item)picker.SelectedItem;
        if (selectedItem != null)
        {
            PopsperItemPrice = selectedItem.Price;

        }
        UpdateTotalPrice();
    }



    //reservation combined
    public int booking_number;
    public void ReservationResearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedReservation = (Reservation)picker.SelectedItem;
        if (selectedReservation != null)
        {
            booking_number = selectedReservation.BookingNumber;

        }
    }



    public void UpdateTotalPrice()
    {
        total_Price = MainsperItemPrice * MainsItems + PopsperItemPrice * PopsItems;
        totalPrice.Text = total_Price.ToString("F2");
    }


}