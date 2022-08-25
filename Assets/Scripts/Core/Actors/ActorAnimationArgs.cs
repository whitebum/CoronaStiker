using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [Serializable]
    public class ActorAnimationArgs
    {
        [Tooltip("애니메이션 패러매터의 이름")]
        public string argName;
        [Tooltip("애니메이션 패러매터의 해쉬값")]
        public int argHash;

        public static implicit operator int (ActorAnimationArgs arg)
        {
            return arg.argHash;
        }
    }
}