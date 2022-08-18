using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Level;
using Unity.VisualScripting;

namespace CoronaStriker.UI
{
    public sealed class HallOfFamePanel : BasePanel
    {
        private const int maxCollectionLength = 5;

        [SerializeField] private PlayerRecordViewer[] playerRecordViewers;

        protected override void Reset()
        {
            base.Reset();

            playerRecordViewers = transform.GetComponentsInChildren<PlayerRecordViewer>();
        }

        protected override void Awake()
        {
            
        }

        private void Start()
        {
            var idx = 0;
            var recordDatas = RecordManager.GetInstance().playerRecords;

            while (idx < maxCollectionLength)
            {
                playerRecordViewers[idx].playerInitial = recordDatas[idx].playerInitial;
                playerRecordViewers[idx].playerScore = recordDatas[idx].playerScore;

                idx++;
            }
        }
    }
}