using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class f : MonoBehaviour
{
    public GameObject haze9;
    public GameObject home;
    public void back()
    {
        haze9.SetActive(false);
        home.SetActive(true);
        //SceneManager.LoadScene("missions");
    }

    
}
