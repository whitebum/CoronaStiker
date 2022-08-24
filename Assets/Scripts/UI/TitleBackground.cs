using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public class TitleBackground : BaseBackground
    {
        [Header("�ִϸ��̼� Ʈ����")]
        [SerializeField] private string introTriggerName;
        [SerializeField] private string titleTriggerName;

        protected override void Reset()
        {
            base.Reset();

            introTriggerName = "Introduction";
            titleTriggerName = "Main Title";
        }

        private void Awake()
        {
            AddTrigger(introTriggerName);
            AddTrigger(titleTriggerName);
        }
    }
}