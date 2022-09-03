using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoronaStriker.Core.Effects
{
    [RequireComponent(typeof(EffectGraphics))]
    public abstract class BaseEffect : MonoBehaviour
    {
        public EffectGraphics graphics;

        protected virtual void Reset()
        {
            graphics = GetComponent<EffectGraphics>();
        }

        public abstract void OnEffect();
        public abstract void OffEffect();
    }
}
