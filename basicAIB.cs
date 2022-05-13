using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class basicAIB : MonoBehaviour
    {
        private NavMeshAgent agent;
        private ThirdPersonCharacter character;
        Vector3 last;

        static float maxAngle = 50;
        public float maxRadius;
        int e;
        int z;
        int t;
        int s;
        int ss;

        Transform a;
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
        public float patrolSpeed = 0.8f;


        public float chaseSpeed = 1f;
       
        public GameObject blood;
        float times;
        float htimes;
        public static int bb;
        public GameObject missionF;
        public GameObject missionS;
        private AudioSource hurt;
        public int sala;
        int sal;

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            anim = GetComponent<Animator>();
            m_ObjectCollider = GetComponent<CapsuleCollider>();
            hurt = GetComponent<AudioSource>();
            
            agent.updatePosition = true;
            agent.updateRotation = false;

            t = 0;
            bb = 0;
            maxAngle = 50;
            anim.SetBool("Aim", false);

            GameObject[] enem = GameObject.FindGameObjectsWithTag("Dead");
            foreach(GameObject enemy in enem)
            {
                GameObject.Destroy(enemy);
            }

        }

        private void Update()
        {
            
            deadBody = GameObject.FindGameObjectsWithTag("Dead");
            foreach (GameObject target in deadBody)
            {
                a = target.transform;

            }

           

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
                
                PlayerController.mat = true;
                e = 1;
                t = 1;

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
                if (Vector3.Distance(transform.position, a.transform.position) > 1)
                {
                    agent.SetDestination(a.transform.position);
                    character.Move(agent.desiredVelocity, false, false);

                }
                else if (Vector3.Distance(transform.position, a.transform.position) <= 1)
                {

                    agent.SetDestination(transform.position);
                    character.Move(Vector3.zero, false, false);
                }

            }
          


           



        }

        void Patrol()
        {

            agent.speed = patrolSpeed;
            if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) > 1)
            {
                agent.SetDestination(waypoints[waypointInd].transform.position);
                character.Move(agent.desiredVelocity, false, false);

            }
            else if (Vector3.Distance(transform.position, waypoints[waypointInd].transform.position) <= 1)
            {

                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);

                times += Time.deltaTime;

                if (times >= 1)
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

        
        void Stop()
        {

            if (e == 1)
            {
                agent.speed = 0;
                agent.SetDestination(transform.position);
                character.Move(Vector3.zero, false, false);

                e = 2;
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
            if (coll.gameObject.tag == "bullet")
            {
               

                
                    t = 1;
                    e = 1;
                    tag = "Dead";
                    anim.SetTrigger("dead");
                    bb = 1;
                    missionF.SetActive(true);
                    hurt.Play();
                    
                
                
            }
            
        }

        
    }
}
