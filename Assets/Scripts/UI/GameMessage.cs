using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public class GameMessage : MonoBehaviour
    {
        [SerializeField] private UIGraphics graphics;

        [SerializeField] private float awaitTime;
        [SerializeField] private string openTrigger;
        [SerializeField] private string closeTrigger;

        private void Reset()
        {
            graphics = GetComponent<UIGraphics>();

            awaitTime = 1.0f;

            openTrigger = "Open";
            closeTrigger = "Close";
        }

        private void Awake()
        {
            graphics.AddParam(openTrigger);
            graphics.AddParam(closeTrigger);
        }

        public void OpenMessage()
        {
            StartCoroutine(OpenMessageCoroutine());
        }

        public IEnumerator OpenMessageCoroutine()
        {
            gameObject.SetActive(true);
            graphics?.SetTrigger(openTrigger);

            yield return new WaitForSecondsRealtime(graphics.GetCurrentAnimationLength());
            yield return new WaitForSecondsRealtime(awaitTime);

            graphics?.SetTrigger(closeTrigger);

            yield return new WaitForSecondsRealtime(graphics.GetCurrentAnimationLength());

            gameObject.SetActive(false);

            yield return null;
        }
    }
}