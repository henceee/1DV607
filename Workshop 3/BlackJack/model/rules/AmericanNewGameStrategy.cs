using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class AmericanNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Dealer a_dealer, Player a_player)
        {
            a_dealer.ShowDealACard(true, a_player);
            a_dealer.ShowDealACard(true, a_dealer);
            a_dealer.ShowDealACard(true, a_player);
            a_dealer.ShowDealACard(false, a_dealer);
          
            return true;
        }
    }
}
