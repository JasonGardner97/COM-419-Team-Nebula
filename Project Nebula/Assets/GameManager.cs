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

    // Variables
    public int playerGold;

    public bool doubleDamage;
    public bool autoDamage;

    // Display Gold Variable
    public Text displayGold;

    // Start is called before the first frame update
    void Start()
    {
        // Starting gold
        playerGold = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Display Gold
        displayGold.text = playerGold.ToString();

        // Increment Gold on Enemy Death
        if ((spawner.GetComponent<enemySpawner>().enemyExists == false) && (enemy.GetComponent<enemyControl>().enemyDeaths >= 1) && (enemy.GetComponent<enemyControl>().enemyIsDead == true))
        {
            playerGold += 1;
            enemy.GetComponent<enemyControl>().enemyIsDead = false;
        }
    }
}
