using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        List<model.BlackJackObserver> m_observers;
        public void AddSubscribers(model.BlackJackObserver a_sub)
        {
            if (m_observers == null)
            {
                m_observers = new List<model.BlackJackObserver>();
            }
            m_observers.Add(a_sub);
        }

        public void DisplayWelcomeMessage()
        {
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("Type 'p' to Play, 'h' to Hit, 's' to Stand or 'q' to Quit\n");
            foreach (model.BlackJackObserver o in m_observers)
            {
                DisplayHand(o.GetName(), o.GetHand(), o.GetScore());
                Thread.Sleep(500);
            }
        }

        public model.Game.Status GetInput()
        {
            int input = System.Console.In.Read();

            switch (input)
            {
                case 'p':
                    return model.Game.Status.NewGame;
                case 's':
                    return model.Game.Status.Stand;
                case 'h':
                    return model.Game.Status.Hit;
                case 'q':
                    return model.Game.Status.Quit;
                default:
                    return model.Game.Status.Undefined;
            }
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}
