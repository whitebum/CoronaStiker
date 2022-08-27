using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoronaStriker.Core.Actors
{
    public class BulletFactory : MonoBehaviour
    {
        private Bullet origin;
        private Queue<Bullet> bulletBank;

        [SerializeField] private int limit;

        public void Init(Bullet bullet)
        {
            bulletBank = new Queue<Bullet>();
            origin = bullet;

            for (int count = 0; count < limit; ++count)
            {
                var newBullet = Instantiate(origin, transform);

                newBullet.name = origin.name;
                newBullet.transform.Translate(transform.position);
                newBullet.gameObject.SetActive(false);

                bulletBank.Enqueue(newBullet);
            }
        }

        public Bullet GetBullet()
        {
            // If Bullet's Count Is Zero
            if (bulletBank.Count <= 0)
            {
                var newBullet = Instantiate(origin, transform);

                newBullet.name = origin.name;
                newBullet.transform.Translate(transform.position);
                newBullet.gameObject.SetActive(false);

                bulletBank.Enqueue(newBullet);
            }

            var temp  = bulletBank.Dequeue();

            temp.gameObject.SetActive(true);
            temp.transform.SetParent(null);

            return temp;
        }

        public void PullBullet(Bullet bullet)
        {
            bullet.gameObject.SetActive(false);
            bullet.transform.SetParent(transform);
            bullet.transform.Translate(transform.position);
            bullet.transform.Rotate(transform.rotation.eulerAngles);

            bulletBank.Enqueue(bullet);
        }
    }
}