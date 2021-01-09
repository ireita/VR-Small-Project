using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    float damage = 10f;

    [SerializeField]
    float speed = 5000f;

    [SerializeField]
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction = target.position - transform.position;
        rb.AddForce(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag=="Player")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }


}
