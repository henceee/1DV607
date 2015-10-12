using _1DV607_W2_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class MemberView:ConsoleView
    {
        private BoatView _boatView;
        /// <summary>
        /// constructor, sets field _boatView from arg.
        /// </summary>
        /// <param name="boatView"></param>
        public MemberView(BoatView boatView)
        {
            _boatView = boatView;
        }
        /// <summary>
        /// Views a compact list (name, first- & last name, personal no., no. of boats)
        /// of all members in the list.
        /// </summary>
        /// <param name="members"></param>
        public void viewCompactList(IReadOnlyCollection<Member> members)
        {
            foreach (Member member in members)
            {
                viewMemberCompact(member);
            }

        }
        /// <summary>
        /// Views a verbose list (name, first- & last name, personal no. and boat info)
        /// of all members in the list.
        /// </summary>
        /// <param name="members"></param>
        public void viewVerboseList(IReadOnlyCollection<Member> members)
        {
            foreach (Member member in members)
            {
                viewMemberVerbose(member);   
            }
        }
        /// <summary>
        /// Views a compact info of specific member (name, first- & last name, personal no., no. of boats)
        /// </summary>
        /// <param name="members"></param>
        public void viewMemberCompact(Member member)
        {
            ShowMessage(string.Format("ID:{0}\nName:{1} {2}\n{3}\n\nNo. of boats:{4}\n",
                                      member.ID, member.FirstName, member.LastName, member.PersonalNumber, member.getNumberOfBoats()));
        }
        /// <summary>
        /// Views a verbose info of spec. member (name, first- & last name, personal no. and boat info)
        /// </summary>
        /// <param name="members"></param>
        public void viewMemberVerbose(Member member)
        {
            ShowMessage(String.Format("ID:{0}\nName:{1} {2}\n{3}\n\n",
                                      member.ID, member.FirstName, member.LastName, member.PersonalNumber));
            _boatView.viewBoats(member.Boats);
        }
        /// <summary>
        /// Presents list of members for user to choose from.
        /// </summary>
        /// <param name="members"></param>
        public void chooseMemberList(IReadOnlyCollection<Member> members)
        {
            Console.Clear();
            int memberNumber = -1;
            foreach(Member member in members)
            {
                memberNumber++;
                ShowMessage(string.Format("{0}.{1} {2}",memberNumber, member.FirstName, member.LastName));  
            }
        }
    }
}
