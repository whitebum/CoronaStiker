using Assets.Scripts.Core.Actors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoronaStriker.Core.Utils;

namespace CoronaStriker.Core.Actors
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Player player;

        [SerializeField] private string horizontalKey;
        [SerializeField] private string verticalKey;

        [SerializeField] private KeyCode attackKey1;
        [SerializeField] private KeyCode attackKey2;

        private void Reset()
        {
            player = GetComponent<Player>();

            horizontalKey = "Horizontal";
            verticalKey = "Vertical";

            attackKey1 = KeyCode.Z;
            attackKey2 = KeyCode.X;
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                MovePlayer();
            }
        }
        
        private void MovePlayer()
        {
            var horizontal  = Input.GetAxisRaw(horizontalKey);
            var vertical    = Input.GetAxisRaw(verticalKey);

            var moveDirection = player.playerData.moveSpeed * 
                                Time.deltaTime * 
                                new Vector3(horizontal, vertical, 0.0f);

            player.transform.Translate(moveDirection);
        }
    }
}