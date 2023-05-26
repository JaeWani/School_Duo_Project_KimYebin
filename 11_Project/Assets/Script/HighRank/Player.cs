using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Left,
    Right
}

public class Player : MonoBehaviour
{

    [Header ("Wepon")]
    [SerializeField] GameObject WeponPos;
    [SerializeField] float posX;
    [SerializeField] float posY;
    [Header ("State")]
    public Direction direction = Direction.Right;

    [Header("Stat")]
    public float Speed;
    public float JumpPower;
    [SerializeField] Vector2 groundCastOffset;
    [SerializeField] Vector2 groundCastSize;
    public bool CanJump= true;
    [Header("Wepon")]
    public Wepon UseWepon;
    public Wepon Wepon_1;
    public Wepon Wepon_2;

    public SpriteRenderer WeponSpr;

    [Header("Private")]
    private Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        ChangeWepon();
    }
    private void Update()
    {
        Move();
        SetDirection();
        Jump();
    }
    public virtual void Move()
    {
        float x = Input.GetAxis("Horizontal") * Speed;
        Vector2 vec = new Vector2(x, RB.velocity.y);
        RB.velocity = vec;
    }
    private void ChangeWepon()
    {
        WeponSpr = WeponPos.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }
    private void SetDirection()
    {
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.Right;
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.Left;

        SetWeponPos();
    }
    private void SetWeponPos()
    {
        switch(direction)
        {
            case Direction.Left:
            WeponPos.transform.localPosition = new Vector2(-posX,posY);
            WeponSpr.flipX = true;
            break;

            case Direction.Right:
            WeponPos.transform.localPosition = new Vector2(posX,posY);
            WeponSpr.flipX = false;
            break;
        }
    }
    protected void Jump()
    {
        CanJump = Physics2D.BoxCast((Vector2)transform.position + groundCastOffset, groundCastSize,0f,Vector2.zero,0,LayerMask.GetMask("Ground"));
        if(Input.GetKeyDown(KeyCode.Space) && CanJump == true)
        {
            RB.AddForce(Vector2.up * JumpPower ,ForceMode2D.Impulse);
            CanJump = false;
        }
    }
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Vector2 center = groundCastOffset + (Vector2)transform.position;
        Gizmos.DrawCube(center, groundCastSize);
    }
}
