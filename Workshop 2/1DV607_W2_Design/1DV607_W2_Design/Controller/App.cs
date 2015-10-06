using _1DV607_W2_Design.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.Controller
{
    class App
    {
        
        View.MainMenuView _mainMenu;
        View.EditUpdateMenu _eView;
        MemberController _memberController;

        public App()
        {            
            _mainMenu = new View.MainMenuView();
            _eView = new View.EditUpdateMenu();
            _memberController = new MemberController(_mainMenu,_eView);
        }

       /// <summary>
       /// Initializes app, handles user inputted
       /// choice of event to be executed
       /// </summary>
       /// <returns></returns>
        public bool startApp()
        {
            _mainMenu.PresentInstructions();
            _memberController.loadData();
            MainMenuView.Event e = _mainMenu.getEvent();

            //Quit,C.Member,E.Member,Del.Member,V.Member, V.Compact,V.Verbose,
            switch (e)
            {
                case MainMenuView.Event.Quit:
                    return false;
                case MainMenuView.Event.CreateMember:
                    _memberController.createMember();
                    break;
                case MainMenuView.Event.EditMember:
                    _memberController.editMember();
                    break;
                case MainMenuView.Event.DeleteMember:
                    _memberController.deleteMember();
                    break;
                case MainMenuView.Event.ViewMember:
                    _memberController.viewMember();
                    break;
                case MainMenuView.Event.ViewCompact:
                    _memberController.showCompactList();
                    break;
                case MainMenuView.Event.ViewVerbose:
                    _memberController.showVerboseList();
                    break;

            }

            return true;
        }
    }
}
