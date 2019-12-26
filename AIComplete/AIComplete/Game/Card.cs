using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    /*enum CardLocation
    {
        Deck,
        Discard,
        Hand,
    }*/

    class Card
    {
        public Card(CardEntry _entry)
        {
            entry = _entry;
        }

        public CardEntry entry;

        public Player owner = null;
        public int creditsPaid = 0;

        public int creditsRemaining()
        {
            return entry.creditCost - creditsPaid;
        }
    }
}
