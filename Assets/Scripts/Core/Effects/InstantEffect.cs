using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public class InstantEffect : BaseEffect
    {
        public override void OnEffect()
        {
            gameObject.SetActive(true);
            Invoke(nameof(OffEffect), graphics.GetCurrentAnimationLength());
        }

        public override void OffEffect()
        {
            gameObject.SetActive(false);
        }
    }
}
