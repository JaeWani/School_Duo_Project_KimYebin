using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropWepon : Wepon
{   
    private ToolTip toolTip;

    public string WeponInfo;
    public string WeponName;

    [SerializeField] private WeponKind weponKind;

    private void Start()
    {
        toolTip = ToolTip.instance;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
    }
    private void OnTriggerStay2D(Collider2D other) {
        AddWepon(other);
    }
    private void OnTriggerExit2D(Collider2D other) {
        toolTip.gameObject.SetActive(false);
    }
    void AddWepon(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ActiveToolTip();   
            if(Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("F");
                toolTip.gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    void ActiveToolTip()
    {
        toolTip.gameObject.SetActive(true);
        toolTip.SetInfo(WeponInfo,WeponName);
    }
}
