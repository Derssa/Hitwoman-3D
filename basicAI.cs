using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Cameras;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class basicAI : MonoBehaviour
    {
        private NavMeshAgent agent;
        private ThirdPersonCharacter character;
        Vector3 last;
        private Transform player;
        public static float maxAngle = 50;
        public float maxRadius;
        int e;
        int z;
        int t;
        int s;
        int ss;
        int hesselni;
        int hessl;
        int hesselDead;


        static Transform a;
        private Collider m_ObjectCollider;

        private float btimes;
        bool hsseb = false;
        public static bool chek = false;
        public bool zz = false;
      
        private Animator anim;


        private bool isInFov = false;
        private bool isInFovv = false;
        





        public GameObject[] waypoints;
        private GameObject[] deadBody;
        private int waypointInd = 0;
        public float patrolSpeed = 0.5f;


        public float chaseSpeed = 1f;
        private GameObject target;
        public GameObject mapIcon;
        public GameObject viewIcon;
        public GameObject viewIcon2;
        public GameObject blood;
        float times;
        float htimes;
        
        public ParticleSystem shot;
        public GameObject deadBodyFound;
        public GameObject bloodyScreen;
        private AudioSource bulletSound;

        int khtar;
        public GameObject player0;
        public GameObject player1;
        public GameObject player2;
        public GameObject player3;
        public GameObject player4;

        
        void Start()
        {
            khtar = PlayerPrefs.GetInt("khtar", 0);

            if (khtar == 0)
            {
                player = player0.transform;
                target = player0;
            }
            else if (khtar == 1)
            {
                player = player1.transform;
                target = player1;
            }
            else if (khtar == 2)
            {
                player = player2.transform;
                target = player2;
            }
            else if (khtar == 3)
            {
                player = player3.transform;
                target = player3;
            }
            else if (khtar == 4)
            {
                player = player4.transform;
                target = player4;
            }

            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            anim = GetComponent<Animator>();
            m_ObjectCollider = GetComponent<CapsuleCollider>();
            bulletSound = GetComponent<AudioSource>();
            shot.Stop();

            agent.updatePosition = true;
            agent.updateRotation = false;
            chek = false;
            t = 0;

            maxAngle = 50;
            anim.SetBool("Aim", false);

            hesselDead = 0;
            PlayerPrefs.SetInt("hesselDead", hesselDead);

            hesselni = 0;
            PlayerPrefs.SetInt("hesselni", hesselni);

        }

        private void Update()
        {
            deadBody = GameObject.FindGameObjectsWithTag("Dead");
            
            foreach (GameObject target in deadBody)
            {
                a = target.transform;

            }

            isInFov = inFOV(transform, player, maxAngle, maxRadius);

            if (PlayerController.mat == true && tag != "Dead")
            {

                isInFovv = inFOVV(transform, a, maxAngle, maxRadius);
                

            }

           

            if (t == 0)
            {
                Patrol();
               

            }

            if (gameObject.tag == "Dead")
            {
                isInFov = inFOV(transform, null, maxAngle, maxRadius);
                isInFovv = inFOVV(transform, null, maxAngle, maxRadius);
                mapIcon.SetActive(false);
                viewIcon.SetActive(false);
                viewIcon2.SetActive(false);
                PlayerController.mat = true;
                e = 1;
                t = 1;
                chek = false;
                Stop();
                btimes += Time.deltaTime;
                if (btimes > 1.5f)
                {
                    blood.SetActive(true);

                    btimes = 0;
                }

            }

            if (e == 1)
            {

                Stop();

            }

            if (s == 1)
            {
                Stop();
                anim.SetBool("Aim", false);
            }


            if (isInFovv)
            {
                
                maxAngle = 90;
                t = 1;
                agent.speed = 1;
                if (Vector3.Distance(transform.position, a.transform.position) > 2)
                {
                    agent.SetDestination(a.transform.position);
                    character.Move(agent.desiredVelocity, false, false);

                }
                else if (Vector3.Distance(transform.position, a.transform.position) <= 2)
                {

                    agent.SetDestination(transform.position);
                    character.Move(Vector3.zero, false, false);
                    
                }

            }
            if (maxAngle == 90 && tag != "Dead" && deadBody.Length > 0)
            {


                deadBodyFound.SetActive(true);
                viewIcon.SetActive(false);
                viewIcon2.SetActive(true);
                hesselDead = 1;
                PlayerPrefs.SetInt("hesselDead", hesselDead);


            }


            if (isInFov && e < 2)
            {

                chek = true;
                zz = true;
                t = 1;
                Shoot();
                if (hessl == 0)
                {
                    hesselni = 1;
                    PlayerPrefs.SetInt("hesselni", hesselni);
                    hessl = 1;
                }
            }
            else if (!isInFov && chek == true && zz == true && e < 2)
            {

                anim.SetBool("Aim", false);

                hsseb = true;
                t = 1;
                Chase();


            }

            
           

        }

        void Patrol()
        {

            agent.speed = patrolSpeed;
            if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) > 2)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);

            }
            else if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) <= 2)
            {

                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);

                times += Time.deltaTime;

                if (times >= 6)
                {
                    waypointInd += 1;
                    if (waypointInd >= waypoints.Length)
                    {
                        waypointInd = 0;
                    }
                    times = 0;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }


        }

        void Chase()
        {
            
                if (hsseb == true && z == 0)
            {
                hsseb = false;

                z = 1;
                last = target.transform.position;

            }
            if (Vector3.Distance(transform.position, last) >= 2)
            {


                agent.speed = chaseSpeed;
                agent.SetDestination(last);
                character.Move(agent.desiredVelocity, false, false);

            }
            else if (Vector3.Distance(transform.position, last) < 2)
            {


                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);

                times += Time.deltaTime;

                if (times >= 4)
                {
                    chek = false;
                    zz = false;
                    times = 0;
                    t = 0;
                    z = 0;
                    hessl = 0;
                }
            }

        }

        void Stop()
        {

            if (e == 1)
            {
                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);

                e = 2;
            }


        }

        void Shoot()
        {
            if (s == 0)
            {
                agent.speed = 0f;
                agent.SetDestination(target.transform.position);
                character.Move(agent.desiredVelocity, false, false);

                transform.LookAt(player);
                anim.SetBool("Aim", true);

                if (ss == 0)
                {

                    htimes += Time.deltaTime;

                    if (htimes >= 1)
                    {
                        bloodyScreen.SetActive(false);
                        health.healthS -= 33f;
                        shot.Play();
                        bulletSound.Play();
                        bloodyScreen.SetActive(true);
                        htimes = 0;
                        if (health.healthS <= 0f)
                        {
                            s = 1;

                        }
                    }
                }
            }
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxRadius);

            Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
            Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fovLine1);
            Gizmos.DrawRay(transform.position, fovLine2);

            if (!isInFov)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, transform.forward * maxRadius);


        }

        public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
        {

            Collider[] overlaps = new Collider[1000];
            int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

            for (int i = 0; i < count + 1; i++)
            {

                if (overlaps[i] != null)
                {

                    if (overlaps[i].transform == target)
                    {

                        Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                        directionBetween.y *= 0;

                        float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                        if (angle <= maxAngle)
                        {

                            Ray ray = new Ray(checkingObject.position + checkingObject.up, target.position - checkingObject.position);
                            RaycastHit hit;

                            if (Physics.Raycast(ray, out hit, maxRadius))
                            {

                                if (hit.transform == target)
                                    return true;

                            }


                        }


                    }



                }

            }

            return false;
        }


        public static bool inFOVV(Transform checkingObject, Transform target, float maxAngle, float maxRadius)
        {

            Collider[] overlaps = new Collider[1000];
            int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

            for (int i = 0; i < count + 1; i++)
            {

                if (overlaps[i] != null)
                {

                    if (overlaps[i].transform == target)
                    {

                        Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                        directionBetween.y *= 0;

                        float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                        if (angle <= maxAngle)
                        {

                            Ray ray = new Ray(checkingObject.position + checkingObject.up, target.position - checkingObject.position);
                            RaycastHit hit;

                            if (Physics.Raycast(ray, out hit, maxRadius))
                            {

                                if (hit.transform == target)
                                    return true;

                            }


                        }


                    }



                }

            }

            return false;
        }


        


        void OnCollisionEnter(Collision coll)
        {
            if (coll.gameObject.tag == "Player" && chek == false)
            {
                e = 1;
                t = 1;
                m_ObjectCollider.isTrigger = true;

            }
            if (coll.gameObject.tag == "Player" && chek == true)
            {
                ss = 1;
                shot.Stop();

                anim.SetTrigger("AimW");

                health.healthS = 0;

            }
        }

        
    }
}

