using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class GetShowAndDeal
    {
        public void getShowAndDealCard(Deck a_deck, bool shouldShow, Player player)
        {
            Card c;
            c = a_deck.GetCard();
            c.Show(shouldShow);
            player.DealCard(c);
        }
    }
}
