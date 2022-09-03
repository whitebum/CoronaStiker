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

            infectionTrigger = "Infection";
            cureTrigger = "Cure";
        }

        protected override void Awake()
        {
            base.Awake();

            graphics.AddParam(infectionTrigger);
            graphics.AddParam(cureTrigger);
        }

        public void SetInfection()
        {
            graphics.SetTrigger(infectionTrigger);
        }

        public void SetCure()
        {
            graphics.SetTrigger(cureTrigger);
        }
    }
}
