using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    class ReservationManager
    {
        private static int currentResNumber;
        private int maxReservations;
        private int numReservations;
        protected Reservation[] reservationList;
        

        public ReservationManager(int crn, int max)
        {
            currentResNumber = crn;
            maxReservations = max;
            numReservations = 0;
            reservationList = new Reservation[maxReservations];
        }

        public int getNumReservations() { return numReservations; }
        public int getMaxReservations() { return maxReservations; }

        public bool addReservation(string resDate, Event resEvent, Customer resCustomer)
        {
            if(numReservations > maxReservations) { return false; }
            Reservation res = new Reservation(currentResNumber, resDate, resEvent, resCustomer);
            currentResNumber++;
            resEvent.addAttendee(resCustomer);
            resCustomer.incrementBookings();
            reservationList[numReservations] = res;
            numReservations++;
            return true;
        }
        public int findRes(int resId)
        {
            for (int i = 0; i < numReservations; i++)
            {
                if(reservationList[i].getID() == resId)
                {
                    return i;
                }
            }
            return -1;
        }
        public int findResByCustomer(int custId)
        {
            for(int i = 0; i < numReservations; i++)
            {
                if(reservationList[i].getCustomer().getId() == custId)
                {
                    return i;
                }
            }
            return -1;
        }
        public bool resExists(int resId)
        {
            int loc = findRes(resId);
            if(loc == -1) { return false; }
            return true;
        }

        public bool deleteResFromList(int resId)
        {
            int loc = findRes(resId);
            if(loc == -1) { return false; }
            reservationList[loc] = reservationList[numReservations - 1];
            numReservations--;
            return true;
        }

        public bool deleteReservation(int custId)
        {
            for (int i = 0; i < getNumReservations(); i++)
            {
                if (reservationList[i].getCustomer().getId() == custId)
                {
                    deleteResFromList(reservationList[i].getID());
                    return true;
                }
            }
            return false;
        }

        public Reservation[] getAllReservations()
        {
            return reservationList;
        }

        public string getReservationList()
        {
            string data = "All Current Reservations";
            data += "\n-------------------------------";

            if(numReservations == 0)
            {
                data += "\nNo Reservations Made Yet";
                return data;
            }

            for(int i = 0; i < numReservations; i++)
            {
                data += "\n\nReservation " + reservationList[i].getID();
                data += "-----------------------------";
                data += "\nReservation was made at " + reservationList[i].getDate();
                data += "\n" + reservationList[i].getCustomer().getFirstName() + " " + reservationList[i].getCustomer().getLastName() + " is attending Event ID:" + reservationList[i].getEvent().getEventId() + " Name:" + reservationList[i].getEvent().getEventName();
            }

            return data;
        }
    }
}
