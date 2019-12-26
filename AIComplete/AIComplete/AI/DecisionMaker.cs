using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    interface DecisionMaker
    {
        void makeDecision(GameState state);
    }
    
    class Human : DecisionMaker
    {
        public void makeDecision(GameState state)
        {

        }
    }
}
