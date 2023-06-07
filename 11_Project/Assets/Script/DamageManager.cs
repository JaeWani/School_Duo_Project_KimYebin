using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance;

    [Header ("데미지 프리펩")]
    public GameObject DamagePrefabs;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void TakeDamage(Transform t, int damage)
    {
        var damageEffect = Instantiate(DamagePrefabs, t.position, Quaternion.identity);
        var component = damageEffect.GetComponent<DamageEffect>();
        component.Damage = damage;
    }
}
