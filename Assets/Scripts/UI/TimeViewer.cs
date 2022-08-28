using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoronaStriker.UI
{
    public sealed class TimeViewer : BaseViewer
    {
        protected override void Reset()
        {
            base.Reset();

            label.text = "TIME: ";
            value.text = "00:00";
        }

        public void UpdateViewer(float time)
        {
            var temp = TimeSpan.FromSeconds(time += Time.deltaTime);
            var temp2 = new DateTime().Add(temp).ToString("mm:ss");

            
            value.text = temp2;
        }
    }
}