using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public PlayerController pc;
    Image healthBar;
    float maxHealth = 100f;

    void Start()
    {
        healthBar = GetComponent<Image> ();
    }

    void Update()
    {
        healthBar.fillAmount = pc.hp / maxHealth; // Fills health bar with actual player health
    }
}
