using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<GameObject> Monster_Prefabs = new List<GameObject>();

    [SerializeField] Monster_Kind monster_Kind;
    private enum Monster_Kind
    {
        RangedMonster,
        MeleeMonster
    }
    void Start()
    {
        Instantiate(Monster_Prefabs[(int)monster_Kind], transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
   
}
