using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class abilitiesController : MonoBehaviour
{
    // Objects
    public GameObject gameManager;
    public Text abilityTimer;
    public GameObject upgradeScript;

    // Test
    bool doubleAutoDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AbilityTest()
    {
        if (doubleAutoDamage == true)
        {
            upgradeScript.GetComponent<upgradeScript>().rocketLegsDamage *= 2;
        }
    }
}
