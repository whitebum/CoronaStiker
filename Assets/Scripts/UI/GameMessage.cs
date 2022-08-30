using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public class GameMessage : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [Space(5.0f)]
        [SerializeField] private float waitTime;
        [SerializeField] private bool isShouldDisable = true;

        private Dictionary<string, AnimationArgs> animationArgs;

        [Space(5.0f)]
        [SerializeField] private string openTrigger = "Open";
        [SerializeField] private string closeTrigger = "Close";

        private void Reset()
        {
            animator = GetComponent<Animator>();

            openTrigger = "";
            closeTrigger = "";
        }

        private void Awake()
        {
            animator = animator ?? GetComponent<Animator>();

            animationArgs = new Dictionary<string, AnimationArgs>();

            animationArgs.Add(openTrigger, new AnimationArgs { argName = openTrigger, argHash = Animator.StringToHash(openTrigger) });
            animationArgs.Add(closeTrigger, new AnimationArgs { argName = closeTrigger, argHash = Animator.StringToHash(closeTrigger) });
        }

        public void OpenMessage()
        {
            if (!gameObject.activeSelf)
                gameObject.SetActive(true);

            StartCoroutine(OpenMessageCoroutine());
        }

        public void CloseMessage()
        {
            StartCoroutine(OpenMessageCoroutine());
        }

        public IEnumerator OpenMessageCoroutine()
        {
            if (animationArgs?.ContainsKey(openTrigger) == true)
                animator?.SetTrigger(animationArgs[openTrigger]);

            yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

            yield return new WaitForSecondsRealtime(waitTime);

            if (animationArgs?.ContainsKey(closeTrigger) == true)
                animator?.SetTrigger(animationArgs[closeTrigger]);

            yield return new WaitForSecondsRealtime(animator.GetCurrentAnimatorStateInfo(0).length);

            gameObject.SetActive(false);
        }
    }
}