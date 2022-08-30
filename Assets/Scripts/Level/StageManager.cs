using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Actors;
using CoronaStriker.Core.Effects;
using CoronaStriker.UI;

namespace CoronaStriker.Level
{
    public class StageManager : MonoBehaviour
    {
        public static StageManager Instance { get; private set; }

        [SerializeField] private StageState curState;
        
        [Space(5.0f)]
        [SerializeField] private bool isBossArrives;

        [Header("스테이지 백그라운드")]
        [SerializeField] private StageBackground background;

        [Header("게임 타이머와 제한 시간")]
        [SerializeField] private float gameTime;
        [SerializeField] private float maxGameTime;

        [Header("")]
        public GameTimer gameTimer;
        public ScoreCounter scoreCounter;

        [Header("플레이어 HUD")]
        public PlayerHealth playerHealth;
        [SerializeField] private PlayerHUDManager playerHUD;

        [Header("스테이지 메시지")]
        [SerializeField] private GameMessage stageStart;
        [SerializeField] private GameMessage stageClear;
        [SerializeField] private GameMessage stageFail;

        [Header("클리어 이펙트")]
        [SerializeField] private BaseEffect clearEffect;

        [Header("스테이지 콜백")]
        [SerializeField] private StageEvent onReady;
        [SerializeField] private StageEvent onStart;
        [SerializeField] private StageEvent onClearStart;
        [SerializeField] private StageEvent onClearEnd;
        [SerializeField] private StageEvent onFailStart;
        [SerializeField] private StageEvent onFailEnd;

        private void Reset()
        {
            background = GetComponentInChildren<StageBackground>();

            gameTimer = GetComponentInChildren<GameTimer>();
            scoreCounter = GetComponentInChildren<ScoreCounter>();

            onReady = new StageEvent();
            onStart = new StageEvent();
            onClearStart = new StageEvent();
            onClearEnd = new StageEvent();
            onFailStart = new StageEvent();
            onFailEnd = new StageEvent();
        }

        private void Awake()
        {
            Instance = this;

            onReady = onReady ?? new StageEvent();
            onStart = onStart ?? new StageEvent();
            onClearStart = onClearStart ?? new StageEvent();
            onClearEnd = onClearEnd ?? new StageEvent();
            onFailStart = onFailStart ?? new StageEvent();
            onFailEnd = onFailEnd ?? new StageEvent();
        }

        private void Update()
        {
            if (curState == StageState.ON)
            {
                gameTimer.GetTime();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                clearEffect.OnEffectOnce();
                Invoke(nameof(Temp), 0.75f);
            }

            if (Input.GetKeyDown(KeyCode.Space))
                scoreCounter?.GetScore(Random.Range(0, 1000));
        }

        public void Temp()
        { background.Cure(); }

        public void ChangeState(StageState state)
        {
            switch ((curState = state))
            {
                case StageState.READY:
                    {
                        onReady.Invoke();
                    }
                    break;
                case StageState.ON:
                    {
                        onStart.Invoke();
                    }
                    break;
                case StageState.CLEAR:
                    {
                        onClearStart.Invoke();
                    }
                    break;
                case StageState.FAIL:
                    {
                        onFailStart.Invoke();
                    }
                    break;
                case StageState.DEFAULT:
                default:
                    break;
            }
        }
    }
}