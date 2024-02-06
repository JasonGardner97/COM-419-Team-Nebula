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

        // Display Sprite
        if (spriteChoice == 1)
            enemySprite.sprite = sprite1;
        else if (spriteChoice == 2)
            enemySprite.sprite = sprite2;
        else if (spriteChoice == 3)
            enemySprite.sprite = sprite3;
    }

    void OnMouseDown()
    {
        // Damage enemy
        enemyhealth--;
    }


}

    
