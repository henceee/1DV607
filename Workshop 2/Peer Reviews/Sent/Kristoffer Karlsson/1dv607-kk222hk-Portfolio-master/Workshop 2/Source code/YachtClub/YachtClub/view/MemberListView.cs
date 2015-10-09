using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberListView
    {
        private IEnumerable<model.Member> m_members;

        public MemberListView(IEnumerable<model.Member> memberList)
        {
            m_members = memberList;
        }

        public int GetChosenMemberId(bool compressList)
        {
            //Show available members
            Console.Clear();

            if (compressList)
            {
                ShowCompressedList();
            }
            else
            {
                ShowCompleteList();
            }

            // Notify if no members are available
            if (!m_members.Any())
            {
                Console.WriteLine("-            No users are registered           -");
                Console.WriteLine("-            Press any key to return           -");
                Console.WriteLine("------------------------------------------------");
                Console.ReadKey(true);
                return 0;
            }

            // If members are available, prompt user for member selection
            else
            {
                int id = BaseView.GetInstance().GetIntegerFromUser("Select user by ID: ");      
                return id;
            }
        }

        private void ShowCompressedList()
        {
            Console.WriteLine("MemberID\t\tName\tAmount of boats");
            Console.WriteLine("------------------------------------------------");
            foreach (model.Member member in m_members)
            {
                Console.Write("{0}", member.MemberId);
                Console.Write("\t\t\t{0}", member.Name);
                Console.Write("\t\t{0}", member.GetAmountOfBoats());
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------");
        }

        private void ShowCompleteList()
        {
            Console.WriteLine("MemberID\t\tName\tPersonal number");
            Console.WriteLine("------------------------------------------------");

            foreach (model.Member member in m_members)
            {
                Console.Write("{0}", member.MemberId);
                Console.Write("\t\t\t{0}", member.Name);
                Console.Write("\t{0}\n", member.SocialSecurityNumber);
                Console.WriteLine();
                Console.WriteLine("Registered boats:");
                foreach (model.Boat boat in member.Boats)
                {
                    Console.WriteLine("Type: {0}", boat.Category);
                    Console.WriteLine("Length: {0}\n", boat.Length);
                }
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.WriteLine("------------------------------------------------");
        }
    }
}
