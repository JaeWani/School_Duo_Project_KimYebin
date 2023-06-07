using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeponInfo", menuName = "Wepon/Info", order = int.MaxValue)]
public class WeponInfo : ScriptableObject
{
    public string Name;
    public string info;
    public GameObject DropPrefab;
    public GameObject WeponPrefab;
    public WeponKind Kind;
}
