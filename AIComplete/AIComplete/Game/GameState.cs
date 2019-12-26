using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    class GameState
    {
        public GameState(GameDatabase _database, List<DecisionMaker> AIs)
        {
            database = _database;
            deck = database.cards.makeRandomDeck();
            startingPlayer = Util.randInt(0, AIs.Count);

            for(int playerIdx = 0; playerIdx < AIs.Count; playerIdx++)
            {
                players.Add(new Player(database, playerIdx, AIs[playerIdx]));
            }
        }

        public GameDatabase database;

        public List<Player> players = new List<Player>();
        public List<Card> deck;
        public List<Card> discard = new List<Card>();
        public Dictionary<CorporationType, Corporation> corps = new Dictionary<CorporationType, Corporation>();

        public Phase phase = Phase.Action;
        public int startingPlayer;
        public int year = 1;

        //
        // current decision
        //
        public Player decidingPlayer;

        public bool cardPlayableToCorp(CardEntry c, Player p, Corporation corp)
        {
            if (p.compute < c.computeCost)
            {
                return false;
            }
            if (c.type == CardType.Fragmentation) return false;
            if(c.type == CardType.Agenda || c.type == CardType.Conflict)
            {
                if (c.requiredCorp != CorporationType.None && c.requiredCorp != corp.type)
                    return false;
            }
            if(c.type == CardType.Augmentation || c.type == CardType.Technology)
            {
                if (!corp.playerInStealth(p))
                    return false;
            }
            if (!c.requirement.satisfied(this, p))
            {
                return false;
            }
            return true;
        }

        public bool cardPlayableToTable(CardEntry c, Player p)
        {
            int actualCreditCost = c.getCreditCost(p);
            if(p.credits < actualCreditCost || p.compute < c.computeCost)
            {
                return false;
            }
            if(!c.requirement.satisfied(this, p))
            {
                return false;
            }
            return true;
        }
    }
}
