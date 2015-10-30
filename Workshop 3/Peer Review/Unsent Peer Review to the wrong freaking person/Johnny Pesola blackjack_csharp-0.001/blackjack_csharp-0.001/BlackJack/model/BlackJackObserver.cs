using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    interface BlackJackObserver
    {
        string GetName();
        int GetScore();
        IEnumerable<Card> GetHand();
    }
}
