using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public class MessageHUD : CanvasHandler
    {
        public GameMessage stageStart;
        public GameMessage stageClear;
        public GameMessage stageFail;

        protected override void Reset()
        {
            base.Reset();

            canvas.sortingLayerName = UILayerLevel.uiLayerName;
            canvas.sortingLayerID = SortingLayer.GetLayerValueFromName(UILayerLevel.uiLayerName);
            canvas.sortingOrder = UILayerLevel.gameMessageID;

            stageStart = transform.Find("Stage Start").GetComponent<GameMessage>();
            stageClear = transform.Find("Stage Clear").GetComponent<GameMessage>();
            stageFail = transform.Find("Stage Fail").GetComponent<GameMessage>();
        }
    }
}