using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class deadA : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent agent;
    private ThirdPersonCharacter character;
    float times;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Death");
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();
      
    }
    void Update()
    {
        
        character.Move(Vector3.zero, false, false);
        times += Time.deltaTime;
        if (times > 2f)
        {
            if (PlayerController.lamstuto == 3)
            {
                PlayerController.lamstuto = 4;
                times = 0;
            }

            

            if (PlayerController.lamstuto == 5 && buttons.douz == 3)
            {


                PlayerController.lamstuto = 6;

            }

            

        }
    }

}
