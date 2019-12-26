using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComplete.Game
{
    enum DecisionType
    {
        DraftCard,
        MainPhaseAction,
    }

    enum MainPhaseActionType
    {
        Pass,
        PlayCardToTable,
        PlayCardToCorp,
        SpendInfluence,
        CompleteCorpProject,
        ActivateTechnology,
        ConvertComputeToCredits,
        ConvertCreditsToCompute,
        DiscardCard,
        AdvanceCorpPower,
    }

    interface Decision
    {
        DecisionType type();
    }

    class DecisionDraft : Decision
    {
        public DecisionType type()
        {
            return DecisionType.DraftCard;
        }
        public DecisionDraft()
        {

        }
        public int draftCardIdx = -1;
    }

    class DecisionMainPhaseAction : Decision
    {
        public DecisionType type()
        {
            return DecisionType.MainPhaseAction;
        }
        public DecisionMainPhaseAction(GameState state)
        {
            Player p = state.decidingPlayer;
            foreach(Card c in state.decidingPlayer.hand)
            {
                if(state.cardPlayableToTable(c.entry, p))
                {
                    playableCardsToTable.Add(c);
                }
            }
            foreach (Corporation corp in state.corps.Values)
            {
                foreach (Card c in p.hand)
                {
                    if (state.cardPlayableToCorp(c.entry, p, corp))
                    {
                        playableCardsToCorp.Add(new Tuple<CorporationType, Card>(corp.type, c));
                    }
                }

                bool hasInfluenceTokens = (p.influenceTokens[corp.type] > 0);
                foreach (Card c in corp.projects)
                {
                    if (c.owner == p)
                    {
                        if(hasInfluenceTokens)
                            influencableCards.Add(new Tuple<CorporationType, Card>(corp.type, c));
                        if (p.credits >= c.creditsRemaining())
                            completeableProjects.Add(new Tuple<CorporationType, Card>(corp.type, c));
                    }
                }
            }
        }

        public MainPhaseActionType action;

        public List<Card> playableCardsToTable = new List<Card>();
        public List<Tuple<CorporationType, Card>> playableCardsToCorp = new List<Tuple<CorporationType, Card>>();
        public List<Tuple<CorporationType, Card>> influencableCards = new List<Tuple<CorporationType, Card>>();
        public List<Tuple<CorporationType, Card>> completeableProjects = new List<Tuple<CorporationType, Card>>();
        public List<Card> activatableTechnology = new List<Card>();
        public List<Card> discardableCards = new List<Card>();
        public List<Corporation> empowerableCorps = new List<Corporation>();

        public Card playableCardsToTableChoice;
        public Card playableCardsToCorpChoice;
        public Tuple<CorporationType, Card> influencableCardsChoice;
        public Tuple<CorporationType, Card> completeableAgendasChoice;
        public Card activatableTechnologyChoice;
        public Card discardableCardsChoice;

        /*Pass,
        PlayCardToTable,
        PlayCardToCorp,
        SpendInfluence,
        CompleteCorpAgenda,
        ActivateTechnology,
        ConvertComputeToCredits,
        ConvertCreditsToCompute,
        DiscardCard,
        AdvanceCorpPower,*/
    }
}
