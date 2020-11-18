using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentOne
{
    class EventManager
    {
        private static int currentEventId;
        private int maxEvents;
        private int numEvents;
        private Event[] eventList;

        public EventManager(int idSeed, int max)
        {
            currentEventId = idSeed;
            maxEvents = max;
            numEvents = 0;
            eventList = new Event[maxEvents];
        }

        public int getNumEvents() { return numEvents; }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendees)
        {
            if (numEvents >= maxEvents) { return false; }
            if(maxAttendees == 0)
            {
                Console.WriteLine("Can not have event with 0 attendees");
                return false;
            }
            Event e = new Event(currentEventId, name, venue, eventDate, maxAttendees);
            eventList[numEvents] = e;
            numEvents++;
            currentEventId++;
            return true;
        }

        private int findEvent(int eid)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getEventId() == eid)
                    return x;
            }
            return -1;
        }

        public bool eventExists(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            return true;
        }

        public Event getEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return null; }
            return eventList[loc];
        }

        public bool eventSameVenueSameDay(string venue, int day, int month, int year)
        {
            for (int i = 0; i < getNumEvents(); i++)
            {
                if (eventList[i].getVenue().ToLower() == venue.ToLower() && eventList[i].getEventDate().getYear() == year && eventList[i].getEventDate().getMonth() == month & eventList[i].getEventDate().getDay() == day)
                {
                    return true;
                }
            }

            return false;
        }

        public bool removeCustomerFromEvent(int custId)
        {

            for (int i = 0; i < getNumEvents(); i++)
            {
                if (eventList[i].findAttendee(custId) != -1)
                {
                    eventList[i].removeAttendee(custId);
                    return true;
                }
            }
            return false;
        }

        public bool deleteEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            eventList[loc] = eventList[numEvents - 1];
            numEvents--;
            return true;
        }
        public string getEventInfo(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return "There is no event with id " + eid + "."; }
            return eventList[loc].ToString();
        }

        public string getEventList()
        {
            string s = "Event List:";
            
            if(getNumEvents() == 0)
            {
                s += "\nThere are no events to display";
                return s;
            }

            for (int x = 0; x < numEvents; x++)
            {
                s = s + "\n" + eventList[x].getEventId() + " \t " + eventList[x].getEventName() + " \t " + eventList[x].getVenue();
            }
            return s;
        }

    }
}
