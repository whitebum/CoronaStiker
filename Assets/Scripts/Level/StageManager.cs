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

        [Header("타이머")]
        public GameTimer gameTimer;
        public float maxGameTime;

        [Header("스코어")]
        public ScoreCounter scoreCounter;
        public int maxScoreCount;

        [Header("플레이어 HUD")]
        public PlayerHealth playerHealth;
        [SerializeField] private PlayerHUD playerHUD;

        [Header("스테이지 HUD")]
        [SerializeField] private MessageHUD gameMessages;

        [Header("클리어 이펙트")]
        [SerializeField] private ClearEffect clearEffect;

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
            maxGameTime = 599.0f;

            scoreCounter = GetComponentInChildren<ScoreCounter>();
            maxScoreCount = 999999;

            playerHUD = GetComponentInChildren<PlayerHUD>();

            gameMessages = GetComponentInChildren<MessageHUD>();

            clearEffect = GetComponentInChildren<ClearEffect>();

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

            playerHealth = FindObjectOfType<PlayerHealth>();

            onReady = onReady ?? new StageEvent();
            onStart = onStart ?? new StageEvent();
            onClearStart = onClearStart ?? new StageEvent();
            onClearEnd = onClearEnd ?? new StageEvent();
            onFailStart = onFailStart ?? new StageEvent();
            onFailEnd = onFailEnd ?? new StageEvent();

            playerHealth?.onDead?.AddListener((value) => { StartCoroutine(GameOverCoroutine()); });
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

            if (Input.GetKeyDown(KeyCode.C)) ChangeState(StageState.CLEAR);
            //scoreCounter?.GetScore(Random.Range(0, 1000));

            if (Input.GetKeyDown(KeyCode.F)) ChangeState(StageState.FAIL);
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

            clearEffect?.OnEffect();

            yield return new WaitForSecondsRealtime(clearEffect?.graphics.GetCurrentAnimationLength() / 2.0f ?? 0.0f);
            
            gameMessages?.stageClear?.gameObject.SetActive(true);
            background?.SetCure();

            yield return StartCoroutine(gameMessages?.stageClear?.OpenMessageCoroutine());
        }


        private IEnumerator GameOverCoroutine()
        {
            gameMessages?.stageFail?.gameObject.SetActive(true);

            playerHUD.gameObject.SetActive(false);

            gameMessages?.stageFail?.gameObject.SetActive(true);
            yield return StartCoroutine(gameMessages?.stageFail?.OpenMessageCoroutine());

            SceneManager.GetInstance().LoadLevel("TitleScene");
        }
    }
}