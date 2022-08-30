using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Level
{
    [Serializable]
    public record PlayerRecord
    {
        [SerializeField] private string m_playerInitial;
        [SerializeField] private string m_playerScore;

        public string playerInitial { get => m_playerInitial; private set => m_playerInitial = value; }
        public string playerScore { get => $"{m_playerScore:000000}"; private set => m_playerScore = value; }

        public PlayerRecord(string playerInitial, string playerScore)
        {
            (this.playerInitial, this.playerScore) = (playerInitial, playerScore);
        }

        public PlayerRecord(string playerInitial, int playerScore)
        {
            (this.playerInitial, this.playerScore) = (playerInitial, $"{playerScore:000000}");
        }

        public static explicit operator string(PlayerRecord record)
        {
            return $"{record.playerInitial} {record.playerScore}";
        }
    }
}