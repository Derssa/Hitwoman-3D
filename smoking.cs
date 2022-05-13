using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smoking : MonoBehaviour
{
    // Start is called before the first frame update

    public ParticleSystem smok;
    float smo;
    int pp;
    void Start()
    {
        smok.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        smo += Time.deltaTime;

        if (smo >= 3 && pp == 0)
        {
            smok.Play();
            pp = 1;
        }
        if (smo >= 8)
        {
            pp = 0;
            smo = 0;
        }
    }
}
