using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem
{
    public class Booking
    {
        private BillClass _bookingBill;
        public BillClass BookingBill
        {
            get => _bookingBill;
            set => _bookingBill = value;
        }
        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }
        private int _numberOfCustomers;
        public int NumberOfCustomers
        {
            get => _numberOfCustomers;
            set => _numberOfCustomers = value;
        }
        private DateTime _schedule;
        public DateTime Schedule
        {
            get => _schedule; 
            set => _schedule = value;
        }
        private string _boothName;
        public string BoothName
        {
            get => _boothName; 
            set => _boothName = value;
        }

        public Booking(Customer paramCustomer, int paramNumberOfCustomers, DateTime paramSchedule, string paramBoothName)
        {
            this.BookingBill = new BillClass();
            Customer = paramCustomer;
            NumberOfCustomers = paramNumberOfCustomers;
            Schedule = paramSchedule;
            BoothName = paramBoothName;
        }

    }
}
