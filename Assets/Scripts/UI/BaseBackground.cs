using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public class BaseBackground : MonoBehaviour
    {
        [Header("백그라운드 애니메이터")]
        [SerializeField] private Animator animator;
        
        private Dictionary<string, int> triggers = new Dictionary<string, int>();

        protected virtual void Reset()
        {
            animator = GetComponent<Animator>();
        } 

        public void AddTrigger(string triggerName)
        {
            triggers.Add(triggerName, Animator.StringToHash(triggerName));
        }

        public void SetTrigger(string triggerName)
        {
            if (triggers.ContainsKey(triggerName) != false)
                animator.SetTrigger(triggers[triggerName]);
        }

        public float GetCurrentAnimLength()
        {
            return animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}