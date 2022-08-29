using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Level;

namespace CoronaStriker.UI
{
    public class PlayerHUDManager : MonoBehaviour
    {
        [SerializeField] private PlayerHUD playerHUD;
        [SerializeField] private StageManager stageManager;

        private void Reset()
        {
            playerHUD = GetComponent<PlayerHUD>();
        }

        private void Awake()
        {
            
        }
    }
}