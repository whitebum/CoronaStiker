using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public sealed class ExplosionEffect : InstantEffect
    {
        private void Awake()
        {
            //graphics.GetComponent<SpriteRenderer>().sortingLayerName = EffectLeyerLevel.effectLayerName;
            //graphics.GetComponent<SpriteRenderer>().sortingLayerID = EffectLeyerLevel.explosionID;
        }
    }
}
