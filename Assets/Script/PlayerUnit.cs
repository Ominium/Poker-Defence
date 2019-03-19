using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public int hp = 100;
    int mhp;
    
    public Transform tr;
    float time=0;
    public float moveDist = 1.5f;


    void Start()
    {
        tr = GetComponent<Transform>();
        mhp = hp;
        
    }

    void Update()
    {
       
    }
}
