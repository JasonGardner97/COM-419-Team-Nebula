using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelButton : MonoBehaviour
{
    // Constants
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Click Button
    void OnMouseDown()
    {
        gameManager.GetComponent<GameManager>().gameLevel++;
        gameObject.SetActive(false);
    }
}
