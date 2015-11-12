using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;

        private const int g_maxScore = 21;
        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private IWinRuleStrategy m_winRule;
        private List<NewCardObserver> m_observers;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinRule();
            m_observers = new List<NewCardObserver>();
        }

        public void AddSubscribers(NewCardObserver a_sub)
        {
            m_observers.Add(a_sub);
        }

         public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                ShowDealACard(true, a_player);
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(this, a_player, g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void Stand()
        {
            if (m_deck != null)
            {
                ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    ShowDealACard(true, this);
                }
            }
        }

        public void ShowDealACard(bool show, Player player)
        {
            Card card = m_deck.GetCard();
            card.Show(show);
            player.DealCard(card);

            foreach (NewCardObserver observer in m_observers)
            {
                observer.newCardGiven();
            }
        }
    }    
    
}
