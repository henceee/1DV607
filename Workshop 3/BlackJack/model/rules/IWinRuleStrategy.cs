using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface IWinRuleStrategy
    {
        bool IsDealerWinner(Dealer a_dealer, Player a_player,int g_maxScore);
    }
}
