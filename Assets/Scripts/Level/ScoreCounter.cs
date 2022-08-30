using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Level
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private int curScore;
        [SerializeField] private int maxScore;

        public UnityEvent<int> onValueChanged;

        private void Reset()
        {
            onValueChanged = new UnityEvent<int>();
        }

        private void Awake()
        {
            onValueChanged = onValueChanged ?? new UnityEvent<int>();
        }

        public void GetScore(int value)
        {
            if (curScore > maxScore)
            {
                curScore += value;

                if (curScore > maxScore)
                    curScore = maxScore;

                onValueChanged.Invoke(curScore);
            }
        }
    }
}