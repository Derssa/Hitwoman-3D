using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerController : MonoBehaviour
{

    public Camera cam;
    public GameObject Ccam;
    public GameObject bulletCam;
    public GameObject bullet;
    public NavMeshAgent agent;
    public ThirdPersonCharacter character;
    public Animator anim;
    int e;
    int d;
    int t;
    int k;
    int lmouta;
    int bdastep;
    public static int bull;
    int loc=0;
    int q;


    float times;
    float timess;
    float timesss;
    float btimes;
    float timesD;

    public ParticleSystem shot;
    bool chek;
    public static bool lams;
    public static int lamstuto;
    public static bool mat=false;

    GameObject target;
    public GameObject enemyDead;
    public GameObject blood;
    GameObject closestEnemy = null;

    public GameObject yourD;
    private AudioSource bulletSound;
    public AudioSource stepSound;
    public AudioSource choke;
    public AudioSource slap;
    public AudioSource hurt;
    int slapp;
    int zeb;
    int zebb;
    int khtarw;
    int chok;
    int money;
    public GameObject ferdi;
    public GameObject ma9la;
    int floss;
    public Text flossT;
    public Text levelT;
    public GameObject missionS;

    void Start()
    {
        Application.targetFrameRate = 30;
        health.healthS = 99;
        floss = 0;
        money = PlayerPrefs.GetInt("money");
        agent.updateRotation = false;
        lams = true;
        shot.Stop();
        bulletSound = GetComponent<AudioSource>();
        lmouta = 0;
        PlayerPrefs.SetInt("lmouta", lmouta);
        bull = 0;
        bulletCollider.bdaa = 0;
        chok = 0;
        khtarw = PlayerPrefs.GetInt("khtarw", 0);
        if (khtarw == 1)
        {
            ferdi.SetActive(true);
            shot.Stop();
        }
        else if (khtarw == 2)
        {
            ma9la.SetActive(true);
        }
        else
        {
            ferdi.SetActive(false);
            ma9la.SetActive(false);
        }
    }

    void Update()
    {
        
        FindClosestEnemy();
       
        if (health.healthS <= 0)
        {
            buttons.aim = false;
            anim.SetTrigger("DeathP");
            btimes += Time.deltaTime;
            if (btimes > 1.5f)
            {
                yourD.SetActive(true);
                blood.SetActive(true);
                
                btimes = 0;
            }
            
            k = 2;
            e = 2;
        }

        if (lams == false)
        {
            agent.SetDestination(this.transform.position);
            character.Move(Vector3.zero, false, false);
            
            e = 2;
        }

        if (Input.GetMouseButtonDown(0) && lams == true && zeb==0)
        {
            if (lamstuto == 0)
            {
                lamstuto = 1;
            }
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    chek = basicAI.chek;
                    if (chek == false)
                    {
                        target = hit.transform.gameObject;
                        e = 1;
                        d = 0;
                    }
                    else
                    {
                        target = hit.transform.Find("Point1").gameObject;
                        e = 1;
                        d = 0;
                    }
                }
                else
                {
                    agent.SetDestination(hit.point);
                    d = 1;
                    e = 0;
                }
            }
            zeb = 1;
        }
        if (e == 1)
        {

            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);
            if (bdastep == 0)
            {
                stepSound.Play();
                bdastep = 1;
            }
        }
        else if (e == 2)
        {

            agent.SetDestination(this.transform.position);
            character.Move(Vector3.zero, false, false);
            zeb = 0;
            if (bdastep == 1)
            {
                stepSound.Stop();
                bdastep = 0;
            }
        }

        if (d == 1)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
            {
                character.Move(agent.desiredVelocity, false, false);
                
                if (bdastep == 0)
                {
                    stepSound.Play();
                    bdastep = 1;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
                zeb = 0;
                if (bdastep == 1)
                {
                    stepSound.Stop();
                    bdastep = 0;
                }
            }
        }

        if (buttons.shoot == true && buttons.lmouta == buttons.totalLmouta)
        {


            lams = false;
            anim.SetBool("Aim", true);
            e = 0;
            t = 1;
            target = closestEnemy;
            transform.LookAt(target.transform);



            buttons.aim = false;
            buttons.shoot = false;
            Collider cols = target.GetComponent<CapsuleCollider>();
            cols.isTrigger = true;
            mat = true;
            target.tag = "Dead";
            target.layer = 0;

            lmouta += 1;
            PlayerPrefs.SetInt("lmouta", lmouta);
        }
        else if (buttons.shoot == false && t == 1 && buttons.lmouta == buttons.totalLmouta)
        {

            anim.SetBool("Aim", false);
            lams = true;
            agent.SetDestination(this.transform.position);
            character.Move(Vector3.zero, false, false);
            timesss += Time.deltaTime;



            if (timesss > 0.2f)
            {
                shot.Play();
                bulletSound.Play();

                t = 0;
                timesss = 0;
                bull = 1;
            }


        }
        if (buttons.shoot == false && bull == 1 && buttons.lmouta == buttons.totalLmouta)
        {
            if (bulletCollider.bdaa == 0)
            {
                Ccam.SetActive(false);
                bulletCam.SetActive(true);
                bullet.SetActive(true);

                Time.timeScale = 0.05f;
                Time.fixedDeltaTime = Time.timeScale * 0.005f;
                bullet.transform.Translate(0, 0, 30f * Time.deltaTime);
            }



        }
        if (bulletCollider.bdaa == 1)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = Time.timeScale * 0.005f;
            Animator animE = target.GetComponent<Animator>();
            animE.SetTrigger("dead");
            
            if (Vector3.Distance(transform.position, target.transform.position) > 2)
            {
                agent.SetDestination(target.transform.position);
                character.Move(agent.desiredVelocity, false, false);
                stepSound.Stop();
            }
            else if (Vector3.Distance(transform.position, target.transform.position) <= 2)
            {

                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);
                
                anim.SetTrigger("Dance");

            }
            if (q == 0 && khtarw != 2)
            {
                if (chok == 0)
                {
                    hurt.Play();
                }
                else {
                    
                    chok = 0;
                }
                

                q = 1;
            }

        }

        if (buttons.shoot == true && buttons.lmouta < buttons.totalLmouta)
        {
            

            lams = false;
            anim.SetBool("Aim", true);
            e = 0;
            t = 1;
            target = closestEnemy;
            transform.LookAt(target.transform);

            

            buttons.aim = false;
            buttons.shoot = false;
            Animator animE = target.GetComponent<Animator>();
            Collider cols = target.GetComponent<CapsuleCollider>();
            cols.isTrigger = true;
            mat = true;
            target.tag = "Dead";
            target.layer = 0;
            animE.SetTrigger("dead");
            lmouta += 1;
            PlayerPrefs.SetInt("lmouta", lmouta);
        }

        else if (buttons.shoot == false && t == 1 && buttons.lmouta < buttons.totalLmouta)
        {
            
            anim.SetBool("Aim", false);
            lams = true;
            agent.SetDestination(this.transform.position);
            character.Move(Vector3.zero, false, false);
            timesss += Time.deltaTime;

            
            if (timesss > 0.2f)
            {
                shot.Play();
                bulletSound.Play();
                
                t = 0;
                timesss = 0;
            }
            

        }

        

        if (k == 1)
        {
            
            lams = false;
            target.transform.rotation = transform.rotation;
            if (khtarw != 2)
            {
                target.transform.position = this.transform.Find("Point").position;
            }
            else if (khtarw == 2)
            {
                target.transform.position = this.transform.Find("Point1").position;
            }

            if (buttons.lmouta == buttons.totalLmouta)
            {

                
                Ccam.GetComponent<CameraMovement>().enabled = false;
                bulletCollider.bdaa = 1;
                Ccam.GetComponent<camSmooth>().enabled = true;
                anim.SetTrigger("Dance");
            }
            if (target.gameObject.tag == "Dead")
            {
                times += Time.deltaTime;
               
                
                if (times >= 2f)
                {
                    lams = true;
                    k = 0;
                    times = 0;
                    chok = 0;
                }
            }
        }
        if (k == 2)
        {
            lams = false;

            timesD += Time.deltaTime;


            if (timesD > 1.5f)
            {
                yourD.SetActive(true);
                

            }
        }

        
    }

    void OnCollisionEnter(Collision coll)
    {
        chek = basicAI.chek;
        if (chek == false)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                if (coll.gameObject != target)
                {
                    k = 1;
                    target = coll.gameObject;
                    
                    e = 2;

                }

                if (coll.gameObject == target)
                {
                    if (khtarw != 2)
                    {
                        k = 1;
                        this.transform.rotation = coll.transform.rotation;
                        this.transform.position = coll.transform.Find("Point").position;
                        Destroy(target);
                        mat = true;
                        zebb = 0;
                        if (zebb == 0)
                        {
                            target = Instantiate(enemyDead, transform.Find("Point").position, transform.Find("Point").rotation);
                            zebb = 1;
                        }
                        buttons.aim = false;
                        lmouta += 1;
                        PlayerPrefs.SetInt("lmouta", lmouta);

                        anim.SetTrigger("StealthKill");
                        chok = 1;
                        e = 2;
                        
                        StartCoroutine(Choke());
                        buttons.douz += 1;

                        bulletCollider.meskin = target;

                    }
                    else if (khtarw == 2)
                    {
                        k = 1;
                        this.transform.rotation = coll.transform.rotation;
                        this.transform.position = coll.transform.Find("Point2").position;
                       
                        mat = true;

                        lmouta += 1;
                        PlayerPrefs.SetInt("lmouta", lmouta);

                        anim.SetTrigger("Slap");

                        e = 2;

                        StartCoroutine(Slap());
                        buttons.douz += 1;

                        bulletCollider.meskin = target;

                        coll.gameObject.GetComponent<Animator>().SetTrigger("dead"); 
                        coll.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
                       

                        target.tag = "Dead";
                        target.layer = 0;
                        

                    }
                }
            }
        }
        if (chek == true)
        {
            if (coll.gameObject.tag == "Enemy")
            {
                buttons.aim = false;
                if (slapp == 0)
                {
                    slap.Play();
                    slapp = 1;
                }
                transform.LookAt(coll.transform);
                this.transform.position = coll.transform.Find("Point1").position;
                anim.SetTrigger("DeathP");
                k = 2;
                e = 2;
            }
        }

        if (coll.gameObject.tag == "location")
        {
            if (loc == 0)
            {
                loc = 1;
                StartCoroutine(AsynchronousLoad());
            }
            
        }

        if (coll.gameObject.tag == "floss")
        {
            floss += 1;
            flossT.text = floss + "/10";
            money += 1000;
            PlayerPrefs.SetInt("money", money);
            Destroy(coll.gameObject);
            if (floss == 10) {
                lams = false;
                anim.SetTrigger("Dance");
                missionS.SetActive(true);
                levelT.text = "Level " + tuto.level + " Passed";
                tuto.level += 1;
                PlayerPrefs.SetFloat("level", tuto.level);
            }
        }
    }

    IEnumerator Choke()
    {
        yield return new WaitForSeconds(0.4f);
        choke.Play();
    }

    IEnumerator Slap()
    {
        yield return new WaitForSeconds(0.6f);
        slap.Play();
        
    }

    AsyncOperation ao;
    public GameObject loadingScreen;
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
        

        if (s1.activeSelf == true)
        {
            s1.SetActive(false);
            s1bf.SetActive(true);
        }
        if (s2.activeSelf == true)
        {
            s2.SetActive(false);
            s2bf.SetActive(true);
        }
        if (s3.activeSelf == true)
        {
            s3.SetActive(false);
            s3bf.SetActive(true);
        }
        if (s4.activeSelf == true)
        {
            s4.SetActive(false);
            s4bf.SetActive(true);
        }
        if (s5.activeSelf == true)
        {
            s5.SetActive(false);
            s5bf.SetActive(true);
        }
        if (s6.activeSelf == true)
        {
            s6.SetActive(false);
            s6bf.SetActive(true);
        }
        if (s7.activeSelf == true)
        {
            s7.SetActive(false);
            s7bf.SetActive(true);
        }
        if (s8.activeSelf == true)
        {
            s8.SetActive(false);
            s8bf.SetActive(true);
        }





        yield return null;
       
    }

    void OnTriggerEnter(Collider coll)
    {
        
        if (coll.gameObject.tag == "Enemy")
        {
            Vector3 direction = coll.transform.position - transform.position;
            RaycastHit hit;

            if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, transform.Find("Point").GetComponent<SphereCollider>().radius))
            {

                if (hit.collider.gameObject.tag == "Enemy")
                {
                    if (k == 1)
                    {
                        buttons.aim = false;
                    }
                    if (k == 0 && lamstuto >= 4 && buttons.shootsN > 0)
                    {
                        buttons.aim = true;

                    }
                }
            }
           
        }

        if (coll.gameObject.tag == "bab")
        {
            if (lamstuto == 1)
            {
                lamstuto = 2;
                
                coll.enabled = false;
            }
        }

        

    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {

            Vector3 direction = coll.transform.position - transform.position;
            RaycastHit hit;
            timess += Time.deltaTime;
            if (Physics.Raycast(transform.position+transform.up,direction.normalized, out hit, transform.Find("Point").GetComponent<SphereCollider>().radius))
            {

                if (hit.collider.gameObject.tag == "Enemy")
                {
                    

                    if (timess >= 5)
                    {
                        if (k == 1)
                        {
                            buttons.aim = false;

                        }

                        if (k == 0 && lamstuto >= 4 && buttons.shootsN > 0)
                        {
                            buttons.aim = true;

                        }

                        timess = 0;
                    }
                }
                    

            }
            
            
        }
    }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            
                buttons.aim = false;
                buttons.shoot = false;
           
        }
    }

    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }

        
    }
}
