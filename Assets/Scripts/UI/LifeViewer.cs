using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.UI
{
    public sealed class LifeViewer : MonoBehaviour
    {
        [SerializeField] private Text label;
        [SerializeField] private HeartIcon[] hearts;

        private void Reset()
        {
            label = transform.Find("Label").GetComponent<Text>();
            hearts = transform.Find("Value").GetComponentsInChildren<HeartIcon>();
        }

        public void UpdateViewer(int value)
        {
            for (int idx = 0; idx < hearts.Length; ++idx)
            {
                if (idx > value)
                    hearts[idx].UpdateIcon(false);
                else
                    hearts[idx].UpdateIcon(true);
            }
        }
    }
}