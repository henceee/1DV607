using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    /**
     * Deals with boat related use cases
     */
    class HandleBoats 
    {
        private view.BaseView m_baseView;
        private view.BoatView m_boatView;

        public HandleBoats(view.BaseView baseView, view.BoatView boatView)
        {
            m_baseView = baseView;
            m_boatView = boatView;
        }

        public void DoEditBoat(model.Boat boat)
        {
            m_baseView.ClearMenu();
            m_boatView.DisplayBoatTypes();
            model.BoatCategory category = m_boatView.GetCategoryInput();
            double length = m_baseView.GetDoubleFromUser("Input new boat length in centimeters: ");
            boat.Category = category;
            boat.Length = length;
            m_baseView.PrintMessage("Boat has been edited");
        }


        public void DoRegisterBoat(model.Member member)
        {
            m_boatView.DisplayBoatTypes();
            model.BoatCategory category = m_boatView.GetCategoryInput();
            double length = m_baseView.GetDoubleFromUser("Input boat length in centimeters: ");
            try
            {
                member.RegisterBoat(length, category);
            }
            catch (InvalidOperationException invEx)
            {
                m_baseView.PrintMessage("A boat with that id already exists");
            }
            catch (ArgumentException argEx)
            {
                m_baseView.PrintMessage("Invalid boat details");
            }
        }
    }
}
