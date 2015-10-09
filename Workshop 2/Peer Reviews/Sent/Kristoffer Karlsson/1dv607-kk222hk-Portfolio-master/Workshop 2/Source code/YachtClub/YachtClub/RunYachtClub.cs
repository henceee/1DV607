using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub
{
    class RunYachtClub
    {
        static void Main(string[] args)
        {
            controller.HandleMembers controller = new controller.HandleMembers();
            controller.DoControlOperation();
        }
    }
}
