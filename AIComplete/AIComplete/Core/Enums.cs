using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete
{
    public enum CorporationType
    {
        Onyx,
        Cintamani,
        Biomia,
        None
    }

    public enum Phase
    {
        InitialDraft,
        Action,
        Funding,
        Production,
        Drafting,
        Cleanup
    }

    public enum Tag
    {
        Fragmentation,
        Cintamani,
        Onyx,
        Biomia,
        Cyber,
        Space,
        Economy,
        Insight,
        Discord,
        Unity,
        Corporate
    }

    public enum CardType
    {
        Fragmentation,
        Augmentation,
        Technology,
        Agenda,
        Conflict,
    }
}
