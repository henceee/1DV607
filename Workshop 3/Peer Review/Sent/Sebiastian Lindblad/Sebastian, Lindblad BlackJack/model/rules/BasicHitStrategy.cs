using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            int a = a_dealer.CalcScore();
            if (a == 17)
            {
                foreach (Card c in a_dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        return true;
                    }
                }
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
        
    }
}
