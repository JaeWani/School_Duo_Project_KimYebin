using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponManager : MonoBehaviour
{
    public List<WeponInfo> weponInfos;

    public static WeponManager instance;
    private void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
        GetWeponInfo("Weponkind");
    }
    private void GetWeponInfo(string path)
    {
        WeponInfo[] infos = Resources.LoadAll<WeponInfo>(path);
        weponInfos = new List<WeponInfo>(infos);
    }
    public void AddWepon()
    {

    }
}
