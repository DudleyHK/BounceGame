using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerBounce PlayerBounce;
    public int PlayerID;

    [SerializeField] private bool beginTouch;
    [SerializeField] private bool endTouch;


    private void OnEnable()
    {
        InputManager.handleTouchInput += HandleTouchInput;
        InputManager.handleMouseInput += HandleMouseInput;
    }

    private void OnDisable()
    {
        InputManager.handleTouchInput -= HandleTouchInput;
        InputManager.handleMouseInput -= HandleMouseInput;
    }


    public void FixedUpdate()
    {
        Debug.Log("touch input pos - " + InputManager.ppTouchPos);
        Debug.Log("world input pos - " + InputManager.wpTouchPos);


        if(beginTouch)
        {
            PlayerBounce.CheckBounceClick(InputManager.wpTouchPos, PlayerID);
        }

        if(endTouch)
        {

        }
    }


    private void HandleTouchInput(Touch _touch, int _fingerId)
    {
        Debug.Log("Touch ID - " + _fingerId);
        PlayerID = _fingerId;

        if(_touch.phase == TouchPhase.Began)
        {
            beginTouch = true;
            endTouch = false;
        }
        else if(_touch.phase == TouchPhase.Ended)
        {
            beginTouch = false;
            endTouch = true;
        }
        else
        {
            // Do nothing.
        }
    }


    private void HandleMouseInput(Vector3 _mousePosition, bool _mouseDown, bool _mouseUp, int _id)
    {
        PlayerID = _id;
        beginTouch = _mouseDown;
        endTouch = _mouseUp;
    }

}
