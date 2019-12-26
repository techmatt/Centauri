using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    class CardEntry
    {
        public CardEntry(string line)
        {
            
        }

        public string name;
        public CardType type;
        public int creditCost;
        public int computeCost;
        public List<Tag> tags;
        public GameValue VP;
        public GameValue processors;
        public GameValue income;
        public GameValue memory;
        public GameValue stealth;
        public int corporateDemand;
        public GameValue corporatePower;
        public GameValue reputation;
        public GameValue fragmentsGenerated;
        public CardRequirement requirement;
        public CorporationType requiredCorp;
        public bool hasCorpTarget;

        public string otherEffectText;

        public int getCreditCost(Player p)
        {
            int result = creditCost;
            result -= p.allCardsDiscount;
            foreach (Tag t in tags)
            {
                if (p.discountPerTag.ContainsKey(t))
                {
                    result -= p.discountPerTag[t];
                }
            }
            result = Math.Max(0, result);
            return result;
        }

        public int countTags(Tag tag)
        {
            int sum = 0;
            foreach(Tag t in tags)
            {
                if (t == tag)
                    sum++;
            }
            return sum;
        }
    }

    class CardDatabase
    {
        public CardDatabase()
        {

        }

        public Dictionary<string, CardEntry> cards = new Dictionary<string, CardEntry>();

        public List<Card> makeRandomDeck()
        {
            var result = new List<Card>();
            foreach(var entry in cards.Values)
            {
                result.Add(new Card(entry));
            }
            result = result.Shuffle();
            return result;
        }
    }
}
