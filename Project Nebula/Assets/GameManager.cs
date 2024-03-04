using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Objects
    public GameObject enemy;
    public GameObject spawner;
    public GameObject levelButton;

    // Variables
    public double playerGold;
    public double playerDamage;
    public int gameLevel;

    bool doubleDamage;
    bool autoDamage;

    // Display Gold Variable
    public Text displayGold;

    // Display level info
    public Text displayLevel;

    // Start is called before the first frame update
    void Start()
    {
        // Starting gold
        playerGold = 0;

        // Starting damage
        playerDamage = 1;

        // Starting level
        gameLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Access Enemy Spawner and Controller
        var enemySpawner = spawner.GetComponent<enemySpawner>();
        var enemyController = enemy.GetComponent<enemyControl>();

        // Display Gold
        displayGold.text = playerGold.ToString();

        // Increment Gold on Enemy Death
        if ((enemySpawner.enemyExists == false) && (enemyController.enemyDeaths >= 1) && (enemyController.enemyIsDead == true))
        {
            playerGold += 1;
            enemyController.enemyIsDead = false;
        }

        // Display level
        displayLevel.text = gameLevel.ToString();
    }
    
}
