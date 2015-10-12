using _1DV607_W2_Design.DAL;
using _1DV607_W2_Design.Model;
using _1DV607_W2_Design.Properties;
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
        /// <summary>
        /// Fields
        /// </summary>
        private MemberDAL _memberDAL;
        private IReadOnlyCollection<Member> _members;
        private MainMenuView _mainMenu;
        private EditUpdateMenu _editUpdateMenu;
        private MemberView _memberView;
        private BoatView _boatView;
        
        /// <summary>
        /// Constructor, creates new instances of necessary objects
        /// save them to fields 
        /// </summary>
        /// <param name="mainMenu"></param>
        /// <param name="editUpdateMenu"></param>
        public MemberController(View.MainMenuView mainMenu, EditUpdateMenu editUpdateMenu)
        {         
            _mainMenu = mainMenu;
            _editUpdateMenu = editUpdateMenu;
            _memberDAL = new MemberDAL(directorieStrs.MemberListPath);
            _members = new List<Member>();
            _boatView = new BoatView();   
            _memberView = new MemberView(_boatView);            
            
        }
        /// <summary>
        /// Loads data from text file, saves readonlycollection
        /// of member info in the field _memberDAL 
        /// </summary>
        public void loadData()
        {
            _members = _memberDAL.LoadMemberData();
        }
        /// <summary>
        /// Gets member details from user input, creates instance of member and saves it.
        /// </summary>
        public void createMember()
        {
            //get first- & lastname,personalno., create & save member...
            string firstName;
            string lastName;
            string personalNumber;
            Member member = null;

            do
            {
                firstName = _mainMenu.getStrInput(messages.firstNameInput);
                lastName = _mainMenu.getStrInput(messages.lastNameInput);
                personalNumber = _mainMenu.getStrInput(messages.pNumberInput);

                try
                {
                    member = new Model.Member(firstName, lastName, personalNumber);
                    saveMember(member);
                    _mainMenu.ShowMessage(messages.memberCreated);
                    _mainMenu.ShowMessage(messages.returnStr);
                    goBack();
                }
                catch (Exception)
                {
                    _mainMenu.ShowMessage(string.Format("{0}{1}",messages.invalidInput, messages.memberNotCreated));
                    continue;
                }
            }
            while (member == null);
        }
        /// <summary>
        /// Handles user inputed action for editing member.
        /// </summary>
        public void editMember()
        {
            _editUpdateMenu.ShowMessage(messages.chooseMember,true);
            Member member = chooseMember();

            _editUpdateMenu.PresentInstructions();

            switch (_editUpdateMenu.getEditEvent())
            {
                case EditUpdateMenu.Event.Edit:
                    editMemberInfo(member);
                    break;
                case EditUpdateMenu.Event.AddBoat:
                    addBoat(member);
                    break;
                case EditUpdateMenu.Event.EditBoat:
                    editBoat(member);
                    break;
                case EditUpdateMenu.Event.DeleteBoat:
                    deleteBoat(member);
                    break;
                case EditUpdateMenu.Event.Back:
                    goBack();
                    break;
                default:
                    break;
            }
            
        }
        /// <summary>
        /// Choose member, delete it, save current state.
        /// </summary>
        public void deleteMember()
        {
            Member member = chooseMember();
            _memberDAL.Delete(member);
            _memberDAL.Save();
            _mainMenu.ShowMessage(messages.membeDeleted);
            _mainMenu.ShowMessage(messages.returnStr);
            goBack();
        }
        /// <summary>
        /// Chooses member and views full member info.
        /// </summary>
        public void viewMember()
        {
            Member member = chooseMember();
            _memberView.viewMemberVerbose(member);
            goBack();
        }
        /// <summary>
        ///  Present compact list of member info (first & lastname, personalno. and no. of boats)
        ///  using view.
        /// </summary>
        public void showCompactList()
        {
            _mainMenu.ShowMessage(messages.compactStr, true);
            _memberView.viewCompactList(_members);
            _mainMenu.ShowMessage(messages.returnStr);
            goBack();
        }
        /// <summary>
        ///  Present verbose list of member info (first & lastname, personalno. boat type, boat length)
        ///  using view.
        /// </summary>     
        public void showVerboseList()
        {   
            _mainMenu.ShowMessage(messages.verboseStr, true);
            _memberView.viewVerboseList(_members);            
            _mainMenu.ShowMessage(messages.returnStr);
            goBack();
        }
        /// <summary>
        /// Present all members, and get member to choose member by index
        /// using view.
        /// </summary>
        /// <returns>Member (by index)</returns>
        private Member chooseMember()
        {
            //Present all members...
            _memberView.chooseMemberList(_members);
            // and get user to choose member.
            Member member = null;
            do
            {
                int index = _editUpdateMenu.getIndexFomInput();
                member = _members.ElementAtOrDefault(index);
            }
            while (member == null);
           
            return member;          
        }
        /// <summary>
        /// Adds member to repository, save current state.
        /// </summary>
        /// <param name="member"></param>
        private void saveMember(Member member)
        {
            _memberDAL.Add(member);
            _memberDAL.Save();
        }
        /// <summary>
        /// Delete member fom repository, save currents state.
        /// </summary>
        /// <param name="member"></param>
        private void editMemberInfo(Member member)
        {
            //Delete the current info about the info
            _memberDAL.Delete(member);
            //create new user info
            createMember();
        }
        /// <summary>
        /// Create boat, get boat info using view, add to member and save it.
        /// </summary>
        /// <param name="member"></param>
        private void addBoat(Member member)
        {
            //Create new boat..
            Boat boat = new Boat();
            double length;
            //Delete the current info about the member
            _memberDAL.Delete(member);
            //Get the type of the boat, set it to new boat.
            Boat.Type boatType = _boatView.chooseBoatType();
            //Get the length of the boat, set it to new boat.
            string lengthInput = _editUpdateMenu.getStrInput(messages.inputLength);
            try
            {
                double.TryParse(lengthInput, out length);
                boat.BoatType = boatType;
                boat.Length = length;
                //add boat to the member.
                member.add(boat);
                //save member
                saveMember(member);
                _editUpdateMenu.ShowMessage(messages.boatCreated);
            }
            catch (Exception)
            {
                _editUpdateMenu.ShowMessage(messages.invalidInput);
            }
        }
        /// <summary>
        /// Deletes boat from member, create new boat info.
        /// </summary>
        /// <param name="member"></param>
        private void editBoat(Member member)
        {
            //Delete the current info about the boat
            deleteBoat(member);
            //add new boat info and save!
            addBoat(member);
        }
        /// <summary>
        /// Presents boats using and get user to choose boat by index
        /// using view.
        /// </summary>
        /// <param name="member"></param>
        /// <returns>Boat (by index)</returns>
        private Boat chooseBoat(Member member)
        {
            //Present all boats...
            _boatView.chooseBoatList(member.Boats);           
            //and get user to choose boat.
            int index = _editUpdateMenu.getIndexFomInput();
            return member.Boats.ElementAt(index);
        }
        /// <summary>
        /// Delete current member info, choose boat by index
        /// using view, remove and save.
        /// </summary>
        /// <param name="member"></param>
        private void deleteBoat(Member member)
        {
            //Delete the current info about the member
            _memberDAL.Delete(member);
            if (member.getNumberOfBoats() > 0)
            {
                //choose the boat to remove..
                Boat boat = chooseBoat(member);
                //remove it and save!
                member.remove(boat);
                saveMember(member);
            }
            _editUpdateMenu.ShowMessage(messages.returnStr);
            goBack();
        }
        /// <summary>
        /// Presents message using view, checks if user wishes to return
        /// </summary>     
        private void goBack()
        {   
            EditUpdateMenu.Event e = _editUpdateMenu.getEditEvent();
            if (e == EditUpdateMenu.Event.Back)
            {
                App a = new App();
                a.startApp();        
            }
        }

    }

}
