using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame
    {
        view.IView m_view;

        public PlayGame(view.IView a_view)
        {
            m_view = a_view;
        }
        public bool Play(model.Game a_game)
        {
            //a_game.AddSubscriber(this);
            m_view.DisplayWelcomeMessage();
            
           // m_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            //m_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());//

            if (a_game.IsGameOver())
            {
                m_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            model.Game.Status input = m_view.GetInput();

            if (input == model.Game.Status.NewGame)
            {
                a_game.NewGame();
            }
            else if (input == model.Game.Status.Hit)
            {
                a_game.Hit();
            }
            else if (input == model.Game.Status.Stand)
            {
                a_game.Stand();
            }

            return input != model.Game.Status.Quit;
        }
        public void NewCardDealt(IEnumerable<model.Card> a_hand, int a_score)
        {
            m_view.DisplayPlayerHand(a_hand, a_score);
        }
    }
}
