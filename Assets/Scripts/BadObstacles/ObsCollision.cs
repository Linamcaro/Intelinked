using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObsCollision : MonoBehaviour
{
    DeathController decreaseLives;
    // Start is called before the first frame update
    void Start()
    {
        decreaseLives = GameObject.FindGameObjectWithTag("DeathController").GetComponent<DeathController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col){   
        decreaseLives.DecreaseLives();
        Debug.Log("Here");
    }
}
