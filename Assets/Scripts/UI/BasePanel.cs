using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public class BasePanel : MonoBehaviour
    {
        [Header("Animation Partition")]
        [SerializeField] private UIGraphics graphics;
        
        [Space(5.0f)]
        [SerializeField] private string openTrigger = "Open";
        [SerializeField] private string closeTrigger = "Close";

        [Header("Events Partition")]
        [HideInInspector] public UnityEvent onOpen;
        [HideInInspector] public UnityEvent onClose;

        protected virtual void Reset()
        {
            graphics = GetComponent<UIGraphics>();

            onOpen = new UnityEvent();
            onClose = new UnityEvent();
        }

        protected virtual void Awake()
        {
            onOpen = onOpen ?? new UnityEvent();
            onClose = onClose ?? new UnityEvent();

            graphics.AddArg(openTrigger);
            graphics.AddArg(closeTrigger);
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

            graphics.SetTrigger(openTrigger);
            yield return new WaitForSeconds(graphics.GetCurrentAnimationLength());
            yield return null;
        }

        public IEnumerator ClosePanelCoroutine()
        {
            onClose.Invoke();

            graphics.SetTrigger(closeTrigger);
            yield return new WaitForSeconds(graphics.GetCurrentAnimationLength());

            gameObject.SetActive(false);

            yield return null;
        }
    }
}