using _1DV607_W2_Design.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV607_W2_Design.View
{
    class ConsoleView
    {
        /// <summary>
        /// Gets input from user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string getStrInput(string message)
        {
            ShowMessage(message,true);            
                      
            return Console.ReadLine();
        }

        /// <summary>
        /// Presents message to user.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="shouldClear"></param>
        public void ShowMessage(string message, bool shouldClear=false)
        {
            if (shouldClear)
            {
                Console.Clear();
            }
           Console.WriteLine("\n{0}",message);
        }
    }
}
