using CoronaStriker.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoronaStriker.UI
{
    public class HeartIcon : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private Animator animator;

        private Dictionary<string, AnimationArgs> animTriggers;

        [SerializeField] private string fullTrigger;
        [SerializeField] private string nullTrigger;

        private void Reset()
        {
            image = GetComponent<Image>();
            animator = GetComponent<Animator>();

            fullTrigger = "";
            nullTrigger = "";
        }

        private void Awake()
        {
            animTriggers = new Dictionary<string, AnimationArgs>();

            if (fullTrigger != "")
                animTriggers.Add(fullTrigger, new AnimationArgs { argName = fullTrigger, argHash = Animator.StringToHash(fullTrigger) });

            if (nullTrigger != "")
                animTriggers.Add(nullTrigger, new AnimationArgs { argName = nullTrigger, argHash = Animator.StringToHash(nullTrigger) });
        }

        public void UpdateIcon(bool isActive)
        {
            if (isActive)
                if (animTriggers.ContainsKey(fullTrigger))
                    animator?.SetTrigger(fullTrigger);

            if (!isActive)
                if (animTriggers.ContainsKey(nullTrigger))
                    animator?.SetTrigger(nullTrigger);
        }
    }
}