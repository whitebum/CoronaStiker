using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public class StageBackground : BaseBackground
    {
        [SerializeField] private string infectionTrigger;
        [SerializeField] private string cureTrigger;

        protected override void Reset()
        {
            base.Reset();

            infectionTrigger = "";
            cureTrigger = "";
        }

        protected override void Awake()
        {
            base.Awake();

            AddTrigger(infectionTrigger);
            AddTrigger(cureTrigger);
        }

        public void Infection()
        {
            SetTrigger(infectionTrigger);
        }

        public void Cure()
        {
            SetTrigger(cureTrigger);
        }
    }
}
