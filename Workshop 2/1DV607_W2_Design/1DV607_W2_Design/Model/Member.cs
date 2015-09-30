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
        string _name;
        string _personalNumber;
        string _id;
        List<Boat> _boats;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        public Member(string name, string personalNumber)
        {
            _boats = new List<Boat>();
            _name = name;
            _id = Guid.NewGuid().ToString();

            Regex reg = new Regex(@"\d{6,8}-\d{4}");
            if (reg.IsMatch(personalNumber))
            {
                _personalNumber = personalNumber;
            }
            else
            {
                throw new ArgumentException();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
      
        public string getName()
        {
            return _name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getPersonalNumber()
        {
            return _personalNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boat"></param>
        public void addBoat(Boat boat)
        {
            _boats.Add(boat);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Boat> GetBoats()
        {
            return _boats.AsReadOnly(); 
        }

       
    }
}
