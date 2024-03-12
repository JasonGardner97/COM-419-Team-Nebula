using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButton : MonoBehaviour
{
    // Constants
    public GameManager gameManager;
    public GameObject enemyController;
    public GameObject miniBossController;

    // Click Button
    void OnMouseDown()
    {   
        // Update Level
        gameManager.GetComponent<GameManager>().gameLevel++;
        gameObject.SetActive(false);

        // Reset enemy deaths
        enemyController.GetComponent<enemyControl>().enemyDeaths = 0;
    }
}
