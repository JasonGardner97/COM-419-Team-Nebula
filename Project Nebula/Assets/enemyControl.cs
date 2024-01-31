using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyControl : MonoBehaviour
{
    // Game Manager
    public GameManager gameManager;

    // Variables
    public float enemyhealth;
    public int enemyDeaths;
    int enemyLevel;

    public bool enemyIsDead;

    // Text
    public Text displayHealth;

    // Spawner
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        // Spawn in correct spot
        transform.position = spawner.transform.position;

        // Set enemy health
        enemyhealth = 5;
    }

    // Update is called once per frame
    void Update()
    {

        // Click Enemy
        if (Input.GetMouseButtonDown(0))
        {
            enemyhealth--;
        }

        // Double Damage
        if ((Input.GetMouseButtonDown(0)) && (gameManager.GetComponent<GameManager>().doubleDamage == true))
        {
            enemyhealth -= 2;
        }

        // Auto Damage
        if (gameManager.GetComponent<GameManager>().autoDamage == true)
        {
            enemyhealth -= Time.deltaTime;
        }

        // Kill enemy
        if (enemyhealth <= 0)
        {
            enemyIsDead = true;
            enemyDeaths += 1;
            gameObject.SetActive(false); // Disable enemy
            enemyhealth = 5; // Reset enemy health so next enemy works right
            spawner.GetComponent<enemySpawner>().enemyExists = false; // Mark enemy as not existing
        }

        // Display Health
        displayHealth.text = enemyhealth.ToString();
    }


}

    
