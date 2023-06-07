using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("Stat")]
    public Type MonsterType;

    [SerializeField] private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
            Dead();
            SetHpBar();
        }
    }
    [Header("UI")]
    [SerializeField] GameObject HPBar;
    void Start()
    {

    }

    void Update()
    {

    }
    void Dead()
    {
        Debug.Log("프로퍼티");
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void SetHpBar()
    {
        float x = HPBar.transform.localScale.x;
        float y = HPBar.transform.localScale.y - ((float)(hp / 100f) * HPBar.transform.localScale.y);
        HPBar.transform.localScale = new Vector3(x,y,0);
    }
    void Hit(int damage)
    {
        HP -= damage;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            var bullet = other.GetComponent<Bullet>();
            int Damage = TypeScript.TypeDamage(bullet.Damage, MonsterType, bullet.bulletType);
            DamageManager.instance.TakeDamage(transform, Damage);
            Hit(Damage);
        }
    }
}
