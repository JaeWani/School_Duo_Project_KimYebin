using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 vec;

    Rigidbody2D RB;
    [SerializeField] float BulletSpeed = 10;
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
}
