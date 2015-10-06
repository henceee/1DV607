using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.Model
{
    class Member
    {
        /// <summary>
        /// Fields
        /// </summary>
        string _personalNumber;
        string _id;
        List<Boat> _boats;
        private string _firstName;
        private string _lastName;
        
        /// <summary>
        /// Property to get and set _firstName, if valid string
        /// </summary>
        public string FirstName
        {
            get {return _firstName;}
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _firstName = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        /// <summary>
        /// Property to get and set _lastName, if valid string
        /// </summary>
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _lastName = value.Trim();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        /// <summary>
        /// Property to get and set _personalNumber, if valid string
        /// </summary>
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                Regex reg = new Regex(@"\d{6,8}-\d{4}");
                if (reg.IsMatch(value))
                {
                    _personalNumber = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
             
        }
        /// <summary>
        /// Property to get and set _ID
        /// </summary>
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Property to get boats as readonly
        /// </summary>
        public IEnumerable<Boat> Boats
        {
            get { return _boats.AsReadOnly(); }
            
        }
        
        /// <summary>
        /// Constructor for no params, creates list of boats
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        public Member()
        {
            _boats = new List<Boat>();
        }
        /// <summary>
        /// Constructor for no params, creates list of boats if not set,
        /// sets params using properties.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        public Member(string firstName,string lastName, string personalNumber)
        {
            if (_boats == null)
            {
                _boats = new List<Boat>();
            }
            FirstName = firstName;
            LastName = lastName;
            PersonalNumber = personalNumber;
            /*
             *"Add a Guid property to your class, then in the constructor of the class assign it to NewGuid()."
             * http://stackoverflow.com/questions/9788680/how-do-i-obtain-an-id-that-allows-me-to-tell-difference-instances-of-a-class-apa
             */
            ID = Guid.NewGuid().ToString();

        }

        /// <summary>
        /// Add boat to list _boats.
        /// </summary>
        /// <param name="boat"></param>
        public void add(Boat boat)
        {
            _boats.Add(boat);
        }
        /// <summary>
        /// Removes boat from list of boats.
        /// </summary>
        /// <param name="b"></param>
        public void remove(Boat b)
        {
            _boats.Remove(b);
        }
        /// <summary>
        /// Get the number of boats assigned to member.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        public int getNumberOfBoats()
        {
            return _boats.Count;
        }
        /// <summary>
        /// Returns string representation of member
        /// as compact list (first & lastname, personal no., no. of boats)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        public string compactToString()
        {
            return string.Format("ID:{0}\nName:{1} {2}\n{3}\n\nNo. of boats:{4}\n", ID, FirstName, LastName, PersonalNumber, Boats.Count());
        }
        /// <summary>
        /// Returns string representation of member
        /// as verbose list (first & lastname, personal no.,string representation of boat(s))
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string boats ="";

            foreach (Boat boat in _boats)
            {
                boats += boat.ToString();
            }

            return string.Format("ID:{0}\nName:{1} {2}\n{3}\n{4}\n", ID, FirstName, LastName,PersonalNumber, boats);
        }


       
    }
}
