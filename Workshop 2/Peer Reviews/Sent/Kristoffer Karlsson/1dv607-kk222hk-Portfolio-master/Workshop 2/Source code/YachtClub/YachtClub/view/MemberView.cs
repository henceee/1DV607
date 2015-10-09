using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    public enum MemberOperation
    {
        Edit,
        Delete,
        RegisterBoat,
        DisplayBoat,
        Back
    };

    class MemberView
    { 
        private model.Member m_member;

        public MemberView(model.Member member)
        {
            m_member = member;
        }

        public model.Boat GetMembersBoatToDisplay()
        {
            model.Boat boatToReturn = null;

            do
            {
                try
                {
                    int boatId = BaseView.GetInstance().GetIntegerFromUser("Select boat by ID: ");
                    boatToReturn = m_member.GetBoatByID(boatId);
                    if (boatToReturn == null)
                    {
                        throw new NullReferenceException();
                    }
                    break;
                }
                catch (NullReferenceException nullEx)
                {
                    BaseView.GetInstance().PrintMessage("No boat with that ID");
                }
            } while (true);

            return boatToReturn;
        }

        public void ShowMember()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("--------------------------------");
            sb.AppendLine(String.Format("          Member #{0}         ", m_member.MemberId));
            sb.AppendLine(String.Format("          Name: {0}           ", m_member.Name));
            sb.AppendLine(String.Format(" Personal Number: {0}  ", m_member.SocialSecurityNumber));
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-           OPTIONS            -");
            sb.AppendLine("-           1. Edit            -");
            sb.AppendLine("-          2. Delete           -");
            sb.AppendLine("-       3. Register boat       -");
            sb.AppendLine("-       4. Display boats       -");
            sb.AppendLine("-           5. Back            -");
            sb.AppendLine("--------------------------------");

            Console.WriteLine(sb.ToString());
        }

        public void ShowMembersBoats()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();

            if (m_member.HasNoBoatsRegistered())
            {
                sb.AppendLine("--------------------------------");
                sb.AppendLine("- User has no registered boats -");
                sb.AppendLine("-    Press any key to return   -");
                sb.AppendLine("--------------------------------");
            }
            else
            {
                sb.AppendLine("--------------------------------");
                sb.AppendLine("-       Registered boats       -");
                sb.AppendLine("--------------------------------");
            }

            foreach (model.Boat boat in m_member.Boats)
            {
                sb.AppendLine(String.Format("            ID: {0}       ", boat.BoatId));
                sb.AppendLine(String.Format("          Type: {0}        \n", boat.Category));
                sb.AppendLine("--------------------------------");
            }

            Console.WriteLine(sb.ToString());
        }

        public MemberOperation GetWhatToDoWithUser()
        {
            do
            {
                ConsoleKeyInfo keyPressed = BaseView.GetInstance().GetKeyPress();
                switch (keyPressed.KeyChar)
                {
                    case '1':
                        return MemberOperation.Edit;
                    case '2':
                        return MemberOperation.Delete;
                    case '3':
                        return MemberOperation.RegisterBoat;
                    case '4':
                        return MemberOperation.DisplayBoat;
                    case '5':
                        return MemberOperation.Back;
                }
            } while (true);
        }
    }
}
