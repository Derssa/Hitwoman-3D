using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tuto : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public GameObject bab;
    public GameObject sba3;
    public GameObject sba3a;
    public GameObject gongra;
    public GameObject tutorial;
    public GameObject home;

    public GameObject map;
    public Collider colls;
    Animator babAnim;
    string klam;
    float zmar;
    float times;

    public static float level;

    void Start()
    {
        map.SetActive(false);
        babAnim = bab.GetComponent<Animator>();
        PlayerController.lamstuto=PlayerPrefs.GetInt("lamstuto", 0);
        level = PlayerPrefs.GetFloat("level", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerController.lamstuto == 1)
        {
            klam = "Exit the room";
            text.text = klam;
            babAnim.enabled = true;
            colls.isTrigger = true;
           
        }

        if (PlayerController.lamstuto == 2)
        {
            klam = "Click on the map to see the guards placement and mouvement";
            map.SetActive(true);
            text.text = klam;
            sba3.SetActive(true);
            PlayerController.lams = false;
            buttons.aim = false;
        }

        if (PlayerController.lamstuto == 3)
        {
            
            klam = "Click on the guard to finish him";
            text.text = klam;
            sba3.SetActive(false);
            buttons.aim = false;
            PlayerController.lams = true;
        }

        if (PlayerController.lamstuto == 4)
        {

            /*klam = "shoot the other guard";
            text.text = klam;
            sba3a.SetActive(true);
            buttons.aim = true;
            PlayerController.lams = false;*/
       
            text.enabled = false;
            times += Time.deltaTime;
            if (times > 2f)
            {
                gongra.SetActive(true);
                                
            }
            if (times > 10f)
            {
                bulletShoot.bakii = 0;
                PlayerController.lamstuto = 7;
                PlayerPrefs.SetInt("lamstuto", PlayerController.lamstuto);
                level = 1;
                PlayerPrefs.SetFloat("level", level);
                StartCoroutine(AsynchronousLoad());

            }

        }
        if (PlayerController.lamstuto == 7)
        {


            text.enabled = true;
            Destroy(GameObject.FindGameObjectWithTag("bab"));
            map.SetActive(true);
            klam = "";
            text.text = klam;
        }
    }

    AsyncOperation ao;
    public GameObject loadingScreen;



    public Slider slider;
    public Text progressText;
    IEnumerator AsynchronousLoad()
    {

       
        ao = SceneManager.LoadSceneAsync("home");
        

        loadingScreen.SetActive(true);

        while (!ao.isDone)
        {
            // [0, 0.9] > [0, 1]
            float progress = Mathf.Clamp01(ao.progress / 0.9f);

            slider.value = progress;
            progressText.text = (progress * 100).ToString("0") + "%";

            yield return null;
        }
    }
}
