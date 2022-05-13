using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCollider : MonoBehaviour
{
    
    public MeshRenderer bullet;
    public TrailRenderer bulletT;
    public static int bdaa;
    public static GameObject meskin;
    
    void Start()
    {
        bdaa = 0;
    }
    void Update()
    {
       
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Dead")
        {
            
            bdaa = 1;
            bullet.enabled = false;
            bulletT.enabled = false;
            PlayerController.bull = 0;

            meskin =coll.gameObject;
            
            
        }

    }
}
