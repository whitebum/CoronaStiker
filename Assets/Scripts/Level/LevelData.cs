using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    public class LevelData : ScriptableObject
    {
        [SerializeField] private GameMessage gameStart;
        [SerializeField] private GameMessage gameClear;
        [SerializeField] private GameMessage gameFail;

        [SerializeField] private List<int> phaseMaxium;
        [SerializeField] private List<int> phaseLimit;

        private void OnValidate()
        {
        }
    }
}