using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{

    TextMeshPro timerUp;
    TextMeshPro timerDown;
    SharedStatus positionControllerStatus;
    float timer = 20.0f;
    // Start is called before the first frame update
    /// <summary>
    /// Gets both timers'(objects) textmeshpro component <br/>
    /// Gets positioncontroller game object's sharedStatus component.
    /// </summary>
    void Start()
    {
        timerUp = GameObject.FindGameObjectWithTag("TimerUp").GetComponent<TextMeshPro>();
        timerDown = GameObject.FindGameObjectWithTag("TimerDown").GetComponent<TextMeshPro>();
        positionControllerStatus = GameObject.FindGameObjectWithTag("PositionController").GetComponent<SharedStatus>();
    }

    // FixedUpdate is called once every 0.02 seconds
    void FixedUpdate()
    {
        StatusToDeath();
        ColorControl();
        Counter();
    }

    /// <summary>
    /// if shared status is gap, starts the timer from 20 downand refreshes with the fixedupdate<br/>
    /// else, show empty string and set timer to 20 because the characters are alligned or death.
    /// </summary>
    private void Counter(){
        if (positionControllerStatus.getStatus() == SharedStatus.Status.gap){
            timerUp.text = timer.ToString("0.0");
            timerDown.text = timer.ToString("0.0");
            timer-= Time.fixedDeltaTime;
        }

        else{
            timerUp.text = "";
            timerDown.text = "";
            timer = 20.0f;
        }
    }

    /// <summary>
    /// if timer is 20 to 15 (not inclusive) show it with color green<br/>
    /// if timer is between 15 and 5 (not inclusive) show it yellow<br/>
    /// if timer is 5 or lower show it red.
    /// </summary>
    private void ColorControl(){
        if(timer.ToString("0.0") =="20.0"){
            timerUp.color=Color.green;
            timerDown.color=Color.green;

        }
        else if(timer.ToString("0.0") =="15.0"){
            timerUp.color = Color.yellow;
            timerDown.color=Color.yellow;
        }
        else if(timer.ToString("0.0") =="5.0"){
            timerUp.color = Color.red;
            timerDown.color=Color.red;
        }
    }

    /// <summary>
    /// if timer reaches 0 or lower, change status to death
    /// </summary>
    private void StatusToDeath(){
        if (timer<=0){
            timerUp.text = "";
            timerDown.text = "";
            positionControllerStatus.setStatus(SharedStatus.Status.death);
        }
    }
}
