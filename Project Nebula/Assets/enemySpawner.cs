using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Variables
    public bool enemyExists;
    public float timer;

    // Enemy Object
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyExists = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy spawner in motion
        if (enemyExists == false)
        {
            timer += Time.deltaTime; // Increment timer by 1 second
            Debug.Log(timer.ToString()); // Print time in console
        }

        // Spawn an enemy 
        if ((timer >= 1.00) && (enemyExists == false))
        {
            enemy.SetActive(true); // Create an enemy
            enemyExists = true; // Mark enemy existing
        }

        // Reset timer after spawning 
        if (enemyExists == true)
        {
            timer = 0;
        }
    }
}
