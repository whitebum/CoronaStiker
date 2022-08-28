using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Effects;
using CoronaStriker.UI;

namespace CoronaStriker.Level
{
    public class StageManager : MonoBehaviour
    {
        public static StageManager Instance { get; private set; }

        [SerializeField] private bool isBossArrives;

        [Header("스테이지 백그라운드")]
        [SerializeField] private StageBackground background;

        [Header("게임 타이머와 제한 시간")]
        [SerializeField] private float gameTime;
        [SerializeField] private float maxGameTime;

        [Header("플레이어 HUD")]
        [SerializeField] private PlayerHUD playerHUD;

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

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {

        }
    }
}