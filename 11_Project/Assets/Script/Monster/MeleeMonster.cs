using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonster : Monster
{
    [Header ("Melee Monster")]
    public bool IsTracking = false;
    [SerializeField] GameObject Target;
    public float MoveSpeed;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Tracking();
    }
    public void Tracking()
    {
        if (IsTracking == true)
        {
            Vector3 current = transform.position;
            Vector3 target = Target.transform.position;
            transform.position = Vector3.MoveTowards(current, target, MoveSpeed * Time.deltaTime);
        }
    }
}
