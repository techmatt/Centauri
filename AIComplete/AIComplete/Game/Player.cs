using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    class Player
    {
        public Player(GameDatabase _database, int playerIdx, DecisionMaker _decisionMaker)
        {
            index = playerIdx;
            database = _database;
            decisionMaker = _decisionMaker;

            reputation[CorporationType.Cintamani] = 0;
            reputation[CorporationType.Biomia] = 0;
            reputation[CorporationType.Onyx] = 0;

            influenceTokens[CorporationType.Cintamani] = 0;
            influenceTokens[CorporationType.Biomia] = 0;
            influenceTokens[CorporationType.Onyx] = 0;
        }

        GameDatabase database;
        public int index;
        public DecisionMaker decisionMaker;

        public List<Card> hand = new List<Card>();
        public List<Card> draftingHand = new List<Card>();

        public List<Card> playedCards = new List<Card>();

        public int credits = StartingConditions.playerCredits;
        public int compute = StartingConditions.playerCompute;
        public int processors = StartingConditions.playerProcessorCount;
        public int income = StartingConditions.playerIncome;
        public int memory = StartingConditions.playerMemory;
        public int stealthLevel = StartingConditions.playerStealth;
        public Dictionary<CorporationType, int> reputation = new Dictionary<CorporationType, int>();
        public Dictionary<CorporationType, int> influenceTokens = new Dictionary<CorporationType, int>();

        public int allCardsDiscount = 0;
        public Dictionary<Tag, int> discountPerTag = new Dictionary<Tag, int>();

        public int countTags(Tag tag)
        {
            int sum = 0;
            foreach(Card c in playedCards)
            {
                sum += c.entry.countTags(tag);
            }
            return sum;
        }
    }
}
