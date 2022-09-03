using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using CoronaStriker.UI;
using CoronaStriker.Core.Utils;
using UnityEditor;

namespace CoronaStriker.Level
{
    public sealed class SceneManager : Singleton<SceneManager>
    {
        [SerializeField] private CanvasHandler canvas;
        [SerializeField] private FadeableUI background;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            // 경로 정정하자.
            if (!transform.Find("").TryGetComponent(out canvas))
            {
                canvas = Instantiate(Resources.Load<CanvasHandler>("Canvas"), transform);
            }

            if (!canvas.transform.Find("").TryGetComponent(out background))
            {
                background = Instantiate(Resources.Load<FadeableUI>("Loading Background"), canvas.transform);
            }
        }

        private IEnumerator TranslateScene(string levelName)
        {
            background.gameObject.SetActive(true);
            yield return StartCoroutine(background.AppearCoroutine());

            //UnityEngine.SceneManagement.SceneManager. = false;
            //var levelIdx = UnityEngine.SceneManagement.SceneManager.GetSceneByName(levelName);
            //var loadTask = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelIdx.buildIndex, LoadSceneMode.Single);

            var loadTask = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            //loadTask.allowSceneActivation = false;

            while (true)
            {
                if (loadTask.isDone)
                {

                    //loadTask.allowSceneActivation = true;

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