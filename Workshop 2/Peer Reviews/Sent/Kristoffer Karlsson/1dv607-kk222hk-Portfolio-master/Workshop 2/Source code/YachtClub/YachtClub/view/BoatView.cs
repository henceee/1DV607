using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    public enum BoatOperation
    {
        Edit,
        Delete,
        Back
    };

    class BoatView
    {
        public void ShowEditStart()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-          BOAT EDITING        -");
            Console.WriteLine("--------------------------------");
        }

        public void DisplayBoatTypes()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-       BOAT REGISTRATION      -");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("-     Available boat types     -");
            Console.WriteLine("--------------------------------");
            int index = 0;
            foreach (model.BoatCategory category in Enum.GetValues(typeof(model.BoatCategory)))
            {
                index++;
                Console.WriteLine("{0}:           {1}", index, category);
            }
        }

        public void ShowVerboseBoat(model.Boat boatToShow)
        {
            Console.Clear();

            StringBuilder boatBuilder = new StringBuilder();

            boatBuilder.AppendLine("--------------------------------");
            boatBuilder.AppendLine(String.Format("-            Boat {0}          -", boatToShow.BoatId));
            boatBuilder.AppendLine("--------------------------------");
            boatBuilder.AppendLine(String.Format("      Category: {0}", boatToShow.Category));
            boatBuilder.AppendLine(String.Format("        Length: {0} cm", boatToShow.Length));
            boatBuilder.AppendLine("--------------------------------");
            boatBuilder.AppendLine("-    Please select an option   -");
            boatBuilder.AppendLine("-                              -");
            boatBuilder.AppendLine("-           1. Edit            -");
            boatBuilder.AppendLine("-          2. Delete           -");
            boatBuilder.AppendLine("-    3. Back to main menu      -");
            boatBuilder.AppendLine("--------------------------------");


            Console.WriteLine(boatBuilder.ToString());
        }

        /**
         * @return model.BoatCategory
         * Keeps prompting for valid integer representing a model.BoatCategory value
         */
        public model.BoatCategory GetCategoryInput()
        {
            Console.Write("Input boat category: ");
            int categoryId = 0;
            model.BoatCategory? category = null;
            do
            {
                if (int.TryParse(Console.ReadLine(), out categoryId))
                {
                    if (categoryId < Enum.GetNames(typeof(model.BoatCategory)).Length + 1 && categoryId > 0)
                    {
                        // -1 because of zero based enums
                        category = (model.BoatCategory)categoryId - 1;
                        break;
                    }
                    Console.WriteLine("That's not a valid boat category.");
                }
                else
                {
                    Console.WriteLine("That's not an integer..");
                }
            } while (true);
            return (model.BoatCategory)category;
        }

        /**
         * @return BoatOperation enum
         */ 
        public BoatOperation GetWhatToDoWithBoat()
        {
            do
            {
                ConsoleKeyInfo keyPressed = BaseView.GetInstance().GetKeyPress();
                switch (keyPressed.KeyChar)
                {
                    case '1':
                        return BoatOperation.Edit;
                    case '2':
                        return BoatOperation.Delete;
                    case '3':
                        return BoatOperation.Back;
                }
            } while (true);
        }
    }
}
