namespace LastCard.Logic
{
    using UnityEngine;

    public class RulesResolver : MonoBehaviour
    {
        [SerializeField]
        private CardsPile cardsPile;

        public bool CanPushCard(Card card)
        {
            if (cardsPile.HasAliasThree || (card.nominal == Nominal.Eight) ||
                (card.nominal == Nominal.Four && CanPushFour()) || FollowsBaseCondition(card))
            {
                cardsPile.HasAliasThree = false;

                return true;
            }

            return false;
        }

        private bool CanPushFour()
        {
            Nominal lastPileNominal = cardsPile.PeekCard().nominal;

            if (lastPileNominal == Nominal.Five || lastPileNominal == Nominal.Six || lastPileNominal == Nominal.Seven)
            {
                return true;
            }

            return false;            
        }

        private bool FollowsBaseCondition(Card card)
        {
            return (card.suit == cardsPile.PeekCard().suit) || (card.nominal == cardsPile.PeekCard().nominal);
        }
    }
}
