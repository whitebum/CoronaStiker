using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace CoronaStriker.UI
{
    public class FadeableUI : MonoBehaviour
    {
        [Header("Target Graphics Partition")]
        [SerializeField] private MaskableGraphic targetGraphic;

        [Header("Member Properies Partition")]
        [SerializeField] protected bool isPlayOnAwake = false;
        [SerializeField] protected bool isLoop = false;
        
        [Space(5.0f)]
        [SerializeField] protected float fadeTime = 1.5f;
        [SerializeField] protected float waitTime;

        private void Reset()
        {
            TryGetComponent(out targetGraphic);
        }

        private void Start()
        {
            if (isPlayOnAwake)
            {
                StartCoroutine(FadeCoroutine());
            }
        }

        public void FadeInEffect()
        {
            gameObject.SetActive(true);
            StartCoroutine(FadeInCoroutine());
        }

        public void FadeOutEffect()
        {
            gameObject.SetActive(true);
            StartCoroutine(FadeOutCoroutine());
        }

        public void FadeEffect()
        {
            gameObject.SetActive(true);
            StartCoroutine(FadeCoroutine());
        }

        public void AppearEffect()
        {
            gameObject.SetActive(true);
            StartCoroutine(AppearCoroutine());
        }

        public void DissapearEffect()
        {
            gameObject.SetActive(true);
            StartCoroutine(DisappearCoroutine());
        }

        public IEnumerator FadeOutCoroutine()
        {
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 1.0f);

            while (targetGraphic.color.a > 0.0f)
            {
                targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, targetGraphic.color.a - (Time.deltaTime * fadeTime));
                yield return null;
            }
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 0.0f);
            yield return null;
        }

        public IEnumerator FadeInCoroutine()
        {
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 0.0f);

            while (targetGraphic.color.a < 1.0f)
            {
                targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, targetGraphic.color.a + (Time.deltaTime * fadeTime));
                yield return null;
            }
            targetGraphic.color = new Color(targetGraphic.color.r, targetGraphic.color.g, targetGraphic.color.b, 1.0f);
            yield return null;
        }

        public IEnumerator FadeCoroutine()
        {
            var waitForSeconds = waitTime > 0.0f ? new WaitForSeconds(waitTime) : null;

            do
            {
                yield return StartCoroutine(FadeInCoroutine());
                yield return waitForSeconds;
                yield return StartCoroutine(FadeOutCoroutine());
            } while (isLoop);

            gameObject.SetActive(false);

            yield return null;
        }

        public IEnumerator AppearCoroutine()
        {
            yield return StartCoroutine(FadeInCoroutine());

            yield return null;
        }

        public IEnumerator DisappearCoroutine()
        {
            yield return StartCoroutine(FadeOutCoroutine());

            gameObject.SetActive(false);

            yield return null;
        }
    }
}