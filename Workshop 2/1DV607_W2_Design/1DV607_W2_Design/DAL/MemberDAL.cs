using _1DV607_W2_Design.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.DAL
{
    class MemberDAL
    {
        /// <summary>
        /// Status for reading textfile
        /// </summary>
        public enum MemberReadStatus
        {
            NewMember,
            ID,
            Name,
            PersonalNumber,
            NewBoat,
            Length,
            Type,
            Other
        }

        /// <summary>
        /// Fields
        /// </summary>
        private string _path;        
        private List<Member> _memberRepository;      
       
        /// <summary>
        /// Strings to compare to each line,
        /// which sets MemberReadStatus
        /// </summary>        
        #region CONST STRINGS (sections)

        private const string sectionMember         = "[Member]";
        private const string sectionID             = "[ID]";
        private const string sectionName           = "[Name]";
        private const string sectionPersonalNumber = "[PersonalNumber]";
        private const string sectionBoat           = "[Boat]";
        private const string sectionLength         = "[Length]";
        private const string sectionType           = "[Type]";

        #endregion

        /// <summary>
        /// Constructor
        /// sets path and creates new list for member repository
        /// </summary>
        /// <param name="path"></param>
        public MemberDAL(string path)
        {            
            _path = Path.GetFullPath(path);
            _memberRepository = new List<Member>();
        }
        /// <summary>
        /// Adds member to member repository
        /// </summary>
        /// <param name="member"></param>
        public void Add(Member member)
        {
            _memberRepository.Add(member);
        }
        /// <summary>
        /// Saves members from member repository to text file.
        /// </summary>
        public void Save()
        {
            using (StreamWriter sr = new StreamWriter(_path))
            {
                foreach (Member member in _memberRepository)
                {                    
                    sr.WriteLine("{0}",     sectionMember);
                    sr.WriteLine("{0}",     sectionID);
                    sr.WriteLine("{0}",     member.ID);
                    sr.WriteLine("{0}",     sectionName);
                    sr.WriteLine("{0};{1}", member.FirstName, member.LastName);
                    sr.WriteLine("{0}",     sectionPersonalNumber);
                    sr.WriteLine("{0}",     member.PersonalNumber);

                    foreach(Boat boat in member.Boats)
                    {
                        sr.WriteLine("{0}",     sectionBoat);
                        sr.WriteLine("{0}",     sectionLength);
                        sr.WriteLine("{0};{1}", boat.Length, "Feet");
                        sr.WriteLine("{0}",     sectionType);
                        sr.WriteLine("{0}",     boat.BoatType.ToString());
                    }
                                
                }
            }
        }
        /// <summary>
        /// Loads member info from text file, saves to member repository
        /// and returns it as readonlycollection
        /// </summary>
        /// <returns>_memberReository (as readonly)</returns>
        public IReadOnlyCollection<Member> LoadMemberData()
        {
            using (StreamReader listreader = new StreamReader(_path))
            {
                List<Member> members = new List<Member>();
                Member member = null;
                Boat boat = null;
                string line;
                MemberReadStatus status = MemberReadStatus.Other;

                while ((line = listreader.ReadLine()) != null)
                {
                     switch (line)
                    {
                        case "":
                            continue;

                        case sectionMember:
                            status = MemberReadStatus.NewMember;
                            break;

                        case sectionID:
                            status = MemberReadStatus.ID;
                            continue;

                        case sectionName:
                            status = MemberReadStatus.Name;
                            continue;

                        case sectionPersonalNumber:
                            status = MemberReadStatus.PersonalNumber;
                            continue;

                        case sectionBoat:
                            status = MemberReadStatus.NewBoat;
                            break;

                        case sectionLength:
                            status = MemberReadStatus.Length;
                            continue;

                        case sectionType:
                            status = MemberReadStatus.Type;
                            continue;                       
                    }

                    switch (status)
                    {
                        case MemberReadStatus.NewMember:
                            member = new Member();
                            members.Add(member);
                            continue;

                        case MemberReadStatus.ID:
                            member.ID = line;                                   
                            continue;

                        case MemberReadStatus.Name:
                            string[] names = line.Split(new char[] { ';' });
                            if (names.Length < 2)
                            {
                                throw new FormatException();
                            }
                            member.FirstName = names[0];
                            member.LastName = names[1];
                            continue;
                        
                        case MemberReadStatus.PersonalNumber:
                            member.PersonalNumber = line;
                            continue;
                        
                        case MemberReadStatus.NewBoat:
                            boat = new Boat();
                            member.add(boat);
                            continue;

                        case MemberReadStatus.Length:
                            string[] length = line.Split(new char[] { ';' });
                           
                                boat.Length = double.Parse(length[0]);                                                     
 
                            continue;

                        case MemberReadStatus.Type:

                            foreach (Boat.Type t in Enum.GetValues(typeof(Boat.Type)))
                            {
                                if (Enum.GetName(typeof(Boat.Type),t) == line)
                                {
                                    boat.BoatType = t;
                                }
                            }
                            continue;
                        }
                      }

                members.TrimExcess();
                members = members.OrderBy(m => m.ID).ToList();
                _memberRepository = members;
             
                return members.AsReadOnly();
            }

        }
        /// <summary>
        /// Deletes a member.
        /// </summary>
        /// <param name="recipe">The recipe to delete. The value can be null.</param>
        public virtual void Delete(Member member)
        {
            // If it's a copy of a member...
            if (!_memberRepository.Contains(member))
            {
                // ...try to find the original!
                member = _memberRepository.Find(m => m.Equals(member));
            }
            _memberRepository.Remove(member);
           
        }
        /// <summary>
        /// Deletes a member by index.
        /// </summary>
        /// <param name="index">The zero-based index of the recipe to delete.</param>
        public virtual void Delete(int index)
        {
            Delete(_memberRepository[index]);
        }
        
    }
}
