using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    class Corporation
    {
        public Corporation(CorporationType _type)
        {
            type = _type;
            if (type == CorporationType.Biomia) tag = Tag.Biomia;
            if (type == CorporationType.Cintamani) tag = Tag.Cintamani;
            if (type == CorporationType.Onyx) tag = Tag.Onyx;
        }
        public CorporationType type;

        public int power = StartingConditions.corporationPower;
        public int stealthAwareness = 0;
        public Tag tag;
        public List<Card> projects = new List<Card>();

        public bool playerInStealth(Player p)
        {
            return (p.stealthLevel > stealthAwareness);
        }
    }
}
