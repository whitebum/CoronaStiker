using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.UI
{
    public class BasePanel : MonoBehaviour
    {
        [Header("Animation Partition")]
        [SerializeField] private Animator animator;
        
        [Space(5.0f)]
        [SerializeField] private string openTriggerName = "Open";
        private readonly int openTriggerHash = Animator.StringToHash("Open");
        [SerializeField] private string closeTriggerName = "Close";
        private readonly int closeTriggerHash = Animator.StringToHash("Close");

        [Header("Events Partition")]
        [HideInInspector] public UnityEvent onOpen;
        [HideInInspector] public UnityEvent onClose;

        protected virtual void Reset()
        {
            TryGetComponent(out animator);

            onOpen = new UnityEvent();
            onClose = new UnityEvent();
        }

        protected virtual void Awake()
        {
            onOpen = onOpen ?? new UnityEvent();
            onClose = onClose ?? new UnityEvent();
        }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
        }

        public void OpenPanel()
        {
            gameObject.SetActive(true);

            StartCoroutine(OpenPanelCoroutine());
        }

        public void ClosePanel()
        {
            gameObject.SetActive(true);

            StartCoroutine(ClosePanelCoroutine());
        }

        public IEnumerator OpenPanelCoroutine()
        {
            onOpen.Invoke();

            animator.SetTrigger(openTriggerHash);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
            yield return null;
        }

        public IEnumerator ClosePanelCoroutine()
        {
            onClose.Invoke();

            animator.SetTrigger("Close");
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            gameObject.SetActive(false);

            yield return null;
        }
    }
}