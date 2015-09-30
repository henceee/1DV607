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

        public enum Type
        {
            Sailboat,
            Motorsailer,
            Canoe,
            Kayak,
            Other
        }

        double _length;
        Type _type;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <param name="boatType"></param>
        public Boat(double length, Type boatType)
        {
            _length = length;
            _type = boatType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Type getBoatType()
        {
            return _type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double getLength()
        {
            return _length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Regex.Replace(String.Format("{0} {1}", _length, _type).Trim(), @"\s{2,}", " ");
        }
      
    }
}
