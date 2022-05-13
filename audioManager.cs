using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class audioManager : MonoBehaviour
{

    public GameObject am;
    public GameObject home;
    public GameObject skin;
    public GameObject weapons;
    public GameObject haze9;

    // Start is called before the first frame update




    void Update()
    {

        if (home.activeSelf == true || skin.activeSelf == true || weapons.activeSelf == true || haze9.activeSelf == true)
        {
            am.SetActive(true);

        }
        else
        {
            am.SetActive(false);
        }
        
    }


}
