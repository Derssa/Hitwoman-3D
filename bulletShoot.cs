using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class bulletShoot : MonoBehaviour
{
    public static int bda;
    public GameObject viseCam;
    public GameObject bulletCam;
    public GameObject sniper;
    public GameObject shoot;

    int lmouta;
    int hesselni;
    int hesselDead;
    int shootsN;

    public Text levelT;
    public Text lmoutaT;
    public Text hesselniT;
    public Text hesselDeadT;
    public Text shootsNT;
    public Text paycheckT;

    int hhesselDead;
    int hhesselni;

    public Transform bullet;
    public MeshRenderer bulletD;
    public AudioSource bulletSound;
    public static int camKH;
    float t;
    int q;
    public static int baki;
    public static float bakii;
    int v;

    void Start()
    {
        Application.targetFrameRate = 30;
        lmouta = PlayerPrefs.GetInt("lmouta");
        hesselni = PlayerPrefs.GetInt("hesselni");
        hesselDead = PlayerPrefs.GetInt("hesselDead");
        shootsN = PlayerPrefs.GetInt("shootsN");
        camKH = 0;
        v=0;
    }

        // Update is called once per frame
    void Update()
    {
        if (bda == 1)
        {
            viseCam.SetActive(false);
            sniper.SetActive(false);
            shoot.SetActive(false);
            bulletCam.SetActive(true);
            if (q == 0)
            {
                bulletSound.Play();
                q = 1;
            }
            
            Time.timeScale = 0.05f;
            Time.fixedDeltaTime = Time.timeScale * 0.005f;
            bullet.transform.Translate(0, 0, 30f * Time.deltaTime);
            
        }
        if (basicAIB.bb == 1)
        {
            
            bda = 2;
            bullet.transform.Translate(0, 0, 0);
            bulletD.enabled = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.005f;
            camKH = 1;
            
            if (hesselni == 0)
            {
                hhesselni = 3000;
                hesselniT.text = "Alerted guards (" + hesselni + ") : +$" + hhesselni;
            }
            if (hesselni > 0)
            {
                hhesselni = hesselni * -500;
                hesselniT.text = "Alerted guards (" + hesselni + ") : $" + hhesselni;
            }

            if (hesselDead == 0)
            {
                hhesselDead = 3000;
                hesselDeadT.text = "Dead body found (" + hesselDead + ") : +$" + hhesselDead;
            }
            if (hesselDead > 0)
            {
                hhesselDead = hesselDead * -500;
                hesselDeadT.text = "Dead body found (" + hesselDead + ") : -$" + hhesselDead;
            }
            shootsNT.text = "Bullet remaining ("+shootsN+"/3) : +$" + (shootsN * 1000);


            

            if (s1bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                
                lmoutaT.text = "finished guards (" + lmouta + "/7) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (25000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));

            }
            if (s2bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/7) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (70000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s3bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/9) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (100000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s4bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/10) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (160000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s5bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/10) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (250000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s6bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/16) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (400000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s7bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/14) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (725000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            if (s8bf.activeSelf == true)
            {
                if (v == 0)
                {
                    v = 1;
                }
                lmoutaT.text = "finished guards (" + lmouta + "/16) : +$" + (lmouta * 500);
                paycheckT.text = "paycheck\n$" + (1000000 + (lmouta * 500) + hhesselni + hhesselDead + (shootsN * 1000));
            }
            
        }
    }

    public void bull()
    {
        bda = 1;
        bullet.rotation = viseCam.transform.rotation;
    }

    public void replay()
    {

        baki = 0;
         
        StartCoroutine(AsynchronousLoad());
    }

    public void continues()
    {

        baki = 1;
        bakii = 0;
        StartCoroutine(AsynchronousLoadC());

    }


    AsyncOperation ao;
    public GameObject loadingScreen;
    public GameObject home;
    public GameObject tutorial; 
    public GameObject missions;
    public GameObject s1;
    public GameObject s1bf;
    public GameObject s2;
    public GameObject s2bf;
    public GameObject s3;
    public GameObject s3bf;
    public GameObject s4;
    public GameObject s4bf;
    public GameObject s5;
    public GameObject s5bf;
    public GameObject s6;
    public GameObject s6bf;
    public GameObject s7;
    public GameObject s7bf;
    public GameObject s8;
    public GameObject s8bf;
    public Slider slider;
    public Text progressText;
    IEnumerator AsynchronousLoad()
    {

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (tutorial.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 0.5f;
        }

        if (s1.activeSelf == true || s1bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 1;
        }
        if (s2.activeSelf == true || s2bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 2;
        }
        if (s3.activeSelf == true || s3bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 3;
        }
        if (s4.activeSelf == true || s4bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 4;
        }
        if (s5.activeSelf == true || s5bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 5;
        }
        if (s6.activeSelf == true || s6bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 6;
        }
        if (s7.activeSelf == true || s7bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 7;
        }
        if (s8.activeSelf == true || s8bf.activeSelf == true)
        {
            ao = SceneManager.LoadSceneAsync("home");
            bakii = 8;
        }



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

    IEnumerator AsynchronousLoadC()
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
