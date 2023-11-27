using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    SharedStatus deathOrAlive;


    // Start is called before the first frame update
    void Start()
    {
        deathOrAlive = GameObject.FindGameObjectWithTag("PositionController").GetComponent<SharedStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
