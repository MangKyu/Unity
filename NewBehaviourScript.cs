using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hoosa
{
    public class Tower
    {
        private Transform transform;
        float timer;


        public float FireRate;
        public int FireDamage;
        public int Price;
        public float range = 15f;

        Ray shootRay = new Ray();
        RaycastHit shootHit;
        ParticleSystem gunParticles;
        Light gunLight;
        LineRenderer gunLine;
        int shootableMask;


       // private Enemy targetEnemy;
        private Transform target;

        public Transform partToRotate;
        public float turnSpeed = 10f;

        public string enemyTag = "Enemy";

        void Start()
        {

        }

        void Update()
        {
            if (Input.GetButton("Fire1") && timer >= FireRate && Time.timeScale != 0)
            {
                //  UpdateTarget();
                //   LockOnTarget();
                Turning();
                //Shoot();
            }

            if (timer >= FireRate * (0.5))
            {
                DisableEffects();
            }
        }


        public void DisableEffects()
        {
            gunLine.enabled = false;
            gunLight.enabled = false;
        }

        void Turning()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(camRay))
            {
                Vector3 dir = target.position - transform.position;
                Quaternion lookRotation = Quaternion.LookRotation(dir);
                Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            }
        }

        void LockOnTarget()
        {
            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
              //  targetEnemy = nearestEnemy.GetComponent<Enemy>();
            }
            else
            {
                target = null;
            }

        }

        void Shoot()
        {
            timer = 0f;

            gunLight.enabled = true;

            gunParticles.Stop();
            gunParticles.Play();

            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);


            if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
            {
             //   EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
              //  if (enemyHealth != null)
                {
          //          enemyHealth.TakeDamage(FireDamage, shootHit.point);
                }
                gunLine.SetPosition(1, shootHit.point);
            }
            else
            {
                gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
            }
        }

    }

}
