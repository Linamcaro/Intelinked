using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JoystickAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite joyStickRight;
    [SerializeField]
    Sprite joyStickLeft;
    [SerializeField]
    Sprite joyStickIdle;
    [SerializeField]
    GameObject joyStick;

    PlayerInputs playerInput;

    void Awake(){
        playerInput = new PlayerInputs();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (joyStick == null){
            joyStick = GameObject.FindGameObjectWithTag("JoyStick");
            
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSprite();
    }

    private void ChangeSprite(){
        Vector2 inputDir = playerInput.PlayerMain.Movement.ReadValue<Vector2>();

        if (inputDir.x >0){
            joyStick.GetComponent<Image>().sprite = joyStickRight;
        }
        else if (inputDir.x < 0){
            joyStick.GetComponent<Image>().sprite = joyStickLeft;
        }
        else{
            joyStick.GetComponent<Image>().sprite = joyStickIdle;

        }
    }
}
