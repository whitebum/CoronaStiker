﻿using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public sealed class InvincibleEffect : KeepableEffect
    {
        private void Awake()
        {
            //graphics.GetComponent<SpriteRenderer>().sortingLayerName = EffectLeyerLevel.effectLayerName;
            //graphics.GetComponent<SpriteRenderer>().sortingLayerID = EffectLeyerLevel.invincibleID;
        }
    }
}
