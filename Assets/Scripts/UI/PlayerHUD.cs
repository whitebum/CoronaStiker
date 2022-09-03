using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Level;

namespace CoronaStriker.UI
{
    public class PlayerHUD : CanvasHandler
    {
        [SerializeField] private StageManager stageManager;
        
        [SerializeField] private TimeViewer timeViewer;
        [SerializeField] private ScoreViewer scoreViewer;
        [SerializeField] private LifeViewer lifeViewer;

        protected override void Reset()
        {
            base.Reset();

            canvas.sortingLayerName = UILayerLevel.uiLayerName;
            canvas.sortingLayerID = SortingLayer.GetLayerValueFromName(UILayerLevel.uiLayerName);
            canvas.sortingOrder = UILayerLevel.playerHUDID;

            timeViewer = GetComponentInChildren<TimeViewer>();
            scoreViewer = GetComponentInChildren<ScoreViewer>();
            lifeViewer = GetComponentInChildren<LifeViewer>();
        }

        protected override void Awake()
        {
            base.Reset();

            stageManager.scoreCounter.onValueChanged.AddListener((value) => { scoreViewer.UpdateViewer(value); });
            stageManager.gameTimer.onValueChanged.AddListener((value) => { timeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onHeal.AddListener((value) => { lifeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onHurt.AddListener((value) => { lifeViewer.UpdateViewer(value); });
            stageManager.playerHealth.onDead.AddListener((value) => { lifeViewer.UpdateViewer(value); });
        }
    }
}