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

        public UnityEvent<int> onValueChanged;

        public void GetTime()
        {
            time = time.Add(TimeSpan.FromSeconds(Time.deltaTime));
            onValueChanged?.Invoke(time.Seconds);
        }
    }
}