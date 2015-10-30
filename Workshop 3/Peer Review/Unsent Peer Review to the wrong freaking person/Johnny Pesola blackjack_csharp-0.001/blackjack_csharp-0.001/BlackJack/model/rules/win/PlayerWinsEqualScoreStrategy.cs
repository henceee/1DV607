using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class PlayerWinsEqualScoreStrategy : IWinStrategy
    {
        private const int g_maxScore = 21;

        public int MaxScore 
        {
            get {
                return g_maxScore;
            }
        }

        public bool IsDealerWinner(Player a_dealer, Player a_player)
        {
            int dealerScore = a_dealer.CalcScore();
            int playerScore = a_player.CalcScore();

            if (playerScore > g_maxScore)
            {
                return true;
            }
            else if (dealerScore > g_maxScore)
            {
                return false;
            }

            return dealerScore > playerScore;
        }
    }
}
