using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Level;

namespace CoronaStriker.UI
{
    public class PlayerHUDManager : MonoBehaviour
    {
        [SerializeField] private StageManager stageManager;
        
        [SerializeField] private TimeViewer timeViewer;
        [SerializeField] private ScoreViewer scoreViewer;
        [SerializeField] private LifeViewer lifeViewer;

        private void Reset()
        {
            stageManager = GetComponentInParent<StageManager>();

            timeViewer = GetComponentInChildren<TimeViewer>();
            scoreViewer = GetComponentInChildren<ScoreViewer>();
            lifeViewer = GetComponentInChildren<LifeViewer>();
        }

        private void Awake()
        {
            stageManager.scoreCounter.onValueChanged.AddListener((value) => { scoreViewer.UpdateViewer(value); });
            stageManager.gameTimer.onValueChanged.AddListener((value) => { timeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onHeal.AddListener((value) => { lifeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onHurt.AddListener((value) => { lifeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onDead.AddListener((value) => { lifeViewer.UpdateViewer(value); });
        }
    }
}