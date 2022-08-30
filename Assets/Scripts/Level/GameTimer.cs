using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CoronaStriker.Level
{
    public class GameTimer : MonoBehaviour
    {
        public TimeSpan time;
        [SerializeField] private int totalTime;
        public UnityEvent<int> onValueChanged;

        private void Reset()
        {
            onValueChanged = new UnityEvent<int>();
        }

        private void Awake()
        {
            onValueChanged = onValueChanged ?? new UnityEvent<int>();

            onValueChanged.AddListener((value) => { totalTime = value; });
        }

        public void GetTime()
        {
            time = time.Add(TimeSpan.FromSeconds(Time.deltaTime));
            onValueChanged?.Invoke(time.Seconds);
        }

        public static explicit operator float(GameTimer timer) => (float)timer.time.TotalSeconds;
    }
}