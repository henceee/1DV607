using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace YachtClub.model.DAL
{
    enum LoadStatus
    {
        Member,
        Boat
    };

    /**
     * Encapsulates saving of the member list to a text file
     */
    class MemberDAL
    {
        private string m_fileName = "members.txt";

        public void Save(List<Member> members)
        {
            using (StreamWriter memberWriter = new StreamWriter(m_fileName))
            {
                memberWriter.WriteLine("Members");
                foreach (Member m in members)
                {
                    memberWriter.WriteLine(m.Name + ";" + m.SocialSecurityNumber + ";" + m.MemberId + ";" + m.GetAmountOfBoats());
                }
                memberWriter.WriteLine("Boats");

                //Member ID connects each boat to a member owner
                foreach (Member m in members)
                {
                    foreach (Boat boat in m.Boats)
                    {
                        memberWriter.WriteLine(boat.Length + ";" + boat.Category + ";" + boat.BoatId + ";" + m.MemberId);
                    }
                }
            }
        }

        public List<Member> Load()
        {
            LoadStatus stat = LoadStatus.Member;
            List<Member> members = new List<Member>();
            using (StreamReader reader = new StreamReader(m_fileName))
            {
                string textFileLine = "";

                while (!String.IsNullOrWhiteSpace(textFileLine = reader.ReadLine()))
                {
                    if (textFileLine == "Members")
                    {
                        stat = LoadStatus.Member;
                    }
                    else if (textFileLine == "Boats")
                    {
                        stat = LoadStatus.Boat;
                    }
                    else
                    {
                        if (stat == LoadStatus.Member)
                        {
                            string[] member = textFileLine.Split(';');
                            string name = member[0];
                            string socialSecurityNumber = member[1];
                            int memberId = int.Parse(member[2]);

                            members.Add(new Member(name, socialSecurityNumber, memberId));
                        }
                        else if (stat == LoadStatus.Boat)
                        {
                            string[] boat = textFileLine.Split(';');

                            foreach (Member m in members)
                            {
                                if (m.MemberId == int.Parse(boat[3]))
                                {
                                    double length = double.Parse(boat[0]);
                                    int boatId = int.Parse(boat[2]);
                                    BoatCategory category;
                                    Enum.TryParse(boat[1], out category);
                                    m.UpdateBoat(length, category, boatId);
                                }
                            }
                        }
                    }
                }
            }
            return members;
        }
    }
}
