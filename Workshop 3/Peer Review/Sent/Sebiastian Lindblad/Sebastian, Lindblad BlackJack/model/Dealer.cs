﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;
        private const int g_hitLimit = 17;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.WinGameRules m_rules;
        public event EventHandler ANewCard;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_rules = a_rulesFactory.GetWinner();
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
                Card c = m_deck.GetCard();
                c.Show(true);
                a_player.DealCard(c);
                NewCard();
                return true;
            }
            return false;
        }
        public bool Stand(Player a_dealer)
        {
            if (m_deck != null)
            {
                ShowHand();
                while (m_hitRule.DoHit(this))
                {
                    Card c = m_deck.GetCard();
                    c.Show(true);
                    DealCard(c);
                    NewCard();
                }
                return true;
            }
            return false;
        }
        public void NewCard()
            {
            EventHandler handler = ANewCard;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool IsDealerWinner(Player a_player, Dealer a_dealer)
        {
            return m_rules.Winner(a_player, a_dealer);
        }

        public bool IsGameOver()
        {

            if (m_deck != null && CalcScore() >= g_hitLimit && m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }
    }
}
