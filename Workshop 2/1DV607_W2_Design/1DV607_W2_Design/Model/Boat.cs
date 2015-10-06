using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.Model
{
    class Boat
    {
        /// <summary>
        /// Valid types of boat
        /// </summary>
        public enum Type
        {
            sailboat,
            motorsailer,
            canoe,
            kayak,
            other,
            None
        }
               
        /// <summary>
        /// FIELDS
        /// </summary>
        double _length;
        Type _boatType;
        
        /// <summary>
        /// Property to get and set _length
        /// </summary>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// Property to get and set _boatType if valid type.
        /// </summary>
        public Type BoatType
        {
            get { return _boatType; }
            set 
            {
                if(value.GetType() == typeof(Type))
                {
                    _boatType = value; 
                }
                else
                {
                    throw new ArgumentException();
                }
                
            }
        }

        /// <summary>
        ///  Constructor for 0 args.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="boatType"></param>
        public Boat()
        {
            //empty.
        }
        /// <summary>
        ///  Constructor sets params to properties.
        /// </summary>
        /// <param name="length"></param>
        /// <param name="boatType"></param>
        public Boat(double length,Type boatType)
        {
            Length = length;
            BoatType = boatType;
            
        }

        /// <summary>
        /// Returns string representation of boat object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Removes leading and traling white spaces and then replaces consecutive white spaces with a single white space.
            return Regex.Replace(String.Format("Boat:\nLength: {0} Feet\nType: {1}\n", _length, _boatType).Trim(), @"\s{2,}", " ");
        }

        
    }
}
