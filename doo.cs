using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doo : MonoBehaviour
{
    // Start is called before the first frame update
    float wakt=0;
    public Light l;
    void Start()
    {
        RenderSettings.ambientIntensity = 0;
        l.range = 0;
    }

    // Update is called once per frame
    void Update()
    {
        wakt += Time.deltaTime;
        if (wakt < 2)
        {
            RenderSettings.ambientIntensity = 0;
            
        }
        if (wakt >= 1 && wakt < 3)
        {
           
            l.range += 0.05f;
        }
        if (wakt >= 2 && wakt < 4)
        {
            RenderSettings.ambientIntensity += 0.01f;
            
        }
    }
}
