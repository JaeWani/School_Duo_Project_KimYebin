using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private enum BackGround_Kind
    {
        Sub_BackGround,
        Main_BackGround
    }
    [SerializeField] BackGround_Kind Kind;
    float lenght, startpos;
    public GameObject cam;
    public GameObject player;
    public float parallaxEffect;
    void Start()
    {
        startpos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        SetBackGround();
    }
    void SetBackGround()
    {
        if (Kind == BackGround_Kind.Sub_BackGround)
        {
            float temp = (cam.transform.position.x * (1 - parallaxEffect));
            float dist = (cam.transform.position.x * parallaxEffect);

            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        }
        else if (Kind == BackGround_Kind.Main_BackGround)
        {
            transform.position = player.transform.position;
        }
    }
}
