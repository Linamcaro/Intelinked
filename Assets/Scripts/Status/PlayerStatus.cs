using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public enum Status{
        ground,
        jump,
        gap
    }

    
    private Status currentStatus;

    ///<summary>
    ///Description: Public function to <b>SET</b> the player status to <paramref name="newStatus"/> provided as parameter <br/>
    ///Input: <paramref name="newStatus"/><br/>
    ///Return: None
    ///</summary>
    public void setStatus(Status newStatus){
        currentStatus = newStatus;
    }

    ///<summary>
    ///Description: Public function to <b>GET</b> the player status <br/>
    ///Input: None <br/>
    ///Return: <paramref name="currentStatus"/><br/>
    ///</summary>
    public Status getStatus(){
        return currentStatus;
    }


    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
