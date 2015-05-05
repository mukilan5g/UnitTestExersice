using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCR
{
    public class AVTransport 
    {
        Dictionary<string, double> labels = new Dictionary<string, double>();
        public double BOT, EOT;
        private double currentPosition;
        public AVTransport()
        {
            BOT = 00.00;
            EOT = 55.00;
            currentPosition = BOT;
        }

        public void FastForward(double seconds)
        {
            if (currentPosition < EOT)
            {
                currentPosition = currentPosition + seconds;
                if (currentPosition > EOT)
                {
                    currentPosition = currentPosition - seconds;
                    Console.WriteLine("you cant advance to the location that past the end of the file");
                }
            }
        }

        public void Rewind(double seconds)
        {
            if (currentPosition > BOT)
            {
                currentPosition = currentPosition - seconds;
                if (currentPosition < BOT)
                {
                    currentPosition = currentPosition + seconds;
                    Console.WriteLine("you cant   rewind any more");
                }
            }
        }

        public double CurrentTimePosition()
        {
            return currentPosition;
        }

        public void MarkTimePosition(String name)
        {
            labels.Add(name, currentPosition);
        }

        public void GotoMark(String name)
        {
            currentPosition = labels[name];
        }
    }
}
