using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    public class Boat
    {
        private double m_length;
        private int m_boatId;
        private BoatCategory m_category;

        public BoatCategory Category
        {
            get
            {
                return m_category;
            }
            set
            {
                m_category = value;
            }
        }
        public int BoatId
        {
            get
            {
                return m_boatId;
            }
            private set 
            {
                m_boatId = value;
            }
        }
        public double Length
        {
            get
            {
                return m_length;
            }
            set
            {
                if (value <= 0 || value >= 1000)
                {
                    throw new ArgumentException("Model.Boat.Length needs to be between 0 and 1000");
                }
                m_length = value;
            }
        }

        public Boat(double length, BoatCategory category, int id)
        {
            Category = category;
            Length = length;
            BoatId = id;
        }
    }
}
