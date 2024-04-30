using MySqlConnector;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantManagementSystem;

public partial class Reservation_input : ContentPage
{
	public Reservation_input()
	{
		InitializeComponent();
        update_picker(); //Call update_picker funciton so it loads on the page load.
        updateTablepicker();
    }


    private async void OnBackToMainButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private async void OnSubmitReservationButtonClicked(object sender, EventArgs e)
    {
        Customer selectedCustomer = (Customer)customerPicker.SelectedItem;
        DateTime selectedDateTime = dateTimeOptions[timePicker.SelectedIndex];
        int selectedBooth = boothIdList[tablePicker.SelectedIndex];
        string selectedBoothName = (string)tablePicker.SelectedItem;

        await Navigation.PushAsync(new Reservation_confirm(selectedCustomer, selectedDateTime, selectedBooth, selectedBoothName));
    }

    //if timeslot is booked, error message will appear


    //**************************** Kyles Code ***************************//


    public void update_picker()         //Update the picker wheel Method
    {
        //DataBase Connection

        DatabaseAccess dbAccess = new DatabaseAccess();  //create object of the MSQL string builder

        //Methods that read/write from DB must be in DB class and called with DB object
        List<Customer> customers = dbAccess.FetchAllCustomers(); // Fetch the list of customers
                                                                 // Set picker item source to list of customers
        customerPicker.ItemsSource = customers;
        //display the string line FullDetails from EACH object in Customer Class/Reservation Class
        customerPicker.ItemDisplayBinding = new Binding("FullDetails");
    }



    ////////***************** USE THIS VARIABLE FOR CUSTOMER ID WHEN ADDING RESO TO DATABASE!!!*********///////////
    private int rselectedCustomerId = -1;
    ////////***************** USE THIS VARIABLE FOR CUSTOMER ID WHEN ADDING RESO TO DATABASE!!!*********///////////
    //When Customer is selected in picker , select 
    private void CustomerPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Check if the picker selection is valid
        if (customerPicker.SelectedIndex != -1)
        {
            //store selected customer Object in variable
            var selectedCustomer = (Customer)customerPicker.SelectedItem;
            // Store the Customer ID in the variable
            //Store object variable Customer_num in selectedCustomerId
            rselectedCustomerId = selectedCustomer.Customer_Num;

        }
    }

    //**************************** Kyles Code END ***************************//

    private List<int> boothIdList;
    public void updateTablepicker()
    {
       
        boothIdList = new List<int>();

        DatabaseAccess dbAccess = new DatabaseAccess();  

        Dictionary<int, string> booths = dbAccess.getAllBooths();

        foreach(KeyValuePair<int, string> entry in booths)
        {
            tablePicker.Items.Add(entry.Value);
            boothIdList.Add(entry.Key);
        }
    }

    private List<DateTime> dateTimeOptions;
    public void updateTimepicker(object sender, EventArgs e)
    {
        if (tablePicker.SelectedIndex == -1)
        {
            return;
        }
        timePicker.Items.Clear();
        dateTimeOptions = new List<DateTime>();
        DateTime chosenSchedule = schedulePicker.Date;
        int chosenTable = boothIdList[tablePicker.SelectedIndex];


        chosenSchedule = chosenSchedule.Add(new System.TimeSpan(0, 8, 0, 0));

        DatabaseAccess dbAccess = new DatabaseAccess();

        List<DateTime> takenTimeSlots = dbAccess.takenTimeSlots(chosenTable, chosenSchedule);


        for (int i = 0; i < 8;  i++)
        {
            if (!takenTimeSlots.Contains(chosenSchedule))
            {
                timePicker.Items.Add($"{8+i}:00 - {9+i}:00");
                dateTimeOptions.Add(chosenSchedule);
            }
            chosenSchedule = chosenSchedule.Add(new System.TimeSpan(0, 1, 0, 0));
        }
       
    }









}