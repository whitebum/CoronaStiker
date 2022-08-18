using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Utils
{
    [Serializable]
    public class AnimationTrigger
    {
        [SerializeField] private string m_triggerName;
        [SerializeField] private int m_triggerHash;

        public string triggerName { get => m_triggerName; }
        public int triggerHash { get => m_triggerHash; }

        public AnimationTrigger(string triggerName)
        {
            m_triggerName = triggerName;
            m_triggerHash = Animator.StringToHash(triggerName);
        }
    }
}