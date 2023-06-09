using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UseWepon : Wepon
{
    [Header("Kind")]
    [SerializeField] private WeponKind weponKind;
    [Header("Stat")]
    public float Damage;
    public Type WeponType;

    [Header("State")]
    [SerializeField] protected bool CanAttack = true;
    [SerializeField] private float curDealy = 0;
    public float Delay;

    [Header("Protected")]
    protected Action AttackAction;
    void Start()
    {

    }

    void Update()
    {
        AttackDelay();
        Attack();
    }

    public virtual void Attack()
    {
        if (CanAttack == true)
        {
            if (transform.parent.name == "Wepon Slot")
            {
                if (Input.GetKey(KeyCode.Z))
                {
                    AttackAction();
                    CanAttack = false;
                }
            }
        }
    }
    private void AttackDelay()
    {
        if (curDealy < Delay)
        {
            curDealy += Time.deltaTime;
            return;
        }
        else
        {
            CanAttack = true;
            curDealy = 0;
        }
    }
}
