using _1DV607_W2_Design.Model;
using _1DV607_W2_Design.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class EditUpdateMenu :ConsoleView
    {
        /// <summary>
        /// Events that user may choose.
        /// </summary>
        public enum Event
        {
            None,
            Back,
            AddBoat,
            Edit,
            DeleteBoat,
            EditBoat,

        }
        /// <summary>
        /// Event handler for edit menu
        /// </summary>
        /// <returns>Event (chosen by user)</returns>
        public Event getEditEvent()
        {
            char pressedKey = Console.ReadKey().KeyChar;

            switch (pressedKey)
            {
                case '1': return Event.Edit;
                case '2': return Event.AddBoat;
                case '3': return Event.EditBoat;
                case '4': return Event.DeleteBoat;
                case 'r': return Event.Back;
                default: return Event.None;
            }

        }
        /// <summary>
        /// Choose index, if valid return index.
        /// </summary>
        /// <returns>int index (inputted by user)</returns>
        public int getIndexFomInput()
        {
            int index;

            while (!int.TryParse(Console.ReadLine(), out index));
            return index;
            
        }
        /// <summary>
        /// Presents actions to user.
        /// Edit Member Info,Add Boat, Edit Boat, Delete Boat, return.
        /// </summary>
        public void PresentInstructions()
        {
            ShowMessage(string.Format("{0}\n\n{1}\n{2}\n{3}\n{4}\n{5}",
                        messages.chooseAction,actions.actionEditMemberInfo, actions.actionAddBoat,
                        actions.actionEditBoat, actions.actionDeleteBoat, messages.returnStr), true);
        }
      
       
        
    }
}
