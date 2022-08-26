using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Effects
{
    public class BaseEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;

        private void Reset()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        private void Awake()
        {
            spriteRenderer = spriteRenderer ?? GetComponent<SpriteRenderer>();
            animator = animator ?? GetComponent<Animator>();
        }

        public void OnEffect()
        {
            if (gameObject.activeSelf)
                animator.playbackTime = 0.0f;

            else
                gameObject.SetActive(true);
        }

        public void OffEffect()
        {
            gameObject.SetActive(false);
        }

        public void OnEffectOnce()
        {
            gameObject.SetActive(true);
            StartCoroutine(OnEffectOnceCoroutine());
        }

        public IEnumerator OnEffectOnceCoroutine()
        {
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            gameObject.SetActive(false);
        }
    }
}