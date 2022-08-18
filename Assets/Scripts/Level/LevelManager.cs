using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using CoronaStriker.UI;
using CoronaStriker.Utils;
using UnityEditor;

namespace CoronaStriker.Level
{
    public sealed class LevelManager : LazySingleton<LevelManager>
    {
        [SerializeField] private CanvasHandler canvas;
        [SerializeField] private FadeableUI background;

        private IEnumerator TranslateScene(string levelName)
        {
            background.gameObject.SetActive(true);
            yield return StartCoroutine(background.AppearCoroutine());

            var task = SceneManager.LoadSceneAsync(levelName);

            while (true)
            {
                if (task.isDone)
                {
                    yield return StartCoroutine(background.DisappearCoroutine());

                    yield break;
                }

                yield return null;
            }
        }

        public void LoadLevel(string levelName)
        {
            StartCoroutine(TranslateScene(levelName));
        }
    }
}