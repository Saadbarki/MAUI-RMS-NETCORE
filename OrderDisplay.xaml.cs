namespace RestaurantManagementSystem;
//WORKIGN ON
public partial class OrderDisplay : ContentPage
{
    private Item selectedItem1;
    private Item selectedItem2;
    int mq;
    int pq;
    string item_name1;
    string item_name2;

    //Take  out order display
    public OrderDisplay(Item selectedItem1, int mainsquantity, Item selectedItem2, int popsquantity, double totalcost)
    {
        InitializeComponent();

        MainsChosen.Text = $"Mains: {selectedItem1.Name}    Price-{selectedItem1.Price}    Number-{mainsquantity} ";
        PopsChosen.Text = $"Pops: {selectedItem2.Name}    Price-{selectedItem2.Price}    Number-{popsquantity}";
        TotalCost.Text = $"Total Cost: {totalcost}";
        mq = mainsquantity;
        pq = popsquantity;
        item_name1 = selectedItem1.Name;
        item_name2 = selectedItem2.Name;

    }

    //reservation related order display
    public OrderDisplay(Item selectedItem1, int mainsquantity, Item selectedItem2, int popsquantity, double totalcost, Reservation reservation)
    {
        InitializeComponent();
        BookingNumber.Text = $"Booking Number:{reservation.BookingNumber}";
        MainsChosen.Text = $"Mains: {selectedItem1.Name}    Price-{selectedItem1.Price}    Number-{mainsquantity}";
        PopsChosen.Text = $"Pops: {selectedItem2.Name}   Price-{selectedItem2.Price}    Number-{popsquantity}";
        TotalCost.Text = $"Total Cost: {totalcost}";

        this.selectedItem1 = selectedItem1;
        this.selectedItem2 = selectedItem2;
        this.mq = mainsquantity;
        this.pq = popsquantity;

    }
    private async void OnBackToMainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    //saves data to db once clicked.
    private async void OnSendToOrderButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());

        DatabaseAccess access = new DatabaseAccess();
        if (selectedItem1 == null)
            access.SaveMainToBill_Items(mq, item_name1);
        else
            access.SaveMainToBill_Items(mq, selectedItem1.Name);
        if (selectedItem2 == null)
            access.SavePopToBill_Items(pq, item_name2);
        else
            access.SavePopToBill_Items(pq, selectedItem2.Name);
    }

}