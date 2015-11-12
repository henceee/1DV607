﻿using System;
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

        public bool Stand()
        {
            if(m_deck != null)
            {
                ShowHand();                               
                do
                {
                    GetShowAndDealCard(this, true);
                  /*  Card card = m_deck.GetCard();
                    card.Show(true);
                    DealCard(card);                      */

                }
                while (m_hitRule.DoHit(this));                               
            }
            return m_hitRule.DoHit(this);            
        }

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_winRule = a_rulesFactory.GetWinRule();
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

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                GetShowAndDealCard(a_player, true);
                /*Card c;
                c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);*/

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            return m_winRule.IsDealerWinner(this, a_player,g_maxScore);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void GetShowAndDealCard(Player player, bool show)
        {
            Card card = m_deck.GetCard();
            card.Show(show);
            player.DealCard(card);                      

        }
    }
}