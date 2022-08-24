using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [Serializable]
    public class ActorAnimationParam
    {
        [Tooltip("애니메이션 패러매터의 이름")]
        public string paramName;
        [Tooltip("애니메이션 패러매터의 해쉬값")]
        public int paramHash;

        public static implicit operator int (ActorAnimationParam param)
        {
            return param.paramHash;
        }
    }
}