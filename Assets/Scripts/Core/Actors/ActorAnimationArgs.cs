using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    [Serializable]
    public class ActorAnimationArgs
    {
        [Tooltip("�ִϸ��̼� �з������� �̸�")]
        public string argName;
        [Tooltip("�ִϸ��̼� �з������� �ؽ���")]
        public int argHash;

        public static implicit operator int (ActorAnimationArgs arg)
        {
            return arg.argHash;
        }
    }
}