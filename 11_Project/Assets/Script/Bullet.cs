using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 vec;
    public Type bulletType;
    Rigidbody2D RB;
    [SerializeField] float BulletSpeed = 10;
    public int Damage;
    private void Start() 
    {
        RB = GetComponent<Rigidbody2D>();
    }
    private void Update() 
    {
        Move(vec);
    }

    void Move(Vector2 vec)
    {
        RB.velocity = vec * BulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
