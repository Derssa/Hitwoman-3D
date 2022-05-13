using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class arrowsgunB : MonoBehaviour
{
    public Transform cameraP;
    public Image arrowR;
    public Image arrowL;
    public Text moneyT;

    int namesC;

    public Text nameC;
    Color newColorR;
    Color newColorL;
    private int sala;

    private int bs1w;
    private int bs2w;
    

    private int khtarw;
    int money;

    public GameObject haze9;
    public GameObject home;
    public GameObject weapons;

    // Start is called before the first frame update
    void Start()
    {
        namesC = 1;
        sala = PlayerPrefs.GetInt("sala");
        money = PlayerPrefs.GetInt("money");
        bs1w = PlayerPrefs.GetInt("bs1w", 0);
        bs2w = PlayerPrefs.GetInt("bs2w", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyT.text = "$" + money;
        if (cameraP.position.x == 0)
        {

            newColorR = arrowR.color;
            newColorR.a = 0.95f;
            arrowR.color = newColorR;
            newColorL = arrowL.color;
            newColorL.a = 0.2f;
            arrowL.color = newColorL;
        }
        if (cameraP.position.x == 18)
        {

            newColorR = arrowR.color;
            newColorR.a = 0.2f;
            arrowR.color = newColorR;
            newColorL = arrowL.color;
            newColorL.a = 0.95f;
            arrowL.color = newColorL;
        }

        if (cameraP.position.x > 0 && cameraP.position.x < 18)
        {

            newColorR = arrowR.color;
            newColorR.a = 0.95f;
            arrowR.color = newColorR;
            newColorL = arrowL.color;
            newColorL.a = 0.95f;
            arrowL.color = newColorL;
        }

        if (namesC == 1)
        {

            if (bs1w == 1)
            {
                nameC.text = "Choose";
            }
            else
            {
                nameC.text = "Buy\n$20000";
            }
        }


        if (namesC == 2)
        {
            if (bs2w == 1)
            {
                nameC.text = "Choose";
            }
            else
            {
                nameC.text = "Buy\n$50000";
            }
        }

        


    }

    public void arowR()
    {
        if (cameraP.position.x >= 0 && cameraP.position.x < 18)
        {
            cameraP.Translate(18, 0, 0);
            namesC += 1;
        }
    }

    public void arowL()
    {
        if (cameraP.position.x > 0 && cameraP.position.x <= 18)
        {
            cameraP.Translate(-18, 0, 0);
            namesC -= 1;
        }
    }

    public void close()
    {
        StartCoroutine(AsynchronousLoadC());
    }

    public void Buy()
    {
        if (namesC == 1)
        {

            if (bs1w == 0)
            {
                if (money >= 20000)
                {
                    money -= 20000;
                    PlayerPrefs.SetInt("money", money);
                    khtarw = 1;
                    PlayerPrefs.SetInt("khtarw", khtarw);
                    bs1w = 1;
                    PlayerPrefs.SetInt("bs1w", bs1w);
                    StartCoroutine(AsynchronousLoadC());
                }
                else if (money < 20000)
                {
                    haze9.SetActive(true);
                    weapons.SetActive(false);
                }

            }
            else
            {
                khtarw = 1;
                PlayerPrefs.SetInt("khtarw", khtarw);
                StartCoroutine(AsynchronousLoadC());
            }
        }


        if (namesC == 2)
        {
            if (bs2w == 0)
            {
                if (money >= 50000)
                {
                    money -= 50000;
                    PlayerPrefs.SetInt("money", money);
                    khtarw = 2;
                    PlayerPrefs.SetInt("khtarw", khtarw);
                    bs2w = 1;
                    PlayerPrefs.SetInt("bs2w", bs2w);
                    StartCoroutine(AsynchronousLoadC());
                }
                else if (money < 50000)
                {
                    haze9.SetActive(true);
                    weapons.SetActive(false);
                }

            }
            else
            {
                khtarw = 2;
                PlayerPrefs.SetInt("khtarw", khtarw);
                StartCoroutine(AsynchronousLoadC());
            }
        }

        
    }

    /*AsyncOperation ao;
    public GameObject loadingScreen;
    public GameObject missions;
    public GameObject f;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public GameObject s6;
    public GameObject s7;
    public GameObject s8;
    public Slider slider;
    public Text progressText;
    IEnumerator AsynchronousLoad()
    {
        
        if (namesC == 1 && sala >= 0)
        {
            TinySauce.OnGameStarted(levelNumber:"1");
            missions.SetActive(false);
            s1.SetActive(true);
            
        }
        if (namesC == 2)
        {

            if (sala >= 1)
            {
                TinySauce.OnGameStarted(levelNumber: "2");
                missions.SetActive(false);
                s2.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);
                
                //ao = SceneManager.LoadSceneAsync("f");
            }
        }
        if (namesC == 3)
        {

            if (sala >= 2)
            {
                TinySauce.OnGameStarted(levelNumber: "3");
                missions.SetActive(false);
                s3.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }
        if (namesC == 4)
        {

            if (sala >= 3)
            {
                TinySauce.OnGameStarted(levelNumber: "4");
                missions.SetActive(false);
                s4.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }

        if (namesC == 5)
        {

            if (sala >= 4)
            {
                TinySauce.OnGameStarted(levelNumber: "5");
                missions.SetActive(false);
                s5.SetActive(true);
                
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }
        if (namesC == 6)
        {

            if (sala >= 5)
            {
                TinySauce.OnGameStarted(levelNumber: "6");
                missions.SetActive(false);
                s6.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }
        if (namesC == 7)
        {

            if (sala >= 6)
            {
                TinySauce.OnGameStarted(levelNumber: "7");
                missions.SetActive(false);
                s7.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }
        if (namesC == 8)
        {

            if (sala >= 7)
            {
                TinySauce.OnGameStarted(levelNumber: "8");
                missions.SetActive(false);
                s8.SetActive(true);
                
            }
            else
            {
                missions.SetActive(false);
                f.SetActive(true);

                //ao = SceneManager.LoadSceneAsync("f");
            }
        }

            yield return null;
       
    }*/

    AsyncOperation ao;
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

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

