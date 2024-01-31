using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doubleDamageUpgrades : MonoBehaviour
{
    // Game Manager
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetMouseButtonDown(0)) && (gameManager.GetComponent<GameManager>().playerGold >= 10) && (gameManager.GetComponent<GameManager>().doubleDamage == false))
        {
            gameManager.GetComponent<GameManager>().doubleDamage = true;
            gameManager.GetComponent<GameManager>().playerGold -= 10;
        }
    }
}
