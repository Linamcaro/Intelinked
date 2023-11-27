using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    DeathController gameStatus;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = GameObject.FindGameObjectWithTag("DeathController").GetComponent<DeathController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void CheckStatus(){
        gameStatus.getIsAlive();
    }
}
