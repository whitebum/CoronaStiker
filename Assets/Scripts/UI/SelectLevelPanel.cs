using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Level;

namespace CoronaStriker.UI
{
    public sealed class SelectLevelPanel : BasePanel
    {
        [SerializeField] private SelectableItem[] levels;
        [SerializeField] private FadeableUI panel;

        protected override void Awake()
        {
            base.Awake();

            levels[0].onSelected.AddListener(() => 
            {
                StartCoroutine(SceneTranslateCoroutine(0));
            });
            levels[1].onSelected.AddListener(() => 
            {
                StartCoroutine(SceneTranslateCoroutine(2));
            });
        }

        private IEnumerator SceneTranslateCoroutine(int levelIndex = 0)
        {
            panel.gameObject.SetActive(true);
            yield return StartCoroutine(panel.FadeInCoroutine());

            SceneManager.GetInstance().LoadLevel("StageScene");
        }
    }
}