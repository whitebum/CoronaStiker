using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public class KeepableEffect : BaseEffect
    {
        public override void OnEffect()
        {
            gameObject.SetActive(true);
        }

        public override void OffEffect()
        {
            gameObject.SetActive(false);
        }
    }
}
