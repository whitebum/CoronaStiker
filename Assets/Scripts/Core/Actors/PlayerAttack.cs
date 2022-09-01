using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerController controller;

        [SerializeField] private int level = 1;
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

                if (attackTimer >= controller.playerParam.attackTime)
                {
                    switch (level)
                    {
                        default:
                        case 1:
                            {
                                var newBullet = magazine[0].GetBullet();
                                newBullet.transform.position = controller.transform.position;
                                attackTimer = 0.0f;
                            }
                            break;
                        case 2:
                            {
                                var newBullet1 = magazine[0].GetBullet();
                                newBullet1.transform.position = controller.transform.position + new Vector3(+0.2f, 0.0f, 0.0f);

                                var newBullet2 = magazine[0].GetBullet();
                                newBullet2.transform.position = controller.transform.position + new Vector3(-0.2f, 0.0f, 0.0f);
                                attackTimer = 0.0f;
                            }
                            break;
                        case 3:
                            {
                                var newBullet1 = magazine[0].GetBullet();
                                newBullet1.transform.position = controller.transform.position + new Vector3(+0.2f, 0.0f, 0.0f);

                                var newBullet2 = magazine[1].GetBullet();
                                newBullet2.transform.position = controller.transform.position + new Vector3(0.0f, 0.0f, 0.0f);

                                var newBullet3 = magazine[0].GetBullet();
                                newBullet3.transform.position = controller.transform.position + new Vector3(-0.2f, 0.0f, 0.0f);
                                attackTimer = 0.0f;
                            }
                            break;
                        case 4:
                            {
                                var newBullet1 = magazine[0].GetBullet();
                                newBullet1.transform.position = controller.transform.position + new Vector3(+0.2f, 0.0f, 0.0f);

                                var newBullet2 = magazine[1].GetBullet();
                                newBullet2.transform.position = controller.transform.position + new Vector3(0.0f, 0.0f, 0.0f);

                                var newBullet3 = magazine[0].GetBullet();
                                newBullet3.transform.position = controller.transform.position + new Vector3(-0.2f, 0.0f, 0.0f);

                                var newBullet4 = magazine[2].GetBullet();
                                newBullet4.transform.position = controller.transform.position + new Vector3(-0.5f, 0.0f, 0.0f);
                                newBullet4.transform.rotation = Quaternion.Euler(new Vector3(0.2f, 0.0f, 10.0f));

                                var newBullet5 = magazine[2].GetBullet();
                                newBullet5.transform.position = controller.transform.position + new Vector3(0.5f, 0.0f, 0.0f);
                                newBullet5.transform.rotation = Quaternion.Euler(new Vector3(0.2f, 0.0f, -10.0f));

                                attackTimer = 0.0f;
                            }
                            break;
                    }
                }
            }
            else
            {
                attackTimer = 0.0f;
            }
        }
    }
}