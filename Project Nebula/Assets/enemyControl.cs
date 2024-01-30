using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyControl : MonoBehaviour
{
    // Variables
    public int enemyhealth;
    int enemyLevel;

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

        // Kill enemy
        if (enemyhealth <= 0)
        {
            gameObject.SetActive(false); // Disable enemy
            enemyhealth = 5; // Reset enemy health so next enemy works right
            spawner.GetComponent<enemySpawner>().enemyExists = false; // Mark enemy as not existing
        }

        // Display Health
        displayHealth.text = enemyhealth.ToString();
    }


}

    
