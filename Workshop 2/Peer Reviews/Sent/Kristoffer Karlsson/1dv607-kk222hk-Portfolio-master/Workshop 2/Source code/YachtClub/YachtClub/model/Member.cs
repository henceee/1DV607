using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace YachtClub.model
{
    class Member
    {
        private string m_socialSecurityNumber;
        private int m_memberId;
        private string m_name;
        private List<Boat> m_boats = new List<Boat>();

        public string Name
        {
            get
            {
                return m_name;
            }
            private set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("Model.Member.Name needs to be 1 character or longer");
                }
                m_name = value;

            }
        }
        public int MemberId
        {
            get
            {
                return m_memberId;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Model.Member.MemberId needs to be 1 or higher");
                }
                m_memberId = value;
            }
        }
        public string SocialSecurityNumber
        {
            get
            {
                return m_socialSecurityNumber;
            }
            private set
            {
                if (!Regex.IsMatch(value, @"^\d{2,4}-?\d{4}-?\d{4}"))
                {
                    throw new ArgumentException("Model.Member.SocialSecurityNubmer is not valid format");
                }
                m_socialSecurityNumber = value;
            }
        }

        /**
         * @return read only wrapper for boat list
         */
        public IEnumerable<Boat> Boats
        {
            get
            {
                return new ReadOnlyCollection<Boat>(m_boats);
            }
        }

        public Member(string name, string socialSecurityNumber, int memberId)
        {
            Name = name;
            SocialSecurityNumber = socialSecurityNumber;
            MemberId = memberId;
        }

        public void UpdateBoat(double length, BoatCategory category, int id)
        {
            Boat boatToRegister = new Boat(length, category, id);

            foreach (Boat boat in m_boats)
            {
                if (boat.BoatId == boatToRegister.BoatId)
                {
                    throw new InvalidOperationException("Boat is already registered");
                }
            }
            m_boats.Add(boatToRegister);
        }

        public void RegisterBoat(double length, BoatCategory category)
        {
            Random random = new Random();
            int boatId = random.Next(0, 100);

            //Make sure member ID is unique
            while (true)
            {
                foreach (Boat boat in m_boats)
                {
                    if (boat.BoatId == boatId)
                    {
                        continue;
                    }
                }
                break;
            }
            Boat boatToRegister = new Boat(length, category, boatId);
            m_boats.Add(boatToRegister);
        }

        public void DeleteBoat(Boat boat)
        {
            if (!m_boats.Contains(boat))
            {
                throw new ArgumentException("That boat doesn't exist");
            }
            else
            {
                m_boats.Remove(boat);
            }
        }

        public int GetAmountOfBoats()
        {
            return m_boats.Count;
        }

        public Boat GetBoatByID(int id)
        {
            foreach (Boat boat in Boats)
            {
                if (boat.BoatId == id)
                {
                    return boat;
                }
            }

            return null;
        }

        public bool HasNoBoatsRegistered()
        {
            return !m_boats.Any();
        }
    }
}
