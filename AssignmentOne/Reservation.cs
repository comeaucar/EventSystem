using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    class Reservation
    {
        private int reservationID;
        private string reservationDate;
        private Event reservationEvent;
        private Customer reservationCustomer;

        public Reservation(int resID, string resDate, Event resEvent, Customer resCustomer)
        {
            this.reservationID = resID;
            this.reservationDate = resDate;
            this.reservationEvent = resEvent;
            this.reservationCustomer = resCustomer;
        }

        public int getID() { return reservationID; }
        public string getDate() { return reservationDate; }
        public Event getEvent() { return reservationEvent; }
        public Customer getCustomer() { return reservationCustomer; }

        public override string ToString()
        {
            string data = "Reservation ID: " + reservationID;
            data += "\nReservation Date: " + reservationDate;
            data += "\nReservation Event: " + reservationEvent;
            data += "\nReservation Customer: " + reservationCustomer;

            return data;
        }

    }
}
