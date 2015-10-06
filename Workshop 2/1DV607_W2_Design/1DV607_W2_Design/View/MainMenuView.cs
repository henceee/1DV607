using _1DV607_W2_Design.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class MainMenuView :ConsoleView
    {
        /// <summary>
        /// Events that user may choose.
        /// </summary>
        public enum Event
        {
            None,
            Quit,
            CreateMember,
            CreateBoat,
            ViewCompact,
            ViewVerbose,
            EditMember,
            ViewMember,
            DeleteMember,

        }

        /// <summary>
        /// Event handler for main menu
        /// </summary>
        /// <returns>Event (chosen by user)</returns>
        public Event getEvent()
        {
            char pressedKey = Console.ReadKey().KeyChar;

            switch(pressedKey)
            {
                case '0': return Event.Quit;
                case '1': return Event.CreateMember;
                case '2': return Event.EditMember;
                case '3': return Event.DeleteMember;
                case '4': return Event.ViewMember;
                case '5': return Event.ViewCompact;
                case '6': return Event.ViewVerbose;
                default: return Event.None;
            }
        }

        /// <summary>
        /// Presents actions to user
        /// Quit,Create Member,Edit Member,Delete Member
        /// View Member, View Compact,View Verbose,
        /// </summary>
        public void PresentInstructions()
        {                                
            ShowMessage(string.Format("{0}\n\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}\n{7}",
                                     messages.chooseAction, actions.actionQuit, actions.actionCreateMember, actions.actionEditMember,
                                     actions.actionDeleteMember,actions.actionViewMember,actions.actionViewCompact, actions.actionViewVerbose), true);
        }

        
      
    }
}
