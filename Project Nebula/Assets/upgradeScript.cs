using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeScript : MonoBehaviour
{
    // Game Manager
    public GameManager gameManager;

    // Enemy
    public GameObject enemy;

    // Variables (Oversized Fist)
    bool oversizedFist;
    int oversizedFistLevel;
    int oversizedFistOGPrice = 10;

    // Variables (Rocket Powered Legs)
    public bool rocketLegs;
    public int rocketLegsPrice = 20;
    public double rocketLegsDamage;
    public int rocketLegsLevel;

    void Update()
    {
        // Rocket Legs Effect
        if ((rocketLegs == true) && (enemy.activeSelf == true))
        {
            var enemyObj = enemy.GetComponent<enemyControl>();
            enemyObj.enemyhealth -= rocketLegsDamage;
        }
    }

    public void OversizedFist()
    {
        // Activate upgrade
        if ((oversizedFist == false) && (oversizedFistLevel == 0))
        {
            // Access Game Manager
            var gameManagerObj = gameManager.GetComponent<GameManager>();

            // Set upgrade to true
            if (gameManagerObj.playerGold >= oversizedFistOGPrice)
            {
                gameManagerObj.playerGold -= oversizedFistOGPrice;
                oversizedFist = true;
                oversizedFistLevel = 1;
            }
            else
                Debug.Log("Not enough gold.");
        }

        // Scale Upgrade
        if ((oversizedFist == false) && (oversizedFistLevel >= 1))
        {

            // Access Game Manager
            var gameManagerObj = gameManager.GetComponent<GameManager>();

            // Calculate gold needed for next upgrade level
            var c = oversizedFistOGPrice;
            var n = oversizedFistLevel;
            var x = 1.8;

            // Final calculation
            var newPrice = (c * x) * n;

            // Apply new price
            if (gameManagerObj.playerGold >= newPrice)
            {
                gameManagerObj.playerGold -= newPrice;
                oversizedFist = true;
                oversizedFistLevel++;
            }
            else
            {
                Debug.Log("Gold needed: " + newPrice.ToString());
            }
        }

        // Upgrade effect
        if (oversizedFist == true)
        {
            // Access Game Manager
            var gameManagerObj = gameManager.GetComponent<GameManager>();

            // Formula Variables
            var p = gameManagerObj.playerDamage;
            var n = oversizedFistLevel;
            var x = 1.8;

            // Calculate damage increase
            var damageIncrease = (p * x) * n;
            gameManagerObj.playerDamage += damageIncrease;

            // Turn off upgrade
            oversizedFist = false;
        }
    }

    public void RocketPoweredLegs()
    {
        // Activate upgrade
        if ((rocketLegs == false) && (rocketLegsLevel == 0))
        {
            // Access Game Manager
            var gameManagerObj = gameManager.GetComponent<GameManager>();

            // Set upgrade to true
            if (gameManagerObj.playerGold >= rocketLegsPrice)
            {
                gameManagerObj.playerGold -= rocketLegsPrice;
                rocketLegs = true;
                rocketLegsLevel = 1;
                rocketLegsDamage = 0.001;
            }
            else
                Debug.Log("Not enough gold.");
        }

        // Scale Upgrade Price
        if ((rocketLegs == true) && (rocketLegsLevel >= 1))
        {

            // Access Game Manager
            var gameManagerObj = gameManager.GetComponent<GameManager>();

            // Calculate gold needed for next upgrade level
            var c = rocketLegsPrice;
            var n = rocketLegsLevel;
            var x = 1.8;

            // Final calculation
            var newPrice = (c * x) * n;

            // Apply new price
            if (gameManagerObj.playerGold >= newPrice)
            {
                //var gameManagerObj = gameManager.GetComponent<GameManager>();

                // Level up
                gameManagerObj.playerGold -= newPrice;
                rocketLegsLevel++;

                // Formula Variables
                var p = rocketLegsDamage;
                var m = rocketLegsLevel;
                var v = 1.8;

                // Calculate damage increase
                var damageIncrease = (p * v) * m;
                rocketLegsDamage += damageIncrease;
            }
            else
            {
                Debug.Log("Gold needed: " + newPrice.ToString());
            }
        }
    }
}
