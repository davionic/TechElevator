using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Individual.Exercises.Classes
{
    public class Television
    {
        public bool isOn;
        public int currentChannel;
        public int currentVolume;
        
        public bool IsOn
        {
            get
            {
                return isOn;
            }
            private set
            {
                isOn = value;
            }
        }
        public int CurrentChannel
        {
            get
            {
                return currentChannel;
            }
            private set
            {
                currentChannel = value;
            }
        }
        public int CurrentVolume
        {
            get
            {
                return currentVolume;
            }
            private set
            {
                currentVolume = value;
            }           
        }
        public void TurnOff()
        {
            isOn = false;
        }
        public void TurnOn()
        {
            isOn = true;
            currentChannel = 3;
            currentVolume = 2;
        }
        public void ChangeChannel(int newChannel)
        {
            if (isOn == true && newChannel > 2 && newChannel < 19)
            {
                currentChannel = newChannel;
            }
            else
            {
                currentChannel = 3;
            }
        }
        public void ChannelUp()
        {
            if (isOn == true && currentChannel >= 3 && currentChannel < 18)
            {
                currentChannel = currentChannel + 1;
            }
            else
            {
                currentChannel = 3;
            }
        }
        public void ChannelDown()
        {
            if (isOn == true && currentChannel > 2 && currentChannel < 19)
            {
                currentChannel = currentChannel - 1;
                if(currentChannel < 3)
                {
                    currentChannel = 18;
                }
            }
            else
            {
                currentChannel = 3;
            }
        }
        public void RaiseVolume()
        {
            if (isOn == true && currentVolume < 10)
            {
                currentVolume = currentVolume + 1;
            }
            else
            {
                currentVolume = 2;
            }
        }
        public void LowerVolume()
        {
            if (isOn == true && currentVolume > 0)
            {
                currentVolume = currentVolume - 1;
            }

        }
        public Television()
        {
            currentChannel = 3;
            currentVolume = 2;
        }
        
    }
}
