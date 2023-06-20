using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonster_Bullet : MonoBehaviour
{
    public Vector3 dir;
    public float Speed;
    Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RB.velocity = dir.normalized * Speed;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
