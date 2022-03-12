using System;
using System.IO.Ports;
using System.Threading;

namespace ShinyFinder
{
   
    internal class GameController
    {
        private string portName;
        private SerialPort sp;
     

        enum ButtonState : byte
        {
            PRESS = 0,
            RELEASE
        }
        public GameController(string portName)
        {
            this.portName = portName;
            //recognize controller
        }

        public void BeginSerial()
        {
            int baudRate = 115200;
            sp = new SerialPort(portName);
            sp.Parity = Parity.None;
            sp.DataBits = 8;
            sp.StopBits = StopBits.One;
            sp.BaudRate = baudRate;
            sp.DtrEnable = true;
            sp.Open();
            Thread.Sleep(500);
        }
        public void pressButton(ButtonType button)
        {
            if (sp.IsOpen)
            {
                Byte[] data = new byte[2];
                data[0] = (Byte)button;
                data[1] = (Byte)ButtonState.PRESS;

                sp.Write(data, 0, 2);
            }
        }

        public void releaseButton(ButtonType button)
        {
            if (sp.IsOpen)
            {
                Byte[] data = new byte[2];
                data[0] = (Byte)button;
                data[1] = (Byte)ButtonState.RELEASE;

                sp.Write(data, 0, 2);
            }
        }

        public void pressAndRelease(ButtonType button, int delay)
        {
            pressButton(button);
            Thread.Sleep(100);
            releaseButton(button);
            Thread.Sleep(delay);
            //Debug.Print("pressed:" + button);
        }

        public void release()
        {
            if (sp.IsOpen)
            {
                sp.Close();
            }
        }
    }
}
