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
        /// <summary>
        /// Initializes the application, 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {  
            Controller.App app = new Controller.App();
            
            while (app.startApp());
                        
        }
    }
}
