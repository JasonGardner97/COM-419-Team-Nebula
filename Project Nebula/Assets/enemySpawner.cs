using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    // Variables
    public bool enemyExists;
    public float timer;

    // Enemy Object and UI
    public GameObject enemy;
    public GameObject enemyUI;

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
            enemyUI.SetActive(false); // Disable UI
            timer += Time.deltaTime; // Increment timer by 1 second
            Debug.Log("Spawn Timer: " + timer.ToString()); // Print time in console
        }

        // Spawn an enemy 
        if ((timer >= 1.00) && (enemyExists == false))
        {
            enemy.SetActive(true); // Create an enemy
            enemyUI.SetActive(true); // Activate enemy's UI
            enemyExists = true; // Mark enemy existing
        }

        // Reset timer after spawning 
        if (enemyExists == true)
        {
            timer = 0;
        }
    }
}
