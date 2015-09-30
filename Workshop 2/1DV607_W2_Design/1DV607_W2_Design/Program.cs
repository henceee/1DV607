using _1DV607_W2_Design.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _1DV607_W2_Design
{
    class Program
    {
        static void Main(string[] args)
        {
            View.ConsoleView view = new View.ConsoleView();
            Controller.MemberController memberController = new Controller.MemberController(view);
            
            while (memberController.startApp());

            
        }
    }
}
