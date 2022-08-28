using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.UI
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private TimeViewer timeViewer;
        [SerializeField] private ScoreViewer scoreViewer;
        [SerializeField] private LifeViewer lifeViewer;
    }
}