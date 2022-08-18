using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CoronaStriker.UI;

namespace CoronaStriker.Level
{
    public sealed class TitleScene : MonoBehaviour
    {
        [Header("Member Objects Partition")]
        [SerializeField] private TitleBackground background;

        [SerializeField] private bool isEndedIntro = false;

        [Header("Events Partition")]
        [SerializeField] private UnityEvent onIntroBegin;
        [SerializeField] private UnityEvent onIntroEnd;

        private void Reset()
        {
            onIntroBegin = new UnityEvent();
            onIntroEnd = new UnityEvent();
        }

        private void Awake()
        {
            onIntroBegin = onIntroBegin ?? new UnityEvent();
            onIntroEnd = onIntroEnd ?? new UnityEvent();

            onIntroBegin.AddListener(() => isEndedIntro = false);
            onIntroEnd.AddListener(() => isEndedIntro = true);
        }

        private IEnumerator Start()
        {
            onIntroBegin.Invoke();

            yield return new WaitForSeconds(background.getCurrentAnimLength);

            onIntroEnd.Invoke();

            yield return null;
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
                    LevelManager.GetInstance().LoadLevel("MenuScene");
                }
            }
        }
    }
}