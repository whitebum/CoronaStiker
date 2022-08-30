using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public sealed class ScoreViewer : BaseViewer
    {
        public void UpdateViewer(int value)
        {
            this.value.text = $"{value:000000}";
        }
    }
}