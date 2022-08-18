using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CoronaStriker.UI
{
    public class SelectableItem : MonoBehaviour
    {
        [HideInInspector] public UnityEvent onSelected;
        [HideInInspector] public UnityEvent onPressed;

        [SerializeField] private Animator animator;

        private void Reset()
        {
            onSelected = new UnityEvent();
            onPressed = new UnityEvent();

            //animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            onSelected = onSelected ?? new UnityEvent();
            onPressed = onPressed ?? new UnityEvent();

            //animator = animator ?? GetComponent<Animator>();
        }

        //private void OnDisable()
        //{
        //    animator.SetTrigger("Normal");
        //}
        //
        //public void TempMethod(string triggerName = "Normal")
        //{
        //    animator?.SetTrigger(triggerName);
        //}
    }
}