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

        [SerializeField] private StageState stageState;
        
        [Space(5.0f)]
        [SerializeField] private bool isBossArrives;

        [Header("�������� ��׶���")]
        [SerializeField] private StageBackground background;

        [Header("���� Ÿ�̸ӿ� ���� �ð�")]
        [SerializeField] private float gameTime;
        [SerializeField] private float maxGameTime;

        [Header("�÷��̾� HUD")]
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private PlayerHUD playerHUD;

        [Header("�������� �޽���")]
        [SerializeField] private GameMessage stageStart;
        [SerializeField] private GameMessage stageClear;
        [SerializeField] private GameMessage stageFail;

        [Header("Ŭ���� ����Ʈ")]
        [SerializeField] private BaseEffect clearEffect;

        [Header("�������� �ݹ�")]
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
            if (Input.GetKeyDown(KeyCode.Return))
            {
                clearEffect.OnEffectOnce();
                Invoke(nameof(Temp), 0.75f);
            }
        }

        public void Temp()
        { background.Cure(); }

        public void ChangeState(StageState state)
        {
            
        }
    }
}