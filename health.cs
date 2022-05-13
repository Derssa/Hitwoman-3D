using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 99f;
    public static float healthS;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        healthS = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = healthS / maxHealth;
    }
}
