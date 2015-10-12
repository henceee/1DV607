using _1DV607_W2_Design.Model;
using _1DV607_W2_Design.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class BoatView:ConsoleView
    {
        /// <summary>
        /// Presents a list of boat information (Length, type)
        /// </summary>
        /// <param name="boats"></param>
        public void viewBoats(IEnumerable<Boat> boats)
        {
            foreach (Boat boat in boats)
            {
                ShowMessage(viewBoat(boat));
            }
        }
        /// <summary>
        /// Returns string representation of a certain boat.
        /// </summary>
        /// <param name="boat"></param>
        /// <returns></returns>
        public string viewBoat(Boat boat)
        {
            return String.Format("Boat:\nLength: {0} Feet\nType: {1}\n", boat.Length, boat.BoatType);
        }
        /// <summary>
        /// Choose boat type, if can be parsed to proper type, return type.
        /// </summary>
        /// <returns>Boat.Type boatType</returns>
        internal Boat.Type chooseBoatType()
        {
            ShowMessage(messages.specType, true);
            Boat.Type boatType = Boat.Type.None;

            string input = Console.ReadLine();
            foreach (Boat.Type type in Enum.GetValues(typeof(Boat.Type)))
            {
                if (Enum.GetName(typeof(Boat.Type), type) == input)
                {
                    boatType = type;
                    break;
                }
            }

            return boatType;

        }
        /// <summary>
        /// Presents boats for user to choose from.
        /// </summary>
        /// <param name="boats"></param>
        internal void chooseBoatList(IEnumerable<Boat> boats)
        {
            Console.Clear();
            int boatnumber = -1;
            foreach (Boat boat in boats)
            {
                ShowMessage(string.Format("{0}{1}",boatnumber,viewBoat(boat)));
                
            }
        }
    }
}
