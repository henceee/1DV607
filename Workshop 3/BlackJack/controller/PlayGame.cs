using BlackJack.model;
using BlackJack.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : NewCardObserver
    {
        private Game a_game;
        private IView a_view;
        private bool b_suspense = false;

        public PlayGame(Game game, IView view)
        {
            a_game = game;
            a_view = view;
            a_game.AddSubsribers(this);
        }

        public bool Play()
        {
           a_view.DisplayWelcomeMessage();
           a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore(),b_suspense);
           a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore(),b_suspense);
           b_suspense = false;

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            Event e = a_view.GetEvent();

            switch (e)
            {
                case Event.newgame:
                    a_game.NewGame();
                    break;
                case Event.hit:
                    a_game.Hit();
                    break;
                case Event.stand:
                    a_game.Stand();
                    break;
                case Event.quit:
                    return false;
            }

            return true;
        }

        public void newCardGiven()
        {   
            b_suspense = true;  
        }
    }
}
