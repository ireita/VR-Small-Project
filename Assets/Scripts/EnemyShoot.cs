using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject projectile;

    Transform target;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    float turnSpeed = 5f;
    float firerate = 0.2f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        firerate -= Time.deltaTime;

        Vector3 direction =  transform.position - target.position ;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);

        if (firerate<=0)
        {
            firerate = 1.5f;
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(projectile, shootPoint.position, shootPoint.rotation);
    }
}
