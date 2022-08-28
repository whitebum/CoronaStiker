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
            infectionTrigger = "";
            cureTrigger = "";
        }

        protected override void Awake()
        {
            AddTrigger(infectionTrigger);
            AddTrigger(cureTrigger);
        }
    }
}
