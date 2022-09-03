using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Utils
{
    [Serializable]
    public class AnimationParam
    {
        [Tooltip("�ִϸ��̼� �з������� �̸�")]
        public string paramName;
        [Tooltip("�ִϸ��̼� �з������� �ؽ���")]
        public int paramHash;

        public static implicit operator int (AnimationParam param )
        {
            return param.paramHash;
        }
    }
}