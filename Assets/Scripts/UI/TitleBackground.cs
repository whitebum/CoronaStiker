using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public class TitleBackground : BaseBackground
    {
        [Header("애니메이션 트리거")]
        [SerializeField] private string introTrigger;
        [SerializeField] private string titleTrigger;

        protected override void Reset()
        {
            base.Reset();

            introTrigger = "Introduction";
            titleTrigger = "Main Title";
        }

        protected override void Awake()
        {
            base.Awake();

            graphics.AddParam(introTrigger);
            graphics.AddParam(titleTrigger);
        }

        public void SetIntruductionScreen()
        {
            graphics.SetTrigger(introTrigger);
        }

        public void SetTitleScreen()
        {
            graphics.SetTrigger(titleTrigger);
        }
    }
}