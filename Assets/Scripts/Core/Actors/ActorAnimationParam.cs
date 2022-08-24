using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [Serializable]
    public class ActorAnimationParam
    {
        [Tooltip("�ִϸ��̼� �з������� �̸�")]
        public string paramName;
        [Tooltip("�ִϸ��̼� �з������� �ؽ���")]
        public int paramHash;

        public static implicit operator int (ActorAnimationParam param)
        {
            return param.paramHash;
        }
    }
}