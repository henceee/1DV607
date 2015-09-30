using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class ConsoleView
    {
        public enum Event
        {
            None,
            Quit,
            CreateMember,
            CreateBoat,


        }

        /// <summary>
        /// 
        /// </summary>
        public void PresentInstructions()
        {
            System.Console.Clear();
            System.Console.WriteLine("\tWelcome! \nUse the numberkeys to choose action: \n0: Quit\n1:View Member Details \n");
           

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Event getEvent()
        {
            char pressedKey = Console.ReadKey().KeyChar;

            switch(pressedKey)
            {
                case '0': return Event.Quit;
                case '1': return Event.CreateMember;
                default: return Event.None;
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string getStrInput(string message)
        {
            System.Console.Clear();
            Console.WriteLine(message);
                       
            return Console.ReadLine();
        }
    }
}
