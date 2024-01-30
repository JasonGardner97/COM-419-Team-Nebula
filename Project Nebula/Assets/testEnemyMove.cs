using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{
    // Variables
    int clickSpeed;
    int clickCounter;

    // Start is called before the first frame update
    void Start()
    {
        clickSpeed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("OUCH");
            clickCounter++;
        }

        if (Input.GetMouseButtonDown(0) && clickSpeed >= 2)
        {
            Debug.Log("OUCH 2");
        }

        if (clickCounter >= 10)
        {
            clickSpeed = 2;
        }
    }
}
