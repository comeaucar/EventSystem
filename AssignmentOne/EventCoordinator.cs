using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        ReservationManager resMan;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents, int resIdSeed, int maxRes)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            resMan = new ReservationManager(resIdSeed, maxRes);
        }

        //customer related methods
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            return custMan.deleteCustomer(id);
        }

        // Event related methods
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        public bool checkEventSameVenueSameDay(string venue, int day, int month, int year)
        {
            return eventMan.eventSameVenueSameDay(venue, day, month, year);
        }

        //Reservation related methods
        public bool deleteReservation(int custId)
        {
            return resMan.deleteReservation(custId);
        }
        
        public bool removeCustomerFromEvent(int custId)
        {
            return eventMan.removeCustomerFromEvent(custId);
        }

        public string reservationList()
        {
            return resMan.getReservationList();
        }

        public string reserveCustomerToEvent(string currTime, int customerID, int eventID)
        {
            Event currentEvent;
            Customer currCustomer;
            if (custMan.customerExist(customerID) && eventMan.eventExists(eventID))
            {
                currentEvent = eventMan.getEvent(eventID);
                currCustomer = custMan.getCustomer(customerID);

                if (currentEvent.getNumAttendees() == currentEvent.getMaxAttendees())
                {
                    return "Max Attendees Reached! Reservation was unsuccessful";
                }

                if (currentEvent.getNumAttendees() != 0)
                {
                    if (currentEvent.findAttendee(customerID) == -1)
                    {          
                        resMan.addReservation(currTime, currentEvent, currCustomer);
                        return "Reservation Successfully Added.";
                    }
                }
                else
                {      
                    resMan.addReservation(currTime, currentEvent, currCustomer);
                    return "Reservation Successfully Added.";                    
                }
            }
            return "Booking was Unsuccessful.";
        }
    }
}
