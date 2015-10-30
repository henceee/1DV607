using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private List<Card> m_hand = new List<Card>(20);

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IWinStrategy m_winRule;

        
        // Constructor
        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinnerRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }
        private Card GetCardAndShow()
        {
            Card c = m_deck.GetCard();
            c.Show(true);
            DealCard(c);

            return c;
        }

        // Public methods
        public void Stand()
        {
            if(m_deck != null)
            {
                ShowHand();

                while(m_hitRule.DoHit(this))
                {
                    //Card c = m_deck.GetCard();

                    //c.Show(true);

                    //DealCard(c);

                    GetCardAndShow();
                }
            }
        }


        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < m_winRule.MaxScore && !IsGameOver())
            {
                //Card c;
                //c = m_deck.GetCard();
                //c.Show(true);
                a_player.DealCard(GetCardAndShow());

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
