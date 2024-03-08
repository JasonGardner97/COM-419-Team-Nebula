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

    // Boss Object and UI
    public GameObject miniBoss;
    public GameObject miniBossUI;

    // Game Manager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        enemyExists = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Access Enemy Controller and Game Manager
        var enemyController = enemy.GetComponent<enemyControl>();
        var gameManagerObj = gameManager.GetComponent<GameManager>();

        // Regular Enemies
        if ((gameManagerObj.gameLevel >= 1) && (gameManagerObj.gameLevel <= 4) || (gameManagerObj.gameLevel >= 6) && (gameManagerObj.gameLevel <= 9) || (gameManagerObj.gameLevel >= 11))
        {
            // Set enemy spawner in motion
            if (enemyExists == false)
            {
                enemyController.spriteChoice = Random.Range(0, 4); // Reset enemy sprite
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

        // Mini Boss
        if (gameManagerObj.gameLevel == 5)
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
                miniBoss.SetActive(true); // Create an enemy
                miniBossUI.SetActive(true); // Activate enemy's UI
                enemyExists = true; // Mark enemy existing
            }

            // Reset timer after spawning 
            if (enemyExists == true)
            {
                timer = 0;
            }
        }
    }
}
