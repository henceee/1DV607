using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class EventHandler
    {
        /// <summary>
        /// Event handler for main menu
        /// </summary>
        /// <returns>Event (chosen by user)</returns>
        public Event GetEvent()
        {
            int input = GetInput();

            if (input == 'p')
            {
                return Event.newgame;
            }
            else if (input == 'h')
            {
                return Event.hit;
            }
            else if (input == 's')
            {
                return Event.stand;
            }
            else if (input == 'q')
            {
                return Event.quit;
            }

            return Event.none;
        }

        public int GetInput()
        {
            return Console.In.Read();
        }
    }

}
