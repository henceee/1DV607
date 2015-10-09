using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YachtClub.model
{
    class MemberList
    {
        private List<Member> m_members = new List<Member>();
        private DAL.MemberDAL m_DAL = new DAL.MemberDAL();
        private Random m_random = new Random();
        
        /**
         ** @return read only wrapper of m_members
         **/
        public IEnumerable<Member> Members
        {
            get
            {
                return m_members;
            }
        }

        public MemberList()
        {
            m_members = m_DAL.Load();
        }

        public void UpdateMember(string name, string socialSecurityNumber, int memberId)
        {
            model.Member memberToAdd = new model.Member(name, socialSecurityNumber, memberId);
            m_members.Add(memberToAdd);
            SaveMemberList();
        }

        public void RegisterMember(string name, string socialSecurityNumber)
        {
            //Randomize member ID
            int memberId = 0;
            bool isInList = false;

            //Make sure member ID is unique
            do
            {
                memberId = m_random.Next(0, 500);
                foreach (Member member in m_members)
                {
                    if (member.MemberId == memberId)
                    {
                        isInList = true;
                    }
                }
            } while (isInList);

            model.Member memberToAdd = new model.Member(name, socialSecurityNumber, memberId);

            m_members.Add(memberToAdd);
            SaveMemberList();
        }

        public void DeleteMember(Member member)
        {
            if (!m_members.Contains(member))
            {
                throw new ArgumentException("That member doesn't exist");
            }
            m_members.Remove(member);
        }

        public void SaveMemberList()
        {
            m_DAL.Save(m_members);
        }

        public Member GetMemberById(int memberId)
        {
            foreach (Member member in m_members)
            {
                if (member.MemberId == memberId)
                {
                    return member;
                }
            }
            return null;
        }
    }
}