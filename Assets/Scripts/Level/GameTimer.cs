using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    public class GameTimer : MonoBehaviour
    {
        public TimeSpan time;

        public void Update()
        {
            time = time.Add(TimeSpan.FromSeconds(Time.deltaTime));
        }
    }
}