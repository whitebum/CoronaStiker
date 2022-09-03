using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.UI;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Level
{
    public sealed class TitleScene : MonoBehaviour
    {
        [Header("Member Objects Partition")]
        [SerializeField] private TitleBackground background;

        [Space(5.0f)]
        [SerializeField] private bool isEndedIntro;

        [Space(5.0f)]
        [SerializeField] private Transform titleLogo;
        [SerializeField] private Transform pressLogo;
        [SerializeField] private FadeableUI whitePanel;

        [Header("Events Partition")]
        [HideInInspector] public UnityEvent onIntroBegin;
        [HideInInspector] public UnityEvent onIntroEnd;

        private void Reset()
        {
            onIntroBegin = new UnityEvent();
            onIntroEnd = new UnityEvent();
        }

        private void Awake()
        {
            onIntroBegin = onIntroBegin ?? new UnityEvent();
            onIntroEnd = onIntroEnd ?? new UnityEvent();

            onIntroBegin.AddListener(() => { isEndedIntro = false; });
            onIntroBegin.AddListener(() => { background.SetIntruductionScreen(); });
            onIntroBegin.AddListener(() => { titleLogo.gameObject.SetActive(false); });
            onIntroBegin.AddListener(() => { pressLogo.gameObject.SetActive(false); });
            onIntroBegin.AddListener(() => { StartCoroutine(TurnTitle()); });

            onIntroEnd.AddListener(() => { isEndedIntro = true; });
            onIntroEnd.AddListener(() => { background.SetTitleScreen(); });
            onIntroEnd.AddListener(() => { titleLogo.gameObject.SetActive(true); });
            onIntroEnd.AddListener(() => { pressLogo.gameObject.SetActive(true); });
            onIntroEnd.AddListener(() => { whitePanel.FadeOutEffect(); });
        }

        private void Start()
        {
            onIntroBegin.Invoke();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!isEndedIntro)
                {
                    StopAllCoroutines();

                    onIntroEnd.Invoke();

                    return;
                }

                if (isEndedIntro)
                {
                    SceneManager.GetInstance().LoadLevel("MenuScene");
                }
            }
        }

        private IEnumerator TurnTitle()
        {
            yield return new WaitForSecondsRealtime(background.graphics.GetCurrentAnimationLength());
            onIntroEnd.Invoke();
        }
    }
}