using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField]
    PositionController characterPos;
    //Status for alive or death
    public enum isAlive{
        death,
        alive
    }
    //variable saving status
    private isAlive charactersAlive;

    //Getter and setter for alive and death
    #region getter_and_setter
    ///<summary>
    ///Description: Public function to <b>SET</b> the player status to <paramref name="newStatus"/> provided as parameter <br/>
    ///Input: <paramref name="newStatus"/><br/>
    ///Return: None
    ///</summary>
    public void setIsAlive(isAlive newStatus){
        charactersAlive = newStatus;
    }

    ///<summary>
    ///Description: Public function to <b>GET</b> the player status <br/>
    ///Input: None <br/>
    ///Return: <paramref name="charactersAlive"/><br/>
    ///</summary>
    public isAlive getIsAlive(){
        return charactersAlive;
    }
    #endregion

    //Characters lives
    int numberOfLives = 3;


    // Start is called before the first frame update
    void Start()
    {
        characterPos = GameObject.FindGameObjectWithTag("PositionController").GetComponent<PositionController>();
    }

    // Update is called once per frame
    void Update()
    {
        setDeath();
    }

    /// <summary>
    /// Numbers of live decreases when called by other objects
    /// </summary>
    public void DecreaseLives(){
        numberOfLives--;
        characterPos.ResetPos();
    }

    private void setDeath(){
        if (numberOfLives <=0){
            setIsAlive(isAlive.death);
        }
    }

}
