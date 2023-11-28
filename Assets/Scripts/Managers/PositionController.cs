using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{

    [SerializeField]
    Transform charUp;
    [SerializeField]
    Transform charDown;
    [SerializeField]
    DeathController liveChanged;
    Vector3 startPos = new Vector3(-12.2f, 1.5f, 0);

    SharedStatus charactersStatus;
    // Start is called before the first frame update

    /// <summary>
    /// Gets the transform from both characters if there is any problem
    /// Gets the Sharedstatus component of this game object
    /// </summary>
    void Start()
    {
        if (charUp==null){
            charUp = GameObject.FindGameObjectWithTag("PlayerTop").transform;
        }
        if (charDown==null){
            charDown = GameObject.FindGameObjectWithTag("PlayerDown").transform;
        }
        charactersStatus = gameObject.GetComponent<SharedStatus>();        
    }

    // Update is called once per frame
    void Update()
    {
        CheckPos();
    }


    /// <summary>
    /// gets the position of both characters and compares them<br/>
    /// if they don't share the same X position with a tolerance of <b>+-0.005</b><br/>
    /// we consider there is a gap and change the status, if not, we go back to alligned status
    /// </summary>
    private void CheckPos(){
        Vector3 positionDown = charDown.position;
        Vector3 positionUp = charUp.position;
        if (positionUp.x<positionDown.x-0.005 || positionUp.x > positionDown.x + 0.005){
            charactersStatus.setStatus(SharedStatus.Status.gap);
        }
        else{
            charactersStatus.setStatus(SharedStatus.Status.aligned);
        }
    }

    public void ResetPos(){
        charUp.position = startPos;
        startPos.y *=-1;
        charDown.position = startPos;
        startPos.y *=-1;
    }
}
