using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    public enum StartMenuChoice
    {
        ListUsersCompact,
        ListUsersVerbose,
        AddMember,
        ExitApplication
    };

    /**
     * Singleton class for basic console input and output
     */
    class BaseView
    {
        private static BaseView m_instance;

        public static BaseView GetInstance()
        {
            if (m_instance == null)
            {
                m_instance = new BaseView();
            }
            return m_instance;
        }

        public void ShowStartMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-           WELCOME            -");
            sb.AppendLine("-     Boat Club Sys. 1.0       -");
            sb.AppendLine("--------------------------------");
            sb.AppendLine("-         Press a key          -");
            sb.AppendLine("-      to pick an option       -");
            sb.AppendLine("-                              -");
            sb.AppendLine("-     1. Show users in a       -");
            sb.AppendLine("-         compact view         -");
            sb.AppendLine("-       2. Show all info       -");
            sb.AppendLine("-          about users         -");
            sb.AppendLine("-       3. Add a new user      -");
            sb.AppendLine("-           4. Exit            -");
            sb.AppendLine("--------------------------------");

            Console.WriteLine(sb.ToString());
        }
        
        /**
         * @return view.NavigationView.Choices - enum representing chosen start menu operation
         * Key presses outside 1, 2, 3 and 4 are ignored
         */
        public StartMenuChoice GetStartMenuChoice()
        {
            // The @param true to ReadKey supresses printing of the pressed key
            do
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                switch (keyPressed.KeyChar)
                {
                    case '1':
                        return StartMenuChoice.ListUsersCompact;
                    case '2':
                        return StartMenuChoice.ListUsersVerbose;
                    case '3':
                        return StartMenuChoice.AddMember;
                    case '4':
                        return StartMenuChoice.ExitApplication;

                }
            } while (true);
        }

        public void ClearMenu()
        {
            Console.Clear();
        }

        public void InitializeConsole()
        {
            ClearMenu();
            Console.ForegroundColor = ConsoleColor.Green;
            ShowStartMenu();
        }

        public int GetIntegerFromUser(string prompt)
        {
            Console.Write(prompt);
            int input = 0;
            do
            {
                string textInput = Console.ReadLine();
                if (int.TryParse(textInput, out input))
                {
                    break;
                }
                Console.WriteLine("That's not a valid number! Try again.");
            } while (true);
            return input;
        }

        public double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            double input = 0;
            do
            {
                string textInput = Console.ReadLine();
                if (double.TryParse(textInput, out input))
                {
                    break;
                }
                Console.Write("That's not a valid number! Try again.");
            } while (true);
            return input;
        }

        public string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            string input = "";
            do
            {
                input = Console.ReadLine().Trim();
                if (!String.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                Console.CursorTop--;
            } while (true);
            return input;
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
            Console.ReadKey(true);
        }

        public bool Confirm(string prompt)
        {
            Console.WriteLine(prompt);
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);
            return pressedKey.KeyChar == 'y';
        }

        public ConsoleKeyInfo GetKeyPress()
        {
            return Console.ReadKey(true);
        }
    }
}
