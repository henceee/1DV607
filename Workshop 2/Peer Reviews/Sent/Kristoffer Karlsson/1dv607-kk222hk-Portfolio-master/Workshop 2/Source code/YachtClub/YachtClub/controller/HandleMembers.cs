using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    /**
     * Deals with member related use cases
     */
    class HandleMembers
    {
        private model.MemberList m_list;
        private view.BaseView m_baseView;
        private view.MemberListView m_listView;
        private view.MemberView m_memberView;
        private view.BoatView m_boatView;
        private controller.HandleBoats m_boatController;

        public HandleMembers()
        {
            m_list = new model.MemberList();
            m_baseView = new view.BaseView();
            m_boatView = new view.BoatView();
            m_listView = new view.MemberListView(m_list.Members);
            m_boatController = new controller.HandleBoats(m_baseView, m_boatView);
        }

        /**
         * Checks start menu option and delegates control to specialized functions 
         */
        public void DoControlOperation()
        {
            m_baseView.InitializeConsole();
            view.StartMenuChoice option = m_baseView.GetStartMenuChoice();

            switch (option)
            {
                case view.StartMenuChoice.ListUsersCompact:
                    DoListMembers(true);
                    DoControlOperation();
                    break;
                case view.StartMenuChoice.ListUsersVerbose:
                    DoListMembers(false);
                    DoControlOperation();
                    break;
                case view.StartMenuChoice.AddMember:
                    DoAddMember();
                    DoControlOperation();
                    break;
                case view.StartMenuChoice.ExitApplication:
                    m_baseView.PrintMessage("Thank you for using the yacht club system 1.0.");
                    return;
            }
        }

        /**
         * Checks user menu option and delegates control to specialized functions 
         */
        private void DoHandleMember(model.Member member)
        {
            m_memberView = new view.MemberView(member);
            m_memberView.ShowMember();
            view.MemberOperation whatDo = m_memberView.GetWhatToDoWithUser();

            switch (whatDo)
            {
                case view.MemberOperation.Edit:
                    DoEditMember(member);
                    break;
                case view.MemberOperation.Delete:
                    DoDeleteMember(member);
                    break;
                case view.MemberOperation.RegisterBoat:
                    m_boatController.DoRegisterBoat(member);
                    break;
                case view.MemberOperation.DisplayBoat:
                    DoDelegateBoatOperation(member);
                    break;
                case view.MemberOperation.Back:
                    break;
                default:
                    break;
            }
            m_list.SaveMemberList();
        }

        /**
         * Checks boat menu option and delegates control to specialized functions 
         */
        private void DoDelegateBoatOperation(model.Member member)
        {
            m_memberView.ShowMembersBoats();
            if (!member.HasNoBoatsRegistered())
            {
                model.Boat boatToHandle = m_memberView.GetMembersBoatToDisplay();
                m_boatView.ShowVerboseBoat(boatToHandle);
                view.BoatOperation operation = m_boatView.GetWhatToDoWithBoat();

                switch (operation)
                {
                    case view.BoatOperation.Edit:
                        m_boatController.DoEditBoat(boatToHandle);
                        break;
                    case view.BoatOperation.Delete:
                        member.DeleteBoat(boatToHandle);
                        m_baseView.PrintMessage("Boat deleted");
                        break;
                    case view.BoatOperation.Back:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                m_baseView.GetKeyPress();
            }
            m_list.SaveMemberList();
        }

        /**
         * Deletes model.Member @param.
         * Deals with exceptions
         */
        private void DoDeleteMember(model.Member member)
        {
            try
            {
                if (m_baseView.Confirm("Are you sure you want to delete this member? Press \"y\" to delete"))
                {
                    m_list.DeleteMember(member);
                    m_baseView.PrintMessage("Member successfully deleted!");
                }
                else
                {
                    m_baseView.PrintMessage("User not deleted");
                }
            }
            catch
            {
                m_baseView.PrintMessage("Deleting user failed. Try again later.");
            }
        }

        /**
         * Retrieves member info and sends them to m_list.RegisterMember to create a model.Member instance
         */
        private void DoAddMember()
        {
            string registrationMessage = "";
            try
            {
                string name = m_baseView.GetStringFromUser("Input name: ");
                string socialSecurityNumber = m_baseView.GetStringFromUser("Input social security number: ");
                m_list.RegisterMember(name, socialSecurityNumber);
                registrationMessage = "User successfully added to the registry. Press any key to continue.";
                m_baseView.PrintMessage("User successfully added to the registry. Press any key to continue.");
            }
            catch
            {
                registrationMessage = "User registration failed. Press any key to continue.";
                m_baseView.PrintMessage(registrationMessage);
            }
        }

        /**
         * Changes properties of model.Member @param
         */
        private void DoEditMember(model.Member member)
        {
            string name = m_baseView.GetStringFromUser("Input name: ");
            string socialSecurityNumber = m_baseView.GetStringFromUser("Input social security number: ");
            int id = member.MemberId;
            m_list.DeleteMember(member);
            m_list.UpdateMember(name, socialSecurityNumber, id);
            m_baseView.PrintMessage("Member has been updated.");
        }

        /**
         * Lists all members in m_list, gets chosen member from the menu list and delegates control to DoHandleMember
         */
        private void DoListMembers(bool compressedList)
        {
            try
            {
                model.Member member = null;
                int memberId;

                while (true)
                {
                    memberId = m_listView.GetChosenMemberId(compressedList);
                    member = m_list.GetMemberById(memberId);
                    if (member != null || memberId == 0)
                    {
                        break;
                    }
                    m_baseView.PrintMessage(String.Format("No user with id {0}", memberId));
                }
                DoHandleMember(m_list.GetMemberById(memberId));
            }
            catch
            {
                DoControlOperation();
            }
        }
    }
}