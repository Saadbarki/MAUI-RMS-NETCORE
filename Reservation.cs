using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem
{
    public class Reservation
    {
        private int _bookingNumber;
        public int BookingNumber
        {
            get => _bookingNumber;
            set => _bookingNumber = value;
        }

        private DateTime _schedule;
        public DateTime Schedule
        {
            get => _schedule;
            set => _schedule = value;
        }

        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set => _customer = value;
        }

        private string _boothName;
        public string BoothName
        {
            get => _boothName;
            set => _boothName = value;
        }
        public Reservation(int parambookingNumber, DateTime paramSchedule, Customer paramCustomer, string paramBoothName)
        {
            BookingNumber = parambookingNumber;
            Schedule = paramSchedule;
            Customer = paramCustomer;
            BoothName = paramBoothName;
        }
        public string FullDetails => $"Booking Number : {_bookingNumber} Reservation Time: {_schedule}, Reservation Name:{_customer}, Reservation Table:{_boothName}";
        public Reservation(){}
    }
}
