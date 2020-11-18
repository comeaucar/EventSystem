using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Carter Comeau 101253879
// Kazi Safa
// Aliks
namespace AssignmentOne
{
    class Program
    {
        static EventCoordinator eCoord;

        public static void deleteCustomer()
        {
            int id;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to delete:");
            id = getIntChoice();
            if (eCoord.deleteCustomer(id))
            {
                eCoord.removeCustomerFromEvent(id);
                eCoord.deleteReservation(id);
                Console.WriteLine("Customer with id {0} deleted..", id);
            }
            else
            {
                Console.WriteLine("Customer with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewCustomers()
        {
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificCustomer()
        {
            int id;
            string cust;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to View:");
            id = getIntChoice();
            Console.Clear();
            cust = eCoord.getCustomerInfoById(id);
            Console.WriteLine(cust);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void addCustomer()
        {
            string fname, lname, phone;

            Console.Clear();
            Console.WriteLine("-----------Add Customer----------");
            Console.Write("Please enter the customer's first name:");
            fname = Console.ReadLine();
            Console.Write("Please enter the customer's last name:");
            lname = Console.ReadLine();
            Console.Write("Please enter the customer's phone:");
            phone = validatePhone();
            if (eCoord.addCustomer(fname, lname, phone))
            {
                Console.WriteLine("Customer successfully added..");
            }
            else
            {
                Console.WriteLine("Customer was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void addEvent()
        {
            string eventName, venue;
            Date eventDate;
            int maxAttendees;
            int day, month, year, hour, minute;

            Console.Clear();
            Console.WriteLine("-----------Add Event----------");
            Console.Write("Please enter the name of the Event:");
            eventName = Console.ReadLine();
            Console.Write("Please enter venue for the event:");
            venue = Console.ReadLine();
            Console.Write("Please enter the Day of the event:");
            day = getDayChoice();
            Console.Write("Please enter the Month of the event (as an integer):");
            month = getMonthChoice();
            Console.Write("Please enter the Year of the event:");
            year = getYearChoice();
            Console.Write("Please enter the Hour the event starts in 24 hour format:");
            hour = getHourChoice();
            Console.Write("Please enter the Minute the event starts:");
            minute = getMinuteChoice();
            eventDate = new Date(day, month, year, hour, minute);
            DateTime compareDate = new DateTime(year, month, day, hour, minute, 0);
            Console.Write("Please enter the maximum number of attendees:");
            maxAttendees = getIntChoice();

            if(eCoord.checkEventSameVenueSameDay(venue, day, month, year))
            {
                Console.WriteLine("The event was not added..");
                Console.WriteLine("There is already an event at that venue on that day.");
            }

            if (dateIsInPast(compareDate))
            {
                Console.WriteLine("The event was not added..");
                Console.WriteLine("You can not create an event for a past date.");
            }

            else if (eCoord.addEvent(eventName, venue, eventDate, maxAttendees))
            {
                Console.WriteLine("Event successfully added..");
            }
            else
            {
                Console.WriteLine("The event was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewEvents()
        {
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificEvent()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.Write("Please enter an event id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = eCoord.getEventInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void ReservationForEvent()
        {
            int customerID;
            int eventID;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\n");
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("----------------------------");
            Console.Write("Please enter customer ID:");
            customerID = getIntChoice();
            Console.Write("Please enter event ID:");
            eventID = getIntChoice();
            string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            Console.WriteLine(eCoord.reserveCustomerToEvent(date, customerID, eventID));
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void viewReservation()
        {
            Console.Clear();
            Console.WriteLine(eCoord.reservationList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static string customerMenu()
        {
            string s = "Eventie.io\n";
            s += "Customer Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Customer \n";
            s += "2: View Customers \n";
            s += "3: View Customer Details \n";
            s += "4: Delete Customer\n";
            s += "5: Return to the main menu.";
            return s;
        }

        public static string eventMenu()
        {
            string s = "Eventie.io\n";
            s += "Event Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Event \n";
            s += "2: View all Events \n";
            s += "3: View Event Details \n";
            s += "4: Return to the main menu.";
            return s;
        }

        public static string registrationMenu()
        {
            string s = "Eventie.io\n";
            s += "Event Registration Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Reservation for event \n";
            s += "2: View Reservations \n";
            s += "3: Return to the main menu.";
            return s;
        }

        public static string mainMenu()
        {
            string s = "Eventie.io\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Customer Options \n";
            s += "2: Event Options \n";
            s += "3: Reserve for Event \n";
            s += "4: Exit";
            return s;
        }


        public static void runCustomerMenu()
        {
            string menu = customerMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 5)
            {
                if (choice == 1) { addCustomer(); }
                if (choice == 2) { viewCustomers(); }
                if (choice == 3) { viewSpecificCustomer(); }
                if (choice == 4) { deleteCustomer(); }
                choice = getValidChoice(5, menu);
            }
        }

        public static void runEventMenu()
        {
            string menu = eventMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { addEvent(); }
                if (choice == 2) { viewEvents(); }
                if (choice == 3) { viewSpecificEvent(); }

                choice = getValidChoice(4, menu);
            }
        }

        public static void runRegistrationMenu()
        {
            string menu = registrationMenu();
            int choice = getValidChoice(3, menu);
            while (choice != 3)
            {
                if (choice == 1) { ReservationForEvent(); }
                if (choice == 2) { viewReservation(); }

                choice = getValidChoice(3, menu);
            }
        }


        public static int getValidChoice(int max, string menu)
        {
            int choice;
            Console.Clear();
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > max))
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        public static int getIntChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Please enter an integer:");
            }
            return choice;
        }

        public static int getDayChoice()
        {
            int dayChoice = getIntChoice();
            bool validate = true;

            while (validate)
            {
                if (dayChoice < 1|| dayChoice > 32)
                {
                    Console.Write("Please enter a valid day:");
                    getDayChoice();
                }
                validate = false;
            }
            return dayChoice;
        }

        public static int getMonthChoice()
        {
            int monthChoice = getIntChoice();
            bool validate = true;

            while (validate)
            {
                if(monthChoice < 1 || monthChoice > 12)
                {
                    Console.Write("Please enter a valid month:");
                    getMonthChoice();
                }
                validate = false;
            }
            return monthChoice;
        }

        public static int getYearChoice()
        {
            int yearChoice = getIntChoice();
            bool validate = true;
            int currentYear = DateTime.Now.Year;

            while (validate)
            {
                if(yearChoice < currentYear || yearChoice > (currentYear + 50))
                {
                    Console.WriteLine("Please note you can not create an event for a past time or for more than 50 years in the future.");
                    Console.Write("Please enter a valid year:");
                    getYearChoice();
                }
                validate = false;
            }
            return yearChoice;
        }

        public static int getHourChoice()
        {
            int hourChoice = getIntChoice();
            bool validate = true;

            while (validate)
            {
                if(hourChoice < 1 || hourChoice > 24)
                {
                    Console.Write("Please enter a valid hour:");
                    getHourChoice();
                }
                validate = false;
            }
            return hourChoice;
        }

        public static int getMinuteChoice()
        {
            int minuteChoice = getIntChoice();
            bool validate = true;

            while (validate)
            {
                if(minuteChoice < 0 || minuteChoice > 59)
                {
                    Console.Write("Please enter a valid minute:");
                    getMinuteChoice();
                }
                validate = false;
            }

            return minuteChoice;
        }

        public static string validatePhone()
        {
            string choice = Console.ReadLine();
            bool valid = choice.All(char.IsDigit);

            while (!valid)
            {
                Console.Write("Please enter a valid phone number:");
                choice = Console.ReadLine();
                valid = choice.All(char.IsDigit);
            }
            return choice;
        }

        public static bool dateIsInPast(DateTime resDate)
        {
            int check = DateTime.Compare(resDate, DateTime.Now);

            if(check < 0)
            {
                return true;
            }
            return false;
        }
  
        public static void runProgram()
        {
            string menu = mainMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { runCustomerMenu(); }
                if (choice == 2) { runEventMenu(); }
                if (choice == 3) { runRegistrationMenu(); }

                choice = getValidChoice(4, menu);
            }
        }

        static void Main(string[] args)
        {
            eCoord = new EventCoordinator(200, 1000, 100, 5000, 300, 5000);
            runProgram();
            Console.WriteLine("Thank you for using Eventie.io");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
