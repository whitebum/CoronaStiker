using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CoronaStriker.UI
{
    public sealed class PlayerRecordViewer : MonoBehaviour
    {
        [SerializeField] private Text m_playerInitial;
        [SerializeField] private Text m_playerScore;

        public string playerInitial
        {
            get => m_playerInitial.text;
            set => m_playerInitial.text = value;
        }

        public string playerScore
        {
            get => m_playerScore.text;
            set => m_playerScore.text = value;
        }

        private void Reset()
        {
            transform.Find("Initial").TryGetComponent(out m_playerInitial);
            transform.Find("Score").TryGetComponent(out m_playerScore);
        }
    }
}