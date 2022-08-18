using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoronaStriker.Utils;

namespace CoronaStriker.UI
{
    public class TitleBackground : MonoBehaviour
    {
        [Header("Member Instance Partition")]
        [SerializeField] private Image background;
        [SerializeField] private Animator backgroundAnim;
        
        [Header("Animation Trigger Partition")]
        [SerializeField] private AnimationTrigger introTrigger;
        [SerializeField] private AnimationTrigger titleTrigger;

        public float getCurrentAnimLength { get => backgroundAnim.GetCurrentAnimatorStateInfo(0).length; }

        private void Reset()
        {
            TryGetComponent(out background);
            TryGetComponent(out backgroundAnim);

            introTrigger = new AnimationTrigger("Introduction");
            titleTrigger = new AnimationTrigger("Main Title");
        }

        private void Awake()
        {
            introTrigger = introTrigger ?? new AnimationTrigger("Introduction");
            titleTrigger = titleTrigger ?? new AnimationTrigger("Main Title") ;
        }

        public void ChangeMainTitle()
        {
            backgroundAnim.SetTrigger(titleTrigger.triggerHash);
        }
    }
}