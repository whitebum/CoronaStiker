using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public sealed class HealthEffect : InstantEffect
    {
        private void Awake()
        {
            //graphics.GetComponent<SpriteRenderer>().sortingLayerName = EffectLeyerLevel.effectLayerName;
            //graphics.GetComponent<SpriteRenderer>().sortingLayerID = EffectLeyerLevel.healthID;
        }
    }
}
