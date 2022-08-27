using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public class FlashEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void Reset()
        {
            spriteRenderer = GetComponentInParent<SpriteRenderer>();
        }

        private IEnumerator Start()
        {
            while(true)
            {
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                yield return new WaitForSeconds(0.2f);
                spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }

        private void OnDisable()
        {
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            StopCoroutine(nameof(Start));
        }

        public void OnEffect()
        {
            gameObject.SetActive(true);
        }

        public void OffEffect()
        {
            gameObject.SetActive(false);
        }

        private IEnumerator FlashCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}