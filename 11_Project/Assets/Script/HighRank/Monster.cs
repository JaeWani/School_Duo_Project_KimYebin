using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    [Header("Stat")]
    public Type MonsterType;
    [SerializeField] public int MaxHP;
    [SerializeField] public int HP;

    [Header("HPBar")]
    [SerializeField] GameObject HPBarPrefabs;
    [SerializeField] private Canvas HPCanvas;
    [SerializeField] private Slider HPSlider;
    [SerializeField] private MonsterHPBar HPBar;
    protected virtual void Start()
    {
        HP = MaxHP;
        CreatHPBar();
    }

    protected virtual void Update()
    {
        UpdateHPBar();
        Dead();
    }
    protected virtual void Dead()
    {
        if (HP <= 0)
        {
            Destroy(HPSlider.gameObject);
            Destroy(gameObject);
        }
    }
    void Hit(int damage)
    {
        HP -= damage;
    }
    private void CreatHPBar()
    {
        HPCanvas = GameObject.Find("HPCanvas").GetComponent<Canvas>();
        var HPBar = Instantiate(HPBarPrefabs, HPCanvas.transform);
        HPSlider = HPBar.GetComponent<Slider>();
    }
    private void UpdateHPBar()
    {
        HPBar = HPSlider.GetComponent<MonsterHPBar>();
        HPBar.TargetPos = transform;
        HPBar.Offset = new Vector3(0, 1, 0);

        HPSlider.value = Mathf.Lerp(HPSlider.value, ((float)HP / (float)MaxHP), Time.deltaTime * 10);
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
