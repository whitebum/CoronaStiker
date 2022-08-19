using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Utils;

namespace CoronaStriker.Level
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public LevelData[] levelData;
        public int curLevelIndex;

        private void Awake()
        {
            levelData = Resources.LoadAll<LevelData>("");
            curLevelIndex = 0;
        }
    }
}