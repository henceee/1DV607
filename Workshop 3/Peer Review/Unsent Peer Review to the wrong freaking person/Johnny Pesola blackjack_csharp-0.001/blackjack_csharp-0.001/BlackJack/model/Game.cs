using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {

        public enum Status
        {
            NewGame,
            Hit,
            Stand,
            Quit,
            Undefined
        }

        // Init variables
        private model.Dealer m_dealer;
        private model.Player m_player;

        //List<BlackJackObserver> m_observers;

        // Constructor
        public Game(view.IView view)
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            view.AddSubscribers(m_dealer);
            view.AddSubscribers(m_player);
            //m_observers = new List<BlackJackObserver>();
        }

        // Public methods
        //public void AddSubscriber(BlackJackObserver a_sub)
        //{
        //    m_observers.Add(a_sub);
        //}
        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Hit()
        {
            //foreach (BlackJackObserver o in m_observers)
            //{
            //    o.NewCardDealt(m_player.GetHand(), m_player.CalcScore());
            //}
            return m_dealer.Hit(m_player);
        }

        public bool Stand()
        {
            // TODO: Implement this according to Game_Stand.sequencediagram DONE

            m_dealer.Stand();
            return true;
        }

        public IEnumerable<Card> GetDealerHand()
        {
            //System.Threading.Thread.Sleep(2000);
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            //System.Threading.Thread.Sleep(2000);
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }
    }
}
