using System;
using System.Collections.Generic;
using System.Text;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;

namespace Capstone
{
    public class NationalParkReservationCLI
    {
        const string DatabaseConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=NationalParkReservation;Integrated Security=True;";

        public void RunNationalParks()
        {
            PrintParkMenu();

        }

        int parkId = 0;
        int campgroundId = 0;
        int siteId = 0;
        DateTime requestedStart = DateTime.Parse("2001-01-01 00:00:00");
        DateTime requestedEnd = DateTime.Parse("2001-01-01 00:00:00");
        int menuChoice1 = 0;
        int newReservationId = 0;


        private void PrintParkMenu()
        {
            ParksDAL ParkyParkDAL = new ParksDAL(DatabaseConnectionString);

            List<Park> parks = ParkyParkDAL.ListParkNames();

            Console.WriteLine("View Parks Interface");
            Console.WriteLine("Select a Park for Further Details");

            foreach (Park park in parks)
            {
                Console.WriteLine($"{park.ParkId}. { park.Name}");

            }
            Console.WriteLine("0) quit");
            parkId = int.Parse(Console.ReadLine());

            if (parkId > 0)
            {
                DisplayParkInfo(parkId);
            }
            else
            {
                return;
            }




            void DisplayParkInfo(int parkId)
            {

                Park parkInfo = ParkyParkDAL.FullParkInfo(parkId);

                Console.WriteLine("Park Information Screen");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine(parkInfo.Name);
                Console.WriteLine($"Location: {parkInfo.Location}");
                Console.WriteLine($"Established: {parkInfo.EstablishDate}");
                Console.WriteLine($"Area: {parkInfo.Area} sq km");
                Console.WriteLine($"Annual Visitors: {parkInfo.Visitors}");
                Console.WriteLine("");

                Console.WriteLine($"{parkInfo.Description}");
                Console.WriteLine("");
                Console.WriteLine("");

                Menu1();
            }

            void Menu1()
            {
                Console.WriteLine("Select a Command");
                Console.WriteLine("1) View Campgrounds");
                Console.WriteLine("2) Search for Reservation");
                Console.WriteLine("3) Return to Previous Screen");

                menuChoice1 = int.Parse(Console.ReadLine());
                switch (menuChoice1)
                {
                    case 1:
                        DisplayCampgrounds(parkId);
                        Menu1();
                        return;
                    case 2:
                        CampgroundMenu(parkId);
                        return;
                    case 3:
                        return;
                }
            }

            void DisplayCampgrounds(int parkId)
            {

                int parkPosition = 1;
                Console.WriteLine("Park Campgrounds");
                Console.WriteLine();
                Console.WriteLine($" Name                         Open      Close    Daily Fee");

                CampgroundsDAL campgrounddal = new CampgroundsDAL(DatabaseConnectionString);
                List<Campground> campgroundList = campgrounddal.CampgroundInfo(parkId);


                foreach (Campground campground in campgroundList)
                {
                    Console.WriteLine($"{parkPosition} {campground}");
                    parkPosition++;
                }


            }

            void CampgroundMenu(int parkId)
            {
                DisplayCampgrounds(parkId);

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Select an option");
                Console.WriteLine("1) Search for Available Reservation");
                Console.WriteLine("2) Return to Previous Screen");

                int reservationSelection = int.Parse(Console.ReadLine());

                switch (reservationSelection)
                {
                    case 1:
                        SelectCampgroundDates();
                        break;
                    case 2:
                        return;
                }
            }

            void SelectCampgroundDates()
            {
                DisplayCampgrounds(parkId);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                Console.WriteLine("Which campground (enter 9 to cancel)?");
                campgroundId = int.Parse(Console.ReadLine());
                if(campgroundId == 9)
                {
                    return;
                }
                else
                {

                    Console.WriteLine("What is the arrival date? __/__/__");
                    requestedStart = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("What is the departure date? __/__/__");
                    requestedEnd = DateTime.Parse(Console.ReadLine());

                    ReservationMenu(campgroundId, requestedStart, requestedEnd);
                }
            }

            void ReservationMenu(int campgroundId, DateTime requestedStart, DateTime requestedEnd)
            {
                CampsiteDAL campsiteDal = new CampsiteDAL(DatabaseConnectionString);
                CampgroundsDAL campgroundsDAL = new CampgroundsDAL(DatabaseConnectionString);
                ReservationDAL reservationDAL = new ReservationDAL(DatabaseConnectionString);

                List<Campsite> campsiteList = campsiteDal.AvailableCampsites(campgroundId, requestedStart, requestedEnd);

                Console.WriteLine("Results Matching Your Search Criteria");
                Console.WriteLine("Campground Site No. | Max Occup. | Accessible? | RV Len | Utilities | Cost");


                foreach (Campsite site in campsiteList)
                {
                    decimal dailyFee = campgroundsDAL.GetDailyFeeFromOneCampground(campgroundId);
                    decimal totalCost = site.GetCost(requestedStart, requestedEnd, dailyFee, site.HasUtilities);                   
                    Console.WriteLine($"{site} {totalCost}");
                }

                Console.WriteLine("");
                Console.WriteLine("");

                while (true)
                {
                    Console.WriteLine("Which site should be reserved? (enter 0 to cancel)");
                    int siteChoice = int.Parse(Console.ReadLine());

                    if (siteChoice == 0)
                    {
                        PrintParkMenu();
                    }
                    siteId = campsiteDal.GetCampsiteId(campgroundId, siteChoice);

                    if (SiteIsValid(campsiteList, siteId))
                    {
                        Console.WriteLine("What last name should the reservation be made under? Press 0 to cancel");
                        string reservationName = $"{Console.ReadLine()} Reservation";
                        if (reservationName == "0")
                        {
                            PrintParkMenu();
                        }
                        else
                        {
                            newReservationId = reservationDAL.ReserveCampsite(siteId, reservationName, requestedStart, requestedEnd, DateTime.Today);
                            Console.WriteLine($"The Reservation has been made. Your confirmation ID is {newReservationId}.");
                            Console.WriteLine();
                            Console.WriteLine("Enter 1 to return to the main menu, or 0 to quit.");
                            menuChoice1 = int.Parse(Console.ReadLine());
                            if(menuChoice1 == 1)
                            {
                                Console.WriteLine();
                                PrintParkMenu();
                            }
                            else
                            {
                                return;
                            }


                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid site number. Enter one of the provided site numbers.");
                        Console.WriteLine();
                    }
                }

                //We need to take in this info, check for conflicts in the reservation table, and do a new reservation insert.
                //Console.WriteLine($"The Reservation has been made. Your confirmation ID is {}.);
            }

            bool SiteIsValid(List<Campsite> campsites, int siteChoice)
            {
                foreach (Campsite campsite in campsites)
                {
                    if (siteChoice == campsite.SiteId)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
