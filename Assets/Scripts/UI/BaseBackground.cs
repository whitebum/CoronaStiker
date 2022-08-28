using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public abstract class BaseBackground : MonoBehaviour
    {
        [SerializeField] protected Animator animator;

        protected Dictionary<string, AnimationArgs> animTriggers;

        protected virtual void Reset()
        {
            animator = GetComponent<Animator>();
        } 

        protected virtual void Awake()
        {
            animTriggers = new Dictionary<string, AnimationArgs>();
        }

        protected void AddTrigger(string triggerName)
        {
            if (triggerName != null && triggerName != "")
                animTriggers.Add(triggerName, new AnimationArgs { argName = triggerName, argHash = Animator.StringToHash(triggerName) });
        }

        protected void SetTrigger(string triggerName)
        {
            if (animTriggers.ContainsKey(triggerName))
                animator?.SetTrigger(animTriggers[triggerName]);
        }

        protected float GetCurrentAnimLength()
        {
            return animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}