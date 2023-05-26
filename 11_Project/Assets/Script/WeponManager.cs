using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponManager : MonoBehaviour
{
    public static WeponManager instance;
    private void Awake() {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddWepon()
    {


    }
}
