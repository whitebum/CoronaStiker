using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    [Serializable]
    public class AnimationArgs
    {
        [Tooltip("�ִϸ��̼� �з������� �̸�")]
        public string argName;
        [Tooltip("�ִϸ��̼� �з������� �ؽ���")]
        public int argHash;

        public static implicit operator int (AnimationArgs arg)
        {
            return arg.argHash;
        }
    }
}