using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;

        [SerializeField] private float attackTimer = 0.0f;
        [SerializeField] private List<BulletFactory> magazine;

        private void Reset()
        {
            controller = GetComponentInParent<PlayerController>();
        }

        private void Awake()
        {
            controller = controller ?? GetComponentInParent<PlayerController>();

            foreach (var bullet in controller.playerParam.useBullet)
            {
                var newMagazine = new GameObject(bullet.name).AddComponent<BulletFactory>();

                newMagazine?.transform.SetParent(controller.transform);
                newMagazine?.Init(bullet, 30);

                magazine?.Add(newMagazine);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Z))
            {
                attackTimer += Time.deltaTime;

                if (attackTimer >= controller.playerParam.attackSpeed)
                {
                    var newBullet = magazine[0].GetBullet();
                    newBullet.transform.position = controller.transform.position;
                    attackTimer = 0.0f;
                }
            }
        }
    }
}