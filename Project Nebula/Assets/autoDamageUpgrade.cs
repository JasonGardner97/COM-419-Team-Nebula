using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDamageUpgrade : MonoBehaviour
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
        if ((Input.GetMouseButtonDown(0)) && (gameManager.GetComponent<GameManager>().playerGold >= 20) && (gameManager.GetComponent<GameManager>().autoDamage == false))
        {
            gameManager.GetComponent<GameManager>().autoDamage = true;
            gameManager.GetComponent<GameManager>().playerGold -= 20;
        }
    }
}
