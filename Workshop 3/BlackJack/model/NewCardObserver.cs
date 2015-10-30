using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    /*
     * Use the Observer-pattern to send an event to the user interface that a player has got a new card in his hand.
     * When the event is handled the user interface should be redrawn to show the new hand (with the new card) and
     * the game should be briefly paused, to make the game a bit more exciting, the pausing code should be in the user 
     * interface (view or controller) and not in the model. The pause should be when any player (dealer or player) gets a card.
     */
    interface NewCardObserver
    {
        void newCardGiven();
    }
}
