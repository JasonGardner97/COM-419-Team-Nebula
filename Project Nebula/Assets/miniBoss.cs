using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class miniBoss : MonoBehaviour
{
    // Game Manager
    public GameManager gameManager;

    // Variables
    public double miniBossHealth;
    public int miniBossDeaths;
    public bool miniBossIsDead;
    public double miniBossTimer;

    // Text
    public Text displayHealth;
    public Text timer;

    // Spawner and Timer
    public GameObject spawner;

    // Start
    void Start()
    {
        // Spawn in right spot
        transform.position = spawner.transform.position;

        // Set health
        miniBossHealth = 500;

        // Set Timer
        miniBossTimer = 30;
    }

    // Update
    void Update()
    {
        // Access Spawner
        var enemySpawner = spawner.GetComponent<enemySpawner>();

        // Kill mini boss
        if (miniBossHealth <= 0)
        {
            // Destroy boss
            miniBossIsDead = true;
            miniBossDeaths++;
            gameObject.SetActive(false);
            miniBossHealth = 500;
            enemySpawner.enemyExists = false;
            miniBossTimer = 30;
            timer.gameObject.SetActive(false);
            displayHealth.gameObject.SetActive(false);
        }

        // Decrease timer
        if (miniBossHealth > 0)
        {
            timer.gameObject.SetActive(true);
            miniBossTimer -= Time.deltaTime;
        }

        // Time Runs Out
        if ((miniBossHealth > 0) && (miniBossTimer <= 0))
        {
            Debug.Log("Ran out of time.");
            miniBossHealth = 500;
            miniBossTimer = 30;
        }

        // Display health and time
        displayHealth.text = miniBossHealth.ToString("F2");
        timer.text = miniBossTimer.ToString("F2");
    }

    // Take Damage
    void OnMouseDown()
    {
        // Access Game Manager
        var gameManagerObj = gameManager.GetComponent<GameManager>();

        // Take Damage
        miniBossHealth -= gameManagerObj.playerDamage;
    }
}
