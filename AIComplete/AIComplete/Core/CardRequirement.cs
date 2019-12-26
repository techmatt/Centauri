using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AIComplete
{
    enum RequirementType
    {
        TagCount,
        Stealth,
        Reputation,
        CorporatePower,
        Compound,
    }

    class CardRequirement
    {
        public CardRequirement(string text)
        {

        }

        RequirementType type;
        int threshold;
        bool isGEQ;

        Tag tag;
        CorporationType corporation;
        List<CardRequirement> terms;

        public bool satisfied(GameState state, Player p)
        {
            if (type == RequirementType.Compound)
            {
                foreach (CardRequirement r in terms)
                {
                    if (!r.satisfied(state, p))
                        return false;
                }
                return true;
            }
            int value = -999;
            if (type == RequirementType.TagCount)
            {
                value = p.countTags(tag);
            }
            else if (type == RequirementType.Stealth)
            {
                value = p.stealthLevel;
            }
            else if (type == RequirementType.Reputation)
            {
                value = p.reputation[corporation];
            }
            else if (type == RequirementType.CorporatePower)
            {
                value = state.corps[corporation].power;
            }
            else
            {
                Debug.Assert(false, "invalid requirement type");
            }
            if(isGEQ)
            {
                return (value >= threshold);
            }
            else
            {
                return (value <= threshold);
            }
        }
    }
}
