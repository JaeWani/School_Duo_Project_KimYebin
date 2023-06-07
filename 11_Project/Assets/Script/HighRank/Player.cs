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

    [Header("Wepon")]
    [SerializeField] GameObject WeponPos;
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] GameObject Sub_WeponPos;
    [SerializeField] float Sub_PosX;
    [SerializeField] float Sub_PosY;
    [Header("State")]
    public Direction direction = Direction.Right;

    [Header("Stat")]
    public float Speed;
    public float JumpPower;
    [SerializeField] Vector2 groundCastOffset;
    [SerializeField] Vector2 groundCastSize;
    public bool CanJump = true;
    [Header("Wepon")]
    public Wepon UseWepon;
    public Wepon Wepon_1;
    public Wepon Wepon_2;


    public SpriteRenderer WeponSpr;

    [Header("Private")]
    private Rigidbody2D RB;

    private void Start()
    {
        GetWepon();
        RB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
        SetDirection();
        ChageSlot();
        Jump();
    }
    public virtual void Move()
    {
        float x = Input.GetAxis("Horizontal") * Speed;
        Vector2 vec = new Vector2(x, RB.velocity.y);
        RB.velocity = vec;
    }
    private void SetDirection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.Right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.Left;

        SetWeponPos();
    }
    private void SetWeponPos()
    {
        switch (direction)
        {
            case Direction.Left:
                WeponPos.transform.localPosition = new Vector2(-posX, posY);
                Sub_WeponPos.transform.localPosition = new Vector2((Sub_PosX) * -1,Sub_PosY);
                Wepon_1.transform.localRotation = Quaternion.Euler(0,180,0);
                Wepon_2.transform.localRotation = Quaternion.Euler(180,0,0);
                break;

            case Direction.Right:
                WeponPos.transform.localPosition = new Vector2(posX, posY);
                Sub_WeponPos.transform.localPosition = new Vector2((Sub_PosX) * 1,Sub_PosY);
                Wepon_1.transform.localRotation = Quaternion.Euler(0,0,0);
                Wepon_2.transform.localRotation = Quaternion.Euler(0,0,0);
                break;
        }
    }
    protected void Jump()
    {
        CanJump = Physics2D.BoxCast((Vector2)transform.position + groundCastOffset, groundCastSize, 0f, Vector2.zero, 0, LayerMask.GetMask("Ground"));
        if (Input.GetKeyDown(KeyCode.Space) && CanJump == true)
        {
            RB.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            CanJump = false;
        }
    }
    public void ChageSlot()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Wepon_1.gameObject.transform.SetParent(Sub_WeponPos.transform);
            Wepon_2.gameObject.transform.SetParent(WeponPos.transform);
            GetWepon();
            Wepon_1.transform.localPosition = new Vector3(0,0,0);
            Wepon_1.transform.localRotation = Quaternion.Euler(0,Wepon_1.transform.localRotation.y,0);

            Wepon_2.transform.localPosition = new Vector3(0,0,0);
            Wepon_2.transform.localRotation = Quaternion.Euler(Wepon_2.transform.localRotation.x,0,0);
        }
    }
    public void GetWepon()
    {
        Wepon_1 = WeponPos.transform.GetChild(0).GetComponent<Wepon>();   
        Wepon_2 = Sub_WeponPos.transform.GetChild(0).GetComponent<Wepon>();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 center = groundCastOffset + (Vector2)transform.position;
        Gizmos.DrawCube(center, groundCastSize);
    }
}
