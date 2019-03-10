using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Elevator
    {
        public int currentLevel;
        public int numberOfLevels;
        public bool doorIsOpen;

        public int CurrentLevel
        {
            get
            {
                return currentLevel;
            }
            private set
            {
                currentLevel = value;
            }       
        }

        public int NumberOfLevels
        {
            get
            {
                return numberOfLevels;
            }
        }

        public bool DoorIsOpen
        {
            get
            {
                return doorIsOpen;
            }
            private set
            {
                doorIsOpen = value;
            }
        }

        public Elevator(int numberOfLevels)
        {
            this.numberOfLevels = numberOfLevels;
            currentLevel = 1;
        }

        public void OpenDoor()
        {
            doorIsOpen = true;
        }

        public void CloseDoor()
        {
            doorIsOpen = false;
        }

        public void GoUp(int desiredFloor)
        {
            if(desiredFloor > currentLevel && desiredFloor <= numberOfLevels && doorIsOpen == false)
            {
                currentLevel = desiredFloor;
            }
        }

        public void GoDown(int desiredFloor)
        {
            if (desiredFloor < currentLevel && desiredFloor >= 1 && doorIsOpen == false)
            {
                currentLevel = desiredFloor;
            }
        }
    }

}
