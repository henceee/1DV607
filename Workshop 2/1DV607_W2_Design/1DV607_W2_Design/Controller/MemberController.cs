using _1DV607_W2_Design.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.Controller
{
    class MemberController
    {
        private View.ConsoleView _view;
        private Model.Member _member =null;

        public MemberController(View.ConsoleView view)
        {
            _view = view;
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool startApp()
        {
            _view.PresentInstructions();
            
            ConsoleView.Event e = _view.getEvent();
            if (e == ConsoleView.Event.Quit)
            {
                return false;
            }
            if (e == ConsoleView.Event.CreateMember)
            {
                CreateMember();
            }
            if (e == ConsoleView.Event.CreateBoat)
            {
                
            }

            return true;
        }

        private void CreateMember()
        {
            string name = _view.getStrInput("Please Enter Name.");
            string personalNumber = _view.getStrInput("Please Enter Personal Number. [YYYYMMDD-XXXX]");
            _member = new Model.Member(name, personalNumber);

            //TODO: IMPLEMENT MORE FUNCTIONALITY
        }
    }

}
