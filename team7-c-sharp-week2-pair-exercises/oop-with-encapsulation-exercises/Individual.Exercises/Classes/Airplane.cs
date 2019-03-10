using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Airplane
    {
        public string planeNumber;
        public int bookedFirstClassSeats;
        public int availableFirstClassSeats;
        public int totalFirstClassSeats;
        public int bookedCoachSeats;
        public int availableCoachSeats;
        public int totalCoachSeats;

        public string PlaneNumber
        {
            get
            {
                return planeNumber;
            }
        }

        public int BookedFirstClassSeats
        {
            get
            {
                return bookedFirstClassSeats;
            }
            private set
            {
                bookedFirstClassSeats = value;
            }
        }

        public int AvailableFirstClassSeats
        {
            get
            {
                availableFirstClassSeats = totalFirstClassSeats - bookedFirstClassSeats;
                return availableFirstClassSeats;
            }            
        }

        public int TotalFirstClassSeats
        {
            get
            {
                return totalFirstClassSeats;
            }
        }

        public int BookedCoachSeats
        {
            get
            {
                return bookedCoachSeats;
            }
            private set
            {
                bookedCoachSeats = value;
            }
        }

        public int AvailableCoachSeats
        {
            get
            {
                availableCoachSeats = totalCoachSeats - bookedCoachSeats;
                return availableCoachSeats;
            }            
        }

        public int TotalCoachSeats
        {
            get
            {
                return totalCoachSeats;
            }            
        }

        public Airplane(string planeNumber, int totalFirstClassSeats, int totalCoachSeats)
        {
            this.planeNumber = planeNumber;
            this.totalFirstClassSeats = totalFirstClassSeats;
            this.totalCoachSeats = totalCoachSeats;
        }

        public bool ReserveSeats(bool forFirstClass, int totalNumberOfSeats)
        {
            if(forFirstClass == true)
            {
                if (availableFirstClassSeats >= 0)
                {                 
                    if (bookedFirstClassSeats + totalNumberOfSeats <= totalFirstClassSeats)
                    {
                        bookedFirstClassSeats += totalNumberOfSeats;
                        return true;
                    }
                    return false;
                }
                return false;
            }
            else
            {
                if (availableFirstClassSeats >= 0)
                {
                    
                    if (bookedCoachSeats + totalNumberOfSeats <= totalFirstClassSeats)
                    {
                        bookedCoachSeats += totalNumberOfSeats;
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
            
    }
}
