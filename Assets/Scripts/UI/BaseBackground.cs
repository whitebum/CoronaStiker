using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public abstract class BaseBackground : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        protected Dictionary<string, AnimationParam> animTriggers;

        protected virtual void Reset()
        {
            animator = GetComponent<Animator>();
        } 

        protected virtual void Awake()
        {
            animTriggers = new Dictionary<string, AnimationParam>();
        }

        protected void AddTrigger(string triggerName)
        {
            if (triggerName != null && triggerName != "")
                animTriggers.Add(triggerName, new AnimationParam { paramName = triggerName, paramHash = Animator.StringToHash(triggerName) });
        }

        public void SetTrigger(string triggerName)
        {
            if (animTriggers.ContainsKey(triggerName))
                animator?.SetTrigger(animTriggers[triggerName]);
        }

        public float GetCurrentAnimLength()
        {
            return animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}