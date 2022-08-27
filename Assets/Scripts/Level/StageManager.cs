using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    public class StageManager : MonoBehaviour
    {
        public static StageManager Instance { get; private set; }

        [SerializeField] private bool isBossArrives;

        [SerializeField] private float gameTime;
        [SerializeField] private float maxGameTime;

        [SerializeField] private GameObject scoreViewer;
        [SerializeField] private GameObject maxScoreViewer;
        [SerializeField] private GameObject playerLifeViewer;

        [SerializeField] private GameObject background;

        [SerializeField] private GameObject stageStart;
        [SerializeField] private GameObject stageClear;
        [SerializeField] private GameObject stageFail;

        [SerializeField] private GameObject clearEffect;

        [SerializeField] private StageEvent onStart;
        [SerializeField] private StageEvent onClear;
        [SerializeField] private StageEvent onFail;

        private void Awake()
        {
            Instance = this;
        }
    }
}