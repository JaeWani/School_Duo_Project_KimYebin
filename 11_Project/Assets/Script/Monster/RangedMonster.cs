using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMonster : Monster
{
    [Header("Ranged Monster")]
    [SerializeField] Transform AttackPos;
    [SerializeField] GameObject AttackPrefab;

    [SerializeField] GameObject Target;

    public float curDelay;
    public float Delay;

    public int AttackNumber;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        AttackDelay();
    }
    void AttackDelay()
    {
        if (curDelay > Delay)
        {
            StartCoroutine(Attack());
            curDelay = 0;
        }
        else
        {
            curDelay += Time.deltaTime;
            return;
        }
    }
    IEnumerator Attack()
    {
        for (int i = 0; i < AttackNumber; i++)
        {
            var bullet = Instantiate(AttackPrefab, AttackPos.position, Quaternion.identity).GetComponent<RangedMonster_Bullet>();
            Vector3 dir = Target.transform.position - AttackPos.position;
            bullet.dir = dir;
            yield return new WaitForSeconds(0.3f);
        }
    }
}
