using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    enum GameValueType
    {
        FixedValue,
        ValuePerTag,
        ValuePerResource,
        AgendaDoubleValue,
        Sum,
    }

    class GameValue
    {
        public GameValue(string text)
        {
            sourceText = text;
        }

        GameValueType type;
        string sourceText;

        int fixedValue;

        Tag perTagType;
        int perTagRate;

        int perResourceRate;

        int agendaOwnerValue;
        int agendaSecondaryValue;

        List<GameValue> sumParts;
    }
}
