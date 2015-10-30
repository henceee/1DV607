using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
                     //BasicHitStrategy
            return new soft17Strategy();
        }

        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }

        internal IWinRuleStrategy GetWinRule()
        {
                     //BasicWinStrategy
            return new PlayerWinsIfEqualWinStrategy();
        }
    }
}
