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
        [SerializeField] private PlayerHUD playerHUD;

        [Header("스테이지 HUD")]
        [SerializeField] private MessageHUD gameMessages;

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

            playerHUD = GetComponentInChildren<PlayerHUD>();

            gameMessages = GetComponentInChildren<MessageHUD>();

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

            playerHealth.onDead.AddListener((value) => { StartCoroutine(GameOverCoroutine()); });
        }

        private void Start()
        {
            ChangeState(StageState.READY);
        }

        private void Update()
        {
            if (curState == StageState.ON)
            {
                gameTimer.GetTime();
            }

            if (Input.GetKeyDown(KeyCode.Space)) ChangeState(StageState.CLEAR);
                //scoreCounter?.GetScore(Random.Range(0, 1000));
        }

        public void ChangeState(StageState state)
        {
            switch ((curState = state))
            {
                case StageState.READY:
                    {
                        StartCoroutine(GameStartCoroutine());
                    }
                    break;
                case StageState.ON:
                    {
                    }
                    break;
                case StageState.CLEAR:
                    {
                        StartCoroutine(GameClearCoroutine());
                    }
                    break;
                case StageState.FAIL:
                    {
                        StartCoroutine(GameOverCoroutine());
                    }
                    break;
                case StageState.DEFAULT:
                default:
                    break;
            }
        }

        private IEnumerator GameStartCoroutine()
        {
            gameMessages.stageStart.gameObject.SetActive(true);

            playerHUD.gameObject.SetActive(false);
            yield return StartCoroutine(gameMessages?.stageStart?.OpenMessageCoroutine());
            playerHUD.gameObject.SetActive(true);

            ChangeState(StageState.ON);
        }
        
        private IEnumerator GameClearCoroutine()
        {
            playerHUD.gameObject.SetActive(false);

            gameMessages?.stageClear?.gameObject.SetActive(true);
            yield return StartCoroutine(gameMessages?.stageClear?.OpenMessageCoroutine());
        }


        private IEnumerator GameOverCoroutine()
        {
            playerHUD.gameObject.SetActive(false);

            gameMessages?.stageFail?.gameObject.SetActive(true);
            yield return StartCoroutine(gameMessages?.stageFail?.OpenMessageCoroutine());
        }
    }
}