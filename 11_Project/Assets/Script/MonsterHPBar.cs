using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHPBar : MonoBehaviour
{
    private Canvas HPCanvas;
    private Camera HPCamera;
    private RectTransform ParentRect;
    private RectTransform MyRect;

    public Transform TargetPos;
    public Vector3 Offset;
    void Start()
    {
        HPCanvas = GetComponentInParent<Canvas>();
        HPCamera = HPCanvas.worldCamera;
        ParentRect = HPCanvas.GetComponent<RectTransform>();
        MyRect = GetComponent<RectTransform>();
    }
    private void LateUpdate()
    {
        var screenPos = Camera.main.WorldToScreenPoint(TargetPos.position + Offset);
        if(screenPos.z < 0.0f)
            screenPos *= -1f;
        
        var localPos = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(ParentRect,screenPos,HPCamera,out localPos);

        MyRect.localPosition = localPos;
    }
}
