using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public sealed class ShieldEffect : KeepableEffect
    {
        protected override void Reset()
        {
            base.Reset();

            if (graphics != null)
            {
                var spriteRenderer = GetComponent<SpriteRenderer>() ?? gameObject.AddComponent<SpriteRenderer>();

                spriteRenderer.sortingLayerName = EffectLeyerLevel.effectLayerName;
                spriteRenderer.sortingLayerID = SortingLayer.NameToID(EffectLeyerLevel.effectLayerName);
                spriteRenderer.sortingOrder = EffectLeyerLevel.shieldID;
            }
        }
    }
}
