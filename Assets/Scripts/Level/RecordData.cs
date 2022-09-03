using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    [Serializable]
    public record RecordData
    {
        public string playerInitial;
        public int playerScore;

        public float clearTime;
        public int killCount;

        public static explicit operator string(RecordData record)
        {
            return $"playerInital: {record.playerInitial},\n" +
                   $"playerScore: {record.playerScore},\n" +
                   $"clearTime: {record.clearTime},\n" +
                   $"killCount: {record.killCount}";
        }
    }
}