using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Level
{
    public sealed class GameManager : Singleton<GameManager>
    {
        public LevelData[] levelData;

        private void Awake()
        {
            levelData = Resources.LoadAll<LevelData>("");
        }
    }
}