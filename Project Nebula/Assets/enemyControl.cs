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
    public double enemyhealth;
    public int enemyDeaths;
    int enemyLevel;

    // Sprites
    public SpriteRenderer enemySprite;
    public Sprite sprite1, sprite2, sprite3;
    public int spriteChoice;

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

        // Set enemy Sprite
        spriteChoice = Random.Range(1, 3);
 
    }

    // Update is called once per frame
    void Update()
    {
        // Access Enemy Spawner
        var enemySpawner = spawner.GetComponent<enemySpawner>();

        // Kill enemy
        if (enemyhealth <= 0)
        {
            // Destroy Enemy
            enemyIsDead = true;
            enemyDeaths += 1;
            gameObject.SetActive(false); // Disable enemy
            enemyhealth = 5; // Reset enemy health so next enemy works right
            enemySpawner.enemyExists = false; // Mark enemy as not existing
        }

        // Display Health
        displayHealth.text = enemyhealth.ToString("F0");

        // Display Sprite
        if (spriteChoice <= 1)
            enemySprite.sprite = sprite1;
        else if (spriteChoice == 2)
            enemySprite.sprite = sprite2;
        else if (spriteChoice >= 3)
            enemySprite.sprite = sprite3;
    }

    void OnMouseDown()
    {
        // Access Game Manager
        var gameManagerObj = gameManager.GetComponent<GameManager>();

        // Damage enemy
        enemyhealth -= gameManagerObj.playerDamage;
    }

    void OnEnable()
    {
        // Temporary Health Scale
        if (gameManager.GetComponent<GameManager>().gameLevel > 1)
        {
            var l = gameManager.GetComponent<GameManager>().gameLevel;
            enemyhealth += 2.5 * (l * enemyhealth);
        }
    }
}

    
