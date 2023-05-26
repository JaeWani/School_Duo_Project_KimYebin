using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToolTip : MonoBehaviour
{
    public static ToolTip instance;
    public bool IsToolTip = false;


    [SerializeField] Text WeponInfo;
    [SerializeField] Text WeponName;

    private void Awake() {
        if(instance == null)
            instance  = this;
        else 
            Destroy(gameObject);
    }

    public void SetInfo(string info , string name)
    {
        WeponName.text = name;
        WeponInfo.text = info;
    }
}
